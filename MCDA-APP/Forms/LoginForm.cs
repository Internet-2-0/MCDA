using MCDA_APP.Forms;
using Microsoft.Win32;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.Metadata;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;
// using Windows.Web.Http;

namespace MCDA_APP
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            this.ActiveControl = txtEmail;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void btnLogin_Click_1(object sender, EventArgs e)
        {
            lblError.Visible = false;

            string username = txtEmail.Text;
            string password = txtPassword.Text;
            Debug.WriteLine(Program.APIKEY, username + ":" + password);

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
                Debug.WriteLine(response.StatusCode);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    // var userdata = JsonConvert.DeserializeObject(content);
                    JObject json = JObject.Parse(content);
                    var authdata = "";
                    var userdata = json["data"];
                    Boolean success = json["success"] != null ? (Boolean)json["success"] : false;
                    Debug.WriteLine("userdata=>" + userdata);


                    if (success == true && userdata != null)
                    {
                        authdata = userdata["user"].ToString();

                        if (authdata != "")
                        {
                            RegistryKey key = Registry.CurrentUser.CreateSubKey(@".malcore");
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
                        Debug.WriteLine(errorMsg);
                        lblError.Visible = true;
                        lblError.Text = errorMsg.ToString();
                    }

                    Debug.WriteLine(authdata);
                }
                else
                {
                    lblError.Visible = true;
                    lblError.Text = "Something went wrong";
                }

            }
            catch (Exception ex)
            {
                // Write out any exceptions.
                Debug.WriteLine(ex);

                lblError.Visible = true;
                lblError.Text = "Something went wrong";
            }
        }

        private void linkAgree_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.chkAgree.Checked = true;
        }
    }

    public class UserData
    {
        public string email { get; set; }
        public string password { get; set; }
    }

}
