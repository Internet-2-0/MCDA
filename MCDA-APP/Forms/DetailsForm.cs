using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Diagnostics;
using Newtonsoft.Json.Linq;

namespace MCDA_APP.Forms
{
    public partial class DetailsForm : Form
    {
        string responseString = "";
        string folderName = "";
        string fileName = "";

        public DetailsForm(string responseString, string folderName, string fileName)
        {
            InitializeComponent();
            this.responseString = responseString;
            this.folderName = folderName;
            this.fileName = fileName;
            Debug.WriteLine("DetailsForm........................." + this.responseString + this.folderName + this.fileName);
            initDetailFormUI();

        }

        private void initDetailFormUI()
        {
            JObject jsonObject = JObject.Parse(responseString);
            bool success = (bool)jsonObject["success"];
            Debug.WriteLine("........................." + jsonObject["data"]["data"].ToString());

            // folder label 
            folderLabel.Text = this.folderName;
            labelFullPath.Text = this.folderName;

            if (jsonObject["data"]["data"].ToString() == "{}")
            {
                success = false;
            }
            string score = "";
            double score_num = 0;
            string discovered = "";
            string entropyDescription = "";
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
                        Debug.WriteLine("DETAILS---------------------------........................." + signatures[i]);

                        Panel panel = new Panel();
                        panel.AutoSize = true;
                        panel.MaximumSize = new System.Drawing.Size(480, 0);
                        
                        Panel linePanel = new Panel();
                        linePanel.Size = new System.Drawing.Size(480, 1);
                        linePanel.BackColor = Color.Gray;

                        Label lblSignatureTitle = new Label();
                        lblSignatureTitle.Font = new Font("Calibri", 14, FontStyle.Bold);
                        lblSignatureTitle.ForeColor = Color.Orange;
                        lblSignatureTitle.Text = (string)signatures[i]["info"]["title"];

                        Label lblEntropyDescription = new Label();
                        lblEntropyDescription.Font = new Font("Calibri", 11, FontStyle.Regular);
                        lblEntropyDescription.ForeColor = Color.White;
                        lblEntropyDescription.Text = (string)signatures[i]["info"]["description"];
                        lblEntropyDescription.Location = new System.Drawing.Point(0, 23);
                        lblEntropyDescription.AutoSize = true;
                        lblEntropyDescription.MaximumSize = new System.Drawing.Size(480, 0);
                        // Size = new System.Drawing.Size(500, 100);

                        // labelDiscovery.Text = (string)jObject["discovered"];

                        panel.Controls.Add(lblSignatureTitle);
                        panel.Controls.Add(lblEntropyDescription);

                        flowLayoutPanelDetails.Controls.Add(panel);
                        flowLayoutPanelDetails.Controls.Add(linePanel);

                    }
                    // foreach (var jObject in signatures)
                    // {
                    //     Debug.WriteLine("DETAILS---------------------------........................." + jObject);

                    //     // labelDiscovery.Text = (string)jObject["discovered"];
                    //     lblSignatureTitle.Text = (string)jObject["info"]["title"];
                    //     lblEntropyDescription.Text = (string)jObject["info"]["description"];
                    //     panel.Controls.Add(lblSignatureTitle);
                    //     panel.Controls.Add(lblEntropyDescription);

                    //     flowLayoutPanelDetails.Controls.Add(panel);
                    // }
                }


            }
            else
            {
                flowLayoutPanelDetails.Visible = false;
            }

            // percent label
            percentLabel.Text = score;
            removeButton.Click += delegate (object obj, EventArgs ea)
            {
                // panel.Dispose();
            };

            // rerunButton.Click += delegate (object obj, EventArgs ea)
            // {
            // };

            releaseButton.Click += delegate (object obj, EventArgs ea)
            {
            };

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
            }

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

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

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
