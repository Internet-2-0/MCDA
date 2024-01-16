using System.Diagnostics;
using System.Text;
using Microsoft.Win32;
using Newtonsoft.Json.Linq;
using System.Security.AccessControl;
using System.Security.Principal;
using System;
using System.IO;
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
            if (!Directory.Exists(@"C:\\Program Files (x86)\\Malcore Agent\\Malcore Agent\\malcore"))
            {
                Directory.CreateDirectory(@"C:\\Program Files (x86)\\Malcore Agent\\Malcore Agent\\malcore");
            }
            if (!Directory.Exists(@"C:\\Program Files (x86)\\Malcore Agent\\Malcore Agent\\malcore\\threat"))
            {
                Directory.CreateDirectory(@"C:\\Program Files (x86)\\Malcore Agent\\Malcore Agent\\malcore\\threat");
            }
            if (!Directory.Exists(@"C:\\Program Files (x86)\\Malcore Agent\\Malcore Agent\\malcore\\doc"))
            {
                Directory.CreateDirectory(@"C:\\Program Files (x86)\\Malcore Agent\\Malcore Agent\\malcore\\doc");
            }
            if (!Directory.Exists(@"C:\\Program Files (x86)\\Malcore Agent\\Malcore Agent\\malcore\\threat\\drag"))
            {
                Directory.CreateDirectory(@"C:\\Program Files (x86)\\Malcore Agent\\Malcore Agent\\malcore\\threat\\drag");
            }
            if (!Directory.Exists(@"C:\\Program Files (x86)\\Malcore Agent\\Malcore Agent\\malcore\\doc\\drag"))
            {
                Directory.CreateDirectory(@"C:\\Program Files (x86)\\Malcore Agent\\Malcore Agent\\malcore\\doc\\drag");
            }

            // // use for local ***tempcode
            // if (!Directory.Exists(@"./malcore"))
            // {
            //     Directory.CreateDirectory(@"./malcore");
            // }
            // if (!Directory.Exists(@"./malcore/threat"))
            // {
            //     Directory.CreateDirectory(@"./malcore/threat");
            // }
            // if (!Directory.Exists(@"./malcore/doc"))
            // {
            //     Directory.CreateDirectory(@"./malcore/doc");
            // }
            // if (!Directory.Exists(@"./malcore/threat/drag"))
            // {
            //     Directory.CreateDirectory(@"./malcore/threat/drag");
            // }
            // if (!Directory.Exists(@"./malcore/doc/drag"))
            // {
            //     Directory.CreateDirectory(@"./malcore/doc/drag");
            // }

            showAllScannedDragFiles();
            startMonitoring();
        }

        /**
        * @Description: process the files in the queue. 
        * This function runs when there are files in the queue and stops when the file queue is empty.
        * Call threat API if currently running processes are less than 10 
        * Otherwise, wait until the number of currently running processes is less than 10.
        * @return void.
        **/
        private async Task processHoldQueue()
        {
            try
            {
                if (this.numberOfProcessing > this.queueHoldSize)
                {
                    await Task.Delay(300);
                    await processHoldQueue();
                }
                else
                {
                    if(Program.FilePool.Count > 0) {
                        this.numberOfProcessing++;
                        ProcessFile(Program.FilePool.Dequeue());
                    } else { 
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
        public async void removeAllScanedFiles()
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
        public async void startMonitoring()
        {
            queuePanel.Visible = false;
            queuePanel.Width = this.screenWidth - 30;
            btnViewQueue.Location = new System.Drawing.Point(this.screenWidth - 210, 6);
            labelRemaining.Location = new System.Drawing.Point(this.screenWidth - 248, 78); // 680

            monitoringFlowLayoutPanel.Width = this.screenWidth;

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
                                    await processHoldQueue();
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
                    lblRequestNumber.Location = new System.Drawing.Point(this.screenWidth - 80, 79); // 680

                    lblStatus.Text = "ACTIVE";
                    lblStatus.ForeColor = Color.Green;

                    RegistryKey? key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\\Malcore");
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
                                    await processHoldQueue();
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
        private async Task<bool> initFilePool()
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
                                    bool result = checkFileExtentionIsAllowed(path);
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
        private async Task<bool> showAllScannedDragFiles()
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
                                bool succeed = true;
                                if (fileString != "released" && fileString != "")
                                { 

                                    JObject jsonData = JObject.Parse(fileString); 
                                    string folderName = jsonData["folderName"].ToString();
                                    string fileName = jsonData["fileName"].ToString();

                                    addItemToMonitoringPanel(fileString, folderName, fileName, succeed);
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

                                    addItemToMonitoringPanelForDoc(fileString, folderName, fileName, succeed);
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
        private async Task<string> getThreatScore(string pathFile, string fileName, string type)
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
                                
                                // if (this.numberOfProcessing == 0) {
                                //     lblProcessFileCount.Visible = false;
                                // }
                                return responseString;
                            }
                            else
                            {
                                string payload2 = "{\"type\":\"file_failed\",\"payload\":{\"name\":\"" + fileName + "\",\"type\":\"" + type + "\",\"response\":\"api_error\",\"message\":\"API Error\"}}";
                                await agentStat(payload2);
                                this.numberOfProcessing--;

                                // if (this.numberOfProcessing == 0) {
                                //     lblProcessFileCount.Visible = false;
                                // }
                                return "";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.Write(ex);
                this.numberOfProcessing--;
                // if (this.numberOfProcessing == 0) {
                //     lblProcessFileCount.Visible = false;
                // }
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
                    client.DefaultRequestHeaders.Add("agentVersion", "1.1.1");

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
                    client.DefaultRequestHeaders.Add("agentVersion", "1.1.1");

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
        private void addItemToMonitoringPanel(string responseString, string folderName, string fileName, bool succeed)
        {
            try
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
                            // score = Convert.ToString(Math.Round(score_num)) + "%";
                            score = scores[0] + "%";
                        }
                    }
                }

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
                // percentLabel.Width = 76;
                percentLabel.Width = 110;
                percentLabel.Height = 40;
                // percentLabel.Location = new System.Drawing.Point(this.screenWidth - 288, 4);  // 512
                percentLabel.Location = new System.Drawing.Point(this.screenWidth - 320, 0); 
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
                removeButton.Location = new System.Drawing.Point(this.screenWidth - 210, 6); // 590
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
                        if (File.Exists("./malcore/threat/drag/" + hashFileName))
                        {
                            File.Delete("./malcore/threat/drag/" + hashFileName);
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
                rerunButton.Width = 80;
                rerunButton.Height = 31;
                rerunButton.Location = new System.Drawing.Point(this.screenWidth - 295, 6);  // 515
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
                releaseButton.Location = new System.Drawing.Point(this.screenWidth - 121, 6);
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
            catch (Exception ex)
            {
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
        public async void rerunScanFile(string folderName, string fileName, Panel panel, bool isThreat)
        {
            try
            {
                Button rerunButton = (Button)panel.Controls.Find("rerunButton", true)[0];
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
                    responseString = await getThreatScore(path, fileName, "threatscore");
                    if(responseString != "") {
                        JObject jsonObject = JObject.Parse(responseString);
                        jsonObject["fileName"] = fileName;
                        jsonObject["folderName"] = folderName;
                        responseString = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObject);
                    }

                    if(Program.DragFilePool.Contains(path)) {
                        File.WriteAllText(@"./malcore/threat/drag/" + hashFileName, responseString);
                    } else {
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
                    responseString = await getThreatScore(path, fileName, "docfile");
                    if(responseString != "") {
                        JObject jsonObject = JObject.Parse(responseString);
                        jsonObject["fileName"] = fileName;
                        jsonObject["folderName"] = folderName;
                        responseString = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObject);
                    }

                    if(Program.DragFilePool.Contains(path)) {
                        File.WriteAllText(@"./malcore/doc/drag/" + hashFileName, responseString);
                    } else {
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
                            // score = Convert.ToString(Math.Round(score_num)) + "%";
                            score = scores[0] + "%";
                        }
                        else
                        {
                            score = (string)jsonObject["data"]["data"]["dfi"]["results"]["dfi_results"]["score"];
                            score_num = Convert.ToDouble(score);
                            // score = Convert.ToString(Math.Round(score_num)) + "%";
                            score = score + "%";
                        }

                        Panel colorPanel = (Panel)panel.Controls.Find("colorPanel", true)[0];
                        Label fileLabel = (Label)panel.Controls.Find("fileLabel", true)[0];

                        percentLabel.Text = score;
                        percentLabel.Font = new Font("Calibri", 20, FontStyle.Bold);
                        percentLabel.Location = new System.Drawing.Point(this.screenWidth - 320, 0); // 512

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
                percentLabel.Font = new Font("Calibri", 20, FontStyle.Bold);
                percentLabel.Location = new System.Drawing.Point(this.screenWidth - 320, 0); // 512
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
            try
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
                        // score = Convert.ToString(Math.Round(score_num)) + "%";
                        score = score + "%";
                    }
                }

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
                percentLabel.Font = new Font("Calibri", 20, FontStyle.Bold);
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
                removeButton.Location = new System.Drawing.Point(this.screenWidth - 210, 6);
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
                        if (File.Exists("./malcore/doc/drag/" + hashFileName))
                        {
                            File.Delete("./malcore/doc/drag/" + hashFileName);
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
                rerunButton.Width = 80;
                rerunButton.Height = 31;
                rerunButton.Location = new System.Drawing.Point(this.screenWidth - 295, 6); // 515
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
                releaseButton.Location = new System.Drawing.Point(this.screenWidth - 121, 6); // 679
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
            catch (Exception ex)
            {
                Debug.Write(ex.Message);
            }
        }


        /**
        * @Description: add scanning files to monitoring panel temporary
        * @param folderName: full path of the target file excluding it's name 
        * @param fileName: target file name
        * @return void
        **/
        private Panel? addItemToMonitoringPanelForInitialScan(string folderName, string fileName)
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
        public async void ProcessDirectory(string targetDirectory)
        {
            try
            {
                // Process the list of files found in the directory.
                string[] fileEntries = Directory.GetFiles(targetDirectory);
                foreach (string fileName in fileEntries)
                {
                    bool result = checkFileExtentionIsAllowed(fileName);
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
                foreach (string subdirectory in subdirectoryEntries) {
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
                // // tempcode
                // if(this.numberOfProcessing > 0) {
                //     lblProcessFileCount.Visible = true;
                //     lblProcessFileCount.Text = this.numberOfProcessing + " files are running now.";
                // } else {
                //     lblProcessFileCount.Visible = false;
                // }
                Debug.WriteLine("process file......." + path);

                Program.PrecessedFilePool.Enqueue(path);

                string fileName = Path.GetFileName(path);
                string folderName = Directory.GetParent(path) != null ? Directory.GetParent(path).FullName : path;

                string hashFileName = folderName.Replace("\\", "-").Replace(":", "") + fileName + "-hash.json";
                // check if the hash file is already scanned
                if (File.Exists("./malcore/threat/" + hashFileName))
                {
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

                    // if (this.numberOfProcessing == 0) {
                    //     lblProcessFileCount.Visible = false;
                    // }
                    addItemToMonitoringPanel(fileString, folderName, fileName, succeed);
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
                                        //tempcode
                                        var panel = addItemToMonitoringPanelForInitialScan(folderName, fileName);
                                        Debug.WriteLine("start scanning................." + fileName);

                                        string responseString = await getThreatScore(path, fileName, "threatscore");

                                        // save to hash file                                        
                                        bool succeed = true;
                                        if (responseString == "")
                                        {
                                            succeed = false; 
                                        } else {
                                            JObject jsonObject = JObject.Parse(responseString);
                                            jsonObject["fileName"] = fileName;
                                            jsonObject["folderName"] = folderName;
                                            responseString = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObject);
                                        }
                                        if(Program.DragFilePool.Contains(path)) {
                                            File.WriteAllText(@"./malcore/threat/drag/" + hashFileName, responseString);
                                        } else {
                                            File.WriteAllText(@"./malcore/threat/" + hashFileName, responseString);
                                        }

                                        if(panel != null) {
                                            panel.Dispose();
                                            Debug.WriteLine("end scanning................." + fileName);
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
                                        var panel = addItemToMonitoringPanelForInitialScan(folderName, fileName);
                                        string responseString = await getThreatScore(path, fileName, "docfile");

                                        // save to hash file
                                        bool succeed = true;
                                        if (responseString == "")
                                        {
                                            succeed = false; 
                                        } else {
                                            JObject jsonObject = JObject.Parse(responseString);
                                            jsonObject["fileName"] = fileName;
                                            jsonObject["folderName"] = folderName;
                                            responseString = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObject);
                                        }

                                        if(Program.DragFilePool.Contains(path)) {
                                            File.WriteAllText(@"./malcore/doc/drag/" + hashFileName, responseString);                                   
                                        } else {
                                            File.WriteAllText(@"./malcore/doc/" + hashFileName, responseString);                                   
                                        }
                                        
                                        if(panel != null) {
                                            panel.Dispose();
                                            Debug.WriteLine("end scanning................." + fileName);
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
        private void handleRelease(string path, bool locking)
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
        private bool checkFileExtentionIsAllowed(string path)
        {
            try
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
                monitorTimer.Tick += new EventHandler(detectFileChange);
                monitorTimer.Interval = 3000; // in miliseconds
                monitorTimer.Start();
            }
            catch (Exception ex)
            {
            }
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
                    if (f.Name != "LoginForm") {
                        f.Hide();
                    } 
                } 
            }
            catch (Exception ex)
            {
                Debug.Write("em..............."+ex.Message);
                LoginForm loginForm = new LoginForm();
                loginForm.Show(this); 
            }
        }

        /**
        * @Description: show settings form
        **/
        private void btnSettings_Click_1(object sender, EventArgs e)
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
        private void fileSystemWatcherMain_Created_1(object sender, FileSystemEventArgs e)
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

        private void fileSystemWatcherMain_Changed(object sender, FileSystemEventArgs e)
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
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
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
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
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
        private void btnViewQueue_Click(object sender, EventArgs e)
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

        private void label3_Click(object sender, EventArgs e)
        {
            Program.OpenBrowser(Constants.MalcorePrivacy);
        }

        private void lblTerms_Click(object sender, EventArgs e)
        {
            Program.OpenBrowser(Constants.MalcoreTerms);
        }

        private void lblMalcore_Click(object sender, EventArgs e)
        {
            Program.OpenBrowser(Constants.MalcoreBaseUrl);
        }
         
        /**
        * @Description: if drag&drop a folder from windows explorer to monitoring form,
        * @Description: update the settings and restart scanning
        **/
        private void monitoringForm_DragDrop(object sender, DragEventArgs e)
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

        private void monitoringForm_DragEnter(object sender, DragEventArgs e)
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
                    if (!Directory.Exists(folderPath)) {
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

        }
    }

    public class FileNameData
    {
        public bool success { get; set; }
        public string fileName { get; set; }
        public string folderName { get; set; }
    }
}