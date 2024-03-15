using System.Diagnostics;
using System.Text;
using Microsoft.Win32;
using Newtonsoft.Json.Linq;
using System.Security.AccessControl;
using System.Security.Principal;
using System;
using System.IO;
using MCDA_APP.Controls;
using System.Text.Json.Nodes;
// using System.ComponentModel;

namespace MCDA_APP.Forms
{
    public partial class MonitoringForm : Form
    {
        double minThreatScore = 15.0;
        bool sendStatistics = true;
        List<string> paths = new List<string>();

        bool closing = false;
        int screenWidth = 820;

        // Increased the queue to hold 10 files at once
        int queueHoldSize = 10;
        int numberOfProcessing = 0;
        private System.Windows.Forms.Timer monitorTimer;

        public MonitoringForm()
        {
            InitializeComponent();

            this.screenWidth = this.Size.Width;
            labelEmail.Text = Program.USEREMAIL;
            labelPlan.Text = Program.SUBSCRIPTION;

            // Create directories for caching
            // there was a problem for the installer. installer did not recognize the relative path
            Helper.CreateFolders();

            ShowAllScannedDragFiles();
            StartMonitoring();
        }

        /**
        * @Description: process the files in the queue. 
        * This function runs when there are files in the queue and stops when the file queue is empty.
        * Call threat API if currently running processes are less than 10 
        * Otherwise, wait until the number of currently running processes is less than 10.
        * @return void.
        **/
        private async Task ProcessHoldQueue()
        {
            try
            {
                if (this.numberOfProcessing > this.queueHoldSize)
                {
                    await Task.Delay(300);
                    await ProcessHoldQueue();
                }
                else
                {
                    if (Program.FilePool.Count > 0)
                    {
                        this.numberOfProcessing++;
                        ProcessFile(Program.FilePool.Dequeue());
                    }
                    else
                    {
                        queuePanel.Visible = false;
                    }
                    return;
                }
            }
            catch (Exception ex)
            {
                return;
            }
        }
        /**
                * @Description: Start monitoring and update monitoring form with result
                * @Description: This function works only one time when the app starts
                * @return void.
                **/
        public void RemoveAllScanedFiles()
        {
            try
            {
                monitoringFlowLayoutPanel.Controls.Clear();
            }
            catch (Exception ex)
            {
                // Write out any exceptions.
                Debug.Write(ex);
            }
        }


