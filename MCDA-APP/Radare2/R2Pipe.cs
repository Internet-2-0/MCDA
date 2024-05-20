using System.Diagnostics;
using System.Text;

namespace MCDA_APP.Radare2
{
    public class R2Pipe : IDisposable
    {
        private readonly Process _r2Process;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="file"></param>
        /// <param name="r2executable"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public R2Pipe(string file, string r2executable)
        {
            if (file == null)
                throw new ArgumentNullException("File is null");

            if (!File.Exists(file))
                throw new FileNotFoundException($"File '{file}' was not found!");

            _r2Process = new Process
            {
                StartInfo = new ProcessStartInfo()
                {
                    CreateNoWindow = true,
                    RedirectStandardOutput = true,
                    RedirectStandardInput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    Arguments = "-q0 " + file,
                    FileName = r2executable
                }
            };

            _r2Process.Start();
            _r2Process.StandardInput.AutoFlush = true;
            _r2Process.StandardInput.NewLine = "\n";
            _r2Process.StandardOutput.Read();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public string RunCommand(string command)
        {
            _r2Process.StandardInput.WriteLine(command);
            _r2Process.StandardInput.Flush();

            StringBuilder sb = new StringBuilder();
            char buffer;
            int charCode;

            while ((charCode = _r2Process.StandardOutput.Read()) != -1) 
            {
                buffer = (char)charCode;
                if (buffer == '\0') 
                    break;
                sb.Append(buffer);
            }

            return sb.ToString();
        }

        /// <summary>
        /// Exits and disposes of the _r2Process object
        /// </summary>
        public void Dispose()
        {
            if (!_r2Process.HasExited)
            {
                this.RunCommand("q!");
                _r2Process.WaitForExit();
            }
            _r2Process.Dispose();
        }
    }
}
