namespace MCDA_APP.Forms
{
    public partial class NewScanForm : Form
    {
        public NewScanForm()
        {
            InitializeComponent();
        }

        public static void MinimizeMonitoringForm()
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.Name == "MonitoringForm")
                    form.WindowState = FormWindowState.Minimized;
            }
        }

        private void CasmButton_Click(object sender, EventArgs e)
        {
            CodeReuse codeReuse = new CodeReuse();
            MinimizeMonitoringForm();
            codeReuse.Show();
            codeReuse.BringToFront();


            this.Close();
        }

        private void DisassemblyButton_Click(object sender, EventArgs e)
        {
            Disasembly dissasembly = new Disasembly();
            MinimizeMonitoringForm();
            dissasembly.Show();
            dissasembly.BringToFront();

            this.Close();
        }

        private void HexDumpButton_Click(object sender, EventArgs e)
        {
            HexDump hexDump = new HexDump();
            MinimizeMonitoringForm();
            hexDump.Show();
            hexDump.BringToFront();

            this.Close();
        }
    }
}
