namespace MCDA_APP.Forms
{
    partial class NewScanForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewScanForm));
            CasmButton = new Button();
            DisassemblyButton = new Button();
            HexDumpButton = new Button();
            SuspendLayout();
            // 
            // CasmButton
            // 
            CasmButton.Cursor = Cursors.Hand;
            CasmButton.FlatStyle = FlatStyle.Flat;
            CasmButton.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            CasmButton.ForeColor = Color.White;
            CasmButton.Location = new Point(12, 12);
            CasmButton.Name = "CasmButton";
            CasmButton.Size = new Size(229, 70);
            CasmButton.TabIndex = 0;
            CasmButton.Text = "CODE REUSE";
            CasmButton.UseVisualStyleBackColor = true;
            CasmButton.Click += CasmButton_Click;
            // 
            // DisassemblyButton
            // 
            DisassemblyButton.Cursor = Cursors.Hand;
            DisassemblyButton.FlatStyle = FlatStyle.Flat;
            DisassemblyButton.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            DisassemblyButton.ForeColor = Color.White;
            DisassemblyButton.Location = new Point(12, 93);
            DisassemblyButton.Name = "DisassemblyButton";
            DisassemblyButton.Size = new Size(229, 70);
            DisassemblyButton.TabIndex = 1;
            DisassemblyButton.Text = "DISASSEMBLY";
            DisassemblyButton.UseVisualStyleBackColor = true;
            DisassemblyButton.Click += DisassemblyButton_Click;
            // 
            // HexDumpButton
            // 
            HexDumpButton.Cursor = Cursors.Hand;
            HexDumpButton.FlatStyle = FlatStyle.Flat;
            HexDumpButton.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            HexDumpButton.ForeColor = Color.White;
            HexDumpButton.Location = new Point(12, 174);
            HexDumpButton.Name = "HexDumpButton";
            HexDumpButton.Size = new Size(229, 70);
            HexDumpButton.TabIndex = 2;
            HexDumpButton.Text = "HEXDUMP";
            HexDumpButton.UseVisualStyleBackColor = true;
            HexDumpButton.Click += HexDumpButton_Click;
            // 
            // NewScanForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(26, 26, 34);
            ClientSize = new Size(253, 260);
            Controls.Add(HexDumpButton);
            Controls.Add(DisassemblyButton);
            Controls.Add(CasmButton);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "NewScanForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "NewScanForm";
            ResumeLayout(false);
        }

        #endregion

        private Button CasmButton;
        private Button DisassemblyButton;
        private Button HexDumpButton;
    }
}