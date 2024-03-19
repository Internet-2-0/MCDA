using MCDA_APP.Controls; 
using System.Text; 
using System.Diagnostics;
using MCDA_APP.Model;
using Newtonsoft.Json.Linq;


namespace MCDA_APP.Forms
{
    public partial class SignupForm : Form
    {
        public SignupForm()
        {
            InitializeComponent();
        }

        private async void PictureRegister_Click(object sender, EventArgs e)
        {

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
            Debug.WriteLine("################################################" + username + password);

            try
            {

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

                    if (success == true && userdata != null)
                    {
                        // authdata = userdata["user"].ToString();

                        // if (authdata != "")
                        // {
                        //     // store API Key and settings info to registory
                        //     RegistryKey key = Registry.CurrentUser.CreateSubKey(Constants.RegistryMalcoreKey);
                        //     key.SetValue("API_KEY", authdata);
                        //     key.SetValue("SETTINGS", "");
                        //     key.Close();

                        //     Program.APIKEY = userdata["user"]["apiKey"].ToString();
                        //     Program.USEREMAIL = userdata["user"]["email"].ToString();
                        //     Program.SUBSCRIPTION = userdata["user"]["subscription"]["name"].ToString();

                        //     Hide();
                        //     SettingsForm settingsForm = new SettingsForm();
                        //     settingsForm.Show(this);
                        // }
                        // else
                        // {
                        //     LabelError.Visible = true;
                        //     LabelError.Text = "Something went wrong";
                        // }
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
