using MCDA_APP.Forms;
using Microsoft.Win32;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Text;
using System.Reflection;
using MCDA_APP.Model;
using MCDA_APP.Controls;
using MCDA_APP.Model.Api;

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
                AccountInformation? account = await Program.Client?.Login(username, password)!;

                if (!account!.Success)
                {
                    LabelError.Visible = true;
                    LabelError.Text = account.Message;

                    return;
                }

                if (string.IsNullOrEmpty(account.ApiKey))
                {
                    LabelError.Visible = true;
                    LabelError.Text = "Something went wrong";

                    return;
                }

                Helper.SetRegistryKey("API_KEY", account.ApiKey);
                Helper.SetRegistryKey("EMAIL", account.UserEmail!);
                Helper.SetRegistryKey("SUBSCRIPTION", account.Subscription!);
                Helper.SetRegistryKey("SETTINGS", "");

                Program.APIKEY = account.ApiKey;
                Program.USEREMAIL = account.UserEmail!;
                Program.SUBSCRIPTION = account.Subscription!;

                Hide();

                SettingsForm settingsForm = new();
                settingsForm.Show(this);
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
            Program.OpenBrowser($"https://malcore.io/register?utm_source=agent&utm_medium=login&utm_campaign=v{Helper.GetAgentVersion()}&utm_content=win");
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
            Text = string.Format(Constants.MalcoreFormTitle, Helper.GetAgentVersion(), "Log in");
            MalcoreFooter malcoreFooter = new()
            {
                Dock = DockStyle.Bottom
            };

            Controls.Add(malcoreFooter);
        }
    }
}
