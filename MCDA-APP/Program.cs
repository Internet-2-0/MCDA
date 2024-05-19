using MCDA_APP.Forms;
using System.Diagnostics;
using System.Reflection;
using MCDA_APP.Core;
using MCDA_APP.Model.Api;

namespace MCDA_APP
{
    public static class Program
    {
        public static Queue<string> FilePool = new Queue<string>();
        public static Queue<string> PrecessedFilePool = new Queue<string>();
        public static Queue<string> DragFilePool = new Queue<string>();
        public static Client? Client { private set; get; }
        public static AccountInformation? AccountInformation { set; get; }

        ///  The main entry point for the application.
        [STAThread]
        static void Main()
        {
            // Kill current process if there is already process that is running
            if (Process.GetProcessesByName(Path.GetFileNameWithoutExtension(Assembly.GetEntryAssembly()?.Location)).Length > 1) Process.GetCurrentProcess().Kill();

            Client = new Client();
            AccountInformation = new AccountInformation();

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            HexDump hexDump = new HexDump();
            hexDump.Show();
            //Dissasembly d = new Dissasembly();
            //d.Show();

            //new CodeReuse().Show();

            try
            {
                AccountInformation.ApiKey = Helper.GetRegistryKey("API_KEY");
                AccountInformation.UserEmail = Helper.GetRegistryKey("EMAIL");
                AccountInformation.Subscription = Helper.GetRegistryKey("SUBSCRIPTION");
                var SETTINGS = Helper.GetRegistryKey("SETTINGS");

                if (string.IsNullOrEmpty(AccountInformation.ApiKey))
                {
                    //Client.SendAgentStatus().GetAwaiter().GetResult();
                    Application.Run(new LoginForm());
                    return;
                }

                Client.AddApiKey(AccountInformation.ApiKey);

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