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
    }
}
