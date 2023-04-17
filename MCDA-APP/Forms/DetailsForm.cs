using Microsoft.Win32;
using System.Diagnostics;
using Newtonsoft.Json.Linq;
using System.Security.AccessControl;

namespace MCDA_APP.Forms
{
    public partial class DetailsForm : Form
    {
        string type = "";
        string responseString = "";
        string folderName = "";
        string fileName = "";
        double minThreatScore = 15.0;

        public DetailsForm(string type, string responseString, string folderName, string fileName, MonitoringForm monitoringForm, Panel panel)
        {
            InitializeComponent();
            this.responseString = responseString;
            this.folderName = folderName;
            this.fileName = fileName;
            this.type = type;
            labelEmail.Text = Program.USEREMAIL;

            RegistryKey key = Registry.CurrentUser.OpenSubKey(@".malcore");
            if (key != null)
            {
                var SETTINGS = key.GetValue("SETTINGS");
                if (SETTINGS != null)
                {
                    JObject json = JObject.Parse(SETTINGS.ToString());
                    this.minThreatScore = (double)(json["minThreatScore"]);
                }
            }

            if (type == "threat")
            {
                initDetailFormUI(monitoringForm, panel);
            }
            else
            {
                initDetailFormUIForDoc(monitoringForm, panel);
            }

        }


