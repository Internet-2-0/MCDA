namespace MCDA_APP.Controls
{
    public partial class Overlay : UserControl
    {
        public Overlay()
        {
            InitializeComponent();
        }

        private void Overlay_Resize(object sender, EventArgs e)
        {
            pictureBox1.Location = new Point((this.Width - pictureBox1.Width) / 2, (this.Height - pictureBox1.Height) / 2);
            label1.Location = new Point((this.Width - label1.Width) / 2, (this.Height - label1.Height) / 2 + (pictureBox1.Height / 2) + 10);
        }
    }
}
