using System.Text.RegularExpressions;

namespace MCDA_APP.Highlight.Patterns
{
    public sealed class RegexPattern : Pattern
    {
        public string RegexExpression { get; private set; }

        public RegexPattern(string name, Style style, string regexExpression)
            : base(name, style)
        {
            RegexExpression = regexExpression;
        }

        public override string GetRegexPattern()
        {
            return RegexExpression;
        }
    }
}
