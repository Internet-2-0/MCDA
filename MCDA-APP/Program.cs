using MCDA_APP.Forms;
using Microsoft.Win32;
using System.Diagnostics;

namespace MCDA_APP
{
    internal static class Program
    {
        public static string APIKEY = "APIKEY here";
        public static string USEREMAIL = "USEREMAIL here";

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]

        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();


            // Check if user authentication 
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"MCDA\AUTH");
            if (key != null)
            {
                var API_KEY = key.GetValue("API_KEY");
                APIKEY = "test api key1";
                USEREMAIL = "test USEREMAIL1";
                Debug.WriteLine("APIKEY: " + API_KEY);

                if(API_KEY != null)
                {
                    Application.Run(new SettingsForm());
                }
            } else
            {
                Application.Run(new LoginForm());
            }
        }

    }
}