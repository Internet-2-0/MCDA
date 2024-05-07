using MCDA_APP.Controls;
using MCDA_APP.Model.Api.Reuse;

namespace MCDA_APP.Forms
{
    public partial class CodeReuseResult : Form
    {
        public CodeReuseResult(ReuseResponse parsedData)
        {
            InitializeComponent();

            var tableLayoutPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                ColumnCount = 1,
                RowCount = 0,
                Padding = new Padding(10),
                AutoScroll = true
            };
            Controls.Add(tableLayoutPanel);

            var dataGroups = new[] { parsedData.Data.InnerData.DataBy5, parsedData.Data.InnerData.DataBy10, parsedData.Data.InnerData.DataBy15 };
            var groupNames = new[] { "Group by 5", "Group by 10", "Group by 15" };

            for (int i = 0; i < dataGroups.Length; i++)
            {
                var dataGroup = dataGroups[i];
                var groupName = groupNames[i];
                if (dataGroup != null)
                {
                    var userControl = new Casm(groupName, dataGroup);
                    tableLayoutPanel.Controls.Add(userControl);
                }
            }

            Text = "Code Reuse Analysis";
            //AutoSize = true;
            //AutoSizeMode = AutoSizeMode.GrowAndShrink;
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = Color.FromArgb(22, 25, 34);
        }
    }
}
