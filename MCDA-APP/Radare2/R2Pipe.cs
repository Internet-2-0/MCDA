using System.Diagnostics;
using System.Text;

namespace MCDA_APP.Radare2
{
    public class R2Pipe : IDisposable
    {
        private Process _r2Process;

        public R2Pipe(string file, string r2executable)
        {
            if (file == null)
                throw new ArgumentNullException("File is null");

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

        public string RunCommand(string command)
        {
            _r2Process.StandardInput.WriteLine(command);
            _r2Process.StandardInput.Flush();

            StringBuilder sb = new StringBuilder();
            char buffer;
            int charCode;

            // Continue to read until a null character is encountered
            while ((charCode = _r2Process.StandardOutput.Read()) != -1)  // Read returns -1 if no more characters are available
            {
                buffer = (char)charCode;
                if (buffer == '\0')  // Check for null terminator
                    break;
                sb.Append(buffer);
            }

            return sb.ToString();
        }

        //public string RunCommand(string command)
        //{
        //    var sb = new StringBuilder();
        //    _r2Process.StandardInput.WriteLine(command);
        //    _r2Process.StandardInput.Flush();

        //    while (true)
        //    {
        //        int buffer = _r2Process.StandardOutput.Read();

        //        if (buffer == -1)
        //            break;

        //        sb.Append((char)buffer);
        //    }
        //    return sb.ToString();
        //}

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
