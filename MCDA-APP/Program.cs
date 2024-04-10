using MCDA_APP.Forms;
using Microsoft.Win32;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Text;
using System.Reflection;
using MCDA_APP.Model.Agent;
using MCDA_APP.Core;

namespace MCDA_APP
{
    internal static class Program
    {
        public static string APIKEY = "";
        public static string USEREMAIL = "";
        public static string SUBSCRIPTION = "";
        public static Queue<string> FilePool = new Queue<string>();
        public static Queue<string> PrecessedFilePool = new Queue<string>();
        public static Queue<string> DragFilePool = new Queue<string>();
        public static Client? _client;

        ///  The main entry point for the application.
        [STAThread]
        static void Main()
        {
            // Kill current process if there is already process that is running
            if (Process.GetProcessesByName(Path.GetFileNameWithoutExtension(Assembly.GetEntryAssembly()?.Location)).Length > 1) Process.GetCurrentProcess().Kill();

            _client = new Client();
            //_client.SendAgentStatus().GetAwaiter().GetResult();

            SendAgentStatus("{\"type\":\"started\",\"payload\":{\"message\":\"Agent Started\"}}").GetAwaiter().GetResult();

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            try
            {
                // Check user authentication status
                RegistryKey? key = Registry.CurrentUser.OpenSubKey(Constants.RegistryMalcoreKey);
                if (key != null)
                {
                    var API_KEY = key.GetValue("API_KEY");
                    // if user already log in
                    if (API_KEY != null)
                    {
                        JObject json = JObject.Parse(API_KEY.ToString());
                        APIKEY = json["apiKey"].ToString();
                        USEREMAIL = json["email"].ToString();
                        SUBSCRIPTION = json["subscription"]["name"].ToString();

                        var SETTINGS = key.GetValue("SETTINGS");

                        // if user have saved settings, go to monitoring
                        if (SETTINGS != null && SETTINGS.ToString() != "")
                        {
                            Application.Run(new MonitoringForm());
                        }
                        else
                        {
                            Application.Run(new SettingsForm());
                        }
                    }
                    else
                    {
                        Application.Run(new LoginForm());
                    }
                }
                else
                {
                    Application.Run(new LoginForm());
                }
            }
            catch (Exception ex)
            {
                // Write out any exceptions.
                Debug.WriteLine(ex);
                Application.Run(new LoginForm());
            }

        }

        private static async Task<string> SendAgentStatus(string jsonData)
        {
            try
            {
                AgentStatus agentStatus = new()
                {
                    Payload = new Payload
                    {
                        Message = "Agent Started"
                    },
                    Type = "started"
                };

                string url = System.Configuration.ConfigurationManager.AppSettings["URI"] + "/agent/stat";

                using (var client = new HttpClient())
                {
                    var requestContent = new StringContent(jsonData, Encoding.Unicode, "application/json");
                    client.DefaultRequestHeaders.Add("apiKey", Program.APIKEY);
                    client.DefaultRequestHeaders.Add("source", "agent");
                    client.DefaultRequestHeaders.Add("agentVersion", "1.1.1");

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
            catch (Exception)
            {
                return "";
            }
        }

        public static void OpenBrowser(string url)
        {
            try
            {

                ProcessStartInfo processStartInfo = new()
                {
                    FileName = url,
                    UseShellExecute = true
                };

                Process.Start(processStartInfo);

            }
            catch (Exception)
            {
               
            }
        }
    }
}