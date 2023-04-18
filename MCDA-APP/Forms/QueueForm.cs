using System.Diagnostics;
using Microsoft.Win32;
using System.Security.AccessControl;
using System.Text;
using System.Security.Principal;

namespace MCDA_APP.Forms
{
    public partial class QueueForm : Form
    {
        private System.Windows.Forms.Timer drawTimer;
        public QueueForm()
        {
            InitializeComponent();

            labelEmail.Text = Program.USEREMAIL;
            AddItemToViewQueueFlowLayoutPanel(true);
            InitTimer();
        }

        /**
        * @Description: Redraw the queue items in QueueForm 
        **/
        private void CheckItemIsDrawed()
        {

            if (viewQueueFlowLayoutPanel != null)
            {
                List<Control> listControls = viewQueueFlowLayoutPanel.Controls.Cast<Control>().ToList();

                // Check if queued files are submitted to the api and update the view
                if (listControls.Count() > Program.filePool.Count())
                {
                    int removed = listControls.Count() - Program.filePool.Count();
                    for (int i = 0; i < listControls.Count() - Program.filePool.Count(); i++)
                    {
                        Control control = listControls[i];
                        viewQueueFlowLayoutPanel.Controls.Remove(control);
                        control.Dispose();
                    }
                }

                listControls = viewQueueFlowLayoutPanel.Controls.Cast<Control>().ToList();
                if (listControls.Count() > 0)
                {
                    // Remove to top button from first element
                    Panel firstPanel = (Panel)listControls[0];
                    List<Control> buttonControls = firstPanel.Controls.Cast<Control>().ToList();
                    for (int i = 0; i < buttonControls.Count(); i++)
                    {
                        if (buttonControls[i].Name == "totopButton")
                        {
                            buttonControls[i].Visible = false;
                        }
                    }

                }
                else
                {
                    this.Dispose();
                }
            }
        }

        /**
        * @Description: Start monitoring queue file changes
        **/
        public void InitTimer()
        {
            drawTimer = new System.Windows.Forms.Timer();
            drawTimer.Tick += new EventHandler(RedrawPanel);
            drawTimer.Interval = 2000; // in miliseconds
            drawTimer.Start();
        }
        private void RedrawPanel(object sender, EventArgs e)
        {
            // AddItemToViewQueueFlowLayoutPanel(false);
            CheckItemIsDrawed();
        }

        /**
        * @Description: Add all queue files to QueueFlowLayout to display
        * @param setPermission: If true, enable file permission before perform draw 
        * @return void
        **/
        private void AddItemToViewQueueFlowLayoutPanel(bool setPermission)
        {
            viewQueueFlowLayoutPanel.Controls.Clear();
            int index = 0;
            foreach (string fileName in Program.filePool)
            {
                if (setPermission)
                {
                    handleRelease(fileName, true);
                }

                DrawViewQueueFlowLayoutPanel(fileName, index);
                index++;
            }

        }

