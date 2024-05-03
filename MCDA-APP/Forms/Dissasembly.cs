using MCDA_APP.Model.Agent;
using MCDA_APP.Radare2;
using MCDA_APP.Rendering;
using System.Text.RegularExpressions;

namespace MCDA_APP.Forms
{
    public partial class Dissasembly : Form
    {
        private string FilePath;
        private R2Pipe _r2Pipe;
        private List<FunctionDetail> _functions;

        public Dissasembly()
        {
            InitializeComponent();
            OptionsMenu.Renderer = new CustomRender(true);
        }

        public List<FunctionDetail> ParseFunctionDetails(string data)
        {
            List<FunctionDetail> functions = new List<FunctionDetail>();
            string[] lines = data.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            Regex lineRegex = new Regex(@"\s*(0x[0-9a-fA-F]+)\s+(\d+)\s+(\d+)\s+(.+)$");

            foreach (string line in lines)
            {
                Match match = lineRegex.Match(line);
                if (match.Success)
                {
                    FunctionDetail fd = new FunctionDetail
                    {
                        Address = match.Groups[1].Value,
                        Size = int.Parse(match.Groups[2].Value),
                        Operations = int.Parse(match.Groups[3].Value),
                        Name = match.Groups[4].Value.Trim()
                    };
                    functions.Add(fd);

                    ListViewItem tempItem = new ListViewItem(fd.Name);
                    tempItem.SubItems.Add(fd.Address);

                    FunctionsListView.Items.Add(tempItem);
                }
            }

            return functions;
        }

        private void Dissasembly_Load(object sender, EventArgs e)
        {
            Text = string.Format(Constants.MalcoreFormTitle, Helper.GetAgentVersion(), "Dissasembler");

            //_r2Pipe = new R2Pipe(File)
        }

        private void OptionsMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "All Files|*.*|Executable Files|*.exe|DLL Files|*.dll";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    FilePath = openFileDialog.FileName;

                    LoadFile();
                }
            }
        }

        private void LoadFile()
        {
            _r2Pipe = new R2Pipe(FilePath, "bin\\radare2.exe");

            string response = _r2Pipe.RunCommand("aaa;afl");
            _functions = ParseFunctionDetails(response);

            string strings = _r2Pipe.RunCommand("izz");
        }
    }
}
