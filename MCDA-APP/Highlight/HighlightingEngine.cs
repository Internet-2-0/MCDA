using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace MCDA_APP.Highlight
{
    public class HighlightingEngine
    {
        public List<HighlightRule> Rules { get; private set; }

        public HighlightingEngine(string rules)
        {
            LoadRules(rules);
        }

        private void LoadRules(string rules)
        {
            var highlightRules = JsonConvert.DeserializeObject<HighlightRules>(rules);
            Rules = highlightRules.Rules;
        }

        public void ApplyHighlighting(RichTextBox richTextBox)
        {
            var highlightedIndexes = new HashSet<int>();
            var highlights = new List<Highlight>();

            richTextBox.SuspendLayout();
            foreach (var rule in Rules)
            {
                if (rule.Type == "regex" && rule.Pattern != null)
                {
                    CollectPatternHighlights(richTextBox.Text, rule.Pattern, rule.Color, highlights, highlightedIndexes);
                }
                else if (rule.Type == "words" && rule.Words != null)
                {
                    CollectWordHighlights(richTextBox.Text, rule.Words, rule.Color, highlights, highlightedIndexes);
                }
            }

            richTextBox.ResumeLayout();

            foreach (var highlight in highlights)
            {
                richTextBox.Select(highlight.Start, highlight.Length);
                richTextBox.SelectionColor = ColorTranslator.FromHtml(highlight.Color);
            }
        }

        private void CollectWordHighlights(string text, List<string> words, string? color, List<Highlight> highlights, HashSet<int> highlightedIndexes)
        {
            foreach (var word in words)
            {
                var matches = Regex.Matches(text, $@"\b{Regex.Escape(word)}\b");
                foreach (Match match in matches)
                {
                    if (!IsRangeHighlighted(match.Index, match.Length, highlightedIndexes))
                    {
                        highlights.Add(new Highlight(match.Index, match.Length, color));
                        AddRangeToHighlightedIndexes(match.Index, match.Length, highlightedIndexes);
                    }
                }
            }
        }

        private void CollectPatternHighlights(string text, string pattern, string? color, List<Highlight> highlights, HashSet<int> highlightedIndexes)
        {
            var matches = Regex.Matches(text, pattern, RegexOptions.Multiline);
            foreach (Match match in matches)
            {
                if (!IsRangeHighlighted(match.Index, match.Length, highlightedIndexes))
                {
                    highlights.Add(new Highlight(match.Index, match.Length, color));

                    AddRangeToHighlightedIndexes(match.Index, match.Length, highlightedIndexes);
                }
            }
        }

        private bool IsRangeHighlighted(int start, int length, HashSet<int> highlightedIndexes)
        {
            for (int i = start; i < start + length; i++)
            {
                if (highlightedIndexes.Contains(i))
                {
                    return true;
                }
            }
            return false;
        }

        private void AddRangeToHighlightedIndexes(int start, int length, HashSet<int> highlightedIndexes)
        {
            for (int i = start; i < start + length; i++)
            {
                highlightedIndexes.Add(i);
            }
        }
    }
}
