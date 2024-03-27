using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MCDA_APP.Controls;
using Newtonsoft.Json.Linq;


namespace MCDA_APP.Forms
{
    public partial class HexdumpForm : Form
    {
        string filePath = "";
        string fileName = "";
        bool submitting = false;
        int lastOffset = 0;

        int searchStartIndex = 0;

        public HexdumpForm()
        {
            InitializeComponent();
        }

        private void HexdumpForm_Load(object sender, EventArgs e)
        {
            MalcoreFooter malcoreFooter = new()
            {
                Dock = DockStyle.Bottom
            };

            Controls.Add(malcoreFooter);
        }

        private void LabelSelectFile_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog fileDlg = new OpenFileDialog();

                // Show the FolderBrowserDialog.  
                DialogResult result = fileDlg.ShowDialog();
                if (result == DialogResult.OK)
                {
                    this.filePath = fileDlg.FileName;
                    this.fileName = Path.GetFileName(this.filePath);

                    labelFileName.Visible = true;
                    labelFileName.Text = this.fileName;

                    this.submitting = false;
                    UploadPictureBox.Visible = true;

                }
            }
            catch (Exception ex)
            {
                labelFileName.Text = "";
            }
        }

        private async void UploadPictureBox_Click(object sender, EventArgs e)
        {
            if (this.submitting)
            {
                return;
            }

            if (this.filePath == "")
            {
                MessageBox.Show("Please select a file.");
                return;
            }

            string hexData = await this.GetHexDump();
            if (hexData == "")
            {
                MessageBox.Show("Cannot get a hexdump for " + fileName);
            }
            else
            {
                this.ShowHexdump(hexData);
            }
        }


        private async Task<string> GetHexDump()
        {
            try
            {
                this.submitting = true;
                UploadPictureBox.Visible = false;
                LoadingLabel.Visible = true;
                OffsetPanel.Visible = false;
                HexSearchPanel.Visible = false;
                HexdumpPanel.Visible = false;
                HexdumpRichTextBox.Visible = false;
                HexdumpRichTextBox.Text = "";
                this.searchStartIndex = 0;

                string url = System.Configuration.ConfigurationManager.AppSettings["URI"] + "/hexdump";

                using (var client = new HttpClient())
                {
                    using (var content = new MultipartFormDataContent())
                    {
                        byte[] fileData = File.ReadAllBytes(this.filePath);
                        content.Add(new StreamContent(new MemoryStream(fileData)), "file1", this.fileName);
                        content.Headers.Add("apiKey", Program.APIKEY);
                        content.Headers.Add("source", "agent");

                        using (
                           var response = await client.PostAsync(url, content))
                        {
                            this.submitting = false;
                            LoadingLabel.Visible = false;


                            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                            {
                                string responseString = await response.Content.ReadAsStringAsync();
                                JObject jsonObject = JObject.Parse(responseString);

                                if ((bool)jsonObject["success"] == true)
                                {
                                    return (string)jsonObject["data"]["hexdump"];
                                }
                                else
                                {
                                    UploadPictureBox.Visible = true;
                                    return "";
                                }
                            }
                            else
                            {
                                UploadPictureBox.Visible = true;
                                return "";
                            }

                        }
                    }
                }

            }
            catch (Exception ex)
            {
                this.submitting = false;
                UploadPictureBox.Visible = true;
                LoadingLabel.Visible = false;

                return "";
            }
        }


        private void ShowHexdump(string hexData)
        {
            try
            {
                HexdumpRichTextBox.SelectionColor = Color.White;

                string[] lines = hexData.Split('\n');
                foreach (var line in lines)
                {
                    string[] parts = line.Split('\t');
                    if (parts.Length >= 3)
                    {
                        string hexIndex = int.Parse(parts[0].Trim()[..10]).ToString("X10");
                        HexdumpRichTextBox.AppendText(hexIndex + ": \t");
                        HexdumpRichTextBox.SelectionColor = ColorTranslator.FromHtml("#00e676");

                        string hexString = string.Join("", parts[1].Select((c, index) => index % 2 == 0 ? c.ToString() : c.ToString() + " "));
                        HexdumpRichTextBox.AppendText(hexString + "    ");
                        HexdumpRichTextBox.SelectionColor = Color.White;

                        HexdumpRichTextBox.AppendText(parts[2] + "\n");
                        HexdumpRichTextBox.SelectionColor = Color.White;
                    }
                }
                this.lastOffset = lines.Length - 1;

                HexdumpPanel.Visible = true;
                HexdumpRichTextBox.Visible = true;
                OffsetPanel.Visible = true;
                HexSearchPanel.Visible = true;

            }
            catch (System.Exception)
            {
                throw;
            }
        }

        private void OffsetTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '\r')
                {
                    e.Handled = true;
                }

                if (e.KeyChar == '\r')
                {
                    if (OffsetTextBox.Text.Length > 0)
                    {
                        int lineToMove = int.Parse(OffsetTextBox.Text) > 0 ? int.Parse(OffsetTextBox.Text) - 1 : 0;
                        if (lineToMove > this.lastOffset)
                        {
                            lineToMove = this.lastOffset;
                        }
                        int startIndex = HexdumpRichTextBox.GetFirstCharIndexFromLine(lineToMove);

                        HexdumpRichTextBox.SelectionStart = startIndex;
                        HexdumpRichTextBox.SelectionLength = 10;
                        HexdumpRichTextBox.Focus();

                    }
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        private void HexSearchTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == '\r')
                {
                    this.HandleSearch(1);
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        private void HandleSearch(int type = 1)
        {
            try
            {
                string searchText = HexSearchTextBox.Text;
                if (searchText.Length > 0)
                {
                    searchText = searchText.ToLower();
                    int startIndex = HexdumpRichTextBox.Find(searchText, this.searchStartIndex, RichTextBoxFinds.MatchCase);
                    if (startIndex != -1)
                    {
                        HexdumpRichTextBox.Select(startIndex, searchText.Length);
                        HexdumpRichTextBox.SelectionBackColor = ColorTranslator.FromHtml("#676767");
                        HexdumpRichTextBox.ScrollToCaret();

                        this.searchStartIndex = startIndex + searchText.Length;
                    }
                    else
                    {
                        this.searchStartIndex = 0;

                        if (HexdumpRichTextBox.TextLength > 0 && type == 1)
                        {
                            this.HandleSearch(0);
                        }
                        else
                        {
                            MessageBox.Show("There is no data matching your search text");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please enter search text");

                }

            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}