        /**
        * @Description: draw detail form for exe files
        * @param monitoringForm: MonitoringForm object
        * @param listPanel: monitoring form's panel of selected file
        * @return void
        **/
        private void initDetailFormUI(MonitoringForm monitoringForm, Panel listPanel)
        {
            // folder label 
            folderLabel.Text = this.folderName;
            labelFullPath.Text = this.folderName;

            bool success = true;

            if (this.responseString == "" || this.responseString == null)
            {
                success = false;
            }
            else
            {
                JObject jsonObject = JObject.Parse(this.responseString);
                success = (bool)jsonObject["success"];

                if (jsonObject["data"]["data"].ToString() == "{}")
                {
                    success = false;
                }
                string score = "";
                double score_num = 0;
                if (success)
                {
                    flowLayoutPanelDetails.Visible = true;

                    score = (string)jsonObject["data"]["data"]["score"];
                    string[] scores = score.Split('/');
                    score_num = Convert.ToDouble(scores[0]);
                    score = Convert.ToString(Math.Round(score_num)) + "%";

                    if (jsonObject["data"]["data"]["signatures"] != null)
                    {
                        JArray signatures = (JArray)jsonObject["data"]["data"]["signatures"];
                        for (int i = 0; i < signatures.Count; i++)
                        {
                            FlowLayoutPanel panel = new FlowLayoutPanel();
                            panel.AutoSize = true;
                            panel.MaximumSize = new System.Drawing.Size(480, 0);

                            Panel linePanel = new Panel();
                            linePanel.Size = new System.Drawing.Size(480, 1);
                            linePanel.BackColor = Color.Gray;

                            Label lblSignatureTitle = new Label();
                            lblSignatureTitle.Font = new Font("Calibri", 14, FontStyle.Bold);
                            lblSignatureTitle.ForeColor = Color.Orange;
                            string title = (string)signatures[i]["info"]["title"];
                            lblSignatureTitle.Text = title.ToUpper();

                            Label lblEntropyDescription = new Label();
                            lblEntropyDescription.Font = new Font("Calibri", 11, FontStyle.Regular);
                            lblEntropyDescription.ForeColor = Color.White;
                            lblEntropyDescription.Text = (string)signatures[i]["info"]["description"];
                            lblEntropyDescription.AutoSize = true;
                            lblEntropyDescription.MaximumSize = new System.Drawing.Size(480, 0);

                            Label lblDiscovered = new Label();
                            lblDiscovered.Text = "Discovered:";
                            lblDiscovered.ForeColor = Color.Red;
                            lblDiscovered.Font = new Font("Calibri", 12, FontStyle.Italic);
                            lblDiscovered.Width = 480;

                            Label lblDiscoveredContent = new Label();
                            var discovered = signatures[i]["discovered"];

                            if (typeof(JValue).Equals(discovered.GetType()))
                            {
                                lblDiscoveredContent.Text = (string)discovered;
                            }
                            else if (typeof(JObject).Equals(discovered.GetType()))
                            {
                                lblDiscoveredContent.Text = Newtonsoft.Json.JsonConvert.SerializeObject(discovered).Replace('{', ' ').Replace('}', ' ');
                            }
                            else if (typeof(JArray).Equals(discovered.GetType()))
                            {
                                string discoveredContent = "";
                                int idx = 0;
                                foreach (var item in discovered)
                                {
                                    if (typeof(JValue).Equals(item.GetType()))
                                    {
                                        if (idx == 0)
                                        {
                                            discoveredContent += "\"" + (string)item + '"';
                                        }
                                        else
                                        {
                                            discoveredContent += ", \"" + (string)item + '"';
                                        }
                                    }
                                    else if (typeof(JObject).Equals(item.GetType()))
                                    {
                                        discoveredContent += Newtonsoft.Json.JsonConvert.SerializeObject(item).Replace('{', ' ').Replace('}', ' ');
                                    }
                                    else if (typeof(JArray).Equals(discovered.GetType()))
                                    {
                                        discoveredContent += '"' + (string)string.Join("\", \"", discovered).Replace('{', ' ').Replace('}', ' ') + '"';
                                    }
                                    idx++;
                                }
                                lblDiscoveredContent.Text = discoveredContent;
                            }

                            lblDiscoveredContent.Font = new Font("Calibri", 11, FontStyle.Regular);
                            lblDiscoveredContent.ForeColor = Color.White;
                            lblDiscoveredContent.AutoSize = true;
                            lblDiscoveredContent.MaximumSize = new System.Drawing.Size(480, 0);

                            panel.Controls.Add(lblSignatureTitle);
                            panel.Controls.Add(lblEntropyDescription);
                            panel.Controls.Add(lblDiscovered);
                            panel.Controls.Add(lblDiscoveredContent);

                            flowLayoutPanelDetails.Controls.Add(panel);
                            flowLayoutPanelDetails.Controls.Add(linePanel);

                        }
                    }

                    if (score_num > this.minThreatScore)
                    {
                        removeButton.Visible = true;
                        releaseButton.Visible = true;
                    }
                    else
                    {
                        removeButton.Visible = false;
                        releaseButton.Visible = false;
                    }
                }
                else
                {
                    flowLayoutPanelDetails.Visible = false;
                }

                // percent label
                percentLabel.Text = score;

                // update colors based on score
                if (score_num < 20.0)
                {
                    colorPanel.BackColor = Color.Green;
                    percentLabel.ForeColor = Color.Green;
                }
                else if (score_num >= 20.0 && score_num < 40.0)
                {
                    colorPanel.BackColor = Color.Yellow;
                    percentLabel.ForeColor = Color.Yellow;
                }
                else if (score_num >= 40.0 && score_num < 60.0)
                {
                    colorPanel.BackColor = Color.Orange;
                    percentLabel.ForeColor = Color.Orange;
                }
                else
                {
                    colorPanel.BackColor = Color.Red;
                    percentLabel.ForeColor = Color.Red;
                }
            }

            if (success)
            {
                fileLabel.Text = this.fileName;
                fileLabel.ForeColor = Color.White;
            }
            else
            {
                fileLabel.Text = "[FAILED] " + this.fileName;
                fileLabel.ForeColor = Color.Yellow;
                colorPanel.BackColor = Color.Yellow;
                panelDetailItem.BackColor = Color.DarkRed;

                Button rerunButton = new Button();
                rerunButton.Text = "RERUN";
                rerunButton.Font = new Font("Calibri", 12, FontStyle.Bold);
                rerunButton.BackColor = Color.Yellow;
                rerunButton.ForeColor = Color.Black;
                rerunButton.FlatStyle = FlatStyle.Flat;
                rerunButton.FlatAppearance.BorderSize = 0;
                rerunButton.Width = 70;
                rerunButton.Height = 31;
                rerunButton.Location = new System.Drawing.Point(255, 7);
                rerunButton.Click += delegate (object obj, EventArgs ea)
                {
                    this.Close();
                    monitoringForm.rerunScanFile(folderName, fileName, listPanel, true);
                };
                panelDetailItem.Controls.Add(rerunButton);
                percentLabel.Visible = false;
            }

            removeButton.Click += delegate (object obj, EventArgs ea)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this file?", "DELETE", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    if (File.Exists(folderName + "\\" + fileName))
                    {
                        handleRelease(folderName + "\\" + fileName, false);
                        File.Delete(folderName + "\\" + fileName);
                    }
                    string hashFileName = folderName.Replace("\\", "-").Replace(":", "") + fileName + "-hash.json";
                    if (File.Exists("./malcore/threat/" + hashFileName))
                    {

                        File.Delete("./malcore/threat/" + hashFileName);
                    }
                    listPanel.Dispose();
                    this.Dispose();
                }
            };

