using MCDA_APP.Forms;
using Microsoft.Win32;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Text;

namespace MCDA_APP
{
    internal static class Program
    {
        public static string APIKEY = "";
        public static string USEREMAIL = "";
        public static Queue<string> FilePool = new Queue<string>();
        public static Queue<string> PrecessedFilePool = new Queue<string>();


        ///  The main entry point for the application.
        [STAThread]

        static void Main()
        {
            // Kill current process if there is already process that is running
            if (System.Diagnostics.Process.GetProcessesByName(System.IO.Path.GetFileNameWithoutExtension(System.Reflection.Assembly.GetEntryAssembly().Location)).Count() > 1) System.Diagnostics.Process.GetCurrentProcess().Kill();

            agentStat("{\"type\":\"started\",\"payload\":{\"message\":\"Agent Started\"}}");

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            try
            {
                // Check user authentication status
                RegistryKey key = Registry.CurrentUser.OpenSubKey(@".malcore");
                if (key != null)
                {
                    var API_KEY = key.GetValue("API_KEY");
                    // if user already log in
                    if (API_KEY != null)
                    {
                        JObject json = JObject.Parse(API_KEY.ToString());
                        APIKEY = json["apiKey"].ToString();
                        USEREMAIL = json["email"].ToString();

                        var SETTINGS = key.GetValue("SETTINGS");

                        // if user have saved settings, go to monitoring
                        if (SETTINGS != null && SETTINGS != "")
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

        private static async Task<string> agentStat(string jsonData)
        {
            try
            {
                string url = System.Configuration.ConfigurationManager.AppSettings["URI"] + "/agent/stat";

                using (var client = new HttpClient())
                {
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
                return "";
            }
        }

    }
}