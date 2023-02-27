using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using Newtonsoft.Json.Linq;

namespace MCDA_APP.Forms
{
    public partial class MonitoringForm : Form
    {
        public MonitoringForm()
        {
            InitializeComponent();
        }

        private async void MonitoringForm_Load(object sender, EventArgs e)
        {
            try
            {
                // check if active or inactive
                bool active = true;
                if (active)
                {
                    panelInactive.Visible = false;
                    monitoringFlowLayoutPanel.Visible = true;
                    labelRemaining.Visible = true;
                    lblRequestNumber.Visible = true;
                    lblStatus.Text = "ACTIVE";
                    lblStatus.ForeColor = Color.Green;

                    RegistryKey key = Registry.CurrentUser.OpenSubKey(@".malcore");
                    if (key != null)
                    {
                        var SETTINGS = key.GetValue("SETTINGS");
                        if (SETTINGS != null)
                        {
                            JObject json = JObject.Parse(SETTINGS.ToString());

                            if ((bool)json["enableMornitoring"])
                            {
                                // start monitoring
                                Debug.WriteLine("start monitoring::::::::::: ");
                                string[] dirs = Directory.GetFiles(@"c:\", "*.exe");
                                Console.WriteLine("The number of files starting with c is {0}.", dirs.Length);
                                foreach (string dir in dirs)
                                {
                                    Console.WriteLine(dir);
                                }


                                string[] paths = new string[] { @"C:\Users\Administrator\Documents\TEST" };
                                foreach (string path in paths)
                                {
                                    if (File.Exists(path))
                                    {
                                        // This path is a file
                                        ProcessFile(path);
                                    }
                                    else if (Directory.Exists(path))
                                    {
                                        // This path is a directory
                                        ProcessDirectory(path);
                                    }
                                    else
                                    {
                                        Console.WriteLine("{0} is not a valid file or directory.", path);
                                    }
                                }
                                // add element to the list 
                            }
                        }
                    }
                }
                else
                {
                    panelInactive.Visible = true;
                    monitoringFlowLayoutPanel.Visible = false;
                    labelRemaining.Visible = false;
                    lblRequestNumber.Visible = false;
                    lblStatus.Text = "INACTIVE";
                    lblStatus.ForeColor = Color.Red;
                }


            }
            catch (Exception ex)
            {
                // Write out any exceptions.
                Debug.WriteLine(ex);
            }
        }

        private async Task<string> getThreatScore(string pathFile, string fileName)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    using (var content = new MultipartFormDataContent())
                    {
                        string url = System.Configuration.ConfigurationManager.AppSettings["URI"] + "/api/threatscore";

                        byte[] fileData = File.ReadAllBytes(pathFile);
                        content.Add(new StreamContent(new MemoryStream(fileData)), "filename1", fileName);
                        content.Headers.Add("apiKey", Program.APIKEY);
                        content.Headers.Add("source", "agent");

                        using (
                           var response = await client.PostAsync(url, content))
                        {
                            Debug.WriteLine("response...." + response);
                            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                            {
                                string responseString = await response.Content.ReadAsStringAsync();
                                // updateMonitoringUI(responseString, true);

                                Debug.WriteLine("threat...." + responseString);
                                return responseString;
                            }
                            else
                            {
                                // updateMonitoringUI("", false);
                                return "";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Write out any exceptions.
                Debug.WriteLine(ex);
                return "";
            }
        }

        private void updateMonitoringUI(string response, bool status)
        {
            try
            {
                if (status)
                {
                    JObject json = JObject.Parse(response);
                    if (json["data"] != null && (bool)json["data"]["success"] == true)
                    {
                        string score = (string)json["data"]["data"]["score"];

                        // addItemToMonitoringPanel();

                    }
                    else
                    {

                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void addItemToMonitoringPanel(string responseString, string folderName, string fileName)
        {
            JObject jsonObject = JObject.Parse(responseString);
            bool success = (bool)jsonObject["success"];
            Debug.WriteLine("........................." +  jsonObject["data"]["data"].ToString());

            if (jsonObject["data"]["data"].ToString() == "{}")
            {
                success = false;
            }
            string score = "";
            if (success)
            {
                score = (string)jsonObject["data"]["data"]["score"];
            }
            // item panel
            Panel panel = new Panel();
            panel.Width = 501;
            panel.Height = 44;
            panel.BackColor = Color.Black;

            // color panel
            Panel colorPanel = new Panel();
            colorPanel.Width = 20;
            colorPanel.Height = 44;
            colorPanel.BackColor = Color.Red;

            // file label
            Label fileLabel = new Label();
            if (success)
            {
                fileLabel.Text = fileName;
                fileLabel.ForeColor = Color.White;
            }
            else
            {
                fileLabel.Text = "[FAILED] " + fileName;
                fileLabel.ForeColor = Color.Yellow;
            }

            fileLabel.Font = new Font("Calibri", 12, FontStyle.Bold);
            fileLabel.AutoSize = false;
            fileLabel.Width = 200;
            fileLabel.Location = new System.Drawing.Point(22, 1);

            // folder label
            Label folderLabel = new Label();
            folderLabel.Text = folderName;
            folderLabel.ForeColor = Color.White;
            folderLabel.Font = new Font("Calibri", 11, FontStyle.Regular);
            folderLabel.AutoSize = false;
            folderLabel.Width = 200;
            folderLabel.Location = new System.Drawing.Point(24, 22);

            // percent label
            Label percentLabel = new Label();
            percentLabel.Text = score;
            percentLabel.ForeColor = Color.Red;
            percentLabel.Font = new Font("Calibri", 20, FontStyle.Bold);
            percentLabel.Width = 76;
            percentLabel.Height = 40;
            percentLabel.Location = new System.Drawing.Point(252, 4);

            Button removeButton = new Button();
            removeButton.Text = "DELETE";
            removeButton.Font = new Font("Calibri", 12, FontStyle.Bold);
            removeButton.BackColor = Color.Red;
            removeButton.ForeColor = Color.White;
            removeButton.FlatStyle = FlatStyle.Flat;
            removeButton.FlatAppearance.BorderSize = 0;
            removeButton.Width = 85;
            removeButton.Height = 31;
            removeButton.Location = new System.Drawing.Point(325, 6);
            removeButton.Click += delegate (object obj, EventArgs ea)
            {
                panel.Dispose();
            };

            Button rerunButton = new Button();
            rerunButton.Text = "RERUN";
            rerunButton.Font = new Font("Calibri", 12, FontStyle.Bold);
            rerunButton.BackColor = Color.Yellow;
            rerunButton.ForeColor = Color.Black;
            rerunButton.FlatStyle = FlatStyle.Flat;
            rerunButton.FlatAppearance.BorderSize = 0;
            rerunButton.Width = 70;
            rerunButton.Height = 31;
            rerunButton.Location = new System.Drawing.Point(251, 6);
            rerunButton.Click += delegate (object obj, EventArgs ea)
            {
                panel.Dispose();
            };

            Button releaseButton = new Button();
            releaseButton.Text = "RELEASE";
            releaseButton.Font = new Font("Calibri", 12, FontStyle.Bold);
            releaseButton.BackColor = Color.Goldenrod;
            releaseButton.ForeColor = Color.White;
            releaseButton.FlatStyle = FlatStyle.Flat;
            releaseButton.FlatAppearance.BorderSize = 0;
            releaseButton.Width = 85;
            releaseButton.Height = 31;
            releaseButton.Location = new System.Drawing.Point(414, 6);
            releaseButton.Click += delegate (object obj, EventArgs ea)
            {
                panel.Dispose();
            };

            panel.Controls.Add(colorPanel);
            panel.Controls.Add(fileLabel);
            panel.Controls.Add(folderLabel);
            if (success)
            {
                panel.Controls.Add(percentLabel);
            }
            else
            {
                panel.Controls.Add(rerunButton);
            }
            panel.Controls.Add(removeButton);
            panel.Controls.Add(releaseButton);

            monitoringFlowLayoutPanel.Controls.Add(panel);
        }

        public void ProcessDirectory(string targetDirectory)
        {
            // Process the list of files found in the directory.
            string[] fileEntries = Directory.GetFiles(targetDirectory);
            foreach (string fileName in fileEntries)
                ProcessFile(fileName);

            // Recurse into subdirectories of this directory.
            string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
            foreach (string subdirectory in subdirectoryEntries)
                ProcessDirectory(subdirectory);
        }

        // Insert logic for processing found files here.
        public async void ProcessFile(string path)
        {
            try
            {

                // check if the file is already scanned

                // using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                // {
                //     using (var reader = new BinaryReader(fs, new ASCIIEncoding()))
                //     {
                //         byte[] buffer = new byte[10];
                //         buffer = reader.ReadBytes(10);
                //         Debug.WriteLine("buffer----------------" + buffer[0]);

                //         // if (buffer[0] == 31 && buffer[1] == 139 && buffer[2] == 8)
                //         // {

                //         // }
                //     }
                // }

                Console.WriteLine("Processed file '{0}'.", path);
                HttpClient client = new HttpClient();
                string url = System.Configuration.ConfigurationManager.AppSettings["URI"] + "/api/threatscore";
                Debug.WriteLine("serveruri----------------" + url);

                // string filePath = "C:/Users/Administrator/Documents/notepad.exe";
                string fileName = Path.GetFileName(path);
                string folderName = Directory.GetParent(path) != null ? Directory.GetParent(path).FullName : path;
                string responseString = await getThreatScore(path, fileName);
                JObject jsonObject = JObject.Parse(responseString);

                Debug.WriteLine("getThreatScore----------------" + jsonObject);

                addItemToMonitoringPanel(responseString, folderName, fileName);
            }
            catch (Exception ex)
            {
            }
        }

        private async void getAgentUsuage()
        {
            try
            {
                Debug.WriteLine("getAgentUsuage::::::::::: ");
                string apiKey = Program.APIKEY;

                HttpClient client = new HttpClient();
                string url = System.Configuration.ConfigurationManager.AppSettings["URI"] + "/agent/usage";

                HttpClient httpClient = new HttpClient();
                HttpRequestMessage request = new HttpRequestMessage();
                request.RequestUri = new Uri(url);
                request.Method = HttpMethod.Post;
                request.Headers.Add("apiKey", apiKey);
                HttpResponseMessage response = await httpClient.SendAsync(request);
                var responseString = await response.Content.ReadAsStringAsync();

                Debug.WriteLine(response.StatusCode, responseString);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var content = await response.Content.ReadAsStringAsync();
                }

            }
            catch (Exception ex)
            {
                // Write out any exceptions.
                Debug.WriteLine(ex);
            }
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            Hide();
            SettingsForm settingsForm = new SettingsForm();
            settingsForm.Show(this);
        }

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
                // Write out any exceptions.
                Debug.WriteLine(ex);
            }

            Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.Show(this);
        }

        private void lblStatus_Click(object sender, EventArgs e)
        {
            Hide();
            DetailsForm detailForm = new DetailsForm();
            detailForm.Show(this);
        }

        private void labelInactiveDescription_Click(object sender, EventArgs e)
        {

        }

        private void btnSettings_Click_1(object sender, EventArgs e)
        {
            Hide();
            SettingsForm settingsForm = new SettingsForm();
            settingsForm.Show(this);
        }
    }
}
