using MCDA_APP.HexEditor;
using MCDA_APP.HexEditor.Winforms;
using MCDA_APP.Properties;

namespace MCDA_APP.Forms
{
    public partial class HexDump : Form
    {
        public HexBox hexBox;
        private string _fileName;
        private static readonly string TitleMessageBox = "MalcoreIO";
        HexFormFind _formFind;
        FindOptions _findOptions = new FindOptions();

        //FormGoTo _formGoto = new FormGoTo();
        //string _fileName;

        public HexDump()
        {
            InitializeComponent();
            hexBox = new HexBox
            {
                BorderStyle = BorderStyle.None,
                BackColor = Color.FromArgb(55, 55, 55),
                ForeColor = Color.FromArgb(0, 230, 118),

                //Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Left,
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
            //OpenFile(@"C:\Users\bro\Downloads\TRIGGERcmdAgentSetup.exe");
        }

        void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void HexBox_SelectionLengthChanged(object? sender, EventArgs e)
        {
            ManageAbilityForCopyAndPaste();
        }

        private void HexBox_DragEnter(object? sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void HexBox_DragDrop(object? sender, DragEventArgs e)
        {
            object oFileNames = e.Data.GetData(DataFormats.FileDrop);
            string[] fileNames = (string[])oFileNames;
            if (fileNames.Length == 1)
            {
                OpenFile(fileNames[0]);
            }
        }

        void Position_Changed(object sender, EventArgs e)
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

            //this.bitToolStripStatusLabel.Text = bitPresentation;

            //this.bitControl1.BitInfo = bitInfo;
        }

        /// <summary>
        /// Manages enabling or disabling of menu items and toolstrip buttons.
        /// </summary>
        void ManageAbility()
        {
            if (hexBox.ByteProvider == null)
            {

                findToolStripMenuItem.Enabled = false;
                //findNextToolStripMenuItem.Enabled = false;
                //goToToolStripMenuItem.Enabled = false;

                //selectAllToolStripMenuItem.Enabled = false;
            }
            else
            {
                findToolStripMenuItem.Enabled = true;
                //findNextToolStripMenuItem.Enabled = true;
                //goToToolStripMenuItem.Enabled = true;

                //selectAllToolStripMenuItem.Enabled = true;
            }
            //ManageAbilityForCopyAndPaste();
        }


        private void HexDump_Load(object sender, EventArgs e)
        {

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
            //DisplayText();
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

        public void OpenFile(string fileName)
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
                DynamicFileByteProvider dynamicFileByteProvider;
                try
                {
                    // try to open in write mode
                    dynamicFileByteProvider = new DynamicFileByteProvider(fileName);
                    dynamicFileByteProvider.Changed += new EventHandler(byteProvider_Changed);
                    dynamicFileByteProvider.LengthChanged += new EventHandler(byteProvider_LengthChanged);
                }
                catch (IOException) // write mode failed
                {
                    try
                    {
                        // try to open in read-only mode
                        dynamicFileByteProvider = new DynamicFileByteProvider(fileName, true);
                        if (ShowQuestion("Open read only?") == DialogResult.No)
                        {
                            dynamicFileByteProvider.Dispose();
                            return;
                        }
                    }
                    catch (IOException) // read-only also failed
                    {
                        // file cannot be opened
                        ShowError("Failed to open file.");
                        return;
                    }
                }

                hexBox.ByteProvider = dynamicFileByteProvider;
                _fileName = fileName;

                //DisplayText();

                UpdateFileSizeStatus();

                //RecentFileHandler.AddFile(fileName);
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

        /// <summary>
        /// Saves the current file.
        /// </summary>
        void SaveFile()
        {
            if (hexBox.ByteProvider == null)
                return;

            try
            {
                DynamicFileByteProvider dynamicFileByteProvider = hexBox.ByteProvider as DynamicFileByteProvider;
                dynamicFileByteProvider.ApplyChanges();
            }
            catch (Exception ex1)
            {
                ShowError(ex1);
            }
            finally
            {
                ManageAbility();
            }
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
        HexFormFind ShowFind()
        {
            if (_formFind == null || _formFind.IsDisposed)
            {
                _formFind = new HexFormFind();
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
        /// Find next match
        /// </summary>
        void FindNext()
        {
            ShowFind().FindNext();
        }

        /// <summary>
        /// Aborts the current find process
        /// </summary>
        void FormFindCancel_Closed(object sender, EventArgs e)
        {
            hexBox.AbortFind();
        }

        /// <summary>
        /// Displays the goto byte dialog.
        /// </summary>
        void Goto()
        {
            //_formGoto.SetMaxByteIndex(hexBox.ByteProvider.Length);
            //_formGoto.SetDefaultValue(hexBox.SelectionStart);
            //if (_formGoto.ShowDialog() == DialogResult.OK)
            //{
            //    hexBox.SelectionStart = _formGoto.GetByteIndex();
            //    hexBox.SelectionLength = 1;
            //    hexBox.Focus();
            //}
        }

        /// <summary>
        /// Shows the open file dialog.
        /// </summary>
        void OpenFile()
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                OpenFile(openFileDialog.FileName);
            }
        }

        /// <summary>
        /// Manages enabling or disabling of menustrip items and toolstrip buttons for copy and paste
        /// </summary>
        void ManageAbilityForCopyAndPaste()
        {
            copyHexStringToolStripMenuItem.Enabled =
                copyToolStripSplitButton.Enabled = copyToolStripMenuItem.Enabled = hexBox.CanCopy();

            cutToolStripButton.Enabled = cutToolStripMenuItem.Enabled = hexBox.CanCut();
            pasteToolStripSplitButton.Enabled = pasteToolStripMenuItem.Enabled = hexBox.CanPaste();
            pasteHexToolStripMenuItem.Enabled = pasteHexToolStripMenuItem1.Enabled = hexBox.CanPasteHex();
        }

        void hexBox_Copied(object sender, EventArgs e)
        {
            ManageAbilityForCopyAndPaste();
        }

        void hexBox_CopiedHex(object sender, EventArgs e)
        {
            ManageAbilityForCopyAndPaste();
        }

        void hexBox_SelectionLengthChanged(object sender, System.EventArgs e)
        {
            ManageAbilityForCopyAndPaste();
        }

        void hexBox_SelectionStartChanged(object sender, System.EventArgs e)
        {
            ManageAbilityForCopyAndPaste();
        }

        void open_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        void save_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        void cut_Click(object sender, EventArgs e)
        {
            this.hexBox.Cut();
        }

        private void copy_Click(object sender, EventArgs e)
        {
            this.hexBox.Copy();
        }

        void paste_Click(object sender, EventArgs e)
        {
            this.hexBox.Paste();
        }

        private void copyHex_Click(object sender, EventArgs e)
        {
            this.hexBox.CopyHex();
        }

        private void pasteHex_Click(object sender, EventArgs e)
        {
            this.hexBox.PasteHex();
        }

        void find_Click(object sender, EventArgs e)
        {
            this.Find();
        }

        void findNext_Click(object sender, EventArgs e)
        {
            this.FindNext();
        }

        void goTo_Click(object sender, EventArgs e)
        {
            this.Goto();
        }

        void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.hexBox.SelectAll();
        }


        void about_Click(object sender, EventArgs e)
        {
            //new FormAbout().ShowDialog();
        }

        void options_Click(object sender, EventArgs e)
        {
            //new FormOptions().ShowDialog();
        }

        void FormHexEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            var result = CloseFile();
            if (result == DialogResult.Cancel)
                e.Cancel = true;
        }

        void toolStripEncoding_SelectedIndexChanged(object sender, EventArgs e)
        {
            hexBox.ByteCharConverter = encodingToolStripComboBox.SelectedItem as IByteCharConverter;

            foreach (ToolStripMenuItem encodingMenuItem in encodingToolStripMenuItem.DropDownItems)
                encodingMenuItem.Checked = (encodingMenuItem.Tag == hexBox.ByteCharConverter);
        }

        void bitsToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            //UpdateBitControlVisibility();
        }

