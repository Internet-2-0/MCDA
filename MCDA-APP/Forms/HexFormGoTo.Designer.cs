namespace MCDA_APP.Forms
{
    partial class HexFormGoTo
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
            label1 = new Label();
            line = new Panel();
            label2 = new Label();
            nup = new NumericUpDown();
            flowLayoutPanel1 = new FlowLayoutPanel();
            btnCancel = new Button();
            btnOK = new Button();
            ((System.ComponentModel.ISupportInitialize)nup).BeginInit();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.ForeColor = Color.DodgerBlue;
            label1.Location = new Point(13, 12);
            label1.Name = "label1";
            label1.Size = new Size(64, 23);
            label1.TabIndex = 0;
            label1.Text = "Goto";
            // 
            // line
            // 
            line.BackColor = Color.LightGray;
            line.Location = new Point(78, 22);
            line.Name = "line";
            line.Size = new Size(195, 1);
            line.TabIndex = 1;
            // 
            // label2
            // 
            label2.ForeColor = Color.White;
            label2.Location = new Point(13, 47);
            label2.Name = "label2";
            label2.Size = new Size(112, 23);
            label2.TabIndex = 2;
            label2.Text = "Byte number:";
            // 
            // nup
            // 
            nup.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            nup.BackColor = Color.FromArgb(26, 26, 34);
            nup.ForeColor = Color.White;
            nup.Location = new Point(153, 47);
            nup.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nup.Name = "nup";
            nup.Size = new Size(120, 23);
            nup.TabIndex = 3;
            nup.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanel1.Controls.Add(btnCancel);
            flowLayoutPanel1.Controls.Add(btnOK);
            flowLayoutPanel1.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanel1.Location = new Point(5, 88);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(268, 40);
            flowLayoutPanel1.TabIndex = 4;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnCancel.ForeColor = Color.Red;
            btnCancel.Location = new Point(134, 3);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(131, 34);
            btnCancel.TabIndex = 0;
            btnCancel.Text = "&CANCEL";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += BtnCancel_Click;
            // 
            // btnOK
            // 
            btnOK.FlatStyle = FlatStyle.Flat;
            btnOK.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnOK.ForeColor = Color.White;
            btnOK.Location = new Point(56, 3);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(72, 34);
            btnOK.TabIndex = 1;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += BtnOK_Click;
            // 
            // HexFormGoTo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(26, 26, 34);
            ClientSize = new Size(279, 138);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(nup);
            Controls.Add(label2);
            Controls.Add(line);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "HexFormGoTo";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Goto byte";
            Activated += HexFormGoTo_Activated;
            ((System.ComponentModel.ISupportInitialize)nup).EndInit();
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Panel line;
        private Label label2;
        private NumericUpDown nup;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button btnCancel;
        private Button btnOK;
    }
}