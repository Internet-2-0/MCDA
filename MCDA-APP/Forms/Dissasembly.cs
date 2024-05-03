using MCDA_APP.Model.Agent.Disassembler;
using MCDA_APP.Radare2;
using MCDA_APP.Rendering;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Text.RegularExpressions;
using static System.Windows.Forms.ListView;

namespace MCDA_APP.Forms
{
    public partial class Dissasembly : Form
    {
        private string FilePath;
        private R2Pipe _r2Pipe;
        private List<FunctionDetail> _functions;
        private BackgroundWorker _backgroundWorker;
        private List<RadareString>? _stringsList;
        private List<RadareImport>? _importList;
        private List<RadareExport>? _exportList;

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
                }
            }

            return functions;
        }

        private void FillFunctions()
        {
            foreach (FunctionDetail functionDetail in _functions)
            {
                ListViewItem tempItem = new ListViewItem(functionDetail.Name);
                tempItem.SubItems.Add(functionDetail.Address);

                FunctionsListView.Items.Add(tempItem);
            }
        }

        private void FillStrings()
        {
            for (int i = 0; i < _stringsList?.Count; i++)
            {
                RadareString radareString = _stringsList[i];

                ListViewItem temp = new ListViewItem($"0x{radareString.Vaddr.ToString("X8").ToLower()}");
                temp.SubItems.Add(radareString.Length.ToString());
                temp.SubItems.Add(radareString.Section);
                temp.SubItems.Add(radareString.Type);
                temp.SubItems.Add(radareString.String);

                StringsListView.Items.Add(temp);
            }
        }

        private void FillImports()
        {
            for (int i = 0; i < _importList?.Count; i++)
            {
                RadareImport radareImport = _importList[i];

                ListViewItem temp = new ListViewItem(radareImport.Name);
                temp.SubItems.Add($"0x{radareImport.Plt.ToString("X8").ToLower()}");
                temp.SubItems.Add(radareImport.Libname);

                ImportsListView.Items.Add(temp);
            }
        }

        private void FillExports()
        {
            for (int i = 0; i < _exportList?.Count; i++)
            {
                RadareExport radareExport = _exportList[i];

                ListViewItem temp = new ListViewItem(radareExport.Name);
                temp.SubItems.Add($"0x{radareExport.Vaddr.ToString("X8").ToLower()}");

                ExportsListView.Items.Add(temp);
            }
        }

        private void Dissasembly_Load(object sender, EventArgs e)
        {
            Text = string.Format(Constants.MalcoreFormTitle, Helper.GetAgentVersion(), "Dissasembler");

            _backgroundWorker = new BackgroundWorker();
            _backgroundWorker.DoWork += BackgroundWorker_DoWork;
            _backgroundWorker.ProgressChanged += BackgroundWorker_ProgressChanged;
            _backgroundWorker.RunWorkerCompleted += BackgroundWorker_RunWorkerCompleted;
        }

        private void BackgroundWorker_RunWorkerCompleted(object? sender, RunWorkerCompletedEventArgs e)
        {
            FillFunctions();
            FillStrings();
            FillImports();
            FillExports();

            MessageBox.Show("Completed!");
        }

        private void BackgroundWorker_ProgressChanged(object? sender, ProgressChangedEventArgs e)
        {

        }

        private void BackgroundWorker_DoWork(object? sender, DoWorkEventArgs e)
        {
            _r2Pipe = new R2Pipe(FilePath, "bin\\radare2.exe");

            string response = _r2Pipe.RunCommand("aaa;afl");
            _functions = ParseFunctionDetails(response);

            string strings = _r2Pipe.RunCommand("izzj");
            _stringsList = JsonConvert.DeserializeObject<List<RadareString>>(strings);

            string imports = _r2Pipe.RunCommand("iij");
            _importList = JsonConvert.DeserializeObject<List<RadareImport>>(imports);

            string exports = _r2Pipe.RunCommand("iEj");
            _exportList = JsonConvert.DeserializeObject<List<RadareExport>>(exports);
            
            //set some needed options
            _r2Pipe.RunCommand("e asm.lines=false");
            _r2Pipe.RunCommand("e asm.lines.fcn=false");
            _r2Pipe.RunCommand("e asm.bytes=false");
            //_r2Pipe.RunCommand("e asm.comments=false");
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

        private void ClearControls()
        {
            FunctionsListView.Items.Clear();
            StringsListView.Items.Clear();
            ExportsListView.Items.Clear();
            ImportsListView.Items.Clear();
        }

        private void LoadFile()
        {
            _r2Pipe?.Dispose();

            ClearControls();

            _backgroundWorker.RunWorkerAsync();
        }

        private void FunctionsListView_DoubleClick(object sender, EventArgs e)
        {
            SelectedListViewItemCollection selectedList = FunctionsListView.SelectedItems;

            if (selectedList.Count == 0)
            {
                return;
            }

            string output = _r2Pipe.RunCommand($"s {selectedList[0].Text};pdf");
            richTextBox1.Rtf = AssemblyParser.SetRichText(output);
        }

        private void FunctionsListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
        }
    }
}
