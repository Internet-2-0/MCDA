using MCDA_APP.Highlight.Patterns;
using System.Collections;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace MCDA_APP.Highlight.Engines
{
    public class RtfEngine : Engine
    {
        private const string RtfFormat = "{0} {1}";
        private readonly ArrayList colors = new ArrayList();
        private readonly ArrayList fonts = new ArrayList();

        protected override string PreHighlight(Definition definition, string input)
        {
            return HttpUtility.HtmlEncode(input);
        }

        protected override string PostHighlight(Definition definition, string input)
        {
            // Convert new lines to RTF paragraph breaks.
            // Replace "\r\n" (Windows) or "\n" (Unix) line endings with "\par "
            var formattedInput = input.Replace("\r\n", @"\par ");
            formattedInput = formattedInput.Replace("\n", @"\par ");

            // Build the RTF header including font and color table definitions
            var fontList = BuildFontList();
            var colorList = BuildColorList();

            // Combine all parts into the final RTF string, properly enclosed in a single RTF group.
            return String.Format(@"{{\rtf1\ansi{{\fonttbl{0}}}{{\colortbl;{1}}}{2}}}", fontList, colorList, formattedInput);
        }

        //new
        //protected override string PostHighlight(Definition definition, string input)
        //{
        //    // Build the RTF header including font and color table definitions
        //    var fontList = BuildFontList();
        //    var colorList = BuildColorList();

        //    return String.Format(@"{{\rtf1\ansi{{\fonttbl{0}}}{{\colortbl;{1}}}{2}}}", fontList, colorList, input);
        //}

        //protected override string PostHighlight(Definition definition, string input)
        //{
        //    var result = input
        //        .Replace("{", @"\{").Replace("}", @"\}").Replace("\t", @"\tab ")
        //        .Replace("\r\n", @"\par ");
        //    var fontList = BuildFontList();
        //    var colorList = BuildColorList();

        //    return String.Format(@"{{\rtf1\ansi{{\fonttbl{{{0}}}}}{{\colortbl;{1}}}{2}}}", fontList, colorList, result);
        //}

       

        protected override string ProcessBlockPatternMatch(Definition definition, BlockPattern pattern, Match match)
        {
            var style = CreateRtfPatternStyle(pattern.Style.Colors.ForeColor, pattern.Style.Colors.BackColor, pattern.Style.Font);

            return ("{" + String.Format(RtfFormat, style, match.Value) + "}");
        }

        protected override string ProcessMarkupPatternMatch(Definition definition, MarkupPattern pattern, Match match)
        {
            var builder = new StringBuilder();
            var style = CreateRtfPatternStyle(pattern.Style.Colors.ForeColor, pattern.Style.Colors.BackColor, pattern.Style.Font);
            var bracketStyle = CreateRtfPatternStyle(pattern.BracketColors.ForeColor, pattern.BracketColors.BackColor, pattern.Style.Font);
            string attributeNameStyle = null;
            string attributeValueStyle = null;
            if (pattern.HighlightAttributes)
            {
                attributeNameStyle = CreateRtfPatternStyle(pattern.AttributeNameColors.ForeColor, pattern.AttributeNameColors.BackColor, pattern.Style.Font);
                attributeValueStyle = CreateRtfPatternStyle(pattern.AttributeValueColors.ForeColor, pattern.AttributeValueColors.BackColor, pattern.Style.Font);
            }
            builder.AppendFormat(RtfFormat, bracketStyle, match.Groups["openTag"].Value);
            builder.Append(match.Groups["ws1"].Value);
            builder.AppendFormat(RtfFormat, style, match.Groups["tagName"].Value);
            if (attributeNameStyle != null)
            {
                for (var i = 0; i < match.Groups["attribute"].Captures.Count; i++)
                {
                    builder.Append(match.Groups["ws2"].Captures[i].Value);
                    builder.AppendFormat(RtfFormat, attributeNameStyle, match.Groups["attribName"].Captures[i].Value);

                    if (String.IsNullOrWhiteSpace(match.Groups["attribValue"].Captures[i].Value))
                    {
                        continue;
                    }

                    builder.AppendFormat(RtfFormat, attributeValueStyle, match.Groups["attribValue"].Captures[i].Value);
                }
            }
            builder.Append(match.Groups["ws5"].Value);
            builder.AppendFormat(RtfFormat, bracketStyle, match.Groups["closeTag"].Value);

            return ("{" + builder + "}");
        }

        protected override string ProcessWordPatternMatch(Definition definition, WordPattern pattern, Match match)
        {
            var style = CreateRtfPatternStyle(pattern.Style.Colors.ForeColor, pattern.Style.Colors.BackColor, pattern.Style.Font);

            // Ensure the whole line is not mistakenly encapsulated in style changes
            return String.Format(@"\cf{0} {1}", GetIndexOfColor(pattern.Style.Colors.ForeColor), match.Value);
        }

        //protected override string ProcessWordPatternMatch(Definition definition, WordPattern pattern, Match match)
        //{
        //    var style = CreateRtfPatternStyle(pattern.Style.Colors.ForeColor, pattern.Style.Colors.BackColor, pattern.Style.Font);

        //    return ("{" + String.Format(RtfFormat, style, match.Value) + "}");
        //}

        private string CreateRtfPatternStyle(Color foreColor, Color backColor, SixLabors.Fonts.Font font)
        {
            // Only create RTF control words for colors if they're actually needed
            StringBuilder styleBuilder = new StringBuilder();
            styleBuilder.Append(@"\cf").Append(GetIndexOfColor(foreColor));

            // Apply background color only if it's different from default
            if (backColor != Color.Transparent)
                styleBuilder.Append(@"\highlight").Append(GetIndexOfColor(backColor));

            styleBuilder.Append(@"\f").Append(GetIndexOfFont(font.Name))
                        .Append(@"\fs").Append((int)(font.Size * 2)); // RTF expects size in half-points

            return styleBuilder.ToString();
        }


        //private string CreateRtfPatternStyle(Color foreColor, Color backColor, SixLabors.Fonts.Font font)
        //{
        //    return String.Concat(new object[] { @"\cf", GetIndexOfColor(foreColor), @"\f", GetIndexOfFont(font.Name), @"\fs", font.Size * 2f });
        //}

        private int GetIndexOfColor(Color color)
        {
            var color2 = new HexColor();
            if (color.Name.IndexOf("#") > -1)
            {
                color2.Red = Int32.Parse(color.Name.Substring(1, 2), NumberStyles.AllowHexSpecifier);
                color2.Green = Int32.Parse(color.Name.Substring(3, 2), NumberStyles.AllowHexSpecifier);
                color2.Blue = Int32.Parse(color.Name.Substring(5, 2), NumberStyles.AllowHexSpecifier);
            }
            else
            {
                color2.Red = color.R;
                color2.Green = color.G;
                color2.Blue = color.B;
            }
            var index = colors.IndexOf(color2);
            if (index > -1)
            {
                return (index + 1);
            }
            colors.Add(color2);

            return colors.Count;
        }

        private int GetIndexOfFont(string font)
        {
            var index = fonts.IndexOf(font);
            if (index > -1)
            {
                return (index + 1);
            }
            fonts.Add(font);

            return fonts.Count;
        }

        private string BuildColorList()
        {
            var builder = new StringBuilder();
            foreach (var hexColor in colors.Cast<HexColor>())
            {
                builder.AppendFormat(@"\red{0}\green{1}\blue{2};", hexColor.Red, hexColor.Green, hexColor.Blue);
            }
            return builder.ToString();
        }

        private string BuildFontList()
        {
            var builder = new StringBuilder();
            for (var i = 0; i < fonts.Count; i++)
            {
                builder.AppendFormat(@"\f{0} {1};", i, fonts[i]);
            }
            return builder.ToString();
        }

        protected override string ProcessRegexPatternMatch(Definition definition, RegexPattern pattern, Match match)
        {
            var style = CreateRtfPatternStyle(pattern.Style.Colors.ForeColor, pattern.Style.Colors.BackColor, pattern.Style.Font);
            return ("{" + String.Format(RtfFormat, style, match.Value) + "}");
        }

       
        [StructLayout(LayoutKind.Sequential)]
        private struct HexColor
        {
            public int Red;
            public int Green;
            public int Blue;
        }
    }
}
