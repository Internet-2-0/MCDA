using System.Text;
using System.Text.RegularExpressions;

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
                    line.TrimStart().StartsWith("; XREFS:"))
                    continue;

                sb.AppendLine(line);
            }

            return sb.ToString();
        }
    }
}
