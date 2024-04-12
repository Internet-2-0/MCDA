using Microsoft.Win32;
using System.Reflection;

namespace MCDA_APP
{
    internal class Helper
    {
        public static void CreateFolders()
        {

            string[] folders = new string[] { "malcore", @"malcore\threat", @"malcore\doc", @"malcore\threat\drag",
                        @"malcore\doc\drag" };

            foreach (string folder in folders)
            {
                //string temp = Path.Combine(Constants.ProgramFilesFolder, Constants.MalcoreBasePath, folder);
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }
            }
        }

        public static string GetAgentVersion()
        {
            Version? version = Assembly.GetExecutingAssembly().GetName().Version;
            return $"{version?.Major}.{version?.Minor}.{version?.Build}";
        }

        public static void SetRegistryKey(string key, string value)
        {
            RegistryKey regKey = Registry.CurrentUser.CreateSubKey(Constants.RegistryMalcoreKey, true) 
                ?? throw new NullReferenceException("Registry key does not exist");

            regKey.SetValue(key, value);
            regKey.Close();
        }

        public static void DeleteKeys(string[] keys)
        {
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey(Constants.RegistryMalcoreKey, true)
                ?? throw new NullReferenceException("Registry key does not exist");

            foreach (string key in keys)
            {
                regKey.DeleteValue(key);
            }

            regKey.Close();
        }

        public static string? GetRegistryKey(string key)
        {
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey(Constants.RegistryMalcoreKey) 
                ?? throw new NullReferenceException("Registry key does not exist");

            return (string?)regKey?.GetValue(key);
        }
    }
}
