using MCDA_APP.HexEditor;
using MCDA_APP.HexEditor.Winforms;
using MCDA_APP.Model.Api.Hex;
using MCDA_APP.Properties;
using Newtonsoft.Json;

namespace MCDA_APP.Forms
{
    public partial class HexDump : Form
    {
        public HexBox hexBox;
        private string _fileName;
        HexFormFind _formFind;
        FindOptions _findOptions = new FindOptions();
        HexFormGoTo _formGoto = new HexFormGoTo();

        public HexDump()
        {
            InitializeComponent();
            hexBox = new HexBox
            {
                BorderStyle = BorderStyle.None,
                BackColor = Color.FromArgb(55, 55, 55),
                ForeColor = Color.FromArgb(0, 230, 118),

                Dock = DockStyle.Fill,
                BytesPerLine = 16,
                ColumnInfoVisible = true,
                HexCasing = HexCasing.Upper,
                LineInfoVisible = true,
                StringViewVisible = true,
                VScrollBarVisible = true,
                InfoForeColor = Color.White,
                GroupSize = 4,
                Margin = new Padding(4, 3, 4, 3),
                AllowDrop = true,
                SelectionBackColor = Color.FromArgb(117, 117, 117),
            };

            hexBox.BuiltInContextMenu.CutMenuItemImage = Resources.Cut16;
            hexBox.BuiltInContextMenu.CopyMenuItemImage = Resources.Copy16;
            hexBox.BuiltInContextMenu.PasteMenuItemImage = Resources.Paste16;

            hexBox.Font = new Font("Arial", SystemFonts.MessageBoxFont.Size, SystemFonts.MessageBoxFont.Style);
            hexBox.CurrentLineChanged += new EventHandler(Position_Changed);
            hexBox.CurrentPositionInLineChanged += new EventHandler(Position_Changed);
            hexBox.DragDrop += HexBox_DragDrop;
            hexBox.DragEnter += HexBox_DragEnter;
            hexBox.SelectionLengthChanged += HexBox_SelectionLengthChanged;

            Controls.Add(hexBox);
            hexBox.BringToFront();

            ManageAbility();
        }

        private void HexBox_SelectionLengthChanged(object? sender, EventArgs e)
        {
            ManageAbilityForCopyAndPaste();
        }

