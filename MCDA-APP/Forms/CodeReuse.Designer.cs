namespace MCDA_APP.Forms
{
    partial class CodeReuse
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
            TextBoxFile = new Controls.IconTextBox();
            TextBoxSecondFile = new Controls.IconTextBox();
            ButtonSubmitScan = new Button();
            LabelError = new Label();
            SuspendLayout();
            // 
            // TextBoxFile
            // 
            TextBoxFile.BackColor = Color.FromArgb(40, 47, 53);
            TextBoxFile.Cursor = Cursors.Hand;
            TextBoxFile.Location = new Point(24, 28);
            TextBoxFile.Name = "TextBoxFile";
            TextBoxFile.Size = new Size(272, 40);
            TextBoxFile.TabIndex = 0;
            TextBoxFile.TextBoxFontSize = 12F;
            TextBoxFile.TextBoxText = "File";
            // 
            // TextBoxSecondFile
            // 
            TextBoxSecondFile.AllowDrop = true;
            TextBoxSecondFile.BackColor = Color.FromArgb(40, 47, 53);
            TextBoxSecondFile.Cursor = Cursors.Hand;
            TextBoxSecondFile.Location = new Point(325, 28);
            TextBoxSecondFile.Name = "TextBoxSecondFile";
            TextBoxSecondFile.Size = new Size(272, 40);
            TextBoxSecondFile.TabIndex = 1;
            TextBoxSecondFile.TextBoxFontSize = 12F;
            TextBoxSecondFile.TextBoxText = "Secondary File";
            // 
            // ButtonSubmitScan
            // 
            ButtonSubmitScan.BackColor = Color.FromArgb(255, 128, 128);
            ButtonSubmitScan.FlatStyle = FlatStyle.Popup;
            ButtonSubmitScan.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            ButtonSubmitScan.ForeColor = Color.White;
            ButtonSubmitScan.Location = new Point(24, 85);
            ButtonSubmitScan.Name = "ButtonSubmitScan";
            ButtonSubmitScan.Size = new Size(573, 39);
            ButtonSubmitScan.TabIndex = 2;
            ButtonSubmitScan.Text = "SUBMIT SCAN";
            ButtonSubmitScan.UseVisualStyleBackColor = false;
            ButtonSubmitScan.Click += ButtonSubmitScan_Click;
            // 
            // LabelError
            // 
            LabelError.AutoSize = true;
            LabelError.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            LabelError.ForeColor = Color.Red;
            LabelError.Location = new Point(24, 139);
            LabelError.Name = "LabelError";
            LabelError.Size = new Size(0, 21);
            LabelError.TabIndex = 3;
            // 
            // CodeReuse
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(26, 26, 34);
            ClientSize = new Size(618, 169);
            Controls.Add(LabelError);
            Controls.Add(ButtonSubmitScan);
            Controls.Add(TextBoxSecondFile);
            Controls.Add(TextBoxFile);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "CodeReuse";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "%placeholder%";
            Load += CodeReuse_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Controls.IconTextBox TextBoxFile;
        private Controls.IconTextBox TextBoxSecondFile;
        private Button ButtonSubmitScan;
        private Label LabelError;
    }
}