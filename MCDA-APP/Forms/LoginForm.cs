using MCDA_APP.Forms;
using Microsoft.Win32;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Text;
using System.Reflection;
using MCDA_APP.Model;
using MCDA_APP.Controls;

namespace MCDA_APP
{
    public partial class LoginForm : Form
    {
        public LoginForm() => InitializeComponent();

        //TODO: HTTP requests should be handled in it's own class
        private async void BtnLogin_Click(object sender, EventArgs e)
        {
            LabelError.Visible = false;

            string username = TxtEmail.Text;
            string password = TxtPassword.Text;

            if (string.IsNullOrEmpty(username))
            {
                LabelError.Visible = true;
                LabelError.Text = "Please enter your email address";
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                LabelError.Visible = true;
                LabelError.Text = "Please enter your password";
                return;
            }
            if (!CheckAgree.Checked)
            {
                LabelError.Visible = true;
                LabelError.Text = "Please agree terms & conditions";
                return;
            }

            try
            {
                HttpClient client = new HttpClient();
                string url = System.Configuration.ConfigurationManager.AppSettings["URI"] + "/auth/login";

                var data = new UserData() { Email = username, Password = password };
                var jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(data);

                var requestContent = new StringContent(jsonData, Encoding.Unicode, "application/json");
                var response = await client.PostAsync(url, requestContent);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    JObject json = JObject.Parse(content);
                    var authdata = "";
                    var userdata = json["data"];
                    Boolean success = json["success"] != null ? (Boolean)json["success"] : false;

                    Debug.WriteLine("btnLogin_Click_1################################################" + userdata);

                    if (success == true && userdata != null)
                    {
                        authdata = userdata["user"].ToString();

                        if (authdata != "")
                        {
                            // store API Key and settings info to registory
                            RegistryKey key = Registry.CurrentUser.CreateSubKey(Constants.RegistryMalcoreKey);
                            key.SetValue("API_KEY", authdata);
                            key.SetValue("SETTINGS", "");
                            key.Close();

                            Program.APIKEY = userdata["user"]["apiKey"].ToString();
                            Program.USEREMAIL = userdata["user"]["email"].ToString();
                            Program.SUBSCRIPTION = userdata["user"]["subscription"]["name"].ToString();

                            Hide();
                            SettingsForm settingsForm = new SettingsForm();
                            settingsForm.Show(this);
                        }
                        else
                        {
                            LabelError.Visible = true;
                            LabelError.Text = "Something went wrong";
                        }
                    }
                    else
                    {
                        var errorMsg = json["messages"][0]["message"];
                        LabelError.Visible = true;
                        LabelError.Text = errorMsg.ToString();
                    }
                }
                else
                {
                    LabelError.Visible = true;
                    LabelError.Text = "Something went wrong";
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);

                LabelError.Visible = true;
                LabelError.Text = "Something went wrong";
            }
        }

        private void LinkAgree_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => CheckAgree.Checked = true;

        private void LabelTerms_Click(object sender, EventArgs e) => Program.OpenBrowser(Constants.MalcoreTerms);

        private void LabelPrivacyPolicy_Click(object sender, EventArgs e) => Program.OpenBrowser(Constants.MalcorePrivacy);

        private void LabelMalcore_Click(object sender, EventArgs e) => Program.OpenBrowser(Constants.MalcoreBaseUrl);

        private void LabelSignup_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Program.OpenBrowser($"https://malcore.io/register?utm_source=agent&utm_medium=login&utm_campaign=v{Helper.GetAgentVersion()}&utm_content=win");
            try
            {
                SignupForm signupForm = new SignupForm();
                signupForm.ShowDialog(this);
            }
            catch (Exception ex)
            {
            }
        }

        private void LoginFormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                Debug.WriteLine("closed................" + Path.GetFileNameWithoutExtension(Assembly.GetEntryAssembly()?.Location));
                Application.Exit();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private void LoginFormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Environment.Exit(0);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            MalcoreFooter malcoreFooter = new()
            {
                Dock = DockStyle.Bottom
            };

            Controls.Add(malcoreFooter);
        }

        private async void PictureLogin_Click(object sender, EventArgs e)
        {
            LabelError.Visible = false;

            string username = TxtEmail.Text;
            string password = TxtPassword.Text;

            if (string.IsNullOrEmpty(username))
            {
                LabelError.Visible = true;
                LabelError.Text = "Please enter your email address";
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                LabelError.Visible = true;
                LabelError.Text = "Please enter your password";
                return;
            }
            if (!CheckAgree.Checked)
            {
                LabelError.Visible = true;
                LabelError.Text = "Please agree terms & conditions";
                return;
            }

            try
            {
                HttpClient client = new HttpClient();
                string url = System.Configuration.ConfigurationManager.AppSettings["URI"] + "/auth/login";

                var data = new UserData() { Email = username, Password = password };
                var jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(data);

                var requestContent = new StringContent(jsonData, Encoding.Unicode, "application/json");
                var response = await client.PostAsync(url, requestContent);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    JObject json = JObject.Parse(content);
                    var authdata = "";
                    var userdata = json["data"];
                    Boolean success = json["success"] != null ? (Boolean)json["success"] : false;

                    Debug.WriteLine("btnLogin_Click_1################################################" + userdata);

                    if (success == true && userdata != null)
                    {
                        authdata = userdata["user"].ToString();

                        if (authdata != "")
                        {
                            // store API Key and settings info to registory
                            RegistryKey key = Registry.CurrentUser.CreateSubKey(Constants.RegistryMalcoreKey);
                            key.SetValue("API_KEY", authdata);
                            key.SetValue("SETTINGS", "");
                            key.Close();

                            Program.APIKEY = userdata["user"]["apiKey"].ToString();
                            Program.USEREMAIL = userdata["user"]["email"].ToString();
                            Program.SUBSCRIPTION = userdata["user"]["subscription"]["name"].ToString();

                            Hide();
                            SettingsForm settingsForm = new SettingsForm();
                            settingsForm.Show(this);
                        }
                        else
                        {
                            LabelError.Visible = true;
                            LabelError.Text = "Something went wrong";
                        }
                    }
                    else
                    {
                        var errorMsg = json["messages"][0]["message"];
                        LabelError.Visible = true;
                        LabelError.Text = errorMsg.ToString();
                    }
                }
                else
                {
                    LabelError.Visible = true;
                    LabelError.Text = "Something went wrong";
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);

                LabelError.Visible = true;
                LabelError.Text = "Something went wrong";
            }
        }
    }
}