        private void HexBox_DragEnter(object? sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private async void HexBox_DragDrop(object? sender, DragEventArgs e)
        {
            object oFileNames = e.Data.GetData(DataFormats.FileDrop);
            string[] fileNames = (string[])oFileNames;
            if (fileNames.Length == 1)
            {
                await OpenFile(fileNames[0]);
            }
        }

        void Position_Changed(object? sender, EventArgs e)
        {
            this.toolStripStatusLabel.Text = string.Format("Ln {0}    Col {1}",
                hexBox.CurrentLine, hexBox.CurrentPositionInLine);

            string bitPresentation = string.Empty;

            byte? currentByte = hexBox.ByteProvider != null && hexBox.ByteProvider.Length > hexBox.SelectionStart
                ? hexBox.ByteProvider.ReadByte(hexBox.SelectionStart)
            : (byte?)null;

            BitInfo bitInfo = currentByte != null ? new BitInfo((byte)currentByte, hexBox.SelectionStart) : null;

            if (bitInfo != null)
            {
                byte currentByteNotNull = (byte)currentByte;
                bitPresentation = string.Format("Bits of Byte {0}: {1}"
                    , hexBox.SelectionStart
                    , bitInfo.ToString()
                    );
            }
        }

        /// <summary>
        /// Manages enabling or disabling of menu items and toolstrip buttons.
        /// </summary>
        void ManageAbility()
        {
            if (hexBox.ByteProvider == null)
            {

                findToolStripMenuItem.Enabled = false;
                findNextToolStripMenuItem.Enabled = false;
                goToToolStripMenuItem.Enabled = false;

                //selectAllToolStripMenuItem.Enabled = false;
            }
            else
            {
                findToolStripMenuItem.Enabled = true;
                findNextToolStripMenuItem.Enabled = true;
                goToToolStripMenuItem.Enabled = true;

                //selectAllToolStripMenuItem.Enabled = true;
            }
            ManageAbilityForCopyAndPaste();
        }

        /// <summary>
        /// Manages enabling or disabling of menustrip items and toolstrip buttons for copy and paste
        /// </summary>
        void ManageAbilityForCopyAndPaste()
        {
            copyHexToolStripMenuItem.Enabled =
                copyToolStripSplitButton.Enabled = copyToolStripMenuItem1.Enabled = hexBox.CanCopy();

            cutToolStripButton.Enabled = cutToolStripMenuItem.Enabled = hexBox.CanCut();
            pasteToolStripSplitButton.Enabled = pasteToolStripMenuItem.Enabled = hexBox.CanPaste();
            pasteHexToolStripMenuItem.Enabled = pasteHexToolStripMenuItem1.Enabled = hexBox.CanPasteHex();
        }

        /// <summary>
        /// Saves the current file.
        /// </summary>
        void SaveFile()
        {
            if (hexBox.ByteProvider == null)
                return;

            try
            {
                DynamicByteProvider dynamicFileByteProvider = hexBox.ByteProvider as DynamicByteProvider;
                dynamicFileByteProvider!.ApplyChanges();
            }
            catch (Exception ex1)
            {
                ShowError(ex1.Message);
            }
            finally
            {
                ManageAbility();
            }
        }

        private void HexDump_Load(object sender, EventArgs e)
        {
            Text = string.Format(Constants.MalcoreFormTitle, Helper.GetAgentVersion(), "Hex Dump");
        }

        void CleanUp()
        {
            if (hexBox.ByteProvider != null)
            {
                IDisposable byteProvider = hexBox.ByteProvider as IDisposable;
                if (byteProvider != null)
                    byteProvider.Dispose();
                hexBox.ByteProvider = null;
            }
            _fileName = null;
            DisplayText();
        }

        /// <summary>
        /// Displays the file name in the Form´s text property
        /// </summary>
        /// <param name="fileName">the file name to display</param>
        void DisplayText()
        {
            if (_fileName != null && _fileName.Length > 0)
            {
                string textFormat = "{0}{1} - {2}";
                
                string text = Path.GetFileName(_fileName);
                this.Text = string.Format(textFormat, text, "[read-only]", Constants.Name);
            }
            else
            {
                this.Text = string.Format(Constants.MalcoreFormTitle, Helper.GetAgentVersion(), "Hex Dump");
            }
        }

        DialogResult CloseFile()
        {
            if (hexBox.ByteProvider == null)
                return DialogResult.OK;

            try

            {
                if (hexBox.ByteProvider != null && hexBox.ByteProvider.HasChanges())
                {
                    DialogResult res = MessageBox.Show("Save changes?",
                        "Malcore.io",
                        MessageBoxButtons.YesNoCancel,
                        MessageBoxIcon.Warning);

                    if (res == DialogResult.Yes)
                    {
                        SaveFile();
                        CleanUp();
                    }
                    else if (res == DialogResult.No)
                    {
                        CleanUp();
                    }
                    else if (res == DialogResult.Cancel)
                    {
                        return res;
                    }

                    return res;
                }
                else
                {
                    CleanUp();
                    return DialogResult.OK;
                }
            }
            finally
            {
                ManageAbility();
            }
        }

        public static void ShowMessage(string text)
        {
            MessageBox.Show(text, "Malcore.io",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        void byteProvider_Changed(object sender, EventArgs e)
        {
            ManageAbility();
        }

        void byteProvider_LengthChanged(object sender, EventArgs e)
        {
            UpdateFileSizeStatus();
        }

        /// <summary>
        /// Updates the File size status label
        /// </summary>
        void UpdateFileSizeStatus()
        {
            if (hexBox.ByteProvider == null)
                this.fileSizeToolStripStatusLabel.Text = string.Empty;
            else
                this.fileSizeToolStripStatusLabel.Text = Util.GetDisplayBytes(hexBox.ByteProvider.Length);
        }

        public static DialogResult ShowQuestion(string text)
        {
            DialogResult result = MessageBox.Show(text, "Malcore.io",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question);
            return result;
        }

        internal static DialogResult ShowError(string text)
        {
            DialogResult result = MessageBox.Show(text, "Malcore.io",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            return result;
        }

        private static byte[] FileStreamToByteArray(string fileName)
        {
            using (FileStream fileStream = File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    fileStream.CopyTo(memoryStream);
                    return memoryStream.ToArray();
                }
            }
        }

        private byte[] ProcessHexResult(HexAsciiResult result)
        {
            var hexAsciiDataList = new List<HexAsciiData>();
            var lines = result.Results.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var line in lines)
            {
                var parts = line.Split(new[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length == 3)
                {
                    var hexAsciiData = new HexAsciiData
                    {
                        LineNumber = parts[0].Trim(),
                        Hex = parts[1].Trim(),
                        Ascii = parts[2].Trim()
                    };
                    hexAsciiDataList.Add(hexAsciiData);
                }
            }

            string combinedHex = string.Concat(hexAsciiDataList.Select(data => data.Hex));

            byte[] byteArray = Enumerable.Range(0, combinedHex.Length)
                .Where(x => x % 2 == 0)
                .Select(x => Convert.ToByte(combinedHex.Substring(x, 2), 16))
                .ToArray();

            return byteArray;
        }

        public async Task OpenFile(string fileName)
        {
            if (!File.Exists(fileName))
            {
                ShowMessage("File does not exist");
                return;
            }

            if (CloseFile() == DialogResult.Cancel)
                return;

            try
            {
                var response = await Program.Client!.UploadFile(
                    $"{Constants.ApiBaseUrl}/api/hexdump", FileStreamToByteArray(fileName), Path.GetFileName(fileName));

                HexAsciiResult result = JsonConvert.DeserializeObject<HexAsciiResult>(response.Item1);

                if (result.Results == null)
                {
                    ShowError("An error occurred. Received a wrong response!");
                }
                else
                {
                    DynamicByteProvider dynamicByteProvider;
                    dynamicByteProvider = new DynamicByteProvider(ProcessHexResult(result));

                    dynamicByteProvider.Changed += new EventHandler(byteProvider_Changed);
                    dynamicByteProvider.LengthChanged += new EventHandler(byteProvider_LengthChanged);

                    hexBox.ByteProvider = dynamicByteProvider;
                    _fileName = fileName;

                    DisplayText();

                    UpdateFileSizeStatus();
                }
            }
            catch (Exception ex1)
            {
                ShowError(ex1.Message);
                return;
            }
            finally
            {

                ManageAbility();
            }
        }

        private void CoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.hexBox.Copy();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.hexBox.Cut();
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.hexBox.Paste();
        }

        private void CopyHexToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.hexBox.CopyHex();
        }

        private void PasteHexToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.hexBox.PasteHex();
        }

