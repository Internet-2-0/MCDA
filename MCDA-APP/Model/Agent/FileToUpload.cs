namespace MCDA_APP.Model.Agent
{
    public class FileToUpload
    {
        public string? FileName { get; set; }
        public byte[]? Binary { get; set; }

        public FileToUpload(string? fileName, byte[]? binary)
        {
            FileName = fileName;
            Binary = binary;
        }
    }
}
