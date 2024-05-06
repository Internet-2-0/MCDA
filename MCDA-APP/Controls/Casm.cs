namespace MCDA_APP.Controls
{
    public partial class Casm : UserControl
    {
        public Casm(List<string> leftTexts, List<string> rightTexts, double score)
        {
            BackColor = Color.FromArgb(20, 31, 43);
            DoubleBuffered = true;

            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel
            {
                ColumnCount = 3,
                AutoSize = true,
                CellBorderStyle = TableLayoutPanelCellBorderStyle.Single,
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(22, 25, 34)
            };

            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40));

            //AddRow(tableLayoutPanel, new string[] { "add al, 0x2a", "->", "add al, 0x26" });
            //AddRow(tableLayoutPanel, new string[] { "db 0x1e", "->", "adc al, 0x2b" });
            //AddRow(tableLayoutPanel, new string[] { "add bh, byte ptr [rbx + 0xd]", "->", "or edi, esi" });
            //AddRow(tableLayoutPanel, new string[] { "nop", "->", "db 0x16" });
            //AddRow(tableLayoutPanel, new string[] { "add al, 0x2a", "->", "add al, 0" });
            //AddRow(tableLayoutPanel, new string[] { "add al, 0x2a", "->", "add al, 0" });
            //AddRow(tableLayoutPanel, new string[] { "add al, 0x2a", "->", "add al, 0" });
            //AddScoreRow(tableLayoutPanel, 135.144);

            //AddRow(tableLayoutPanel, new string[] { "nop", "->", "nop" });
            //AddRow(tableLayoutPanel, new string[] { "add al, 0xfe", "->", "adc eax, 0x2a0a0000" });
            //AddRow(tableLayoutPanel, new string[] { "adc eax, 0x200001d", "->", "sbb esi, dword ptr [rax]" });
            //AddRow(tableLayoutPanel, new string[] { "add dl, byte ptr [rdi]", "->", "add eax, dword ptr [rax]" });
            //AddRow(tableLayoutPanel, new string[] { "jge 0x4e5", "->", "jns 0x4e6" });
            //AddScoreRow(tableLayoutPanel, 142.714);

            //AddRow(tableLayoutPanel, new string[] { "push 0x2c060024", "->", "jnp 0x518" });
            //AddRow(tableLayoutPanel, new string[] { "or eax, 0x28140202", "->", "adc al, 0x2d" });
            //AddRow(tableLayoutPanel, new string[] { "adc byte ptr [rax], al", "->", "add dword ptr [rdx], ebp" });
            //AddRow(tableLayoutPanel, new string[] { "nop", "->", "db 0x07" });
            //AddRow(tableLayoutPanel, new string[] { "jge 0x520", "->", "jmp 0x520" });
            //AddScoreRow(tableLayoutPanel, 140.565);

            AddRow(tableLayoutPanel, leftTexts, rightTexts);
            AddScoreRow(tableLayoutPanel, score);

            tableLayoutPanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.None;

            Controls.Add(tableLayoutPanel);
            Text = "Code Alignment";
            BackColor = Color.FromArgb(22, 25, 34);
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BorderStyle = BorderStyle.FixedSingle;
        }

        private void AddRow(TableLayoutPanel tableLayoutPanel, List<string> leftTexts, List<string> rightTexts)
        {
            int maxLines = Math.Max(leftTexts.Count, rightTexts.Count);
            for (int i = 0; i < maxLines; i++)
            {
                string leftText = i < leftTexts.Count ? leftTexts[i] : string.Empty;
                string rightText = i < rightTexts.Count ? rightTexts[i] : string.Empty;

                Label label1 = CreateLabel(leftText);
                Label label2 = CreateLabel("->", centered: true);
                Label label3 = CreateLabel(rightText);

                tableLayoutPanel.Controls.Add(label1);
                tableLayoutPanel.Controls.Add(label2);
                tableLayoutPanel.Controls.Add(label3);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            int borderWidth = 1;
            Color borderColor = Color.FromArgb(25, 41, 58);
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle,
                borderColor, borderWidth, ButtonBorderStyle.Solid,
                borderColor, borderWidth, ButtonBorderStyle.Solid,
                borderColor, borderWidth, ButtonBorderStyle.Solid,
                borderColor, borderWidth, ButtonBorderStyle.Solid);
        }
       
        private void AddRow(TableLayoutPanel tableLayoutPanel, string[] texts)
        {
            Label label1 = CreateLabel(texts[0]);
            Label label2 = CreateLabel(texts[1], centered: true);
            Label label3 = CreateLabel(texts[2]);

            tableLayoutPanel.Controls.Add(label1);
            tableLayoutPanel.Controls.Add(label2);
            tableLayoutPanel.Controls.Add(label3);
        }

        private void AddScoreRow(TableLayoutPanel tableLayoutPanel, double score)
        {
            Label label = CreateLabel(score.ToString("0.###"), true);
            label.Dock = DockStyle.Fill;
            label.TextAlign = ContentAlignment.MiddleCenter;
            tableLayoutPanel.Controls.Add(new Label());
            tableLayoutPanel.Controls.Add(label);
            tableLayoutPanel.Controls.Add(new Label());
        }

        private Label CreateLabel(string text, bool isScore = false, bool centered = false)
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
