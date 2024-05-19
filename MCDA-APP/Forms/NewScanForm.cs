namespace MCDA_APP.Forms
{
    public partial class NewScanForm : Form
    {
        public NewScanForm()
        {
            InitializeComponent();
        }

        private void CasmButton_Click(object sender, EventArgs e)
        {
            CodeReuse codeReuse = new CodeReuse();
            codeReuse.Show();

            this.Close();
        }

        private void DisassemblyButton_Click(object sender, EventArgs e)
        {
            Disasembly dissasembly = new Disasembly();
            dissasembly.Show();

            this.Close();
        }

        private void HexDumpButton_Click(object sender, EventArgs e)
        {
            HexDump hexDump = new HexDump();
            hexDump.Show();

            this.Close();
        }
    }
}
