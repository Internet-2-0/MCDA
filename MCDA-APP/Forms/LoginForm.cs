using MCDA_APP.Forms;
using Microsoft.Win32;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Text;

namespace MCDA_APP
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            this.ActiveControl = txtEmail;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
        }

        private async void btnLogin_Click_1(object sender, EventArgs e)
        {
            lblError.Visible = false;

            string username = txtEmail.Text;
            string password = txtPassword.Text;

            if (username == "" || username == null)
            {
                lblError.Visible = true;
                lblError.Text = "Please enter your email address";
                return;
            }
            if (password == "" || password == null)
            {
                lblError.Visible = true;
                lblError.Text = "Please enter your password";
                return;
            }
            if (!chkAgree.Checked)
            {
                lblError.Visible = true;
                lblError.Text = "Please agree terms & conditions";
                return;
            }

            try
            {
                HttpClient client = new HttpClient();
                string url = System.Configuration.ConfigurationManager.AppSettings["URI"] + "/auth/login";

                var data = new UserData() { email = username, password = password };
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

                    if (success == true && userdata != null)
                    {
                        authdata = userdata["user"].ToString();

                        if (authdata != "")
                        {
                            // store API Key and settings info to registory
                            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\\Malcore");
                            key.SetValue("API_KEY", authdata);
                            key.SetValue("SETTINGS", "");
                            key.Close();

                            Program.APIKEY = userdata["user"]["apiKey"].ToString();
                            Program.USEREMAIL = userdata["user"]["email"].ToString();

                            Hide();
                            SettingsForm settingsForm = new SettingsForm();
                            settingsForm.Show(this);
                        }
                        else
                        {
                            lblError.Visible = true;
                            lblError.Text = "Something went wrong";
                        }
                    }
                    else
                    {
                        var errorMsg = json["messages"][0]["message"];
                        lblError.Visible = true;
                        lblError.Text = errorMsg.ToString();
                    }
                }
                else
                {
                    lblError.Visible = true;
                    lblError.Text = "Something went wrong";
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);

                lblError.Visible = true;
                lblError.Text = "Something went wrong";
            }
        }

        private void linkAgree_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.chkAgree.Checked = true;
        }

        private void lblTerms_Click(object sender, EventArgs e)
        {
            Program.OpenBrowser("https://malcore.io/terms");
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Program.OpenBrowser("https://malcore.io/policy");
        }

        private void lblMalcore_Click(object sender, EventArgs e)
        {
            Program.OpenBrowser("https://malcore.io");
        }

        private void labelSignup_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // this link should be updated based on app version
            Program.OpenBrowser("https://malcore.io/register?utm_source=agent&utm_medium=login&utm_campaign=v1.0.0&utm_content=win");
        }

        private void LoginFormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                Debug.WriteLine("closed................" + System.IO.Path.GetFileNameWithoutExtension(System.Reflection.Assembly.GetEntryAssembly().Location));
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
    }

    public class UserData
    {
        public string email { get; set; }
        public string password { get; set; }
    }

}
