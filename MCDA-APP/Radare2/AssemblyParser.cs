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

        public static string SetRichText(string data)
        {
            List<string> lines = data.Split(new[] { '\n' }, StringSplitOptions.None).ToList();
            StringBuilder sb = new();

            // \red208\green48\blue128 is the custom pinkish color for comments,
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
                    // Comment line: apply pinkish color
                    sb.Append($@"{{\cf1 {trimmedLine}}}\par");
                }
                else
                {
                    // Regular line: apply white color
                    sb.Append($@"{{\cf2 {trimmedLine}}}\par");
                }
            }

            sb.Append("}");

            return sb.ToString();
        }
    }
}