        /// <summary>
        /// Opens the Find dialog
        /// </summary>
        void Find()
        {
            ShowFind();
        }

        /// <summary>
		/// Creates a new FormFind dialog
		/// </summary>
		/// <returns>the form find dialog</returns>
		HexFormFind ShowFind(bool hide = false)
        {
            if (_formFind == null || _formFind.IsDisposed)
            {
                _formFind = new HexFormFind(hide);
                _formFind.HexBox = this.hexBox;
                _formFind.FindOptions = _findOptions;
                _formFind.Show(this);
            }
            else
            {
                _formFind.Focus();
            }
            return _formFind;
        }

        /// <summary>
        /// Shows the open file dialog.
        /// </summary>
        async Task OpenFile()
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    await OpenFile(ofd.FileName);
                }
            }
        }

        private void FindToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Find();
        }

        private void FindNextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.TopMost = true;
            this.FindNext();
            this.TopMost = false;
        }

        /// <summary>
        /// Find next match
        /// </summary>
        void FindNext()
        {
            ShowFind(true).FindNext();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await OpenFile();
        }

        private async void openToolStripButton_Click(object sender, EventArgs e)
        {
            await OpenFile();
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        private void cutToolStripButton_Click(object sender, EventArgs e)
        {
            this.hexBox.Cut();
        }

        private void copyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.hexBox.Copy();
        }

        private void copyHexToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.hexBox.CopyHex();
        }

        private void pasteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.hexBox.Paste();
        }

        private void pasteHexToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.hexBox.PasteHex();
        }

        private void goToToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Goto();
        }

        /// <summary>
        /// Displays the goto byte dialog.
        /// </summary>
        void Goto()
        {
            _formGoto.SetMaxByteIndex(hexBox.ByteProvider.Length);
            _formGoto.SetDefaultValue(hexBox.SelectionStart);
            if (_formGoto.ShowDialog() == DialogResult.OK)
            {
                hexBox.SelectionStart = _formGoto.GetByteIndex();
                hexBox.SelectionLength = 1;
                hexBox.Focus();
            }
        }
    }
}
