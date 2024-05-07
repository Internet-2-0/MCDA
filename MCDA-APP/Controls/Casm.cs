using MCDA_APP.Model.Api.Reuse;
using Newtonsoft.Json.Linq;

namespace MCDA_APP.Controls
{
    public struct Instructions 
    { 
        public List<string> LeftInstructions { get; set; }
        public List<string> RightInstructions { get; set; }
        public double Score { get; set; }
    }

    public partial class Casm : UserControl
    {
        public Casm(string groupName, DataGroup dataGroup)
        {
            var tableLayoutPanel = new TableLayoutPanel
            {
                ColumnCount = 1,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                CellBorderStyle = TableLayoutPanelCellBorderStyle.None,
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(22, 25, 34),
                Padding = new Padding(0, 10, 0, 10)
            };

            tableLayoutPanel.Controls.Add(CreateHeaderLabel(groupName));

            AddResults(tableLayoutPanel, "Kinda Similar", dataGroup.results.kinda_similar);
            AddResults(tableLayoutPanel, "Very Similar", dataGroup.results.very_similar);
            AddResults(tableLayoutPanel, "Perfect Similarity", dataGroup.results.perfect_similarity);

            Controls.Add(tableLayoutPanel);
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
        }

        private Label CreateHeaderLabel(string text)
        {
            return new Label
            {
                Text = text,
                ForeColor = Color.White,
                Font = new Font("Consolas", 16, FontStyle.Bold),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                AutoSize = true,
                BackColor = Color.FromArgb(44, 47, 54)
            };
        }

        private void AddResults(TableLayoutPanel panel, string labelText, List<object> results)
        {
            var title = new Label
            {
                Text = labelText,
                ForeColor = Color.White,
                Font = new Font("Consolas", 14, FontStyle.Bold),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft,
                AutoSize = true,
                Margin = new Padding(0, 10, 10, 10),
                //BackColor = Color.FromArgb(30, 33, 40)
            };
            panel.Controls.Add(title);

            if (results.Count == 1 && results[0].ToString() == "no code reuse discovered")
            {
                var label = new Label
                {
                    Text = "No code reuse discovered",
                    ForeColor = Color.Gray,
                    Font = new Font("Consolas", 10),
                    Dock = DockStyle.Fill,
                    AutoSize = true,
                    //TextAlign = ContentAlignment.MiddleCenter
                };
                panel.Controls.Add(label);
            }
            else
            {
                List<Instructions> instructionsList = new List<Instructions>();

                foreach (var result in results.Cast<JArray>())
                {
                    var leftInstructions = result[0].ToString().Split('\n').ToList();
                    var rightInstructions = result[1].ToString().Split('\n').ToList();
                    double score = Convert.ToDouble(result[2]);

                    var comparisonControl = CreateComparisonControl(leftInstructions, rightInstructions, score);
                    panel.Controls.Add(comparisonControl);
                }
            }
        }

        private Control CreateComparisonControl(List<string> leftTexts, List<string> rightTexts, double score)
        {
            var tableLayoutPanel = new TableLayoutPanel
            {
                ColumnCount = 3,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                CellBorderStyle = TableLayoutPanelCellBorderStyle.None,
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(36, 39, 48)
                
            };

            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40));

            int maxLines = Math.Max(leftTexts.Count, rightTexts.Count);
            for (int i = 0; i < maxLines; i++)
            {
                string leftText = i < leftTexts.Count ? leftTexts[i] : string.Empty;
                string rightText = i < rightTexts.Count ? rightTexts[i] : string.Empty;

                tableLayoutPanel.Controls.Add(CreateTextLabel(leftText), 0, i);
                tableLayoutPanel.Controls.Add(CreateTextLabel("->", centered: true), 1, i);
                tableLayoutPanel.Controls.Add(CreateTextLabel(rightText), 2, i);
            }

            tableLayoutPanel.Controls.Add(new Label(), 0, maxLines);
            tableLayoutPanel.Controls.Add(CreateTextLabel(score.ToString("0.###"), isScore: true), 1, maxLines);
            tableLayoutPanel.Controls.Add(new Label(), 2, maxLines);

            return tableLayoutPanel;
        }

        private Label CreateTextLabel(string text, bool isScore = false, bool centered = false)
        {
            return new Label
            {
                Text = text,
                ForeColor = isScore ? Color.Yellow : Color.Green,
                Font = new Font("Consolas", 10),
                AutoSize = true,
                Dock = DockStyle.Fill,
                TextAlign = centered ? ContentAlignment.MiddleCenter : (isScore ? ContentAlignment.MiddleCenter : ContentAlignment.MiddleLeft)
            };
        }
    }
}
