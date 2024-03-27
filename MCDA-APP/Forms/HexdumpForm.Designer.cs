namespace MCDA_APP.Forms
{
    partial class HexdumpForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HexdumpForm));
            LabelSelectFile = new Label();
            labelFileName = new Label();
            panel1 = new Panel();
            UploadPictureBox = new PictureBox();
            HexdumpRichTextBox = new RichTextBox();
            HexdumpPanel = new Panel();
            LoadingLabel = new Label();
            label2 = new Label();
            panel2 = new Panel();
            OffsetTextBox = new TextBox();
            OffsetPanel = new Panel();
            HexSearchPanel = new Panel();
            HexSearchTextBox = new TextBox();
            label1 = new Label();
            panel4 = new Panel();
            ((System.ComponentModel.ISupportInitialize)UploadPictureBox).BeginInit();
            HexdumpPanel.SuspendLayout();
            OffsetPanel.SuspendLayout();
            HexSearchPanel.SuspendLayout();
            SuspendLayout();
            // 
            // LabelSelectFile
            // 
            LabelSelectFile.AutoSize = true;
            LabelSelectFile.Cursor = Cursors.Hand;
            LabelSelectFile.Font = new Font("Calibri", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            LabelSelectFile.ForeColor = SystemColors.AppWorkspace;
            LabelSelectFile.Location = new Point(35, 36);
            LabelSelectFile.Name = "LabelSelectFile";
            LabelSelectFile.Size = new Size(188, 18);
            LabelSelectFile.TabIndex = 0;
            LabelSelectFile.Text = "Click to select executable file";
            LabelSelectFile.Click += LabelSelectFile_Click;
            // 
            // labelFileName
            // 
            labelFileName.Font = new Font("Calibri", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            labelFileName.ForeColor = SystemColors.ButtonHighlight;
            labelFileName.Location = new Point(35, 54);
            labelFileName.Name = "labelFileName";
            labelFileName.RightToLeft = RightToLeft.No;
            labelFileName.Size = new Size(300, 18);
            labelFileName.TabIndex = 1;
            labelFileName.Text = "test.exe";
            labelFileName.Visible = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(111, 101, 101);
            panel1.Location = new Point(38, 75);
            panel1.Name = "panel1";
            panel1.Size = new Size(305, 1);
            panel1.TabIndex = 27;
            // 
            // UploadPictureBox
            // 
            UploadPictureBox.Cursor = Cursors.Hand;
            UploadPictureBox.Image = Properties.Resources.btn_upload;
            UploadPictureBox.Location = new Point(341, 35);
            UploadPictureBox.Name = "UploadPictureBox";
            UploadPictureBox.Size = new Size(94, 39);
            UploadPictureBox.TabIndex = 28;
            UploadPictureBox.TabStop = false;
            UploadPictureBox.Click += UploadPictureBox_Click;
            // 
            // HexdumpRichTextBox
            // 
            HexdumpRichTextBox.BackColor = SystemColors.InfoText;
            HexdumpRichTextBox.BorderStyle = BorderStyle.None;
            HexdumpRichTextBox.Font = new Font("Courier New", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            HexdumpRichTextBox.Location = new Point(14, 10);
            HexdumpRichTextBox.Name = "HexdumpRichTextBox";
            HexdumpRichTextBox.ReadOnly = true;
            HexdumpRichTextBox.Size = new Size(750, 325);
            HexdumpRichTextBox.TabIndex = 30;
            HexdumpRichTextBox.Text = "";
            HexdumpRichTextBox.Visible = false;
            // 
            // HexdumpPanel
            // 
            HexdumpPanel.BackColor = Color.Black;
            HexdumpPanel.Controls.Add(HexdumpRichTextBox);
            HexdumpPanel.Location = new Point(38, 86);
            HexdumpPanel.Name = "HexdumpPanel";
            HexdumpPanel.Size = new Size(767, 342);
            HexdumpPanel.TabIndex = 31;
            HexdumpPanel.Visible = false;
            // 
            // LoadingLabel
            // 
            LoadingLabel.AutoSize = true;
            LoadingLabel.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point);
            LoadingLabel.ForeColor = SystemColors.ButtonFace;
            LoadingLabel.Location = new Point(388, 220);
            LoadingLabel.Name = "LoadingLabel";
            LoadingLabel.Size = new Size(78, 19);
            LoadingLabel.TabIndex = 32;
            LoadingLabel.Text = "Running...";
            LoadingLabel.Visible = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Calibri", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = SystemColors.AppWorkspace;
            label2.Location = new Point(9, 7);
            label2.Name = "label2";
            label2.Size = new Size(132, 18);
            label2.TabIndex = 33;
            label2.Text = "Enter offset to scroll";
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(111, 101, 101);
            panel2.Location = new Point(11, 47);
            panel2.Name = "panel2";
            panel2.Size = new Size(127, 1);
            panel2.TabIndex = 28;
            // 
            // OffsetTextBox
            // 
            OffsetTextBox.BackColor = Color.FromArgb(16, 27, 38);
            OffsetTextBox.BorderStyle = BorderStyle.None;
            OffsetTextBox.Cursor = Cursors.IBeam;
            OffsetTextBox.Font = new Font("Calibri", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            OffsetTextBox.ForeColor = SystemColors.Info;
            OffsetTextBox.Location = new Point(12, 25);
            OffsetTextBox.Name = "OffsetTextBox";
            OffsetTextBox.PlaceholderText = "Enter offset as integer";
            OffsetTextBox.Size = new Size(124, 19);
            OffsetTextBox.TabIndex = 34;
            OffsetTextBox.TextAlign = HorizontalAlignment.Right;
            OffsetTextBox.KeyPress += OffsetTextBox_KeyPress;
            // 
            // OffsetPanel
            // 
            OffsetPanel.Controls.Add(label2);
            OffsetPanel.Controls.Add(OffsetTextBox);
            OffsetPanel.Controls.Add(panel2);
            OffsetPanel.Location = new Point(663, 28);
            OffsetPanel.Name = "OffsetPanel";
            OffsetPanel.Size = new Size(149, 51);
            OffsetPanel.TabIndex = 35;
            OffsetPanel.Visible = false;
            // 
            // HexSearchPanel
            // 
            HexSearchPanel.Controls.Add(HexSearchTextBox);
            HexSearchPanel.Controls.Add(label1);
            HexSearchPanel.Controls.Add(panel4);
            HexSearchPanel.Location = new Point(456, 28);
            HexSearchPanel.Name = "HexSearchPanel";
            HexSearchPanel.Size = new Size(201, 52);
            HexSearchPanel.TabIndex = 36;
            HexSearchPanel.Visible = false;
            // 
            // HexSearchTextBox
            // 
            HexSearchTextBox.BackColor = Color.FromArgb(16, 27, 38);
            HexSearchTextBox.BorderStyle = BorderStyle.None;
            HexSearchTextBox.Cursor = Cursors.IBeam;
            HexSearchTextBox.Font = new Font("Calibri", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            HexSearchTextBox.ForeColor = SystemColors.Info;
            HexSearchTextBox.Location = new Point(3, 25);
            HexSearchTextBox.Name = "HexSearchTextBox";
            HexSearchTextBox.PlaceholderText = "Enter hex with space";
            HexSearchTextBox.Size = new Size(174, 19);
            HexSearchTextBox.TabIndex = 35;
            HexSearchTextBox.TextAlign = HorizontalAlignment.Right;
            HexSearchTextBox.KeyPress += HexSearchTextBox_KeyPress;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Calibri", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.AppWorkspace;
            label1.Location = new Point(56, 7);
            label1.Name = "label1";
            label1.Size = new Size(126, 18);
            label1.TabIndex = 33;
            label1.Text = "Enter hex to search";
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(111, 101, 101);
            panel4.Location = new Point(0, 47);
            panel4.Name = "panel4";
            panel4.Size = new Size(180, 1);
            panel4.TabIndex = 28;
            // 
            // HexdumpForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(16, 27, 38);
            ClientSize = new Size(834, 521);
            Controls.Add(HexSearchPanel);
            Controls.Add(OffsetPanel);
            Controls.Add(LoadingLabel);
            Controls.Add(HexdumpPanel);
            Controls.Add(UploadPictureBox);
            Controls.Add(panel1);
            Controls.Add(labelFileName);
            Controls.Add(LabelSelectFile);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "HexdumpForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Malcore Agent 1.2 | Hexdump";
            Load += HexdumpForm_Load;
            ((System.ComponentModel.ISupportInitialize)UploadPictureBox).EndInit();
            HexdumpPanel.ResumeLayout(false);
            OffsetPanel.ResumeLayout(false);
            OffsetPanel.PerformLayout();
            HexSearchPanel.ResumeLayout(false);
            HexSearchPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label LabelSelectFile;
        private Label labelFileName;
        private Panel panel1;
        private PictureBox UploadPictureBox;
        private RichTextBox HexdumpRichTextBox;
        private Panel HexdumpPanel;
        private Label LoadingLabel;
        private Label label2;
        private Panel panel2;
        private TextBox OffsetTextBox;
        private Panel OffsetPanel;
        private Panel HexSearchPanel;
        private Label label1;
        private Panel panel4;
        private TextBox HexSearchTextBox;
    }
}