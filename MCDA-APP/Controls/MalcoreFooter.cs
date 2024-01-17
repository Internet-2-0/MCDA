namespace MCDA_APP.Controls
{
    public partial class MalcoreFooter : UserControl
    {
        public MalcoreFooter() => InitializeComponent();

        private void MalcoreFooter_Paint(object sender, PaintEventArgs e)
        {
            using (Pen pen = new Pen(Color.FromArgb(111, 101, 101), 2))
            {
                e.Graphics.DrawLine(pen, 0, 0, this.Width, 0);
            }
        }

        private void LabelMalcore_Click(object sender, EventArgs e) => Program.OpenBrowser(Constants.MalcoreBaseUrl);

        private void LabelTerms_Click(object sender, EventArgs e) => Program.OpenBrowser(Constants.MalcoreTerms);

        private void LabelPrivacyPolicy_Click(object sender, EventArgs e) => Program.OpenBrowser(Constants.MalcorePrivacy);
    }
}
