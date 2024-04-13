using MCDA_APP.Forms;
using System.Diagnostics;
using System.Reflection;
using MCDA_APP.Controls;
using MCDA_APP.Core;

namespace MCDA_APP
{
    public partial class LoginForm : Form
    {
        public LoginForm() => InitializeComponent();

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
                Program.AccountInformation = await Program.Client?.Login(username, password)!;

                if (!Program.AccountInformation!.Success)
                {
                    LabelError.Visible = true;
                    LabelError.Text = Program.AccountInformation.Message;

                    return;
                }

                if (string.IsNullOrEmpty(Program.AccountInformation.ApiKey))
                {
                    LabelError.Visible = true;
                    LabelError.Text = "Something went wrong";

                    return;
                }

                Helper.SetRegistryKey("API_KEY", Program.AccountInformation.ApiKey);
                Helper.SetRegistryKey("EMAIL", Program.AccountInformation.UserEmail!);
                Helper.SetRegistryKey("SUBSCRIPTION", Program.AccountInformation.Subscription!);
                Helper.SetRegistryKey("SETTINGS", "");

                await Program.Client.SendAgentStatus();

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