        /**
        * @Description: Start monitoring and update monitoring form with result
        * @Description: This function works only one time when the app starts
        * @return void.
        **/
        public async void StartMonitoring()
        {
            queuePanel.Visible = false;
            queuePanel.Width = this.screenWidth - 30;
            btnViewQueue.Location = new System.Drawing.Point(this.screenWidth - 210, 6);
            labelRemaining.Location = new System.Drawing.Point(this.screenWidth - 248, 78); // 680

            monitoringFlowLayoutPanel.Width = this.screenWidth;

            InitFilePool();

            this.Visible = true;

            try
            {
                // Check if active or inactive based on usuage
                bool active = await AgentUsuage();

                if (active)
                {
                    panelInactive.Visible = false;
                    monitoringFlowLayoutPanel.Visible = true;
                    labelRemaining.Visible = true;
                    lblRequestNumber.Visible = true;
                    lblRequestNumber.Location = new System.Drawing.Point(this.screenWidth - 80, 79); // 680

                    lblStatus.Text = "ACTIVE";
                    lblStatus.ForeColor = Color.Green;

                    RegistryKey? key = Registry.CurrentUser.OpenSubKey(Constants.RegistryMalcoreKey);
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
                                while (Program.FilePool.Count > 0)
                                {
                                    await ProcessHoldQueue();
                                }
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
                Debug.Write(ex);
            }
        }

        /**
        * @Description: monitoring file changes in the target directory
        * Update Queue status and UI
        * @return void.
        **/
        private async void HandleMonitoring()
        {

            try
            {
                // Check if active or inactive based on usuage
                bool active = await AgentUsuage();

                if (active)
                {
                    panelInactive.Visible = false;
                    monitoringFlowLayoutPanel.Visible = true;
                    labelRemaining.Visible = true;
                    lblRequestNumber.Visible = true;
                    lblRequestNumber.Location = new System.Drawing.Point(this.screenWidth - 80, 79); // 680

                    lblStatus.Text = "ACTIVE";
                    lblStatus.ForeColor = Color.Green;

                    RegistryKey? key = Registry.CurrentUser.OpenSubKey(Constants.RegistryMalcoreKey);
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
                                while (Program.FilePool.Count > 0)
                                {
                                    await ProcessHoldQueue();
                                }
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
                Debug.Write(ex);
            }
        }


        /**
        * @Description: Scan files and add them to the pool
        * @return void.
        **/
        private bool InitFilePool()
        {
            try
            {
                Program.FilePool.Clear();

                RegistryKey? key = Registry.CurrentUser.OpenSubKey(Constants.RegistryMalcoreKey);
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

                            paths = settings_paths.Split(',').ToList();
                            int num = 0;

                            // add all files to the FilePool from settings
                            foreach (string path in paths)
                            {
                                if (File.Exists(path))
                                {
                                    bool result = CheckFileExtentionIsAllowed(path);
                                    if (result)
                                    {
                                        if (!Program.FilePool.Contains(path) && !Program.PrecessedFilePool.Contains(path))
                                        {
                                            Program.FilePool.Enqueue(path);
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
                Debug.Write(ex);
                return false;
            }
        }


        /**
        * @Description: add files to the FilePool from malcore json dump folders
        * @Description: this feature is new added for drag and drop
        * @return void.
        **/
        private bool ShowAllScannedDragFiles()
        {
            try
            {
                RegistryKey? key = Registry.CurrentUser.OpenSubKey(Constants.RegistryMalcoreKey);
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
                            string threatDirectory = @"./malcore/threat/drag/";
                            string[] threatFileEntries = Directory.GetFiles(threatDirectory);
                            foreach (string fname in threatFileEntries)
                            {
                                string fileString = File.ReadAllText(fname);
                                // Debug.Write("fileString##########" + fileString);

                                bool succeed = true;
                                if (fileString != "released" && fileString != "")
                                {

                                    JObject jsonData = JObject.Parse(fileString);
                                    string folderName = jsonData["folderName"].ToString();
                                    string fileName = jsonData["fileName"].ToString();


                                    Debug.Write("folderName##########" + folderName);
                                    Debug.Write("fileName##########" + fileName);

                                    AddItemToMonitoringPanel(fileString, folderName, fileName, succeed);
                                }
                            }
                            string docDirectory = @"./malcore/doc/drag/";
                            string[] docFileEntries = Directory.GetFiles(docDirectory);
                            foreach (string fname in docFileEntries)
                            {
                                string fileString = File.ReadAllText(fname);

                                bool succeed = true;
                                if (fileString != "released" && fileString != "")
                                {

                                    JObject jsonData = JObject.Parse(fileString);
                                    string folderName = jsonData["folderName"].ToString();
                                    string fileName = jsonData["fileName"].ToString();

                                    AddItemToMonitoringPanelForDoc(fileString, folderName, fileName, succeed);
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
                Debug.Write(ex);
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
        private async Task<string> GetThreatScore(string pathFile, string fileName, string type)
        {
            // NotifyPropertyChanged("filePool"); 
            try
            {
                if (Program.FilePool.Count > 0)
                {
                    queuePanel.Visible = true;
                    labelQueuedFiles.Text = Program.FilePool.Count.ToString() + " files were queued for processing";
                }
                else
                {
                    queuePanel.Visible = false;
                }

                string payload = "{\"type\":\"file_submitted\",\"payload\":{\"name\":\"" + fileName + "\",\"type\":\"" + type + "\",\"message\":\"File submitted\"}}";
                await AgentStat(payload);

                HandleRelease(pathFile, false);
                string url = System.Configuration.ConfigurationManager.AppSettings["URI"] + "/api/" + type;

                using (var client = new HttpClient())
                {
                    using (var content = new MultipartFormDataContent())
                    {
                        byte[] fileData = File.ReadAllBytes(pathFile);
                        content.Add(new StreamContent(new MemoryStream(fileData)), "filename1", fileName);
                        content.Headers.Add("apiKey", Program.APIKEY);
                        content.Headers.Add("source", "agent");

                        Debug.Write("getThreatScore#####################" + fileName);

                        using (
                           var response = await client.PostAsync(url, content))
                        {
                            HandleRelease(pathFile, true); 

                            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                            {
                                string responseString = await response.Content.ReadAsStringAsync();
                                this.numberOfProcessing--; 

                                return responseString;
                            }
                            else
                            {
                                string payload2 = "{\"type\":\"file_failed\",\"payload\":{\"name\":\"" + fileName + "\",\"type\":\"" + type + "\",\"response\":\"api_error\",\"message\":\"API Error\"}}";
                                await AgentStat(payload2);
                                this.numberOfProcessing--;
 
                                return "";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.Write("getThreatScore ERROR#####################" + ex);
                this.numberOfProcessing--; 
                HandleRelease(pathFile, false);

                string payload = "{\"type\":\"file_failed\",\"payload\":{\"name\":\"" + fileName + "\",\"type\":\"" + type + "\",\"response\":\"timeout/api_error/other_error\",\"message\":\"API Error/Timeout/Other\"}}";
                await AgentStat(payload);
                return "";
            }
        }


        /**
        * @Description: Call agent/stat for log on the server
        * @param jsonData: json string for request data of the api 
        * @return api response as string.
        **/
        private async Task<string> AgentStat(string jsonData)
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
                    client.DefaultRequestHeaders.Add("agentVersion", "1.2");

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
                Debug.Write(ex);
                return "";
            }
        }


        /**
        * @Description: Call agent/usage API
        * @return true if remaining > 0, else false
        **/
        private async Task<bool> AgentUsuage()
        {
            try
            {
                string url = System.Configuration.ConfigurationManager.AppSettings["URI"] + "/agent/usage";

                using (var client = new HttpClient())
                {

                    var requestContent = new StringContent("", Encoding.Unicode, "application/json");
                    client.DefaultRequestHeaders.Add("apiKey", Program.APIKEY);
                    client.DefaultRequestHeaders.Add("source", "agent");
                    client.DefaultRequestHeaders.Add("agentVersion", "1.2");

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
                                lblRequestNumber.Text = "N/A";
                                return false;
                            }
                        }
                        else
                        {
                            lblRequestNumber.Text = "N/A";
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Write out any exceptions. 
                Debug.Write(ex);
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
        private void AddItemToMonitoringPanel(string responseString, string folderName, string fileName, bool succeed)
        {
            try
            {
                bool success = false;
                string score = "";
                double score_num = 0;
                string scan_result = "";
                string message = "";
                string scan_id = "";

                if (succeed == true)
                {
                    JObject jsonObject = JObject.Parse(responseString);

                    success = (bool)jsonObject["success"];
                    // if (jsonObject["data"]["data"].ToString() == "{}")
                    if (bool.Parse((string)jsonObject["success"]) == false || jsonObject["data"] == null || (jsonObject["data"] != null && jsonObject["data"]["data"].ToString() == "{}"))
                    {
                        success = false;
                    }

                    if (success)
                    {
                        // success = (bool)jsonObject["data"]?["success"];
                        // if (success && jsonObject["data"]?["data"]?["score"] != null)
                        // {
                        //     score = (string)jsonObject["data"]["data"]["score"];
                        //     string[] scores = score.Split('/');
                        //     score_num = Convert.ToDouble(scores[0]);
                        //     // score = Convert.ToString(Math.Round(score_num)) + "%";
                        //     score = scores[0] + "%";
                        // }
                        if (jsonObject["data"]?["data"]?["threat_score"]?["results"]?["score"] != null)
                        {
                            score = (string)jsonObject["data"]?["data"]?["threat_score"]?["results"]?["score"];
                            string[] scores = score.Split('/');
                            score_num = Convert.ToDouble(scores[0]);
                            score = scores[0] + "%";
                        }
                        if (jsonObject["data"]?["data"]?["scan_id"] != null)
                        {
                            scan_id = (string)jsonObject["data"]["data"]["scan_id"]; 
                        }

                        if((string)jsonObject["data"]?["data"]?["handler_type"] == "error") {
                            success = false;
                        }
                    }


                    if (success && jsonObject["data"] is JObject data && data["messages"] is JArray messages && messages.Count > 0)
                    {
                        message = messages[0]["message"].Value<string>();
                    }
                    if (success && jsonObject["data"]?["data"]?["status"] != null)
                    {
                        scan_result = (string)jsonObject["data"]?["data"]?["status"];
                    }
                }

                Debug.Write("score_num######################" + score_num + success);

                // item panel
                Panel panel = new Panel();
                panel.Width = this.Size.Width - 30;
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
                fileLabel.Cursor = Cursors.Hand;
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
                folderLabel.Cursor = Cursors.Hand;
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
                percentLabel.Font = new Font("Calibri", 16, FontStyle.Bold);
                // percentLabel.Width = 76;
                percentLabel.Width = 110;
                percentLabel.Height = 40;
                // percentLabel.Location = new System.Drawing.Point(this.screenWidth - 288, 4);  // 512
                percentLabel.Location = new System.Drawing.Point(this.screenWidth - 320, 0);
                percentLabel.TextAlign = ContentAlignment.MiddleRight;

                Button removeButton = new Button();
                // Button removeButton = new Button();
                removeButton.Name = "removeButton";
                removeButton.Text = "DELETE";
                removeButton.Font = new Font("Calibri", 12, FontStyle.Bold);
                removeButton.BackColor = Color.Red;
                removeButton.ForeColor = Color.White;
                removeButton.FlatStyle = FlatStyle.Flat;
                removeButton.FlatAppearance.BorderSize = 0;
                removeButton.Width = 85;
                removeButton.Height = 31;
                removeButton.Cursor = Cursors.Hand;
                removeButton.Location = new System.Drawing.Point(this.screenWidth - 210, 6); // 590
                removeButton.Click += delegate (object obj, EventArgs ea)
                {
                    DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this file?", "DELETE", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        if (File.Exists(folderName + "\\" + fileName))
                        {
                            HandleRelease(folderName + "\\" + fileName, false);
                            File.Delete(folderName + "\\" + fileName);
                        }
                        string hashFileName = folderName.Replace("\\", "-").Replace(":", "") + fileName + "-hash.json";
                        if (File.Exists("./malcore/threat/" + hashFileName))
                        {
                            File.Delete("./malcore/threat/" + hashFileName);
                        }
                        if (File.Exists("./malcore/threat/drag/" + hashFileName))
                        {
                            File.Delete("./malcore/threat/drag/" + hashFileName);
                        }
                        panel.Dispose();

                        string payload = "{\"type\":\"file_deleted\",\"payload\":{\"name\":\"" + fileName + "\",\"type\":\"threatscore\",\"message\":\"File deleted\"}}";
                        AgentStat(payload);
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
                rerunButton.Width = 80;
                rerunButton.Height = 31;
                rerunButton.Cursor = Cursors.Hand;
                rerunButton.Location = new System.Drawing.Point(this.screenWidth - 295, 6);  // 515
                rerunButton.Click += delegate (object obj, EventArgs ea)
                {
                    rerunButton.Visible = false;
                    RerunScanFile(folderName, fileName, panel, true);

                    string payload = "{\"type\":\"file_reran\",\"payload\":{\"name\":\"" + fileName + "\",\"type\":\"threatscore\",\"message\":\"File reran\"}}";
                    AgentStat(payload);
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
                releaseButton.Cursor = Cursors.Hand;
                releaseButton.Location = new System.Drawing.Point(this.screenWidth - 121, 6);
                releaseButton.Click += delegate (object obj, EventArgs ea)
                {
                    HandleRelease(folderName + "\\" + fileName, false);
                    string payload = "{\"type\":\"file_released\",\"payload\":{\"name\":\"" + fileName + "\",\"message\":\"File released\"}}";
                    AgentStat(payload);
                    releaseButton.Visible = false;
                    panel.Dispose();

                    string hashFileName = folderName.Replace("\\", "-").Replace(":", "") + fileName + "-hash.json";
                    string responseString = "released";
                    if(File.Exists(@"./malcore/threat/" + hashFileName)) {
                        File.WriteAllText(@"./malcore/threat/" + hashFileName, responseString);
                    } else if(File.Exists(@"./malcore/threat/drag/" + hashFileName)) {
                        File.WriteAllText(@"./malcore/threat/drag/" + hashFileName, responseString);
                    }
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
                    removeButton.Visible = false;
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


                // if scan is not completed
                if (scan_result != "completed")
                {
                    percentLabel.Text = scan_result + "...";
                    percentLabel.Font = new Font("Calibri", 10, FontStyle.Bold);
                    percentLabel.ForeColor = Color.White;
                    colorPanel.BackColor = Color.White;
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
                    removeButton.Visible = true;
                }

                panel.Controls.Add(colorPanel);
                panel.Controls.Add(fileLabel);
                panel.Controls.Add(folderLabel);
                panel.Controls.Add(percentLabel);
                panel.Controls.Add(rerunButton);

                Debug.Write("removeButton========================" + success + "::" + scan_result + "::" + score_num + "::" + this.minThreatScore);
                if (success)
                {
                    // panel.Controls.Add(percentLabel);
                    rerunButton.Visible = false;
                    panel.Controls.Add(releaseButton);

                    if (score_num > this.minThreatScore || (scan_result != "completed" && scan_result != ""))
                    {
                        panel.Controls.Add(removeButton);
                    }
                    else
                    {
                        HandleRelease(folderName + "\\" + fileName, false);
                    }
                }
                else
                {
                    // panel.Controls.Add(rerunButton);
                    percentLabel.Visible = false;
                    panel.Controls.Add(removeButton);
                    panel.Controls.Add(releaseButton);
                }

                if (scan_result != "completed" && scan_id != null && scan_id != "")
                {
                    CheckStatus(panel, scan_id, folderName, fileName, true);
                }

                monitoringFlowLayoutPanel.Controls.Add(panel);
            }
            catch (Exception ex)
            {
                Debug.Write("threat parse ERROR###################");
                Debug.Write(ex);
            }

        }


        /**
        * @Description: recall api/threatscore or api/docfile api and update UI accordingly
        * @param folderName: full path of the target file excluding it's name 
        * @param fileName: target file name
        * @param panel: color panel object
        * @param isThreat:  true if api/threatscore or false if api/docfile
        * @return void
        **/
        public async void RerunScanFile(string folderName, string fileName, Panel panel, bool isThreat)
        {
            try
            {
                Button rerunButton = (Button)panel.Controls.Find("rerunButton", true)[0];
                Button removeButton = (Button)panel.Controls.Find("removeButton", true)[0];
                rerunButton.Visible = false;

                Label percentLabel = (Label)panel.Controls.Find("percentLabel", true)[0];
                percentLabel.Visible = true;
                percentLabel.Font = new Font("Calibri", 11, FontStyle.Regular);
                percentLabel.Location = new System.Drawing.Point(this.screenWidth - 292, 14);
                percentLabel.ForeColor = Color.White;
                percentLabel.Text = "Scanning...";
                percentLabel.TextAlign = ContentAlignment.TopRight;
                percentLabel.Width = 76;

                string path = folderName + "\\" + fileName;
                string hashFileName = folderName.Replace("\\", "-").Replace(":", "") + fileName + "-hash.json";

                string responseString = "";
                // save to hash file
                if (isThreat == true)
                {
                    responseString = await GetThreatScore(path, fileName, "upload");
                    if (responseString != "")
                    {
                        JObject jsonObject = JObject.Parse(responseString);
                        jsonObject["fileName"] = fileName;
                        jsonObject["folderName"] = folderName;
                        responseString = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObject);
                    }

                    if (Program.DragFilePool.Contains(path))
                    {
                        File.WriteAllText(@"./malcore/threat/drag/" + hashFileName, responseString);
                    }
                    else
                    {
                        File.WriteAllText(@"./malcore/threat/" + hashFileName, responseString);
                    }

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
                    responseString = await GetThreatScore(path, fileName, "docfile");
                    if (responseString != "")
                    {
                        JObject jsonObject = JObject.Parse(responseString);
                        jsonObject["fileName"] = fileName;
                        jsonObject["folderName"] = folderName;
                        responseString = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObject);
                    }

                    if (Program.DragFilePool.Contains(path))
                    {
                        File.WriteAllText(@"./malcore/doc/drag/" + hashFileName, responseString);
                    }
                    else
                    {
                        File.WriteAllText(@"./malcore/doc/" + hashFileName, responseString);
                    }

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

                Debug.Write("rerun###################" + responseString);

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
                    string scan_result = "";
                    string message = "";
                    string scan_id = "";

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
                            if (jsonObject["data"]?["data"]?["score"] != null)
                            {
                                score = (string)jsonObject["data"]["data"]["score"];
                                string[] scores = score.Split('/');
                                score_num = Convert.ToDouble(scores[0]);
                                score = scores[0] + "%";
                            }
                        }
                        else
                        {
                            if (jsonObject["data"]?["data"]?["dfi"]?["results"]?["dfi_results"]?["score"] != null)
                            {
                                score = (string)jsonObject["data"]["data"]["dfi"]["results"]["dfi_results"]["score"];
                                score_num = Convert.ToDouble(score);
                                score = score + "%";
                            }
                        }


                        if (jsonObject["data"]?["data"]?["scan_id"] != null)
                        {
                            scan_id = (string)jsonObject["data"]["data"]["scan_id"]; 
                        }

                        if (jsonObject["data"]?["data"]?["status"] != null)
                        {
                            scan_result = (string)jsonObject["data"]?["data"]?["status"];

                        }
                        if (jsonObject["data"] is JObject data && data["messages"] is JArray messages && messages.Count > 0)
                        {
                            message = messages[0]["message"].Value<string>();
                        }

                        Panel colorPanel = (Panel)panel.Controls.Find("colorPanel", true)[0];
                        Label fileLabel = (Label)panel.Controls.Find("fileLabel", true)[0];

                        percentLabel.Text = score;
                        percentLabel.Font = new Font("Calibri", 16, FontStyle.Bold);
                        percentLabel.Location = new System.Drawing.Point(this.screenWidth - 320, 0); // 512

                        fileLabel.Text = fileName;
                        fileLabel.ForeColor = Color.White;
                        // update colors based on score
                        if (score_num < 20.0)
                        {
                            colorPanel.BackColor = Color.Green;
                            percentLabel.ForeColor = Color.Green;
                            removeButton.Visible = false;
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



                        // if scan is not completed
                        if (scan_result != "completed")
                        {
                            percentLabel.Text = message + "...";
                            percentLabel.Font = new Font("Calibri", 10, FontStyle.Bold);
                            percentLabel.ForeColor = Color.White;
                            colorPanel.BackColor = Color.White;
                        }

                        if (score_num <= this.minThreatScore)
                        {
                            HandleRelease(path, false);
                        }

                    }

                    if (scan_result != "completed" && scan_id != null && scan_id != "")
                    {
                        CheckStatus(panel, scan_id, folderName, fileName, isThreat);
                    }

                }

                

                percentLabel.TextAlign = ContentAlignment.MiddleRight;
                percentLabel.Width = 110;
                if (success == false)
                {
                    percentLabel.Visible = false;
                    rerunButton.Visible = true;
                    panel.BackColor = Color.DarkRed;
                }
            }
            catch (Exception ex)
            {
                Debug.Write(ex);
                // Write out any exceptions.
                Button rerunButton = (Button)panel.Controls.Find("rerunButton", true)[0];
                rerunButton.Visible = true;

                Label percentLabel = (Label)panel.Controls.Find("percentLabel", true)[0];
                percentLabel.Visible = false;
                percentLabel.Font = new Font("Calibri", 16, FontStyle.Bold);
                percentLabel.Location = new System.Drawing.Point(this.screenWidth - 320, 0); // 512
                panel.BackColor = Color.DarkRed;
            }

        }


        private async Task CheckStatus(Panel panel, string scan_id, string folderName, string fileName, bool isThreat)
        {
            try
            {
                Label percentLabel = (Label)panel.Controls.Find("percentLabel", true)[0];
                Button rerunButton = (Button)panel.Controls.Find("rerunButton", true)[0];
                Button releaseButton = (Button)panel.Controls.Find("releaseButton", true)[0];
                Button removeButton = (Button)panel.Controls.Find("removeButton", true)[0];
                Panel colorPanel = (Panel)panel.Controls.Find("colorPanel", true)[0];

                string url = System.Configuration.ConfigurationManager.AppSettings["URI"] + "/scan/" + scan_id;
                Debug.Write("############checkstatus start################" + url);
                
                string status = "pending";
                string score = "";
                string rewrite = "";
                double score_num = 0;

                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("apiKey", Program.APIKEY);
                    client.DefaultRequestHeaders.Add("agentVersion", "1.2");

                    while (status == "pending" || status == "running")
                    {
                        Debug.Write("############checkstatus loop.");

                        using (var response = await client.GetAsync(url))
                        {

                            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                            {
                                Debug.Write("this.numberOfProcessing>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>" + this.numberOfProcessing + "     ");

                                if (isThreat)
                                {

                                    var content = await response.Content.ReadAsStringAsync();

                                    JObject jsonObject = JObject.Parse(content);

                                    rewrite = (string)jsonObject["rewrite"];
                                    // Debug.Write(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>"+content);

                                    JObject newJObject = new JObject();
                                    status = (string)jsonObject["data"]["status"];

                                    percentLabel.Text = status + "...";
                                    percentLabel.Font = new Font("Calibri", 10, FontStyle.Bold);

                                    Debug.Write("#################################"+status);

                                    if(status == "completed") {

                                        // newJObject["data"] = jsonObject.ContainsKey("output") == true ? jsonObject["data"]?["output"] : jsonObject["data"];

                                        newJObject["data"] = jsonObject["data"]["result"]; 
                                        if(jsonObject["data"]?["result"]?["data"]?["output"]!= null) {
                                            newJObject["data"]["data"] = jsonObject["data"]["result"]["data"]["output"]; 
                                        } 
                                        if(newJObject["data"]["data"] == null) {
                                            newJObject["data"]["data"] = new JObject();
                                        }
                                        newJObject["data"]["data"]["status"] = status;
                                        newJObject["data"]["data"]["scan_id"] = scan_id;
                                        newJObject["success"] = true;
                                        newJObject["fileName"] = fileName;
                                        newJObject["folderName"] = folderName;
                                        newJObject["rewrite"] = "rewrite";

                                        string hashFileName = folderName.Replace("\\", "-").Replace(":", "") + fileName + "-hash.json";
                                        string responseString = Newtonsoft.Json.JsonConvert.SerializeObject(newJObject);

                                        if (File.Exists(@"./malcore/threat/drag/" + hashFileName))
                                        {
                                            File.WriteAllText(@"./malcore/threat/drag/" + hashFileName, responseString);
                                        }
                                        else if (File.Exists(@"./malcore/threat/" + hashFileName))
                                        {
                                            File.WriteAllText(@"./malcore/threat/" + hashFileName, responseString);
                                        }

                                        if (newJObject["data"]?["data"]?["threat_score"]?["results"]?["score"] != null)
                                        {
                                            score = (string)newJObject["data"]?["data"]?["threat_score"]?["results"]?["score"];
                                            string[] scores = score.Split('/');
                                            score_num = Convert.ToDouble(scores[0]);
                                            score = scores[0] + "%";
                                        }

                                        Debug.Write("############checkstatus handler_type################" + (string)newJObject["data"]["data"]?["handler_type"]);
                                        if((string)newJObject["data"]["data"]?["handler_type"] == "error") {
                                            rerunButton.Visible = true;
                                            percentLabel.Visible = false;
                                            status = "error";
                                            colorPanel.BackColor = Color.Red;
                                        }
                                        
                                    }


                                    // Debug.Write("############checkstatus result################" + newJObject);
                                }
                                else
                                {
                                    var content = await response.Content.ReadAsStringAsync();
                                    // Debug.Write("############checkstatus result################" + content);
                                    JObject jsonObject = JObject.Parse(content);
                                    JObject newJObject = new JObject();

                                    rewrite = (string)jsonObject["rewrite"];
                                    status = (string)jsonObject["data"]["status"];

                                    percentLabel.Text = status + "...";
                                    percentLabel.Font = new Font("Calibri", 10, FontStyle.Bold);

                                    newJObject["data"] = jsonObject["data"]["result"];
                                    newJObject["data"]["data"]["status"] = status;
                                    newJObject["data"]["data"]["scan_id"] = scan_id;
                                    newJObject["success"] = true;
                                    newJObject["fileName"] = fileName;
                                    newJObject["folderName"] = folderName;
                                    newJObject["rewrite"] = "rewrite";
                                    string responseString = Newtonsoft.Json.JsonConvert.SerializeObject(newJObject);

                                    Debug.Write("############checkstatus result################" + status);

                                    string hashFileName = folderName.Replace("\\", "-").Replace(":", "") + fileName + "-hash.json";

                                    if (File.Exists(@"./malcore/doc/drag/" + hashFileName))
                                    {
                                        File.WriteAllText(@"./malcore/doc/drag/" + hashFileName, responseString);
                                    }
                                    else if (File.Exists(@"./malcore/doc/" + hashFileName))
                                    {
                                        File.WriteAllText(@"./malcore/doc/" + hashFileName, responseString);
                                    }

                                    // AddItemToMonitoringPanelForDoc(responseString, folderName, fileName, true);
                                    if(status == "completed") {
                                        score = (string)newJObject["data"]["data"]["dfi"]["results"]["dfi_results"]["score"];
                                        score_num = Convert.ToDouble(score);
                                        score += "%";
                                        percentLabel.Text = score;
                                        percentLabel.Font = new Font("Calibri", 16, FontStyle.Bold);
 
                                    }
                                }

                                if(status == "completed") { 
                                    percentLabel.Text = score;
                                    percentLabel.Font = new Font("Calibri", 16, FontStyle.Bold);

                                    if (score_num < 20.0)
                                    {
                                        colorPanel.BackColor = Color.Green;
                                        percentLabel.ForeColor = Color.Green;
                                        removeButton.Visible = false;
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

                                    // if(rewrite != "rewrite") {
                                    //     this.numberOfProcessing--;                                    
                                    // }
                                }

                                // return content;
                            }
                            else
                            {
                                percentLabel.Visible = false;
                                rerunButton.Visible = true;
                                colorPanel.BackColor = Color.Red;
                                // return "";

                                // this.numberOfProcessing--;                                    

                                Debug.Write("############checkstatus failed.");

                            }
                        }
                        await Task.Delay(3000);
                    }

                }
            }
            catch (Exception ex)
            {
                Label percentLabel = (Label)panel.Controls.Find("percentLabel", true)[0];
                Button rerunButton = (Button)panel.Controls.Find("rerunButton", true)[0]; 
                Panel colorPanel = (Panel)panel.Controls.Find("colorPanel", true)[0];

                percentLabel.Visible = false;
                rerunButton.Visible = true;
                colorPanel.BackColor = Color.Red;
                // this.numberOfProcessing--;                                    
                Debug.Write("checkstatus ERROR#####################" + folderName + fileName + ex);
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
        private void AddItemToMonitoringPanelForDoc(string responseString, string folderName, string fileName, bool succeed)
        {
            try
            {
                bool success = false;
                string score = "";
                double score_num = 0;
                string scan_result = "";
                string scan_id = "";

                if (succeed == true)
                {
                    JObject jsonObject = JObject.Parse(responseString);

                    success = (bool)jsonObject["success"];
                    if (bool.Parse((string)jsonObject["success"]) == false || jsonObject["data"] == null || (jsonObject["data"] != null && jsonObject["data"]["data"].ToString() == "{}"))
                    {
                        success = false;
                    }

                    if (success && jsonObject["data"]?["data"]?["dfi"]?["results"]?["dfi_results"]?["score"] != null)
                    {
                        score = (string)jsonObject["data"]["data"]["dfi"]["results"]["dfi_results"]["score"];
                        score_num = Convert.ToDouble(score);
                        // score = Convert.ToString(Math.Round(score_num)) + "%";
                        score += "%";
                    }
                    if (success && jsonObject["data"]?["data"]?["status"] != null)
                    {
                        scan_result = (string)jsonObject["data"]?["data"]?["status"];
                    }
                    if (success && jsonObject["data"]?["data"]?["scan_id"] != null)
                    {
                        scan_id = (string)jsonObject["data"]?["data"]?["scan_id"];
                    }
                }

                Debug.Write("#########################score" + score);

                // item panel
                Panel panel = new Panel();
                panel.Width = this.Size.Width - 30;
                panel.Height = 44;
                panel.BackColor = Color.Black;

                // color panel
                Panel colorPanel = new Panel();
                colorPanel.Name = "colorPanel";
                colorPanel.Width = 20;
                colorPanel.Height = 44;

                // file label
                Label fileLabel = new Label();
                fileLabel.Name = "fileLabel";
                fileLabel.Font = new Font("Calibri", 12, FontStyle.Bold);
                fileLabel.AutoSize = false;
                fileLabel.Width = 400;
                fileLabel.Cursor = Cursors.Hand;
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
                folderLabel.Cursor = Cursors.Hand;
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
                percentLabel.Font = new Font("Calibri", 16, FontStyle.Bold);
                percentLabel.Width = 110;
                percentLabel.Height = 40;
                percentLabel.Location = new System.Drawing.Point(this.screenWidth - 320, 0); // 512
                percentLabel.TextAlign = ContentAlignment.MiddleRight;

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
                removeButton.Cursor = Cursors.Hand;
                removeButton.Location = new System.Drawing.Point(this.screenWidth - 210, 6);
                removeButton.Click += delegate (object obj, EventArgs ea)
                {
                    DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this file?", "DELETE", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        if (File.Exists(folderName + "\\" + fileName))
                        {
                            HandleRelease(folderName + "\\" + fileName, false);
                            File.Delete(folderName + "\\" + fileName);
                        }
                        string hashFileName = folderName.Replace("\\", "-").Replace(":", "") + fileName + "-hash.json";
                        if (File.Exists("./malcore/doc/" + hashFileName))
                        {
                            File.Delete("./malcore/doc/" + hashFileName);
                        }
                        if (File.Exists("./malcore/doc/drag/" + hashFileName))
                        {
                            File.Delete("./malcore/doc/drag/" + hashFileName);
                        }
                        panel.Dispose();

                        string payload = "{\"type\":\"file_deleted\",\"payload\":{\"name\":\"" + fileName + "\",\"type\":\"docfile\",\"message\":\"File deleted\"}}";
                        AgentStat(payload);
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
                rerunButton.Width = 80;
                rerunButton.Height = 31;
                rerunButton.Cursor = Cursors.Hand;
                rerunButton.Location = new System.Drawing.Point(this.screenWidth - 295, 6); // 515
                rerunButton.Click += delegate (object obj, EventArgs ea)
                {
                    rerunButton.Visible = false;
                    RerunScanFile(folderName, fileName, panel, false);

                    string payload = "{\"type\":\"file_reran\",\"payload\":{\"name\":\"" + fileName + "\",\"type\":\"docfile\",\"message\":\"File reran\"}}";
                    AgentStat(payload);
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
                releaseButton.Cursor = Cursors.Hand;
                releaseButton.Location = new System.Drawing.Point(this.screenWidth - 121, 6); // 679
                releaseButton.Click += delegate (object obj, EventArgs ea)
                {
                    HandleRelease(folderName + "\\" + fileName, false);
                    string payload = "{\"type\":\"file_released\",\"payload\":{\"name\":\"" + fileName + "\",\"message\":\"File released\"}}";
                    AgentStat(payload);
                    releaseButton.Visible = false;
                    panel.Dispose();

                    string hashFileName = folderName.Replace("\\", "-").Replace(":", "") + fileName + "-hash.json";
                    string responseString = "released";
                    if(File.Exists(@"./malcore/doc/drag/" + hashFileName)) {
                        File.WriteAllText(@"./malcore/doc/drag/" + hashFileName, responseString);
                    } else if(File.Exists(@"./malcore/doc/" + hashFileName)) {
                        File.WriteAllText(@"./malcore/doc/" + hashFileName, responseString);
                    }
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
                    removeButton.Visible = false;
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

                // if scan is not completed
                if (scan_result != "completed")
                {
                    percentLabel.Text = scan_result + "...";
                    percentLabel.Font = new Font("Calibri", 10, FontStyle.Bold);
                    percentLabel.ForeColor = Color.White;
                    colorPanel.BackColor = Color.White;
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
                    removeButton.Visible = true;
                }

                panel.Controls.Add(colorPanel);
                panel.Controls.Add(fileLabel);
                panel.Controls.Add(folderLabel);
                panel.Controls.Add(percentLabel);
                panel.Controls.Add(rerunButton);

                if (success)
                {
                    rerunButton.Visible = false;
                    panel.Controls.Add(releaseButton);

                    if (score_num > this.minThreatScore || (scan_result != "completed" && scan_result != ""))
                    {
                        panel.Controls.Add(removeButton);
                    }
                    else
                    {
                        HandleRelease(folderName + "\\" + fileName, false);
                    }
                }
                else
                {
                    percentLabel.Visible = false;
                    panel.Controls.Add(removeButton);
                    panel.Controls.Add(releaseButton);
                }

                if (scan_result != "completed" && scan_id != null && scan_id != "")
                {
                    CheckStatus(panel, scan_id, folderName, fileName, false);
                }

                monitoringFlowLayoutPanel.Controls.Add(panel);
            }
            catch (Exception ex)
            {
                Debug.Write("doc parse error###################");
                Debug.Write(ex.Message);
            }
        }


        /**
        * @Description: add scanning files to monitoring panel temporary
        * @param folderName: full path of the target file excluding it's name 
        * @param fileName: target file name
        * @return void
        **/
        private Panel? AddItemToMonitoringPanelForInitialScan(string folderName, string fileName)
        {
            try
            {
                // item panel
                Panel panel = new Panel();
                panel.Width = this.Size.Width - 30;
                panel.Height = 44;
                panel.BackColor = Color.Black;

                // color panel
                Panel colorPanel = new Panel();
                colorPanel.Name = "colorPanel";
                colorPanel.Width = 20;
                colorPanel.Height = 44;
                colorPanel.BackColor = Color.White;

                // file label
                Label fileLabel = new Label();
                fileLabel.Name = "fileLabel";
                fileLabel.Font = new Font("Calibri", 12, FontStyle.Bold);
                fileLabel.Text = fileName;
                fileLabel.AutoSize = false;
                fileLabel.Location = new System.Drawing.Point(22, 1);
                fileLabel.ForeColor = Color.White;

                // folder label
                Label folderLabel = new Label();
                folderLabel.Name = "folderLabel";
                folderLabel.Text = folderName;
                folderLabel.ForeColor = Color.White;
                folderLabel.Font = new Font("Calibri", 11, FontStyle.Regular);
                folderLabel.AutoSize = false;
                folderLabel.Width = 400;
                folderLabel.Location = new System.Drawing.Point(24, 22);

                // percent label
                Label percentLabel = new Label();
                percentLabel.Name = "percentLabel";
                percentLabel.Text = "Scanning...";
                percentLabel.Font = new Font("Calibri", 11, FontStyle.Bold);
                percentLabel.ForeColor = Color.White;
                percentLabel.Width = 110;
                percentLabel.Height = 40;
                // percentLabel.Location = new System.Drawing.Point(this.screenWidth - 288, 4);  // 512
                percentLabel.Location = new System.Drawing.Point(this.screenWidth - 180, 4);
                percentLabel.TextAlign = ContentAlignment.MiddleRight;
                percentLabel.ForeColor = Color.Yellow;

                panel.Controls.Add(colorPanel);
                panel.Controls.Add(fileLabel);
                panel.Controls.Add(folderLabel);
                panel.Controls.Add(percentLabel);

                monitoringFlowLayoutPanel.Controls.Add(panel);
                return panel;
            }
            catch (Exception ex)
            {
                return null;
            }

        }


        /**
        * @Description: Scan all sub directories of the target directory and process if it's an end file
        * @param targetDirectory: full path of the target file 
        * @return void
        **/
        public void ProcessDirectory(string targetDirectory)
        {
            try
            {
                // Process the list of files found in the directory.
                string[] fileEntries = Directory.GetFiles(targetDirectory);
                foreach (string fileName in fileEntries)
                {
                    bool result = CheckFileExtentionIsAllowed(fileName);
                    if (result)
                    {
                        if (!Program.FilePool.Contains(fileName) && !Program.PrecessedFilePool.Contains(fileName))
                        {
                            Program.FilePool.Enqueue(fileName);
                        }
                    }
                }

                // Recurse into subdirectories of this directory.
                string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
                foreach (string subdirectory in subdirectoryEntries)
                {
                    ProcessDirectory(subdirectory);
                }
            }
            catch (Exception ex)
            {
                Debug.Write(ex);
            }
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
                Debug.WriteLine("process file......." + path);

                Program.PrecessedFilePool.Enqueue(path);

                string fileName = Path.GetFileName(path);
                string folderName = Directory.GetParent(path) != null ? Directory.GetParent(path).FullName : path;

                string hashFileName = folderName.Replace("\\", "-").Replace(":", "") + fileName + "-hash.json";
                // check if the hash file is already scanned
                if (File.Exists("./malcore/threat/" + hashFileName))
                {
                    Debug.WriteLine("found a file......." + hashFileName);

                    string fileString = File.ReadAllText("./malcore/threat/" + hashFileName);
                    bool succeed = true;
                    this.numberOfProcessing--;

                    if (fileString == "released")
                    {
                        return false;
                    }

                    if (fileString == "")
                    {
                        succeed = false;
                    }
 
                    AddItemToMonitoringPanel(fileString, folderName, fileName, succeed);
                }
                else if (File.Exists("./malcore/doc/" + hashFileName))
                {
                    string fileString = File.ReadAllText("./malcore/doc/" + hashFileName);
                    bool succeed = true;
                    this.numberOfProcessing--;

                    if (fileString == "released")
                    {
                        return false;
                    }

                    if (fileString == "")
                    {
                        succeed = false;
                    }

                    AddItemToMonitoringPanelForDoc(fileString, folderName, fileName, succeed);
                }
                else
                {
                    HandleRelease(path, false);
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
                                        //tempcode
                                        var panel = AddItemToMonitoringPanelForInitialScan(folderName, fileName);
                                        Debug.WriteLine("start scanning................." + fileName);

                                        string responseString = await GetThreatScore(path, fileName, "upload");

                                        // save to hash file                                        
                                        bool succeed = true;
                                        if (responseString == "")
                                        {
                                            succeed = false;
                                        }
                                        else
                                        {
                                            JObject jsonObject = JObject.Parse(responseString);
                                            jsonObject["fileName"] = fileName;
                                            jsonObject["folderName"] = folderName;
                                            responseString = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObject);
                                        }
                                        if (Program.DragFilePool.Contains(path))
                                        {
                                            File.WriteAllText(@"./malcore/threat/drag/" + hashFileName, responseString);
                                        }
                                        else
                                        {
                                            File.WriteAllText(@"./malcore/threat/" + hashFileName, responseString);
                                        }

                                        if (panel != null)
                                        {
                                            panel.Dispose();
                                            Debug.WriteLine("end scanning................." + fileName);
                                        }
                                        // add to mornitoring list 
                                        AddItemToMonitoringPanel(responseString, folderName, fileName, succeed);
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
                                        var panel = AddItemToMonitoringPanelForInitialScan(folderName, fileName);
                                        string responseString = await GetThreatScore(path, fileName, "docfile");

                                        // save to hash file
                                        bool succeed = true;
                                        if (responseString == "")
                                        {
                                            succeed = false;
                                        }
                                        else
                                        {
                                            JObject jsonObject = JObject.Parse(responseString);
                                            jsonObject["fileName"] = fileName;
                                            jsonObject["folderName"] = folderName;
                                            responseString = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObject);
                                        }

                                        if (Program.DragFilePool.Contains(path))
                                        {
                                            File.WriteAllText(@"./malcore/doc/drag/" + hashFileName, responseString);
                                        }
                                        else
                                        {
                                            File.WriteAllText(@"./malcore/doc/" + hashFileName, responseString);
                                        }

                                        if (panel != null)
                                        {
                                            panel.Dispose();
                                            Debug.WriteLine("end scanning................." + fileName);
                                        }
                                        AddItemToMonitoringPanelForDoc(responseString, folderName, fileName, succeed);
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
                Debug.Write(ex);
                return false;
            }
        }


        /**
        * @Description: Update file access rule based on locking param
        * @param path: full path of the target file  
        * @param locking: true if file is currently Allow, false if file is Deny now
        * @return void
        **/
        private void HandleRelease(string path, bool locking)
        {
            try
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
            catch (Exception ex)
            {
                Debug.Write(ex);
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
            catch (Exception ex)
            {
                Debug.Write(ex);
                return false;
            }
        }

        /**
        * @Description: Check if file extention is in the allowed list
        * @param path: full path of the target file  
        * @return true if available, false if not allowed
        **/
        private bool CheckFileExtentionIsAllowed(string path)
        {
            try
            {
                HandleRelease(path, false);

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
                                // exe files
                                if ((buffer[0] == 77 && buffer[1] == 90) || (buffer[0] == 90 && buffer[1] == 77))
                                {
                                    return true;
                                } // doc type files
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
            catch (Exception ex)
            {
                return false;
            }

        }


        /**
        * @Description: Start monitoring file change and add to the Queue
        * @return void
        **/
        public void InitTimer()
        {
            try
            {
                monitorTimer = new System.Windows.Forms.Timer();
                monitorTimer.Tick += new EventHandler(DetectFileChange);
                monitorTimer.Interval = 3000; // in miliseconds
                monitorTimer.Start();
            }
            catch (Exception ex)
            {
            }
        }
        private void DetectFileChange(object sender, EventArgs e)
        {
            HandleMonitoring();
        }

        /**
        * @Description: handle logout
        **/
        private void BtnLogout_Click_1(object sender, EventArgs e)
        {
            try
            {
                RegistryKey? key = Registry.CurrentUser.OpenSubKey(Constants.RegistryMalcoreKey, true);
                key.DeleteValue("API_KEY");
                key.DeleteValue("SETTINGS");
                key.Close();

                Program.APIKEY = "";
                Program.USEREMAIL = "";
                Program.SUBSCRIPTION = "";

                Hide();
                LoginForm loginForm = new LoginForm();
                loginForm.Show(this);

                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name != "LoginForm")
                    {
                        f.Hide();
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.Write("em..............." + ex.Message);
                LoginForm loginForm = new LoginForm();
                loginForm.Show(this);
            }
        }

        /**
        * @Description: show settings form
        **/
        private void BtnSettings_Click_1(object sender, EventArgs e)
        {
            try
            {
                SettingsForm settingsForm = new SettingsForm();
                settingsForm.ShowDialog(this);
            }
            catch (Exception ex)
            {
            }
        }

        /**
        * @Description: watch target folder and process a file if there is any file created new
        **/
        private void FileSystemWatcherMain_Created_1(object sender, FileSystemEventArgs e)
        {
            try
            {
                if (File.Exists(e.FullPath))
                {
                    if (!Program.FilePool.Contains(e.FullPath))
                    {
                        Program.FilePool.Enqueue(e.FullPath);
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void FileSystemWatcherMain_Changed(object sender, FileSystemEventArgs e)
        {
        }

        /**
        * @Description: move app to windows icon tray
        * @Description: if the form is minimized hide it from the task bar
        * @Description: and show the system tray icon (represented by the NotifyIcon control) 
        **/
        private void MonitoringForm_Resize(object sender, EventArgs e)
        {
            try
            {
                if (this.WindowState == FormWindowState.Minimized)
                {
                    Hide();
                    notifyIcon1.Visible = true;
                    // this is for notification
                    // notifyIcon1.ShowBalloonTip(500);
                }
            }
            catch (Exception ex)
            {
            }
        }

        /**
        * @Description: show app from windows icon tray when double click it in icon tray
        **/
        private void NotifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                Show();
                this.WindowState = FormWindowState.Normal;
                notifyIcon1.Visible = false;
            }
            catch (Exception ex)
            {
            }
        }

        /**
        * @Description: move app to windows icon tray when click Close button
        **/
        private void MonitoringForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (this.closing == false)
                {
                    e.Cancel = true;
                    Hide();
                    notifyIcon1.Visible = true;
                }
            }
            catch (Exception ex)
            {
            }
        }

        /**
        * @Description: exit application 
        **/
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.closing = true;
                notifyIcon1.Visible = false;
                notifyIcon1.Dispose();
                Application.Exit();
            }
            catch (Exception ex)
            {
            }
        }

        /**
        * @Description: View Queue. If QueueForm is already opened, close it and open new one
        **/
        private void BtnViewQueue_Click(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {
            }
        }

        /**
        * @Description: if drag&drop a folder from windows explorer to monitoring form,
        * @Description: update the settings and restart scanning
        **/
        private void MonitoringForm_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                // MessageBox.Show("monitoringForm_DragDrop start");
                string[] filePaths = (string[])e.Data.GetData(DataFormats.FileDrop, false);

                for (int i = 0; i < filePaths.Length; i++)
                {
                    string fileName = filePaths[i];
                    // MessageBox.Show("monitoringForm_DragDrop " + fileName);

                    if (!Program.FilePool.Contains(fileName) && !Program.PrecessedFilePool.Contains(fileName))
                    {
                        Program.DragFilePool.Enqueue(fileName);
                        Program.FilePool.Enqueue(fileName);
                    }
                }
            }
            catch (Exception ex)
            {
                // Write out any exceptions.
                Debug.Write(ex);
                // MessageBox.Show("monitoringForm_DragDrop" + ex);
            }

        }

        private void MonitoringForm_DragEnter(object sender, DragEventArgs e)
        {
            try
            {
                // MessageBox.Show("monitoringForm_DragEnter start");

                string[] filePaths = (string[])e.Data.GetData(DataFormats.FileDrop, false);

                DragDropEffects effects = DragDropEffects.None;
                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                {
                    string folderPath = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
                    // MessageBox.Show(folderPath);

                    // Only allow folders to drop
                    if (!Directory.Exists(folderPath))
                    {
                        effects = DragDropEffects.Copy;
                    }
                }
                e.Effect = effects;
            }
            catch (Exception ex)
            {
                Debug.Write(ex);
                // MessageBox.Show("monitoringForm_DragEnter" + ex);
            }
        }

        private void MonitoringForm_Load(object sender, EventArgs e)
        {
            MalcoreFooter malcoreFooter = new()
            {
                Dock = DockStyle.Bottom
            };

            Controls.Add(malcoreFooter);
        }

        private void PictureSettings_Click(object sender, EventArgs e)
        {
            try
            {
                SettingsForm settingsForm = new SettingsForm();
                settingsForm.ShowDialog(this);
            }
            catch (Exception ex)
            {
            }
        }

        private void PictureLogout_Click(object sender, EventArgs e)
        {
            try
            {
                RegistryKey? key = Registry.CurrentUser.OpenSubKey(Constants.RegistryMalcoreKey, true);
                key.DeleteValue("API_KEY");
                key.DeleteValue("SETTINGS");
                key.Close();

                Program.APIKEY = "";
                Program.USEREMAIL = "";
                Program.SUBSCRIPTION = "";

                Hide();
                LoginForm loginForm = new LoginForm();
                loginForm.Show(this);

                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name != "LoginForm")
                    {
                        f.Hide();
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.Write("em..............." + ex.Message);
                LoginForm loginForm = new LoginForm();
                loginForm.Show(this);
            }
        }
    }

    public class FileNameData
    {
        public bool success { get; set; }
        public string fileName { get; set; }
        public string folderName { get; set; }
    }

    class RoundedButton : Button
    {
        public int rdus = 30;
        System.Drawing.Drawing2D.GraphicsPath GetRoundPath(RectangleF Rect, int radius)
        {
            float r2 = radius / 2f;
            System.Drawing.Drawing2D.GraphicsPath GraphPath = new System.Drawing.Drawing2D.GraphicsPath();
            GraphPath.AddArc(Rect.X, Rect.Y, radius, radius, 180, 90);
            GraphPath.AddLine(Rect.X + r2, Rect.Y, Rect.Width - r2, Rect.Y);
            GraphPath.AddArc(Rect.X + Rect.Width - radius, Rect.Y, radius, radius, 270, 90);
            GraphPath.AddLine(Rect.Width, Rect.Y + r2, Rect.Width, Rect.Height - r2);
            GraphPath.AddArc(Rect.X + Rect.Width - radius,
                    Rect.Y + Rect.Height - radius, radius, radius, 0, 90);
            GraphPath.AddLine(Rect.Width - r2, Rect.Height, Rect.X + r2, Rect.Height);
            GraphPath.AddArc(Rect.X, Rect.Y + Rect.Height - radius, radius, radius, 90, 90);
            GraphPath.AddLine(Rect.X, Rect.Height - r2, Rect.X, Rect.Y + r2);
            GraphPath.CloseFigure();
            return GraphPath;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            RectangleF Rect = new RectangleF(0, 0, this.Width, this.Height);
            using (System.Drawing.Drawing2D.GraphicsPath GraphPath = GetRoundPath(Rect, rdus))
            {
                this.Region = new Region(GraphPath);
                using (Pen pen = new Pen(Color.AliceBlue, 1f))
                {
                    pen.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
                    e.Graphics.DrawPath(pen, GraphPath);
                }
            }
        }

    }
}