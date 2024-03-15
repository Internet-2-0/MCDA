using MCDA_APP.Controls;
using Microsoft.Win32;
using Newtonsoft.Json.Linq;

namespace MCDA_APP.Forms
{
    public partial class SettingsForm : Form
    {
        bool closing = false;
        List<string> paths = new List<string>();

        public SettingsForm() => InitializeComponent();

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            MalcoreFooter malcoreFooter = new()
            {
                Dock = DockStyle.Bottom
            };

            Controls.Add(malcoreFooter);

            try
            {
                // set apikey and user email
                labelEmail.Text = Program.USEREMAIL;
                txtApikey.Text = Program.APIKEY;
                labelPlan.Text = Program.SUBSCRIPTION;

                // Check if user authentication 
                RegistryKey? key = Registry.CurrentUser.OpenSubKey(Constants.RegistryMalcoreKey);
                if (key != null)
                {
                    var SETTINGS = key.GetValue("SETTINGS");
                    if (SETTINGS != null)
                    {
                        JObject json = JObject.Parse(SETTINGS.ToString());

                        checkEnableMonitor.Checked = (bool)json["enableMornitoring"];
                        checkSendStatistics.Checked = (bool)json["sendStatistics"];
                        checkOpenOnStartup.Checked = (bool)json["openOnStartup"];
                        textMinScore.Text = json["minThreatScore"].ToString();

                        // add folders to mornitoring folder list from settings
                        string settings_paths = (string)json["paths"];
                        List<string> paths = settings_paths.Split(',').ToList();
                        this.paths = paths;
                        foreach (string folderPath in paths)
                        {
                            if (folderPath != "")
                            {
                                addPathToFoldersList(folderPath);
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Hide();
            // MonitoringForm monitoringForm = new MonitoringForm();
            // monitoringForm.Visible = false;
            // monitoringForm.Show(this);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                bool enableMornitoring = checkEnableMonitor.Checked;
                bool sendStatistics = checkSendStatistics.Checked;
                bool openOnStartup = checkOpenOnStartup.Checked;
                string minThreatScore = textMinScore.Text;

                var data = new SettingsData()
                {
                    enableMornitoring = enableMornitoring,
                    sendStatistics = sendStatistics,
                    openOnStartup = openOnStartup,
                    minThreatScore = minThreatScore,
                    paths = string.Join(",", this.paths.ToArray())
                };
                var settingsData = Newtonsoft.Json.JsonConvert.SerializeObject(data);

                RegistryKey? key = Registry.CurrentUser.OpenSubKey(Constants.RegistryMalcoreKey, true);
                var OldSettings = key.GetValue("SETTINGS");

                key.SetValue("SETTINGS", settingsData.ToString());
                key.Close();

                // RegistryKey startkeyForLocalMachine = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                RegistryKey startkeyForCurrentUser = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

                // old version for admin permission
                // RegistryKey startkey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\\WOW6432Node\\Microsoft\\Windows\\CurrentVersion\\Run", true);

                // register as start up
                if (openOnStartup)
                {
                    // startkeyForLocalMachine.SetValue("malcore", "\"C:\\Program Files (x86)\\Malcore Agent\\Malcore Agent\\MCDA-APP.exe\" /autostart");
                    startkeyForCurrentUser.SetValue("Malcore", "\"C:\\Program Files (x86)\\Malcore Agent\\Malcore Agent\\MCDA-APP.exe\" --process-start-args --startup");

                    // old version for admin permission
                    // startkey.SetValue("Malcore", "\"C:\\Program Files (x86)\\Malcore Agent\\Malcore Agent\\MCDA-APP.exe\" --process-start-args --startup");
                }
                else
                {
                    // startkeyForLocalMachine.DeleteValue("malcore");
                    if (startkeyForCurrentUser.GetValue("Malcore") != null)
                    {
                        startkeyForCurrentUser.DeleteValue("Malcore");
                    }

                    // old version for admin permission
                    // if(startkey.GetValue("Malcore") != null) {
                    //     startkey.DeleteValue("Malcore");
                    // }
                }
                // startkeyForLocalMachine.Close();
                startkeyForCurrentUser.Close();

                // old version for admin permission
                // startkey.Close();

                Hide();

                // If settings is updated, restart monitoring
                if (OldSettings == null || OldSettings.ToString() == "")
                {
                    // if first start the app after install, open monitoring form
                    MonitoringForm monitoringForm = new MonitoringForm();
                    monitoringForm.Visible = false;
                    monitoringForm.Show(this);
                }
                else
                {
                    // if settings are updated, restart monitoring
                    if ((OldSettings.ToString() != settingsData.ToString()))
                    {
                        FormCollection fc = Application.OpenForms;
                        foreach (Form frm in fc)
                        {
                            if (frm.Name == "MonitoringForm")
                            {
                                MonitoringForm monitoringForm = (MonitoringForm)frm;
                                monitoringForm.StartMonitoring();
                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // MessageBox.Show("save"+ex.ToString());
                Hide();
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
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

                // foreach (Form f in Application.OpenForms)
                // {
                //     if (f.Name == "MonitoringForm") {
                //         f.Close();
                //     }
                // }  
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
                LoginForm loginForm = new LoginForm();
                loginForm.Show(this);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog folderDlg = new FolderBrowserDialog();
                folderDlg.ShowNewFolderButton = true;

                // Show the FolderBrowserDialog.  
                DialogResult result = folderDlg.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string folderPath = folderDlg.SelectedPath;

                    // prevent to add root dirives such as C:\, D:\ and C:\Windows
                    if (folderPath.Equals("C:\\") || folderPath.Contains("C:\\Windows"))
                    {
                        return;
                    }
                    this.paths.Add(folderPath);

                    if (this.paths.Count != this.paths.Distinct().Count())
                    {
                        this.paths.Remove(folderPath);
                    }
                    else
                    {
                        addPathToFoldersList(folderPath);
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void addPathToFoldersList(string folderPath)
        {
            Panel panel = new Panel();
            panel.Width = flowLayoutPanelForFolders.Size.Width - 30; // 425
            panel.Height = 18;

            Panel borderPanel = new Panel();
            borderPanel.Height = 1;
            borderPanel.Width = flowLayoutPanelForFolders.Size.Width - 30; // 425
            borderPanel.BackColor = Color.WhiteSmoke;

            Label label = new Label();
            label.Text = folderPath;
            label.ForeColor = Color.White;
            label.AutoSize = true;
            label.MaximumSize = new System.Drawing.Size(flowLayoutPanelForFolders.Size.Width - 37, 0); // 398

            PictureBox removePicture = new PictureBox();
            removePicture.Size = new System.Drawing.Size(18, 18);
            removePicture.Padding = new Padding(0, 0, 0, 0);
            removePicture.Location = new System.Drawing.Point(flowLayoutPanelForFolders.Size.Width - 52, 2); // 400
            removePicture.Image = pictureBox2.Image;
            removePicture.Cursor = Cursors.Hand;
            removePicture.SizeMode = PictureBoxSizeMode.StretchImage;
            removePicture.Click += delegate (object obj, EventArgs ea)
            {
                panel.Dispose();
                borderPanel.Dispose();
                this.paths.Remove(folderPath);
            };

            panel.Controls.Add(label);
            panel.Controls.Add(removePicture);

            flowLayoutPanelForFolders.Controls.Add(panel);
            flowLayoutPanelForFolders.Controls.Add(borderPanel);
        }

        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // if (this.closing == false)
            // {
            //     e.Cancel = true;
            //     Hide();
            //     notifyIcon1.Visible = true;
            // }
        }

        private void SettingsForm_Resize(object sender, EventArgs e)
        {
            // if (this.WindowState == FormWindowState.Minimized)
            // {
            //     Hide();
            //     notifyIcon1.Visible = true;
            //     // this is for notification
            //     // notifyIcon1.ShowBalloonTip(500);
            // }

        }

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
        * @Description: add folder(s) to the setting's folder list. 
        **/
        private void settingsForm_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                string[] filePaths = (string[])e.Data.GetData(DataFormats.FileDrop, false);
                for (int i = 0; i < filePaths.Length; i++)
                {
                    String folderPath = filePaths[i];
                    // prevent to add root dirives such as C:\, D:\
                    if (folderPath.Equals("C:\\") || folderPath.Contains("C:\\Windows"))
                    {
                        return;
                    }
                    this.paths.Add(folderPath);

                    if (this.paths.Count != this.paths.Distinct().Count())
                    {
                        this.paths.Remove(folderPath);
                    }
                    else
                    {
                        addPathToFoldersList(folderPath);
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void settingsForm_DrapEnter(object sender, DragEventArgs e)
        {
            try
            {
                DragDropEffects effects = DragDropEffects.None;
                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                {
                    string folderPath = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
                    // Only allow folders to drop
                    if (Directory.Exists(folderPath))
                    {
                        effects = DragDropEffects.Copy;
                    }
                }
                e.Effect = effects;
            }
            catch (Exception ex)
            {

            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to clear the history?", "Clear History", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    string temp = Path.Combine(Constants.ProgramFilesFolder, Constants.MalcoreBasePath, @"\malcore");
                    if (Directory.Exists(temp))
                    {
                        Directory.Delete(temp, true);
                    }

                    this.paths.Clear();
                    flowLayoutPanelForFolders.Controls.Clear();

                    // Create directories for caching
                    // there was a problem for the installer. installer did not recognize the relative path
                    Helper.CreateFolders();

                    // remove all history from monitoring form
                    FormCollection fc = Application.OpenForms;
                    foreach (Form frm in fc)
                    {
                        if (frm.Name == "MonitoringForm")
                        {
                            MonitoringForm monitoringForm = (MonitoringForm)frm;
                            monitoringForm.RemoveAllScanedFiles();
                            break;
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }


        }

        private void pictureClearHistory_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to clear the history?", "Clear History", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    string temp = Path.Combine(Constants.ProgramFilesFolder, Constants.MalcoreBasePath, @"\malcore");
                    if (Directory.Exists(temp))
                    {
                        Directory.Delete(temp, true);
                    }

                    this.paths.Clear();
                    flowLayoutPanelForFolders.Controls.Clear();

                    // Create directories for caching
                    // there was a problem for the installer. installer did not recognize the relative path
                    Helper.CreateFolders();

                    // remove all history from monitoring form
                    FormCollection fc = Application.OpenForms;
                    foreach (Form frm in fc)
                    {
                        if (frm.Name == "MonitoringForm")
                        {
                            MonitoringForm monitoringForm = (MonitoringForm)frm;
                            monitoringForm.RemoveAllScanedFiles();
                            break;
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }

        private void pictureLogout_Click(object sender, EventArgs e)
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

                // foreach (Form f in Application.OpenForms)
                // {
                //     if (f.Name == "MonitoringForm") {
                //         f.Close();
                //     }
                // }  
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
                LoginForm loginForm = new LoginForm();
                loginForm.Show(this);
            }
        }

        private void pictureAdd_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog folderDlg = new FolderBrowserDialog();
                folderDlg.ShowNewFolderButton = true;

                // Show the FolderBrowserDialog.  
                DialogResult result = folderDlg.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string folderPath = folderDlg.SelectedPath;

                    // prevent to add root dirives such as C:\, D:\ and C:\Windows
                    if (folderPath.Equals("C:\\") || folderPath.Contains("C:\\Windows"))
                    {
                        return;
                    }
                    this.paths.Add(folderPath);

                    if (this.paths.Count != this.paths.Distinct().Count())
                    {
                        this.paths.Remove(folderPath);
                    }
                    else
                    {
                        addPathToFoldersList(folderPath);
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void pictureSave_Click(object sender, EventArgs e)
        {
            try
            {
                bool enableMornitoring = checkEnableMonitor.Checked;
                bool sendStatistics = checkSendStatistics.Checked;
                bool openOnStartup = checkOpenOnStartup.Checked;
                string minThreatScore = textMinScore.Text;

                var data = new SettingsData()
                {
                    enableMornitoring = enableMornitoring,
                    sendStatistics = sendStatistics,
                    openOnStartup = openOnStartup,
                    minThreatScore = minThreatScore,
                    paths = string.Join(",", this.paths.ToArray())
                };
                var settingsData = Newtonsoft.Json.JsonConvert.SerializeObject(data);

                RegistryKey? key = Registry.CurrentUser.OpenSubKey(Constants.RegistryMalcoreKey, true);
                var OldSettings = key.GetValue("SETTINGS");

                key.SetValue("SETTINGS", settingsData.ToString());
                key.Close();

                // RegistryKey startkeyForLocalMachine = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                RegistryKey startkeyForCurrentUser = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

                // old version for admin permission
                // RegistryKey startkey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\\WOW6432Node\\Microsoft\\Windows\\CurrentVersion\\Run", true);

                // register as start up
                if (openOnStartup)
                {
                    // startkeyForLocalMachine.SetValue("malcore", "\"C:\\Program Files (x86)\\Malcore Agent\\Malcore Agent\\MCDA-APP.exe\" /autostart");
                    startkeyForCurrentUser.SetValue("Malcore", "\"C:\\Program Files (x86)\\Malcore Agent\\Malcore Agent\\MCDA-APP.exe\" --process-start-args --startup");

                    // old version for admin permission
                    // startkey.SetValue("Malcore", "\"C:\\Program Files (x86)\\Malcore Agent\\Malcore Agent\\MCDA-APP.exe\" --process-start-args --startup");
                }
                else
                {
                    // startkeyForLocalMachine.DeleteValue("malcore");
                    if (startkeyForCurrentUser.GetValue("Malcore") != null)
                    {
                        startkeyForCurrentUser.DeleteValue("Malcore");
                    }

                    // old version for admin permission
                    // if(startkey.GetValue("Malcore") != null) {
                    //     startkey.DeleteValue("Malcore");
                    // }
                }
                // startkeyForLocalMachine.Close();
                startkeyForCurrentUser.Close();

                // old version for admin permission
                // startkey.Close();

                Hide();

                // If settings is updated, restart monitoring
                if (OldSettings == null || OldSettings.ToString() == "")
                {
                    // if first start the app after install, open monitoring form
                    MonitoringForm monitoringForm = new MonitoringForm();
                    monitoringForm.Visible = false;
                    monitoringForm.Show(this);
                }
                else
                {
                    // if settings are updated, restart monitoring
                    if ((OldSettings.ToString() != settingsData.ToString()))
                    {
                        FormCollection fc = Application.OpenForms;
                        foreach (Form frm in fc)
                        {
                            if (frm.Name == "MonitoringForm")
                            {
                                MonitoringForm monitoringForm = (MonitoringForm)frm;
                                monitoringForm.StartMonitoring();
                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // MessageBox.Show("save"+ex.ToString());
                Hide();
            }
        }
    }


    public class SettingsData
    {
        public bool enableMornitoring { get; set; }
        public bool sendStatistics { get; set; }
        public bool openOnStartup { get; set; }
        public string minThreatScore { get; set; }
        public string paths { get; set; }
    }
}
