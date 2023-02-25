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
using Microsoft.Win32;
using Newtonsoft.Json.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Windows;

namespace MCDA_APP.Forms
{
    public partial class SettingsForm : Form
    {
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
                        // monitorFolders = "";

                        Debug.WriteLine("SETTINGS::::::::::: " + json + SETTINGS);

                    }
                }

                // flowLayoutPanelForFolders.HorizontalScroll.Maximum = 0;
                // flowLayoutPanelForFolders.AutoScroll = false;
                // flowLayoutPanelForFolders.VerticalScroll.Visible = false;
                // flowLayoutPanelForFolders.AutoScroll = true;

            }
            catch (Exception ex)
            {
                // Write out any exceptions.
                Debug.WriteLine(ex);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Hide();
            MonitoringForm monitoringForm = new MonitoringForm();
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
                    monitorFolders = monitorFolders
                };
                var settingsData = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                Debug.WriteLine("Settings write::" + settingsData);

                RegistryKey key = Registry.CurrentUser.OpenSubKey(@".malcore", true);
                key.SetValue("SETTINGS", settingsData.ToString());
                key.Close();

                Hide();
                MonitoringForm monitoringForm = new MonitoringForm();
                monitoringForm.Show(this);
            }
            catch (Exception ex)
            {
                // Write out any exceptions.
                Debug.WriteLine(ex);

                Hide();
                MonitoringForm monitoringForm = new MonitoringForm();
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
                // Write out any exceptions.
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
                Debug.WriteLine("file dialog:::::::::::::" + folderPath);
                // listMonitorFolders.Items.Add(folderPath); 
                Panel panel = new Panel();
                panel.Width = 220;
                panel.Height = 18;

                Panel borderPanel = new Panel();
                borderPanel.Height = 1;
                borderPanel.Width = 220;
                borderPanel.BackColor = Color.WhiteSmoke;

                Label label = new Label();
                label.Text = folderPath;
                label.ForeColor = Color.White;
                label.AutoSize = false;
                label.Width = 200;

                Button removeButton = new Button();
                removeButton.Text = "X";
                removeButton.Size = new System.Drawing.Size(18, 23);
                removeButton.ForeColor = Color.DarkRed;
                removeButton.FlatStyle = FlatStyle.Flat;
                removeButton.FlatAppearance.BorderSize = 0;
                removeButton.Padding = new Padding(0, 0, 0, 0);
                removeButton.Location = new System.Drawing.Point(200, -4);
                removeButton.Click += delegate (object obj, EventArgs ea)
                {
                    panel.Dispose();
                    borderPanel.Dispose();
                };

                panel.Controls.Add(label);
                panel.Controls.Add(removeButton);

                flowLayoutPanelForFolders.Controls.Add(panel);
                flowLayoutPanelForFolders.Controls.Add(borderPanel);

                // Environment.SpecialFolder root = folderDlg.RootFolder;
            }

            // this.openFileDialog.Filter = "All files (*.*)|*.*";
            // this.openFileDialog.Multiselect = true;
            // this.openFileDialog.Title = "Select Photos";
            // DialogResult dr = this.openFileDialog.ShowDialog();
            // if (dr == System.Windows.Forms.DialogResult.OK)
            // {
            //     foreach (String file in openFileDialog.FileNames)
            //     {
            //         try
            //         {
            //             Debug.WriteLine("file dialog:::::::::::::" + file);
            //         }
            //         catch (Exception ex)
            //         {
            //             MessageBox.Show("Error: " + ex.Message);
            //         }
            //     }
            // }
        }
    }

    public class SettingsData
    {
        public bool enableMornitoring { get; set; }
        public bool sendStatistics { get; set; }
        public bool openOnStartup { get; set; }
        public string minThreatScore { get; set; }
        public string monitorFolders { get; set; }
    }
}
