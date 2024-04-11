using MCDA_APP.Forms;
using Microsoft.Win32;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Reflection;
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
            _client.SendAgentStatus().GetAwaiter().GetResult();

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