        //void UpdateBitControlVisibility()
        //{
        //    if (Util.DesignMode)
        //        return;
        //    //if (this.bitControl1.Visible == bitsToolStripMenuItem.Checked)
        //    //{
        //    //    return;
        //    //}
        //    if (bitsToolStripMenuItem.Checked)
        //    {
        //        hexBox.Height -= bitControl1.Height;
        //        bitControl1.Visible = true;
        //    }
        //    else
        //    {
        //        hexBox.Height += bitControl1.Height;
        //        bitControl1.Visible = false;
        //    }
        //}

        //void bitControl1_BitChanged(object sender, EventArgs e)
        //{
        //    hexBox.ByteProvider.WriteByte(bitControl1.BitInfo.Position, bitControl1.BitInfo.Value);
        //    hexBox.Invalidate();
        //}

        void menuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        public static DialogResult ShowError(Exception ex)
        {
            return ShowError(ex.Message);
        }


        internal static DialogResult ShowError(string text)
        {
            DialogResult result = MessageBox.Show(text, TitleMessageBox,
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            return result;
        }

        public static void ShowMessage(string text)
        {
            MessageBox.Show(text, TitleMessageBox,
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        public static DialogResult ShowQuestion(string text)
        {
            DialogResult result = MessageBox.Show(text, TitleMessageBox,
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question);
            return result;
        }
    }
}
