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
                                // add element to the list
                                addItemToMonitoringPanel();
                                addItemToMonitoringPanel();
                                addItemToMonitoringPanel();
                                addItemToMonitoringPanel();
                                addItemToMonitoringPanel();
                                addItemToMonitoringPanel();
                                addItemToMonitoringPanel();
                                addItemToMonitoringPanel();
                                addItemToMonitoringPanel();
                                addItemToMonitoringPanel();
                                addItemToMonitoringPanel();
                                addItemToMonitoringPanel();
                                addItemToMonitoringPanel();
                                addItemToMonitoringPanel();
                                addItemToMonitoringPanel();
                                // add element to the list
                                return;

                                HttpClient client = new HttpClient();
                                string url = System.Configuration.ConfigurationManager.AppSettings["URI"] + "/api/threatscore";
                                Debug.WriteLine("serveruri----------------" + url);

                                string filePath = "C:/Users/Administrator/Documents/notepad.exe";
                                string fileName = "notepad.exe";
                                string responseString = await getThreatScore(filePath, fileName);
                                JObject jsonObject = JObject.Parse(responseString);

                                Debug.WriteLine("getThreatScore----------------" + jsonObject);
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
                                updateMonitoringUI(responseString, true);

                                Debug.WriteLine("threat...." + responseString);
                                return responseString;
                            }
                            else
                            {
                                updateMonitoringUI("", false);
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

                        addItemToMonitoringPanel();

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

        private void addItemToMonitoringPanel()
        {
            Panel panel = new Panel();
            panel.Width = 500;
            panel.Height = 18;

            Panel borderPanel = new Panel();
            borderPanel.Height = 1;
            borderPanel.Width = 500;
            borderPanel.BackColor = Color.WhiteSmoke;

            Label label = new Label();
            label.Text = "folderPath";
            label.ForeColor = Color.White;
            label.AutoSize = false;
            label.Width = 400;

            Button removeButton = new Button();
            removeButton.Text = "X";
            removeButton.Size = new System.Drawing.Size(18, 23);
            removeButton.ForeColor = Color.DarkRed;
            removeButton.FlatStyle = FlatStyle.Flat;
            removeButton.FlatAppearance.BorderSize = 0;
            removeButton.Padding = new Padding(0, 0, 0, 0);
            removeButton.Location = new System.Drawing.Point(410, -4);
            removeButton.Click += delegate (object obj, EventArgs ea)
            {
                panel.Dispose();
                borderPanel.Dispose();
            };

            panel.Controls.Add(label);
            panel.Controls.Add(removeButton);

            monitoringFlowLayoutPanel.Controls.Add(panel);
            monitoringFlowLayoutPanel.Controls.Add(borderPanel);
            monitoringFlowLayoutPanel.SetFlowBreak(borderPanel, false);
        }

        // private async Task<string> UploadAsync(string fileName, string server)
        // {
        //     string value = null;
        //     using (var fileStream = File.Open(fileName, FileMode.Open))
        //     {
        //         var client = new RestClient(server);
        //         var request = new RestRequest(Method.POST);
        //         using (MemoryStream memoryStream = new MemoryStream())
        //         {
        //             await fileStream.CopyToAsync(memoryStream);
        //             request.AddFile("file", memoryStream.ToArray(), fileName);
        //             request.AlwaysMultipartFormData = true;

        //             var result = client.ExecuteAsync(request, (response, handle) =>
        //             {
        //                 if (response.StatusCode == System.Net.HttpStatusCode.OK)
        //                 {
        //                     dynamic json = JsonConvert.DeserializeObject(response.Content);
        //                     value = json.fileName;
        //                 }
        //             });
        //         }
        //     }
        //     return value;
        // }

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
