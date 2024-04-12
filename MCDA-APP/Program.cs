using MCDA_APP.Forms;
using System.Diagnostics;
using System.Reflection;
using MCDA_APP.Core;

namespace MCDA_APP
{
    public static class Program
    {
        public static string? APIKEY = "";
        public static string? USEREMAIL = "";
        public static string? SUBSCRIPTION = "";
        public static Queue<string> FilePool = new Queue<string>();
        public static Queue<string> PrecessedFilePool = new Queue<string>();
        public static Queue<string> DragFilePool = new Queue<string>();
        public static Client? Client;

        ///  The main entry point for the application.
        [STAThread]
        static void Main()
        {
            // Kill current process if there is already process that is running
            if (Process.GetProcessesByName(Path.GetFileNameWithoutExtension(Assembly.GetEntryAssembly()?.Location)).Length > 1) Process.GetCurrentProcess().Kill();

            Client = new Client();

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            try
            {
                APIKEY = Helper.GetRegistryKey("API_KEY");
                USEREMAIL = Helper.GetRegistryKey("EMAIL");
                SUBSCRIPTION = Helper.GetRegistryKey("SUBSCRIPTION");
                var SETTINGS = Helper.GetRegistryKey("SETTINGS");

                if (string.IsNullOrEmpty(APIKEY))
                {
                    Client.SendAgentStatus().GetAwaiter().GetResult();
                    Application.Run(new LoginForm());
                    return;
                }

                if (!string.IsNullOrEmpty(SETTINGS)) 
                {
                    Application.Run(new MonitoringForm());
                }
                else
                {
                    Application.Run(new SettingsForm());
                }
            }
            catch (Exception ex)
            {
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