        /**
        * @Description: Draw a queue files in QueueFlowLayout
        * @param setPermission: If true, enable file permission before perform draw 
        * @return void
        **/
        private void DrawViewQueueFlowLayoutPanel(string filePath, int index)
        {
            string fileName = Path.GetFileName(filePath) + " (Queued)";

            // item panel
            Panel panel = new Panel();
            panel.Width = 501;
            panel.Height = 32;
            panel.BackColor = Color.Black;
            panel.BorderStyle = BorderStyle.FixedSingle;

            // file label
            Label fileLabel = new Label();
            fileLabel.Name = "fileLabel";
            fileLabel.Font = new Font("Calibri", 12, FontStyle.Bold);
            fileLabel.AutoSize = false;
            fileLabel.Width = 200;
            fileLabel.Location = new System.Drawing.Point(12, 6);

            Button totopButton = new Button();
            totopButton.Name = "totopButton";
            totopButton.Text = "TO TOP";
            totopButton.Font = new Font("Calibri", 12, FontStyle.Bold);
            totopButton.BackColor = Color.Cyan;
            totopButton.ForeColor = Color.White;
            totopButton.FlatStyle = FlatStyle.Flat;
            totopButton.FlatAppearance.BorderSize = 0;
            totopButton.Width = 85;
            totopButton.Height = 28;
            totopButton.Location = new System.Drawing.Point(215, 2);
            totopButton.Click += delegate (object obj, EventArgs ea)
            {
                var list = Program.filePool.ToList();
                list.Remove(filePath);
                list.Insert(0, filePath);
                var queue = new Queue<string>(list);
                Program.filePool = queue;

                AddItemToViewQueueFlowLayoutPanel(false);

            };
            if (index == 0)
            {
                totopButton.Visible = false;
            }

            Button releaseButton = new Button();
            releaseButton.Name = "releaseButton";
            releaseButton.Text = "RELEASE";
            releaseButton.Font = new Font("Calibri", 12, FontStyle.Bold);
            releaseButton.BackColor = Color.Goldenrod;
            releaseButton.ForeColor = Color.White;
            releaseButton.FlatStyle = FlatStyle.Flat;
            releaseButton.FlatAppearance.BorderSize = 0;
            releaseButton.Width = 85;
            releaseButton.Height = 28;
            releaseButton.Location = new System.Drawing.Point(315, 2);
            releaseButton.Click += delegate (object obj, EventArgs ea)
            {

                handleRelease(filePath, false);
                releaseButton.Visible = false;

                string payload = "{\"type\":\"file_released\",\"payload\":{\"name\":\"" + fileName + "\",\"message\":\"File released\"}}";
                agentStat(payload);
            };
            if (HasWritePermission(filePath))
            {
                releaseButton.Visible = false;
            }

            Button removeButton = new Button();
            removeButton.Name = "removeButton";
            removeButton.Text = "DELETE";
            removeButton.Font = new Font("Calibri", 12, FontStyle.Bold);
            removeButton.BackColor = Color.Red;
            removeButton.ForeColor = Color.White;
            removeButton.FlatStyle = FlatStyle.Flat;
            removeButton.FlatAppearance.BorderSize = 0;
            removeButton.Width = 85;
            removeButton.Height = 28;
            removeButton.Location = new System.Drawing.Point(415, 2);
            removeButton.Click += delegate (object obj, EventArgs ea)
            {
                if (File.Exists(filePath))
                {
                    handleRelease(filePath, false);
                    File.Delete(filePath);
                }
                string folderName = Directory.GetParent(filePath) != null ? Directory.GetParent(filePath).FullName : filePath;
                string hashFileName = folderName.Replace("\\", "-").Replace(":", "") + fileName + "-hash.json";
                if (File.Exists("./malcore/doc/" + hashFileName))
                {
                    File.Delete("./malcore/doc/" + hashFileName);
                }
                panel.Dispose();

                var list = Program.filePool.ToList();
                list.Remove(filePath);
                var queue = new Queue<string>(list);
                Program.filePool = queue;

                AddItemToViewQueueFlowLayoutPanel(false);

                string payload = "{\"type\":\"file_deleted\",\"payload\":{\"name\":\"" + fileName + "\",\"type\":\"docfile\",\"message\":\"File deleted\"}}";
                agentStat(payload);

            };

            fileLabel.Text = fileName;
            fileLabel.ForeColor = Color.White;

            panel.Controls.Add(fileLabel);
            panel.Controls.Add(totopButton);
            panel.Controls.Add(removeButton);
            panel.Controls.Add(releaseButton);

            viewQueueFlowLayoutPanel.Controls.Add(panel);
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


        /**
        * @Description: Call agent/stat for log on the server
        * @param jsonData: json string for request data of the api 
        * @return api response as string.
        **/
        private async Task<string> agentStat(string jsonData)
        {
            try
            {
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
        * @Description: Check if file has write permission
        * @param FilePath: full file path
        * @return true if allowed
        **/
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
