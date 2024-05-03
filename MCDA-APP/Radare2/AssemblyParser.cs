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
            //Regex regexAsm = new Regex("(0x[0-9a-fA-F]+\\s+)(.*?)(?:(;.*?))?$", RegexOptions.Multiline);

            List<string> lines = data.Split(new[] { '\n' }, StringSplitOptions.None).ToList();
            StringBuilder sb = new();

            // \red208\green48\blue128 pinkish color for comments,
            // \red255\green255\blue255 regular text
            // \red0\green230\blue118 address color
            //string rtfHeader = @"{\rtf1\ansi\deff0{\colortbl;\red216\green88\blue194;\red255\green255\blue255;\red0\green230\blue118;}";
            //sb.Append(rtfHeader);

            foreach (string line in lines)
            {
                //string trimmedLine = line.TrimEnd();

                if (line.TrimStart().StartsWith("; CODE XREF") ||
                    line.TrimStart().StartsWith("; CALL XREF") ||
                    line.TrimStart().StartsWith("; XREFS:"))
                    continue;

                sb.AppendLine(line);
                //if (trimmedLine.StartsWith(";"))
                //{
                //    sb.Append($@"{{\cf1 {trimmedLine}}}\par");
                //}
                //else
                //{
                //    Regex addressesRegex = new Regex("(0x[0-9a-fA-F]+)");
                //    Match matchAddresses = addressesRegex.Match(line);

                //    if (matchAddresses.Success)
                //    {
                //        sb.Append(line.Replace(matchAddresses.Groups[1].Value, 
                //            $@"{{\cf3 {matchAddresses.Groups[1].Value}}}") + @"\par");
                //    }
                //    else
                //    {
                //        sb.Append($@"{{\cf2 {line}}}\par");
                //    }

                //    //sb.Append($@"{{\cf2 {trimmedLine}}}\par");
                //    //Match match = regexAsm.Match(line);

                //    //if (match.Success)
                //    //{
                //    //    sb.Append($@"{{\cf3 {match.Groups?[1].Value}}}{{\cf2 {match.Groups?[2].Value}{match.Groups?[3].Value}}}\par");
                //    //}
                //    //else
                //    //{
                //    //    sb.Append($@"{{\cf2 {trimmedLine}}}\par");
                //    //}
                //}

            }

            return sb.ToString();
        }
    }
}
