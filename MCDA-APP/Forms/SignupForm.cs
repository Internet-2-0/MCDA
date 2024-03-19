using MCDA_APP.Controls;
using System.Text;
using System.Text.RegularExpressions;
using System.Diagnostics;
using MCDA_APP.Model;
using Newtonsoft.Json.Linq;


namespace MCDA_APP.Forms
{
    public partial class SignupForm : Form
    {
        bool submitting = false;

        public SignupForm()
        {
            InitializeComponent();
        }

        private async void PictureRegister_Click(object sender, EventArgs e)
        {

            LabelError.Visible = false;
            if (this.submitting)
            {
                Debug.WriteLine("submitting################################################");
                return;
            }

            string username = TxtRegEmail.Text;
            string password = TxtRegPassword.Text;
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
            if(!IsPasswordValid(password)) {
                LabelError.Visible = true;
                LabelError.Text = "Requires at least six characters, one digit and one special character.";
                return;
            }
            Debug.WriteLine("################################################" + username + password);

            try
            {
                this.submitting = true;
                HttpClient client = new HttpClient();
                string url = System.Configuration.ConfigurationManager.AppSettings["URI"] + "/auth/register";

                var data = new UserData() { Email = username, Password = password };
                var jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(data);

                var requestContent = new StringContent(jsonData, Encoding.Unicode, "application/json");
                var response = await client.PostAsync(url, requestContent);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    Debug.WriteLine("PictureRegister_Click################################################" + content);
                    JObject json = JObject.Parse(content);
                    var authdata = "";

                    var userdata = json["data"];
                    Boolean success = json["success"] != null ? (Boolean)json["success"] : false;

                    Debug.WriteLine("PictureRegister_Click userdata################################################" + userdata);

                    var errorMsg = json["messages"][0]["message"];

                    if (success == true && userdata != null)
                    {
                        errorMsg = "User created successfully, please verify your email.";
                    } else {
                        this.submitting = false;
                    }

                    LabelError.Visible = true;
                    LabelError.Text = errorMsg.ToString();

                }
                else
                {
                    LabelError.Visible = true;
                    LabelError.Text = "Something went wrong";
                    this.submitting = false;
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);

                LabelError.Visible = true;
                LabelError.Text = "Something went wrong";
                this.submitting = false;

            }
        }

        static bool IsPasswordValid(string password)
        {
            Regex pwdValidator = new Regex(@"^(?=.*\d)(?=.*[!?@#,.;()\[\]<>+\-\/$%^&*])[a-zA-Z0-9!?@;#,\[\]<>.()+\-\/$%;^&*]{6,99}$");

            return pwdValidator.IsMatch(password);
        }

        private void SignupForm_Load(object sender, EventArgs e)
        {

            MalcoreFooter malcoreFooter = new()
            {
                Dock = DockStyle.Bottom
            };

            Controls.Add(malcoreFooter);
        }

        private void TxtRegEmail_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
