using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace MCDA_APP.Radare2
{
    public class AssemblyParser
    {
        public static string GetFunctionSignature(string data)
        {
            Match m = Regex.Match(data, "/.\\d+: (.*?)$");

            if (m.Success)
            {
                return m.Groups[2].Value;
            }

            return string.Empty;
        }

        public static string RemoveUnwantedComments(string data)
        {
            List<string> lines = data.Split(new[] { '\n' }, StringSplitOptions.None).ToList();
            StringBuilder sb = new();

            foreach (string line in lines)
            {
                if (line.TrimStart().StartsWith("; CODE XREF") ||
                    line.TrimStart().StartsWith("; CALL XREF") ||
                    line.TrimStart().StartsWith("; XREFS:") || 
                    line.TrimStart().StartsWith(";-- rip:") ||
                    line.TrimStart().StartsWith(";-- _start:") ||
                    line.TrimStart().StartsWith(";-- section..text:") ||
                    line.TrimStart().StartsWith("; XREFS") ||
                    line.TrimStart().StartsWith("..") ||
                    line.TrimStart().StartsWith("; DATA XREF"))
                    continue;

                string searchString = @"^\s*\d+:\s*";
                Match match = Regex.Match(line, searchString);

                if (match.Success)
                {
                    sb.AppendLine(HttpUtility.HtmlDecode(line.Substring(match.Length).TrimEnd()));
                }
                else
                {
                    sb.AppendLine(HttpUtility.HtmlDecode(line.TrimEnd()));
                }
            }

            return sb.ToString();
        }
    }
}
