using System.Diagnostics;
using System.Text;
using Microsoft.Win32;
using Newtonsoft.Json.Linq;
using System.Security.AccessControl;
using System.Security.Principal;
// using System.ComponentModel;

namespace MCDA_APP.Forms
{
    public partial class MonitoringForm : Form
    {
        double minThreatScore = 15.0;
        bool sendStatistics = true;
        bool closing = false;

        int numberOfProcessing = 0;
        private System.Windows.Forms.Timer monitorTimer;

        public MonitoringForm()
        {
            InitializeComponent();

            labelEmail.Text = Program.USEREMAIL;

            // Create directories for caching
            if (!Directory.Exists(@"./malcore"))
            {
                Directory.CreateDirectory(@"./malcore");
            }
            if (!Directory.Exists(@"./malcore/threat"))
            {
                Directory.CreateDirectory(@"./malcore/threat");
            }
            if (!Directory.Exists(@"./malcore/doc"))
            {
                Directory.CreateDirectory(@"./malcore/doc");
            }

            startMonitoring();
        }


        /**
        * @Description: Start monitoring and update monitoring form with result
        * This function works only once when the app starts
        * @return void.
        **/
        private async void startMonitoring()
        {
            queuePanel.Visible = false;

            await initFilePool();

            this.Visible = true;

            try
            {
                // Check if active or inactive based on usuage
                bool active = await agentUsuage();

                if (active)
                {
                    panelInactive.Visible = false;
                    monitoringFlowLayoutPanel.Visible = true;
                    labelRemaining.Visible = true;
                    lblRequestNumber.Visible = true;
                    lblRequestNumber.Location = new System.Drawing.Point(680, 79);

                    lblStatus.Text = "ACTIVE";
                    lblStatus.ForeColor = Color.Green;

                    RegistryKey key = Registry.CurrentUser.OpenSubKey(@".malcore");
                    if (key != null)
                    {
                        var SETTINGS = key.GetValue("SETTINGS");
                        if (SETTINGS != null)
                        {
                            JObject json = JObject.Parse(SETTINGS.ToString());
                            this.minThreatScore = (double)(json["minThreatScore"]);
                            this.sendStatistics = (bool)(json["sendStatistics"]);

                            if ((bool)json["enableMornitoring"])
                            {
                                // start monitoring
                                while (Program.filePool.Count > 0)
                                {
                                    this.numberOfProcessing++;

                                    if (this.numberOfProcessing > 5)
                                    {
                                        await ProcessFile(Program.filePool.Dequeue());
                                    }
                                    else
                                    {
                                        ProcessFile(Program.filePool.Dequeue());
                                    }
                                }
                                Debug.WriteLine("end monitoring");
                                InitTimer();
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



        /**
        * @Description: monitoring file changes in the target directory
        * Update Queue status and UI
        * @return void.
        **/
        private async void handleMonitoring()
        {

            try
            {
                // Check if active or inactive based on usuage
                bool active = await agentUsuage();

                if (active)
                {
                    panelInactive.Visible = false;
                    monitoringFlowLayoutPanel.Visible = true;
                    labelRemaining.Visible = true;
                    lblRequestNumber.Visible = true;
                    lblRequestNumber.Location = new System.Drawing.Point(680, 79);

                    lblStatus.Text = "ACTIVE";
                    lblStatus.ForeColor = Color.Green;

                    RegistryKey key = Registry.CurrentUser.OpenSubKey(@".malcore");
                    if (key != null)
                    {
                        var SETTINGS = key.GetValue("SETTINGS");
                        if (SETTINGS != null)
                        {
                            JObject json = JObject.Parse(SETTINGS.ToString());
                            this.minThreatScore = (double)(json["minThreatScore"]);
                            this.sendStatistics = (bool)(json["sendStatistics"]);

                            if ((bool)json["enableMornitoring"])
                            {
                                // start monitoring
                                while (Program.filePool.Count > 0)
                                {
                                    this.numberOfProcessing++;

                                    if (this.numberOfProcessing > 5)
                                    {
                                        await ProcessFile(Program.filePool.Dequeue());
                                    }
                                    else
                                    {
                                        ProcessFile(Program.filePool.Dequeue());
                                    }
                                }
                                Debug.WriteLine("end handleMonitoring");
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


        /**
        * @Description: Scan files and add them to the pool
        * @return void.
        **/
        private async Task<bool> initFilePool()
        {
            try
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey(@".malcore");
                if (key != null)
                {
                    var SETTINGS = key.GetValue("SETTINGS");
                    if (SETTINGS != null)
                    {
                        JObject json = JObject.Parse(SETTINGS.ToString());
                        this.minThreatScore = (double)(json["minThreatScore"]);
                        this.sendStatistics = (bool)(json["sendStatistics"]);

                        if ((bool)json["enableMornitoring"])
                        {
                            // start monitoring
                            string settings_paths = (string)json["paths"];

                            List<string> paths = settings_paths.Split(',').ToList();
                            int num = 0;
                            foreach (string path in paths)
                            {
                                if (File.Exists(path))
                                {
                                    bool result = checkFileExtentionIsAllowed(path);
                                    if (result)
                                    {

                                        if (!Program.filePool.Contains(path))
                                        {
                                            Program.filePool.Enqueue(path);
                                        }

                                    }
                                }
                                else if (Directory.Exists(path))
                                {
                                    ProcessDirectory(path);
                                    switch (num)
                                    {
                                        case 0:
                                            fileSystemWatcherMain.Path = path;
                                            break;
                                        case 1:
                                            fileSystemWatcher1.Path = path;
                                            break;
                                        case 2:
                                            fileSystemWatcher2.Path = path;
                                            break;
                                        case 3:
                                            fileSystemWatcher3.Path = path;
                                            break;
                                        case 4:
                                            fileSystemWatcher4.Path = path;
                                            break;
                                        case 5:
                                            fileSystemWatcher5.Path = path;
                                            break;
                                        case 6:
                                            fileSystemWatcher6.Path = path;
                                            break;
                                        case 7:
                                            fileSystemWatcher7.Path = path;
                                            break;
                                        case 8:
                                            fileSystemWatcher8.Path = path;
                                            break;
                                        case 9:
                                            fileSystemWatcher9.Path = path;
                                            break;
                                        case 10:
                                            fileSystemWatcher10.Path = path;
                                            break;
                                        case 11:
                                            fileSystemWatcher11.Path = path;
                                            break;
                                        case 12:
                                            fileSystemWatcher12.Path = path;
                                            break;
                                        case 13:
                                            fileSystemWatcher13.Path = path;
                                            break;
                                        case 14:
                                            fileSystemWatcher14.Path = path;
                                            break;
                                        case 15:
                                            fileSystemWatcher15.Path = path;
                                            break;
                                        case 16:
                                            fileSystemWatcher16.Path = path;
                                            break;
                                        case 17:
                                            fileSystemWatcher17.Path = path;
                                            break;
                                        case 18:
                                            fileSystemWatcher18.Path = path;
                                            break;
                                        case 19:
                                            fileSystemWatcher19.Path = path;
                                            break;
                                        default:
                                            fileSystemWatcherMain.Path = path;
                                            break;
                                    }
                                    num++;
                                }
                                else
                                {
                                    // Console.WriteLine("{0} is not a valid file or directory.", path);
                                }
                            }
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                // Write out any exceptions.
                Debug.WriteLine(ex);
                return false;
            }
        }


        /**
        * @Description: Call api/threatscore or api/docfile to get scan result
        * @param pathFile: full file path of target file
        * @param fileName: target file name
        * @param type: file type - threatscore / docfile
        * @return api response as string.
        **/
        private async Task<string> getThreatScore(string pathFile, string fileName, string type)
        {
            // NotifyPropertyChanged("filePool"); 

            try
            {
                if (Program.filePool.Count > 0)
                {
                    queuePanel.Visible = true;
                    labelQueuedFiles.Text = Program.filePool.Count.ToString() + " files were queued for processing";
                }
                else
                {
                    queuePanel.Visible = false;
                }

                string payload = "{\"type\":\"file_submitted\",\"payload\":{\"name\":\"" + fileName + "\",\"type\":\"" + type + "\",\"message\":\"File submitted\"}}";
                await agentStat(payload);

                handleRelease(pathFile, false);
                string url = System.Configuration.ConfigurationManager.AppSettings["URI"] + "/api/" + type;

                using (var client = new HttpClient())
                {
                    using (var content = new MultipartFormDataContent())
                    {
                        byte[] fileData = File.ReadAllBytes(pathFile);
                        content.Add(new StreamContent(new MemoryStream(fileData)), "filename1", fileName);
                        content.Headers.Add("apiKey", Program.APIKEY);
                        content.Headers.Add("source", "agent");

                        using (
                           var response = await client.PostAsync(url, content))
                        {
                            handleRelease(pathFile, true);

                            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                            {
                                string responseString = await response.Content.ReadAsStringAsync();
                                this.numberOfProcessing--;
                                return responseString;
                            }
                            else
                            {
                                string payload2 = "{\"type\":\"file_failed\",\"payload\":{\"name\":\"" + fileName + "\",\"type\":\"" + type + "\",\"response\":\"api_error\",\"message\":\"API Error\"}}";
                                await agentStat(payload2);
                                this.numberOfProcessing--;
                                return "";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Write out any exceptions.
                this.numberOfProcessing--;
                Debug.WriteLine("getThreatScore Exception.........................." + ex);
                handleRelease(pathFile, false);

                string payload = "{\"type\":\"file_failed\",\"payload\":{\"name\":\"" + fileName + "\",\"type\":\"" + type + "\",\"response\":\"timeout/api_error/other_error\",\"message\":\"API Error/Timeout/Other\"}}";
                await agentStat(payload);
                return "";
            }
        }


        /**
        * @Description: Call agent/stat for log on the server
        * @param jsonData: json string for request data of the api 
        * @return api response as string.
        **/
        private async Task<string> agentStat(string jsonData)
        {
            try
            {
                if (this.sendStatistics == false)
                {
                    return "";
                }
                string url = System.Configuration.ConfigurationManager.AppSettings["URI"] + "/agent/stat";

                using (var client = new HttpClient())
                {
                    // string jsonData = "{\"type\":\"started\",\"payload\":{\"message\":\"Agent Started\"}}";

                    var requestContent = new StringContent(jsonData, Encoding.Unicode, "application/json");
                    client.DefaultRequestHeaders.Add("apiKey", Program.APIKEY);
                    client.DefaultRequestHeaders.Add("source", "agent");
                    client.DefaultRequestHeaders.Add("agentVersion", "1.0");

                    using (
                          var response = await client.PostAsync(url, requestContent))
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            var content = await response.Content.ReadAsStringAsync();
                            return content;
                        }
                        else
                        {
                            return "";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Write out any exceptions.
                Debug.WriteLine("agentStat dug.........................." + ex);
                return "";
            }
        }


        /**
        * @Description: Call agent/usage API
        * @return true if remaining > 0, else false
        **/
        private async Task<bool> agentUsuage()
        {
            try
            {
                string url = System.Configuration.ConfigurationManager.AppSettings["URI"] + "/agent/usage";

                using (var client = new HttpClient())
                {

                    var requestContent = new StringContent("", Encoding.Unicode, "application/json");
                    client.DefaultRequestHeaders.Add("apiKey", Program.APIKEY);
                    client.DefaultRequestHeaders.Add("source", "agent");
                    client.DefaultRequestHeaders.Add("agentVersion", "1.0");

                    using (
                          var response = await client.PostAsync(url, requestContent))
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            var content = await response.Content.ReadAsStringAsync();
                            JObject jsonObject = JObject.Parse(content);

                            if ((bool)jsonObject["success"] == true)
                            {
                                lblRequestNumber.Text = (string)jsonObject["data"]["remaining"];
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Write out any exceptions. 
                return false;
            }
        }


        /**
        * @Description: add exe files report to monitoring panel
        * @param responseString: json string of api/threatscore or api/docfile api
        * @param folderName: full path of the target file excluding it's name 
        * @param fileName: target file name
        * @param succeed:  api result
        * @return void
        **/
        private void addItemToMonitoringPanel(string responseString, string folderName, string fileName, bool succeed)
        {
            bool success = false;
            string score = "";
            double score_num = 0;

            if (succeed == true)
            {
                JObject jsonObject = JObject.Parse(responseString);

                success = (bool)jsonObject["success"];
                if (jsonObject["data"]["data"].ToString() == "{}")
                {
                    success = false;
                }

                if (success)
                {
                    success = (bool)jsonObject["data"]["success"];
                    if (success)
                    {
                        score = (string)jsonObject["data"]["data"]["score"];
                        string[] scores = score.Split('/');
                        score_num = Convert.ToDouble(scores[0]);
                        score = Convert.ToString(Math.Round(score_num)) + "%";
                    }
                }
            }

            // item panel
            Panel panel = new Panel();
            panel.Width = 770;
            panel.Height = 44;
            panel.BackColor = Color.Black;

            // color panel
            Panel colorPanel = new Panel();
            colorPanel.Name = "colorPanel";
            colorPanel.Width = 20;
            colorPanel.Height = 44;
            // colorPanel.BackColor = Color.Red;

            // file label
            Label fileLabel = new Label();
            fileLabel.Name = "fileLabel";
            fileLabel.Font = new Font("Calibri", 12, FontStyle.Bold);
            fileLabel.AutoSize = false;
            fileLabel.Width = 400;
            fileLabel.Location = new System.Drawing.Point(22, 1);
            fileLabel.Click += delegate (object obj, EventArgs ea)
            {
                DetailsForm detailsForm = new DetailsForm("threat", responseString, folderName, fileName, this, panel);
                detailsForm.Show(this);
            };

            // folder label
            Label folderLabel = new Label();
            folderLabel.Name = "folderLabel";
            folderLabel.Text = folderName;
            folderLabel.ForeColor = Color.White;
            folderLabel.Font = new Font("Calibri", 11, FontStyle.Regular);
            folderLabel.AutoSize = false;
            folderLabel.Width = 400;
            folderLabel.Location = new System.Drawing.Point(24, 22);
            folderLabel.Click += delegate (object obj, EventArgs ea)
            {
                DetailsForm detailsForm = new DetailsForm("threat", responseString, folderName, fileName, this, panel);
                detailsForm.Show(this);
            };

            // percent label
            Label percentLabel = new Label();
            percentLabel.Name = "percentLabel";
            percentLabel.Text = score;
            percentLabel.Font = new Font("Calibri", 20, FontStyle.Bold);
            percentLabel.Width = 76;
            percentLabel.Height = 40;
            percentLabel.Location = new System.Drawing.Point(512, 4);

            Button removeButton = new Button();
            removeButton.Name = "removeButton";
            removeButton.Text = "DELETE";
            removeButton.Font = new Font("Calibri", 12, FontStyle.Bold);
            removeButton.BackColor = Color.Red;
            removeButton.ForeColor = Color.White;
            removeButton.FlatStyle = FlatStyle.Flat;
            removeButton.FlatAppearance.BorderSize = 0;
            removeButton.Width = 85;
            removeButton.Height = 31;
            removeButton.Location = new System.Drawing.Point(590, 6);
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
                    panel.Dispose();

                    string payload = "{\"type\":\"file_deleted\",\"payload\":{\"name\":\"" + fileName + "\",\"type\":\"threatscore\",\"message\":\"File deleted\"}}";
                    agentStat(payload);
                }
                else if (dialogResult == DialogResult.No)
                {
                    //do something else
                }

            };

            Button rerunButton = new Button();
            rerunButton.Name = "rerunButton";
            rerunButton.Text = "RERUN";
            rerunButton.Font = new Font("Calibri", 12, FontStyle.Bold);
            rerunButton.BackColor = Color.Yellow;
            rerunButton.ForeColor = Color.Black;
            rerunButton.FlatStyle = FlatStyle.Flat;
            rerunButton.FlatAppearance.BorderSize = 0;
            rerunButton.Width = 70;
            rerunButton.Height = 31;
            rerunButton.Location = new System.Drawing.Point(515, 6);
            rerunButton.Click += delegate (object obj, EventArgs ea)
            {
                rerunButton.Visible = false;
                rerunScanFile(folderName, fileName, panel, true);

                string payload = "{\"type\":\"file_reran\",\"payload\":{\"name\":\"" + fileName + "\",\"type\":\"threatscore\",\"message\":\"File reran\"}}";
                agentStat(payload);
            };

            Button releaseButton = new Button();
            releaseButton.Name = "releaseButton";
            releaseButton.Text = "RELEASE";
            releaseButton.Font = new Font("Calibri", 12, FontStyle.Bold);
            releaseButton.BackColor = Color.Goldenrod;
            releaseButton.ForeColor = Color.White;
            releaseButton.FlatStyle = FlatStyle.Flat;
            releaseButton.FlatAppearance.BorderSize = 0;
            releaseButton.Width = 85;
            releaseButton.Height = 31;
            releaseButton.Location = new System.Drawing.Point(679, 6);
            releaseButton.Click += delegate (object obj, EventArgs ea)
            {
                handleRelease(folderName + "\\" + fileName, false);
                string payload = "{\"type\":\"file_released\",\"payload\":{\"name\":\"" + fileName + "\",\"message\":\"File released\"}}";
                agentStat(payload);
                releaseButton.Visible = false;
                panel.Dispose();

                string hashFileName = folderName.Replace("\\", "-").Replace(":", "") + fileName + "-hash.json";
                string responseString = "released";
                File.WriteAllText(@"./malcore/threat/" + hashFileName, responseString);
            };
            // if (HasWritePermission(folderName + "\\" + fileName))
            // {
            //     releaseButton.Visible = false;
            // }

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
                fileLabel.Text = fileName;
                fileLabel.ForeColor = Color.White;
            }
            else
            {
                fileLabel.Text = "[FAILED] " + fileName;
                fileLabel.ForeColor = Color.Yellow;
                colorPanel.BackColor = Color.Yellow;
                panel.BackColor = Color.DarkRed;
            }

            panel.Controls.Add(colorPanel);
            panel.Controls.Add(fileLabel);
            panel.Controls.Add(folderLabel);
            panel.Controls.Add(percentLabel);
            panel.Controls.Add(rerunButton);
            if (success)
            {
                // panel.Controls.Add(percentLabel);
                rerunButton.Visible = false;
                if (score_num > this.minThreatScore)
                {
                    panel.Controls.Add(removeButton);
                    panel.Controls.Add(releaseButton);
                }
                else
                {
                    handleRelease(folderName + "\\" + fileName, false);
                }
            }
            else
            {
                // panel.Controls.Add(rerunButton);
                percentLabel.Visible = false;
                panel.Controls.Add(removeButton);
                panel.Controls.Add(releaseButton);
            }

            monitoringFlowLayoutPanel.Controls.Add(panel);
        }


        /**
        * @Description: recall api/threatscore or api/docfile api and update UI accordingly
        * @param folderName: full path of the target file excluding it's name 
        * @param fileName: target file name
        * @param panel: color panel object
        * @param isThreat:  true if api/threatscore or false if api/docfile
        * @return void
        **/
        public async void rerunScanFile(string folderName, string fileName, Panel panel, bool isThreat)
        {
            try
            {
                Button rerunButton = (Button)panel.Controls.Find("rerunButton", true)[0];
                rerunButton.Visible = false;

                Label percentLabel = (Label)panel.Controls.Find("percentLabel", true)[0];
                percentLabel.Visible = true;
                percentLabel.Font = new Font("Calibri", 11, FontStyle.Regular);
                percentLabel.Location = new System.Drawing.Point(508, 14);
                percentLabel.ForeColor = Color.White;
                percentLabel.Text = "Scanning...";

                string path = folderName + "\\" + fileName;
                string hashFileName = folderName.Replace("\\", "-").Replace(":", "") + fileName + "-hash.json";

                string responseString = "";
                // save to hash file
                if (isThreat == true)
                {
                    responseString = await getThreatScore(path, fileName, "threatscore");
                    File.WriteAllText(@"./malcore/threat/" + hashFileName, responseString);

                    Label fileLabel = (Label)panel.Controls.Find("fileLabel", true)[0];
                    fileLabel.Click += delegate (object obj, EventArgs ea)
                    {
                        DetailsForm detailsForm = new DetailsForm("threat", responseString, folderName, fileName, this, panel);
                        detailsForm.Show(this);
                    };
                    Label folderLabel = (Label)panel.Controls.Find("folderLabel", true)[0];
                    folderLabel.Click += delegate (object obj, EventArgs ea)
                    {
                        DetailsForm detailsForm = new DetailsForm("threat", responseString, folderName, fileName, this, panel);
                        detailsForm.Show(this);
                    };
                }
                else
                {
                    responseString = await getThreatScore(path, fileName, "docfile");
                    File.WriteAllText(@"./malcore/doc/" + hashFileName, responseString);

                    Label fileLabel = (Label)panel.Controls.Find("fileLabel", true)[0];
                    fileLabel.Click += delegate (object obj, EventArgs ea)
                    {
                        DetailsForm detailsForm = new DetailsForm("doc", responseString, folderName, fileName, this, panel);
                        detailsForm.Show(this);
                    };
                    Label folderLabel = (Label)panel.Controls.Find("folderLabel", true)[0];
                    folderLabel.Click += delegate (object obj, EventArgs ea)
                    {
                        DetailsForm detailsForm = new DetailsForm("doc", responseString, folderName, fileName, this, panel);
                        detailsForm.Show(this);
                    };
                }

                bool success = true;

                if (responseString == "")
                {
                    // Button rerunButton = (Button)panel.Controls.Find("rerunButton", true)[0];
                    // rerunButton.Visible = true;
                    success = false;
                }
                else
                {
                    string score = "";
                    double score_num = 0;
                    JObject jsonObject = JObject.Parse(responseString);

                    success = (bool)jsonObject["success"];
                    if (jsonObject["data"]["data"].ToString() == "{}")
                    {
                        success = false;
                    }

                    if (success)
                    {
                        panel.BackColor = Color.Black;
                        if (isThreat == true)
                        {
                            score = (string)jsonObject["data"]["data"]["score"];
                            string[] scores = score.Split('/');
                            score_num = Convert.ToDouble(scores[0]);
                            score = Convert.ToString(Math.Round(score_num)) + "%";
                        }
                        else
                        {
                            score = (string)jsonObject["data"]["data"]["dfi"]["results"]["dfi_results"]["score"];
                            score_num = Convert.ToDouble(score);
                            score = Convert.ToString(Math.Round(score_num)) + "%";
                        }

                        Panel colorPanel = (Panel)panel.Controls.Find("colorPanel", true)[0];
                        Label fileLabel = (Label)panel.Controls.Find("fileLabel", true)[0];

                        percentLabel.Text = score;
                        percentLabel.Font = new Font("Calibri", 20, FontStyle.Bold);
                        percentLabel.Location = new System.Drawing.Point(512, 4);

                        fileLabel.Text = fileName;
                        fileLabel.ForeColor = Color.White;
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

                        if (score_num <= this.minThreatScore)
                        {
                            handleRelease(path, false);
                        }

                    }

                }

                if (success == false)
                {
                    percentLabel.Visible = false;
                    rerunButton.Visible = true;
                    panel.BackColor = Color.DarkRed;
                }
            }
            catch (Exception ex)
            {
                // Write out any exceptions.
                Debug.WriteLine("rerunScanFile.........................." + ex);
                Button rerunButton = (Button)panel.Controls.Find("rerunButton", true)[0];
                rerunButton.Visible = true;

                Label percentLabel = (Label)panel.Controls.Find("percentLabel", true)[0];
                percentLabel.Visible = false;
                percentLabel.Font = new Font("Calibri", 20, FontStyle.Bold);
                percentLabel.Location = new System.Drawing.Point(512, 4);
                panel.BackColor = Color.DarkRed;
            }

        }


        /**
        * @Description: add doc files report to monitoring panel
        * @param responseString: json string of api/threatscore or api/docfile api
        * @param folderName: full path of the target file excluding it's name 
        * @param fileName: target file name
        * @param succeed:  api result
        * @return void
        **/
        private void addItemToMonitoringPanelForDoc(string responseString, string folderName, string fileName, bool succeed)
        {
            bool success = false;
            string score = "";
            double score_num = 0;

            if (succeed == true)
            {
                JObject jsonObject = JObject.Parse(responseString);

                success = (bool)jsonObject["success"];
                if (jsonObject["data"]["data"].ToString() == "{}")
                {
                    success = false;
                }

                if (success)
                {
                    score = (string)jsonObject["data"]["data"]["dfi"]["results"]["dfi_results"]["score"];
                    score_num = Convert.ToDouble(score);
                    score = Convert.ToString(Math.Round(score_num)) + "%";
                }
            }

            // item panel
            Panel panel = new Panel();
            panel.Width = 770;
            panel.Height = 44;
            panel.BackColor = Color.Black;

            // color panel
            Panel colorPanel = new Panel();
            colorPanel.Name = "colorPanel";
            colorPanel.Width = 20;
            colorPanel.Height = 44;
            // colorPanel.BackColor = Color.Red;

            // file label
            Label fileLabel = new Label();
            fileLabel.Name = "fileLabel";
            fileLabel.Font = new Font("Calibri", 12, FontStyle.Bold);
            fileLabel.AutoSize = false;
            fileLabel.Width = 400;
            fileLabel.Location = new System.Drawing.Point(22, 1);
            fileLabel.Click += delegate (object obj, EventArgs ea)
            {
                DetailsForm detailsForm = new DetailsForm("doc", responseString, folderName, fileName, this, panel);
                detailsForm.Show(this);
            };

            // folder label
            Label folderLabel = new Label();
            folderLabel.Name = "folderLabel";
            folderLabel.Text = folderName;
            folderLabel.ForeColor = Color.White;
            folderLabel.Font = new Font("Calibri", 11, FontStyle.Regular);
            folderLabel.AutoSize = false;
            folderLabel.Width = 400;
            // folderLabel.MaximumSize = new System.Drawing.Size(200, 0);
            folderLabel.Location = new System.Drawing.Point(24, 22);
            folderLabel.Click += delegate (object obj, EventArgs ea)
            {
                DetailsForm detailsForm = new DetailsForm("doc", responseString, folderName, fileName, this, panel);
                detailsForm.Show(this);
            };

            // percent label
            Label percentLabel = new Label();
            percentLabel.Name = "percentLabel";
            percentLabel.Text = score;
            // percentLabel.ForeColor = Color.Red;
            percentLabel.Font = new Font("Calibri", 20, FontStyle.Bold);
            percentLabel.Width = 76;
            percentLabel.Height = 40;
            percentLabel.Location = new System.Drawing.Point(512, 4);

            Button removeButton = new Button();
            removeButton.Name = "removeButton";
            removeButton.Text = "DELETE";
            removeButton.Font = new Font("Calibri", 12, FontStyle.Bold);
            removeButton.BackColor = Color.Red;
            removeButton.ForeColor = Color.White;
            removeButton.FlatStyle = FlatStyle.Flat;
            removeButton.FlatAppearance.BorderSize = 0;
            removeButton.Width = 85;
            removeButton.Height = 31;
            removeButton.Location = new System.Drawing.Point(590, 6);
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
                    panel.Dispose();

                    string payload = "{\"type\":\"file_deleted\",\"payload\":{\"name\":\"" + fileName + "\",\"type\":\"docfile\",\"message\":\"File deleted\"}}";
                    agentStat(payload);
                }
                else if (dialogResult == DialogResult.No)
                {
                    //do something else
                }

            };

            Button rerunButton = new Button();
            rerunButton.Name = "rerunButton";
            rerunButton.Text = "RERUN";
            rerunButton.Font = new Font("Calibri", 12, FontStyle.Bold);
            rerunButton.BackColor = Color.Yellow;
            rerunButton.ForeColor = Color.Black;
            rerunButton.FlatStyle = FlatStyle.Flat;
            rerunButton.FlatAppearance.BorderSize = 0;
            rerunButton.Width = 70;
            rerunButton.Height = 31;
            rerunButton.Location = new System.Drawing.Point(515, 6);
            rerunButton.Click += delegate (object obj, EventArgs ea)
            {
                rerunButton.Visible = false;
                rerunScanFile(folderName, fileName, panel, false);

                string payload = "{\"type\":\"file_reran\",\"payload\":{\"name\":\"" + fileName + "\",\"type\":\"docfile\",\"message\":\"File reran\"}}";
                agentStat(payload);
            };

            Button releaseButton = new Button();
            releaseButton.Name = "releaseButton";
            releaseButton.Text = "RELEASE";
            releaseButton.Font = new Font("Calibri", 12, FontStyle.Bold);
            releaseButton.BackColor = Color.Goldenrod;
            releaseButton.ForeColor = Color.White;
            releaseButton.FlatStyle = FlatStyle.Flat;
            releaseButton.FlatAppearance.BorderSize = 0;
            releaseButton.Width = 85;
            releaseButton.Height = 31;
            releaseButton.Location = new System.Drawing.Point(679, 6);
            releaseButton.Click += delegate (object obj, EventArgs ea)
            {
                handleRelease(folderName + "\\" + fileName, false);
                string payload = "{\"type\":\"file_released\",\"payload\":{\"name\":\"" + fileName + "\",\"message\":\"File released\"}}";
                agentStat(payload);
                releaseButton.Visible = false;
                panel.Dispose();

                string hashFileName = folderName.Replace("\\", "-").Replace(":", "") + fileName + "-hash.json";
                string responseString = "released";
                File.WriteAllText(@"./malcore/doc/" + hashFileName, responseString);
            };
            // if (HasWritePermission(folderName + "\\" + fileName))
            // {
            //     releaseButton.Visible = false;
            // }

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
                fileLabel.Text = fileName;
                fileLabel.ForeColor = Color.White;
            }
            else
            {
                fileLabel.Text = "[FAILED] " + fileName;
                fileLabel.ForeColor = Color.Yellow;
                colorPanel.BackColor = Color.Yellow;
                panel.BackColor = Color.DarkRed;
            }

            panel.Controls.Add(colorPanel);
            panel.Controls.Add(fileLabel);
            panel.Controls.Add(folderLabel);
            panel.Controls.Add(percentLabel);
            panel.Controls.Add(rerunButton);
            if (success)
            {
                rerunButton.Visible = false;
                if (score_num > this.minThreatScore)
                {
                    panel.Controls.Add(removeButton);
                    panel.Controls.Add(releaseButton);
                }
                else
                {
                    handleRelease(folderName + "\\" + fileName, false);
                }
            }
            else
            {
                percentLabel.Visible = false;
                panel.Controls.Add(removeButton);
                panel.Controls.Add(releaseButton);
            }

            monitoringFlowLayoutPanel.Controls.Add(panel);
        }


        /**
        * @Description: Scan all sub directories of the target directory and process if it's an end file
        * @param targetDirectory: full path of the target file 
        * @return void
        **/
        public async void ProcessDirectory(string targetDirectory)
        {
            // Process the list of files found in the directory.
            string[] fileEntries = Directory.GetFiles(targetDirectory);
            foreach (string fileName in fileEntries)
            {
                bool result = checkFileExtentionIsAllowed(fileName);
                if (result)
                {
                    if (!Program.filePool.Contains(fileName))
                    {
                        Program.filePool.Enqueue(fileName);
                    }
                }
            }

            // Recurse into subdirectories of this directory.
            string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
            foreach (string subdirectory in subdirectoryEntries)
                ProcessDirectory(subdirectory);
        }


        /**
        * @Description: Check if file is already scanned based on cache folder 
        * and update UI or call scan API
        * @param path: full path of the target file  
        * @return void
        **/
        public async Task<bool> ProcessFile(string path)
        {
            try
            {
                string fileName = Path.GetFileName(path);
                string folderName = Directory.GetParent(path) != null ? Directory.GetParent(path).FullName : path;

                string hashFileName = folderName.Replace("\\", "-").Replace(":", "") + fileName + "-hash.json";
                // check if the hash file is already scanned
                if (File.Exists("./malcore/threat/" + hashFileName))
                {
                    string fileString = File.ReadAllText("./malcore/threat/" + hashFileName);
                    bool succeed = true;
                    if (fileString == "released")
                    {
                        return false;
                    }

                    if (fileString == "")
                    {
                        succeed = false;
                    }

                    addItemToMonitoringPanel(fileString, folderName, fileName, succeed);
                }
                else if (File.Exists("./malcore/doc/" + hashFileName))
                {
                    string fileString = File.ReadAllText("./malcore/doc/" + hashFileName);
                    bool succeed = true;
                    if (fileString == "released")
                    {
                        return false;
                    }

                    if (fileString == "")
                    {
                        succeed = false;
                    }
                    addItemToMonitoringPanelForDoc(fileString, folderName, fileName, succeed);
                }
                else
                {
                    handleRelease(path, false);
                    // check if the file is allowed
                    using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                    {
                        using (var reader = new BinaryReader(fs, new ASCIIEncoding()))
                        {
                            FileInfo fInfo = new FileInfo(path);

                            // only allow files their size is smaller than 15M **tempcode**
                            if (fInfo.Length < 15728640)
                            {
                                byte[] buffer = new byte[10];
                                buffer = reader.ReadBytes(10);
                                if (buffer.Length > 9)
                                {
                                    // exe file
                                    if ((buffer[0] == 77 && buffer[1] == 90) || (buffer[0] == 90 && buffer[1] == 77))
                                    {
                                        string responseString = await getThreatScore(path, fileName, "threatscore");

                                        // save to hash file
                                        File.WriteAllText(@"./malcore/threat/" + hashFileName, responseString);

                                        bool succeed = true;
                                        if (responseString == "")
                                        {
                                            succeed = false;
                                        }

                                        // add to mornitoring list 
                                        addItemToMonitoringPanel(responseString, folderName, fileName, succeed);
                                    }
                                    else if ((buffer[0] == 37 && buffer[1] == 80 && buffer[2] == 68 && buffer[3] == 70) ||
                                    (buffer[0] == 80 && buffer[1] == 75) ||
                                    (buffer[0] == 208 && buffer[1] == 207) ||
                                    (buffer[0] == 20 && buffer[1] == 0) ||
                                    (buffer[0] == 29 && buffer[1] == 125) ||
                                    (buffer[0] == 219 && buffer[1] == 165 && buffer[2] == 45 && buffer[3] == 0) ||
                                    (buffer[0] == 13 && buffer[1] == 68 && buffer[2] == 79 && buffer[3] == 67) ||
                                    (buffer[0] == 123 && buffer[1] == 114 && buffer[2] == 116 && buffer[3] == 102) ||
                                    (buffer[0] == 123 && buffer[1] == 92 && buffer[2] == 114 && buffer[3] == 116 && buffer[4] == 102) ||
                                    (buffer[0] == 123 && buffer[1] == 92 && buffer[2] == 123 && buffer[3] == 92 && buffer[4] == 114 && buffer[5] == 116 && buffer[6] == 102) ||
                                    (buffer[0] == 80 && buffer[1] == 75 && buffer[2] == 3 && buffer[3] == 4 && buffer[4] == 20 && buffer[5] == 0 && buffer[6] == 6 && buffer[7] == 0) ||
                                    (buffer[0] == 228 && buffer[1] == 82 && buffer[2] == 92 && buffer[3] == 123 && buffer[4] == 140 && buffer[5] == 216 && buffer[6] == 167 && buffer[7] == 77 && buffer[8] == 174 && buffer[9] == 177))
                                    {
                                        string responseString = await getThreatScore(path, fileName, "docfile");

                                        // save to hash file
                                        File.WriteAllText(@"./malcore/doc/" + hashFileName, responseString);

                                        bool succeed = true;
                                        if (responseString == "")
                                        {
                                            succeed = false;
                                        }
                                        addItemToMonitoringPanelForDoc(responseString, folderName, fileName, succeed);
                                    }
                                }
                            }
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Process File failed----------------" + path + "-----------" + ex);
                return false;
            }
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
                fSecurity.AddAccessRule(new FileSystemAccessRule(@"SYSTEM", FileSystemRights.ReadAndExecute, AccessControlType.Deny));
                fInfo.SetAccessControl(fSecurity);
            }
            else
            {
                fSecurity.RemoveAccessRule(new FileSystemAccessRule(userName, FileSystemRights.ReadAndExecute, AccessControlType.Deny));
                fSecurity.RemoveAccessRule(new FileSystemAccessRule(@"SYSTEM", FileSystemRights.ReadAndExecute, AccessControlType.Deny));
                fInfo.SetAccessControl(fSecurity);
            }
        }


        private bool HasWritePermission(string FilePath)
        {
            try
            {
                FileInfo fInfo = new FileInfo(FilePath);
                FileSecurity security = fInfo.GetAccessControl();

                var rules = security.GetAccessRules(true, true, typeof(NTAccount));

                var currentuser = new WindowsPrincipal(WindowsIdentity.GetCurrent());
                bool result = false;
                foreach (FileSystemAccessRule rule in rules)
                {
                    if (rule.AccessControlType == AccessControlType.Deny)
                        return false;
                    if (rule.AccessControlType == AccessControlType.Allow)
                    {
                        result = true;
                        return result;
                    }
                }
                return result;
            }
            catch
            {
                return false;
            }
        }

        /**
        * @Description: Check if file extention is in the allowed list
        * @param path: full path of the target file  
        * @return true if available, false if not allowed
        **/
        private bool checkFileExtentionIsAllowed(string path)
        {
            handleRelease(path, false);

            // check if the file is allowed
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                using (var reader = new BinaryReader(fs, new ASCIIEncoding()))
                {
                    FileInfo fInfo = new FileInfo(path);

                    // only allow files their size is smaller than 15M **tempcode**
                    if (fInfo.Length < 15728640)
                    {
                        byte[] buffer = new byte[10];
                        buffer = reader.ReadBytes(10);
                        if (buffer.Length > 9)
                        {
                            // exe file
                            if ((buffer[0] == 77 && buffer[1] == 90) || (buffer[0] == 90 && buffer[1] == 77))
                            {
                                return true;
                            }
                            else if ((buffer[0] == 37 && buffer[1] == 80 && buffer[2] == 68 && buffer[3] == 70) ||
                                    (buffer[0] == 80 && buffer[1] == 75) ||
                                    (buffer[0] == 208 && buffer[1] == 207) ||
                                    (buffer[0] == 20 && buffer[1] == 0) ||
                                    (buffer[0] == 29 && buffer[1] == 125) ||
                                    (buffer[0] == 219 && buffer[1] == 165 && buffer[2] == 45 && buffer[3] == 0) ||
                                    (buffer[0] == 13 && buffer[1] == 68 && buffer[2] == 79 && buffer[3] == 67) ||
                                    (buffer[0] == 123 && buffer[1] == 114 && buffer[2] == 116 && buffer[3] == 102) ||
                                    (buffer[0] == 123 && buffer[1] == 92 && buffer[2] == 114 && buffer[3] == 116 && buffer[4] == 102) ||
                                    (buffer[0] == 123 && buffer[1] == 92 && buffer[2] == 123 && buffer[3] == 92 && buffer[4] == 114 && buffer[5] == 116 && buffer[6] == 102) ||
                                    (buffer[0] == 80 && buffer[1] == 75 && buffer[2] == 3 && buffer[3] == 4 && buffer[4] == 20 && buffer[5] == 0 && buffer[6] == 6 && buffer[7] == 0) ||
                                    (buffer[0] == 228 && buffer[1] == 82 && buffer[2] == 92 && buffer[3] == 123 && buffer[4] == 140 && buffer[5] == 216 && buffer[6] == 167 && buffer[7] == 77 && buffer[8] == 174 && buffer[9] == 177))
                            {
                                return true;
                            }
                        }
                    }
                    return false;
                }
            }
        }


        /**
        * @Description: Start monitoring file change and add to the Queue
        * @return void
        **/
        public void InitTimer()
        {
            monitorTimer = new System.Windows.Forms.Timer();
            monitorTimer.Tick += new EventHandler(detectFileChange);
            monitorTimer.Interval = 3000; // in miliseconds
            monitorTimer.Start();
        }
        private void detectFileChange(object sender, EventArgs e)
        {
            handleMonitoring();
        }

        /**
        * @Description: handle logout
        **/
        private void btnLogout_Click_1(object sender, EventArgs e)
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

        /**
        * @Description: show settings form
        **/
        private void btnSettings_Click_1(object sender, EventArgs e)
        {
            Hide();
            SettingsForm settingsForm = new SettingsForm();
            settingsForm.Show(this);
        }

        /**
        * @Description: watch target folder and process a file if there is any file created new
        **/
        private void fileSystemWatcherMain_Created_1(object sender, FileSystemEventArgs e)
        {
            if (File.Exists(e.FullPath))
            {
                // ProcessFile(e.FullPath);
                if (!Program.filePool.Contains(e.FullPath))
                {
                    Program.filePool.Enqueue(e.FullPath);
                }
            }
        }

        private void fileSystemWatcherMain_Changed(object sender, FileSystemEventArgs e)
        {
        }

        /**
        * @Description: move app to windows icon tray
        **/
        private void MonitoringForm_Resize(object sender, EventArgs e)
        {
            //if the form is minimized  
            //hide it from the task bar  
            //and show the system tray icon (represented by the NotifyIcon control)  
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon1.Visible = true;
                // this is for notification
                // notifyIcon1.ShowBalloonTip(500);
            }
        }

        /**
        * @Description: show app from windows icon tray when double click it in icon tray
        **/
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
        } 

        /**
        * @Description: move app to windows icon tray when click Close button
        **/
        private void MonitoringForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.closing == false)
            {
                e.Cancel = true;
                Hide();
                notifyIcon1.Visible = true;
            }
        }

        /**
        * @Description: exit application 
        **/
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.closing = true;
            notifyIcon1.Visible = false;
            notifyIcon1.Dispose();
            Application.Exit();
        }

        /**
        * @Description: View Queue. If QueueForm is already opened, close it and open new one
        **/
        private void btnViewQueue_Click(object sender, EventArgs e)
        {
            FormCollection fc = Application.OpenForms;
            foreach (Form frm in fc)
            {
                if (frm.Name == "QueueForm")
                {
                    frm.Close();
                    break;
                }
            }

            QueueForm queueForm = new QueueForm();
            queueForm.Show(this);
        }
    } 
}