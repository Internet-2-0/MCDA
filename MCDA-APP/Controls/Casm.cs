using MCDA_APP.Model.Api.Reuse;
using Newtonsoft.Json.Linq;

namespace MCDA_APP.Controls
{
    public struct Instruction 
    { 
        public List<string> LeftInstructions { get; set; }
        public List<string> RightInstructions { get; set; }
        public double Score { get; set; }

        public Instruction(List<string> leftInstructions, List<string> rightInstructions, double score)
        {
            LeftInstructions = leftInstructions;
            RightInstructions = rightInstructions;
            Score = score;
        }
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
                };
                panel.Controls.Add(label);
            }
            else
            {
                List<Instruction> instructionsList = new List<Instruction>();

                foreach (var result in results.Cast<JArray>())
                {
                    var leftInstructions = result[0].ToString().Split('\n').ToList();
                    var rightInstructions = result[1].ToString().Split('\n').ToList();
                    double score = Convert.ToDouble(result[2]);

                    instructionsList.Add(new Instruction(leftInstructions, rightInstructions, score));
                }

                var comparisonControl = CreateComparisonControl(instructionsList);
                panel.Controls.Add(comparisonControl);
            }
        }

        private Control CreateComparisonControl(List<Instruction> instructionsList)
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

            int row = 0;

            foreach (var instruction in instructionsList)
            {
                int maxLines = Math.Max(instruction.LeftInstructions.Count, instruction.RightInstructions.Count);

                for (int i = 0; i < maxLines; i++)
                {
                    string leftText = i < instruction.LeftInstructions.Count ? instruction.LeftInstructions[i] : string.Empty;
                    string rightText = i < instruction.RightInstructions.Count ? instruction.RightInstructions[i] : string.Empty;

                    tableLayoutPanel.Controls.Add(CreateTextLabel(leftText), 0, row);
                    tableLayoutPanel.Controls.Add(CreateTextLabel("->", centered: true), 1, row);
                    tableLayoutPanel.Controls.Add(CreateTextLabel(rightText), 2, row);

                    row += 1;
                }

                tableLayoutPanel.Controls.Add(new Label(), 0, row);
                tableLayoutPanel.Controls.Add(CreateTextLabel(instruction.Score.ToString("0.###"), isScore: true), 1, row);
                tableLayoutPanel.Controls.Add(new Label(), 2, row);

                row += 1;
            }

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
