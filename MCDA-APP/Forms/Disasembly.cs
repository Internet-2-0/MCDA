using MCDA_APP.Controls;
using MCDA_APP.Highlight;
using MCDA_APP.Model.Agent.Disassembler;
using MCDA_APP.Radare2;
using MCDA_APP.Rendering;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using static System.Windows.Forms.ListView;

namespace MCDA_APP.Forms
{
    public partial class Disasembly : Form
    {
        private Overlay Overlay;
        private string _filePath;
        private R2Pipe _r2Pipe;
        private List<FunctionDetail> _functions;
        private BackgroundWorker _backgroundWorker;
        private List<RadareString>? _stringsList;
        private List<RadareImport>? _importList;
        private List<RadareExport>? _exportList;
        private RadareInformation? _information;
        private Dictionary<string, string> _assemblyFunctions;

        HighlightingEngine highlightingEngine;

        public Disasembly()
        {
            InitializeComponent();
            OptionsMenu.Renderer = new CustomRender(true);

            byte[] rules = Properties.Resources.syntaxhighlight;
            highlightingEngine = new HighlightingEngine(Encoding.UTF8.GetString(rules));
        }

        private static List<FunctionDetail> ParseFunctionDetails(string data)
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
            originalItems = new List<ListViewItem>();

            for (int i = 0; i < _stringsList?.Count; i++)
            {
                RadareString radareString = _stringsList[i];

                ListViewItem temp = new ListViewItem($"0x{radareString.Vaddr.ToString("X8").ToLower()}");
                temp.SubItems.Add(radareString.Length.ToString());
                temp.SubItems.Add(radareString.Section);
                temp.SubItems.Add(radareString.Type);
                temp.SubItems.Add(radareString.String);

                originalItems.Add(temp);
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
            _backgroundWorker.RunWorkerCompleted += BackgroundWorker_RunWorkerCompleted;

            Overlay = new Overlay
            {
                Dock = DockStyle.Fill,
                Enabled = true,
            };
        }

        private void BackgroundWorker_RunWorkerCompleted(object? sender, RunWorkerCompletedEventArgs e)
        {
            FillFunctions();
            FillStrings();
            FillImports();
            FillExports();
            FillInformation();

            _assemblyFunctions = new Dictionary<string, string>();

            this.Controls.Remove(Overlay);
        }

        private string ComputeHash(HashAlgorithm hashAlgorithm, string filePath)
        {
            using (hashAlgorithm)
            {
                using (var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    byte[] hashBytes = hashAlgorithm.ComputeHash(fileStream);
                    return BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();
                }
            }
        }

        private void FillInformation()
        {
            FileTextbox.Text = _information.Core.File;
            BitsTextbox.Text = _information.Bin.Bits.ToString();
            FormatTextbox.Text = _information.Bin.Bintype;
            SizeTextbox.Text = _information.Core.Humansz;
            TypeTextbox.Text = _information.Core.Type;
            LanguageTextbox.Text = _information.Bin.Lang;
            FdTextbox.Text = _information.Core.Fd.ToString();

            BaseAddrTextbox.Text = $"0x{_information.Bin.Baddr.ToString("X8").ToLower()}";
            CanaryTextbox.Text = _information.Bin.Canary.ToString();
            CryptoTextbox.Text = _information.Bin.Crypto.ToString();
            NxTextbox.Text = _information.Bin.Nx.ToString();
            PicTextbox.Text = _information.Bin.Pic.ToString();

            Md5Textbox.Text = ComputeHash(MD5.Create(), _filePath);
            Sha1Textbox.Text = ComputeHash(SHA1.Create(), _filePath);
            Sha256Textbox.Text = ComputeHash(SHA256.Create(), _filePath);
        }

        private void BackgroundWorker_DoWork(object? sender, DoWorkEventArgs e)
        {
            _r2Pipe = new R2Pipe(_filePath, "bin\\radare2.exe");

            string response = _r2Pipe.RunCommand("aaa;afl");
            _functions = ParseFunctionDetails(response);

            string strings = _r2Pipe.RunCommand("izzj");
            _stringsList = JsonConvert.DeserializeObject<List<RadareString>>(strings);

            string imports = _r2Pipe.RunCommand("iij");
            _importList = JsonConvert.DeserializeObject<List<RadareImport>>(imports);

            string exports = _r2Pipe.RunCommand("iEj");
            _exportList = JsonConvert.DeserializeObject<List<RadareExport>>(exports);

            string information = _r2Pipe.RunCommand("ij");
            _information = JsonConvert.DeserializeObject<RadareInformation>(information);

            //set some needed options
            _r2Pipe.RunCommand("e asm.lines=false;e asm.lines.fcn=false;e asm.bytes=false");

            //_assemblyCode = _r2Pipe.RunCommand("pdf @@f");
        }

        private void FindAndScrollToValue(string value)
        {
            string[] lines = AssemblyTextBox.Lines;
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].TrimStart().StartsWith(value))
                {
                    AssemblyTextBox.SelectionStart = AssemblyTextBox.GetFirstCharIndexFromLine(i);
                    AssemblyTextBox.ScrollToCaret();
                    return;
                }
            }
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
                    _filePath = openFileDialog.FileName;

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

            this.Controls.Add(Overlay);
            Overlay.BringToFront();

            _backgroundWorker.RunWorkerAsync();
        }

        private void FunctionsListView_DoubleClick(object sender, EventArgs e)
        {
            SelectedListViewItemCollection selectedList = FunctionsListView.SelectedItems;

            if (selectedList.Count == 0)
            {
                return;
            }
            AssemblyTextBox.Clear();

            DisassemblerTab.SelectedTab = DisassemblyTab;

            if (_assemblyFunctions.ContainsKey(selectedList[0].Text))
            {
                AssemblyTextBox.Text = _assemblyFunctions[selectedList[0].Text];
                highlightingEngine.ApplyHighlighting(AssemblyTextBox);
            }
            else
            {
                string output = _r2Pipe.RunCommand($"s {selectedList[0].Text};pdf");
                string result = AssemblyParser.RemoveUnwantedComments(output);

                _assemblyFunctions.Add(selectedList[0].Text, result);
                AssemblyTextBox.Text = result;
                highlightingEngine.ApplyHighlighting(AssemblyTextBox);
            }
        }

        private List<ListViewItem> originalItems;

        private void SearchStringTextbox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(SearchStringTextbox.Text))
            {
                StringsListView.Items.Clear();
                StringsListView.Items.AddRange(originalItems.ToArray());
            }
            else
            {
                string searchText = SearchStringTextbox.Text.ToLower();
                var filteredItems = originalItems
                    .Where(item => item.SubItems[4].Text.ToLower().Contains(searchText))
                    .ToArray();

                StringsListView.Items.Clear();
                StringsListView.Items.AddRange(filteredItems);
            }


        }

        private void Disasembly_Resize(object sender, EventArgs e)
        {
            SearchStringTextbox.Width = this.flowLayoutPanel1.ClientSize.Width - SearchStringLabel.Width - 18;
        }
    }
}
