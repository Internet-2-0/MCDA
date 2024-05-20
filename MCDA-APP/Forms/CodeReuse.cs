using MCDA_APP.Controls;
using MCDA_APP.Model.Agent;
using MCDA_APP.Model.Api.Reuse;
using Newtonsoft.Json;

namespace MCDA_APP.Forms
{
    public partial class CodeReuse : Form
    {
        private Overlay? _overlay;

        public CodeReuse() => InitializeComponent();

        private void CodeReuse_Load(object sender, EventArgs e)
        {
            Text = string.Format(Constants.MalcoreFormTitle, Helper.GetAgentVersion(), "Code Reuse");

            TextBoxFile.DragEnter += TextBox_DragEnter;
            TextBoxSecondFile.DragEnter += TextBox_DragEnter;

            TextBoxSecondFile.DragDrop += TextBox_DragDrop;
            TextBoxFile.DragDrop += TextBox_DragDrop;

            TextBoxFile.Click += TextBox_Click;
            TextBoxSecondFile.Click += TextBox_Click;

            _overlay = new Overlay
            {
                Dock = DockStyle.Fill,
                Enabled = true,
            };
        }

        private void TextBox_Click(object? sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "All Files|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    ((IconTextBox)sender!).TextBoxText = openFileDialog.FileName;
                }
            }
        }

        private void TextBox_DragEnter(object? sender, DragEventArgs e)
        {
            if (e.Data!.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void TextBox_DragDrop(object? sender, DragEventArgs e)
        {
            if (e.Data!.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (files.Length > 0)
                {
                    ((IconTextBox)sender!).TextBoxText = files[0];
                }
            }
        }

        private void ButtonSubmitScan_Click(object sender, EventArgs e)
        {
            if (!File.Exists(TextBoxFile.TextBoxText))
            {
                LabelError.Text = "First file does not exist!";
                return;
            }

            if (!File.Exists(TextBoxSecondFile.TextBoxText))
            {
                LabelError.Text = "Second file does not exist!";
                return;
            }

            this.Controls.Add(_overlay);
            _overlay.BringToFront();

            backgroundWorker1.RunWorkerAsync();

        }

        private async void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            List<FileToUpload> files = new()
            {
                new FileToUpload(Path.GetFileName(TextBoxFile.TextBoxText), File.ReadAllBytes(TextBoxFile.TextBoxText)),
                new FileToUpload(Path.GetFileName(TextBoxSecondFile.TextBoxText), File.ReadAllBytes(TextBoxSecondFile.TextBoxText))
            };

            try
            {
                string json = await Program.Client!.UploadFiles($"{Constants.ApiBaseUrl}/api/reuse", files);
                var parsedData = JsonConvert.DeserializeObject<ReuseResponse>(json);

                RemoveOverlay();

                CodeReuseResult codeReuseResult = new CodeReuseResult(parsedData);
                codeReuseResult.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Malcore.io", MessageBoxButtons.OK, MessageBoxIcon.Error);
                RemoveOverlay();
            }
        }

        private void RemoveOverlay()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(RemoveOverlay));
            }
            else
            {
                this.Controls.Remove(_overlay);
            }
        }
    }
}
