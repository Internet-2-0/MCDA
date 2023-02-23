using MCDA_APP.Forms;
using Microsoft.Win32;
using Newtonsoft.Json.Linq;
using System.Diagnostics;

namespace MCDA_APP
{
    internal static class Program
    {
        public static string APIKEY = "";
        public static string USEREMAIL = "";

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]

        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            try
            {
                // Check if user authentication 
                RegistryKey key = Registry.CurrentUser.OpenSubKey(@"MCDA\AUTH");
                if (key != null)
                {
                    var API_KEY = key.GetValue("API_KEY");
                    if (API_KEY != null)
                    {
                        JObject json = JObject.Parse(API_KEY.ToString());
                        APIKEY = json["apiKey"].ToString(); 
                        USEREMAIL = json["email"].ToString();

                        Debug.WriteLine("APIKEY: " + APIKEY+USEREMAIL);

                        Application.Run(new SettingsForm());
                    } else
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

    }
}