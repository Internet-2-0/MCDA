namespace MCDA_APP
{
    internal class Helper
    {
        public static void CreateFolders()
        {
            string path = @"Malcore Agent\Malcore Agent\";

            string[] folders = new string[] { "malcore", @"malcore\threat", @"malcore\doc", @"malcore\threat\drag",
                        @"malcore\doc\drag" };

            foreach (string folder in folders)
            {
                string temp = Path.Combine(Constants.ProgramFilesFolder, path, folder);
                if (!Directory.Exists(temp))
                {
                    Directory.CreateDirectory(temp);
                }
            }
        }
    }
}