            releaseButton.Click += delegate (object obj, EventArgs ea)
            {
                handleRelease(folderName + "\\" + fileName, false);
                releaseButton.Visible = false;
                listPanel.Dispose();

                string hashFileName = folderName.Replace("\\", "-").Replace(":", "") + fileName + "-hash.json";
                string responseString = "released";
                File.WriteAllText(@"./malcore/threat/" + hashFileName, responseString);
            };
        }


        /**
        * @Description: draw detail form for doc files
        * @param monitoringForm: MonitoringForm object
        * @param listPanel: monitoring form's panel of selected file
        * @return void
        **/
        private void initDetailFormUIForDoc(MonitoringForm monitoringForm, Panel listPanel)
        {

            // folder label 
            folderLabel.Text = this.folderName;
            labelFullPath.Text = this.folderName;

            bool success = true;

            if (this.responseString == "" || this.responseString == null)
            {
                success = false;
            }
            else
            {

                JObject jsonObject = JObject.Parse(this.responseString);
                success = (bool)jsonObject["success"];

                if (jsonObject["data"]["data"].ToString() == "{}")
                {
                    success = false;
                }
                string score = "";
                double score_num = 0;
                if (success)
                {
                    flowLayoutPanelDetails.Visible = true;

                    score = (string)jsonObject["data"]["data"]["dfi"]["results"]["dfi_results"]["score"];
                    score_num = Convert.ToDouble(score);
                    score = Convert.ToString(Math.Round(score_num)) + "%";

                    if (jsonObject["data"]["data"]["dfi"]["results"]["dfi_results"]["details"] != null)
                    {
                        JArray details = (JArray)jsonObject["data"]["data"]["dfi"]["results"]["dfi_results"]["details"];
                        for (int i = 0; i < details.Count; i++)
                        {
                            FlowLayoutPanel panel = new FlowLayoutPanel();
                            panel.AutoSize = true;
                            panel.MaximumSize = new System.Drawing.Size(480, 0);

                            Panel linePanel = new Panel();
                            linePanel.Size = new System.Drawing.Size(480, 1);
                            linePanel.BackColor = Color.Gray;

                            Label lblSignatureTitle = new Label();
                            lblSignatureTitle.Font = new Font("Calibri", 14, FontStyle.Bold);
                            lblSignatureTitle.ForeColor = Color.Orange;
                            string title = (string)details[i]["title"];
                            lblSignatureTitle.Text = title.ToUpper();
                            lblSignatureTitle.AutoSize = true;

                            panel.Controls.Add(lblSignatureTitle);

                            flowLayoutPanelDetails.Controls.Add(panel);
                            flowLayoutPanelDetails.Controls.Add(linePanel);

                        }
                    }

                    if (score_num > this.minThreatScore)
                    {
                        removeButton.Visible = true;
                        releaseButton.Visible = true;
                    }
                    else
                    {
                        removeButton.Visible = false;
                        releaseButton.Visible = false;
                    }
                }
                else
                {
                    flowLayoutPanelDetails.Visible = false;
                }

                // percent label
                percentLabel.Text = score;

                // update colors based on score
                if (score_num < 20.0)
                {
                    colorPanel.BackColor = Color.Green;
                    percentLabel.ForeColor = Color.Green;
                }
                else if (score_num >= 20.0 && score_num < 40.0)
                {
                    colorPanel.BackColor = Color.Yellow;
                    percentLabel.ForeColor = Color.Yellow;
                }
                else if (score_num >= 40.0 && score_num < 60.0)
                {
                    colorPanel.BackColor = Color.Orange;
                    percentLabel.ForeColor = Color.Orange;
                }
                else
                {
                    colorPanel.BackColor = Color.Red;
                    percentLabel.ForeColor = Color.Red;
                }
            }

            if (success)
            {
                fileLabel.Text = this.fileName;
                fileLabel.ForeColor = Color.White;
            }
            else
            {
                fileLabel.Text = "[FAILED] " + this.fileName;
                fileLabel.ForeColor = Color.Yellow;
                colorPanel.BackColor = Color.Yellow;
                panelDetailItem.BackColor = Color.DarkRed;

                Button rerunButton = new Button();
                rerunButton.Text = "RERUN";
                rerunButton.Font = new Font("Calibri", 12, FontStyle.Bold);
                rerunButton.BackColor = Color.Yellow;
                rerunButton.ForeColor = Color.Black;
                rerunButton.FlatStyle = FlatStyle.Flat;
                rerunButton.FlatAppearance.BorderSize = 0;
                rerunButton.Width = 70;
                rerunButton.Height = 31;
                rerunButton.Location = new System.Drawing.Point(255, 7);
                rerunButton.Click += delegate (object obj, EventArgs ea)
                {
                    this.Close();
                    monitoringForm.rerunScanFile(folderName, fileName, listPanel, false);
                };
                panelDetailItem.Controls.Add(rerunButton);
                percentLabel.Visible = false;
            }

            removeButton.Click += delegate (object obj, EventArgs ea)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this file?", "DELETE", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    if (File.Exists(folderName + "\\" + fileName))
                    {
                        handleRelease(folderName + "\\" + fileName, false);
                        File.Delete(folderName + "\\" + fileName);
                    }
                    string hashFileName = folderName.Replace("\\", "-").Replace(":", "") + fileName + "-hash.json";
                    if (File.Exists("./malcore/doc/" + hashFileName))
                    {
                        File.Delete("./malcore/doc/" + hashFileName);
                    }
                    listPanel.Dispose();
                    this.Dispose();
                }
            };

            releaseButton.Click += delegate (object obj, EventArgs ea)
            {
                handleRelease(folderName + "\\" + fileName, false);
                releaseButton.Visible = false;
                listPanel.Dispose();

                string hashFileName = folderName.Replace("\\", "-").Replace(":", "") + fileName + "-hash.json";
                string responseString = "released";
                File.WriteAllText(@"./malcore/doc/" + hashFileName, responseString);
            };
        }


        /**
        * @Description: Update file access rule based on locking param
        * @param path: full path of the target file  
        * @param locking: true if file is currently Allow, false if file is Deny now
        * @return void
        **/
        private void handleRelease(string path, bool locking)
        {
            string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            FileInfo fInfo = new FileInfo(path);
            FileSecurity fSecurity = fInfo.GetAccessControl();

            if (locking)
            {
                fSecurity.AddAccessRule(new FileSystemAccessRule(userName, FileSystemRights.ReadAndExecute, AccessControlType.Deny));
                fInfo.SetAccessControl(fSecurity);
            }
            else
            {
                fSecurity.RemoveAccessRule(new FileSystemAccessRule(userName, FileSystemRights.ReadAndExecute, AccessControlType.Deny));
                fInfo.SetAccessControl(fSecurity);
            }
        }

        private void DetailsForm_Load(object sender, EventArgs e)
        {
        }

        private void lblFileName_Click(object sender, EventArgs e)
        {
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            Hide();
            SettingsForm settingsForm = new SettingsForm();
            settingsForm.Show(this);
        }

        /**
        * @Description: handle logout
        **/
        private void btnLogout_Click(object sender, EventArgs e)
        {
            try
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey(@".malcore", true);
                key.DeleteValue("API_KEY");
                key.DeleteValue("SETTINGS");
                key.Close();

                Program.APIKEY = "";
                Program.USEREMAIL = "";

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

            Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.Show(this);
        }
    }
}
