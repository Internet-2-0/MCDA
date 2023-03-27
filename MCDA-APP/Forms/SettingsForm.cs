using System.Diagnostics;
using Microsoft.Win32;
using Newtonsoft.Json.Linq;

namespace MCDA_APP.Forms
{
    public partial class SettingsForm : Form
    {
        bool closing = false;
        List<string> paths = new List<string>();

        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            try
            {
                // set apikey and user email
                labelEmail.Text = Program.USEREMAIL;
                txtApikey.Text = Program.APIKEY;

                // Check if user authentication 
                RegistryKey key = Registry.CurrentUser.OpenSubKey(@".malcore");
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
                Debug.WriteLine(ex);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Hide();
            MonitoringForm monitoringForm = new MonitoringForm();
            monitoringForm.Visible = false;
            monitoringForm.Show(this);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                bool enableMornitoring = checkEnableMonitor.Checked;
                bool sendStatistics = checkSendStatistics.Checked;
                bool openOnStartup = checkOpenOnStartup.Checked;
                string minThreatScore = textMinScore.Text;
                string monitorFolders = "";

                var data = new SettingsData()
                {
                    enableMornitoring = enableMornitoring,
                    sendStatistics = sendStatistics,
                    openOnStartup = openOnStartup,
                    minThreatScore = minThreatScore,
                    monitorFolders = monitorFolders,
                    paths = string.Join(",", this.paths.ToArray())
                };
                var settingsData = Newtonsoft.Json.JsonConvert.SerializeObject(data);

                RegistryKey key = Registry.CurrentUser.OpenSubKey(@".malcore", true);
                key.SetValue("SETTINGS", settingsData.ToString());
                key.Close();

                RegistryKey startkey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                if (openOnStartup)
                {
                    startkey.SetValue("malcore", "C:\\Program Files (x86)\\Malcore Agent\\Malcore Agent\\MCDA-APP.exe");
                }
                else
                {
                    startkey.DeleteValue("malcore");
                }
                startkey.Close();

                Hide();
                MonitoringForm monitoringForm = new MonitoringForm();
                monitoringForm.Visible = false;
                monitoringForm.Show(this);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                Hide();
                MonitoringForm monitoringForm = new MonitoringForm();
                monitoringForm.Visible = false;
                monitoringForm.Show(this);
            }
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
                Debug.WriteLine(ex);
            }

            Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.Show(this);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = true;
            // Show the FolderBrowserDialog.  
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                string folderPath = folderDlg.SelectedPath;
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

        private void addPathToFoldersList(string folderPath)
        {
            Panel panel = new Panel();
            panel.Width = 210;
            panel.Height = 18;

            Panel borderPanel = new Panel();
            borderPanel.Height = 1;
            borderPanel.Width = 210;
            borderPanel.BackColor = Color.WhiteSmoke;

            Label label = new Label();
            label.Text = folderPath;
            label.ForeColor = Color.White;
            label.AutoSize = true;
            label.MaximumSize = new System.Drawing.Size(190, 0);

            PictureBox removePicture = new PictureBox();
            removePicture.Size = new System.Drawing.Size(18, 18);
            removePicture.Padding = new Padding(0, 0, 0, 0);
            removePicture.Location = new System.Drawing.Point(192, 2);
            removePicture.Image = pictureBox2.Image;
            // removePicture.Image = Image.FromFile("img/close.png");
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
            if (this.closing == false)
            {
                e.Cancel = true;
                Hide();
                notifyIcon1.Visible = true;
            }
        }

        private void SettingsForm_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon1.Visible = true;
                // this is for notification
                // notifyIcon1.ShowBalloonTip(500);
            }

        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.closing = true;
            notifyIcon1.Visible = false;
            notifyIcon1.Dispose();
            Application.Exit();
        }
    }


    public class SettingsData
    {
        public bool enableMornitoring { get; set; }
        public bool sendStatistics { get; set; }
        public bool openOnStartup { get; set; }
        public string minThreatScore { get; set; }
        public string monitorFolders { get; set; }
        public string paths { get; set; }
    }
}
