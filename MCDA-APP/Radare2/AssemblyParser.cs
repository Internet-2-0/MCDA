using System.Text;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

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

        public static string SetRichText(string data)
        {
            List<string> lines = data.Split(new[] { '\n' }, StringSplitOptions.None).ToList();
            StringBuilder sb = new();

            // \red208\green48\blue128 pinkish color for comments,
            // \red255\green255\blue255 regular text
            // \red0\green230\blue118 address color
            string rtfHeader = @"{\rtf1\ansi\deff0{\colortbl ;\red216\green88\blue194;\red255\green255\blue255;}";
            sb.Append(rtfHeader);

            foreach (string line in lines)
            {
                string trimmedLine = line.TrimEnd();

                if (line.TrimStart().StartsWith("; CODE XREF") ||
                    line.TrimStart().StartsWith("; CALL XREF"))
                    continue;

                if (trimmedLine.StartsWith(";"))
                {
                    sb.Append($@"{{\cf1 {trimmedLine}}}\par");
                }
                else
                {
                    sb.Append($@"{{\cf2 {trimmedLine}}}\par");
                }
            }
            sb.Append("}");
            string result = sb.ToString();

            Regex regex = new Regex(@"\b0x[a-fA-F0-9]+\b");
            int lastPos = 0;

            foreach (Match match in regex.Matches(result))
            {
                sb.Append(@"\cf1 " + EscapeRtf(result.Substring(lastPos, match.Index - lastPos)));
                sb.Append(@"\cf2 " + EscapeRtf(match.Value));

                lastPos = match.Index + match.Length;
            }

            sb.Append(@"\cf1 " + EscapeRtf(result.Substring(lastPos)));
            sb.Append(@"\par}");

            return result;
        }

        private static string EscapeRtf(string text)
        {
            return text.Replace(@"\", @"\\").Replace("{", @"\{").Replace("}", @"\}");
        }
    }
}
