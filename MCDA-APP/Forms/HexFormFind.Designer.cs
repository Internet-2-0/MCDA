using MCDA_APP.HexEditor.Winforms;

namespace MCDA_APP.Forms
{
    partial class HexFormFind
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
            components = new System.ComponentModel.Container();
            timerPercent = new System.Windows.Forms.Timer(components);
            timer = new System.Windows.Forms.Timer(components);
            flowLayoutPanel1 = new FlowLayoutPanel();
            label1 = new Label();
            line = new Panel();
            rbString = new RadioButton();
            chkMatchCase = new CheckBox();
            txtFind = new TextBox();
            rbHex = new RadioButton();
            hexFind = new HexBox();
            flowLayoutPanel2 = new FlowLayoutPanel();
            btnCancel = new Button();
            btnOK = new Button();
            lblFinding = new Label();
            lblPercent = new Label();
            flowLayoutPanel1.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // timerPercent
            // 
            timerPercent.Tick += TimerPercent_Tick;
            // 
            // timer
            // 
            timer.Interval = 50;
            timer.Tick += Timer_Tick;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(label1);
            flowLayoutPanel1.Controls.Add(line);
            flowLayoutPanel1.Location = new Point(11, 19);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(515, 32);
            flowLayoutPanel1.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.DodgerBlue;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(30, 15);
            label1.TabIndex = 8;
            label1.Text = "Find";
            // 
            // line
            // 
            line.BackColor = Color.LightGray;
            line.Location = new Point(39, 10);
            line.Margin = new Padding(3, 10, 3, 3);
            line.Name = "line";
            line.Size = new Size(462, 1);
            line.TabIndex = 8;
            // 
            // rbString
            // 
            rbString.AutoSize = true;
            rbString.ForeColor = Color.White;
            rbString.Location = new Point(26, 59);
            rbString.Name = "rbString";
            rbString.Size = new Size(46, 19);
            rbString.TabIndex = 8;
            rbString.TabStop = true;
            rbString.Text = "Text";
            rbString.UseVisualStyleBackColor = true;
            // 
            // chkMatchCase
            // 
            chkMatchCase.AutoSize = true;
            chkMatchCase.ForeColor = Color.White;
            chkMatchCase.Location = new Point(384, 57);
            chkMatchCase.Name = "chkMatchCase";
            chkMatchCase.Size = new Size(86, 19);
            chkMatchCase.TabIndex = 9;
            chkMatchCase.Text = "Match case";
            chkMatchCase.UseVisualStyleBackColor = true;
            // 
            // txtFind
            // 
            txtFind.BackColor = Color.FromArgb(46, 46, 65);
            txtFind.ForeColor = Color.White;
            txtFind.Location = new Point(26, 81);
            txtFind.Name = "txtFind";
            txtFind.Size = new Size(495, 23);
            txtFind.TabIndex = 10;
            txtFind.TextChanged += txtString_TextChanged;
            // 
            // rbHex
            // 
            rbHex.AutoSize = true;
            rbHex.ForeColor = Color.White;
            rbHex.Location = new Point(26, 131);
            rbHex.Name = "rbHex";
            rbHex.Size = new Size(46, 19);
            rbHex.TabIndex = 11;
            rbHex.TabStop = true;
            rbHex.Text = "Hex";
            rbHex.UseVisualStyleBackColor = true;
            // 
            // hexFind
            // 
            hexFind.BackColor = Color.FromArgb(46, 46, 65);
            // 
            // 
            // 
            hexFind.BuiltInContextMenu.CopyMenuItemImage = Properties.Resources.CopyHS;
            hexFind.BuiltInContextMenu.CopyMenuItemText = "Copy";
            hexFind.BuiltInContextMenu.CutMenuItemImage = Properties.Resources.CutHS;
            hexFind.BuiltInContextMenu.CutMenuItemText = "Cut";
            hexFind.BuiltInContextMenu.PasteMenuItemImage = Properties.Resources.PasteHS;
            hexFind.BuiltInContextMenu.PasteMenuItemText = "Paste";
            hexFind.BuiltInContextMenu.SelectAllMenuItemText = "Select All";
            hexFind.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            hexFind.ForeColor = Color.White;
            hexFind.Location = new Point(26, 154);
            hexFind.Name = "hexFind";
            hexFind.ShadowSelectionColor = Color.FromArgb(100, 60, 188, 255);
            hexFind.Size = new Size(495, 162);
            hexFind.TabIndex = 12;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(btnCancel);
            flowLayoutPanel2.Controls.Add(btnOK);
            flowLayoutPanel2.Controls.Add(lblFinding);
            flowLayoutPanel2.Controls.Add(lblPercent);
            flowLayoutPanel2.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanel2.Location = new Point(6, 322);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(515, 42);
            flowLayoutPanel2.TabIndex = 13;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnCancel.ForeColor = Color.Red;
            btnCancel.Location = new Point(392, 3);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(120, 34);
            btnCancel.TabIndex = 14;
            btnCancel.Text = "&CANCEL";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += BtnCancel_Click_1;
            // 
            // btnOK
            // 
            btnOK.FlatStyle = FlatStyle.Flat;
            btnOK.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnOK.ForeColor = Color.White;
            btnOK.Location = new Point(266, 3);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(120, 34);
            btnOK.TabIndex = 15;
            btnOK.Text = "FIND";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += BtnOK_Click;
            // 
            // lblFinding
            // 
            lblFinding.ForeColor = Color.Blue;
            lblFinding.Location = new Point(161, 0);
            lblFinding.Name = "lblFinding";
            lblFinding.Size = new Size(99, 34);
            lblFinding.TabIndex = 16;
            // 
            // lblPercent
            // 
            lblPercent.Location = new Point(59, 0);
            lblPercent.Name = "lblPercent";
            lblPercent.Size = new Size(96, 34);
            lblPercent.TabIndex = 17;
            // 
            // HexFormFind
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(26, 26, 34);
            ClientSize = new Size(533, 369);
            Controls.Add(flowLayoutPanel2);
            Controls.Add(hexFind);
            Controls.Add(rbHex);
            Controls.Add(txtFind);
            Controls.Add(chkMatchCase);
            Controls.Add(rbString);
            Controls.Add(flowLayoutPanel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "HexFormFind";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Find";
            Activated += FormFind_Activated;
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            flowLayoutPanel2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
        private Label label1;
        private Panel line;
        private RadioButton rbString;
        private CheckBox chkMatchCase;
        private TextBox txtFind;
        private RadioButton rbHex;
        private HexBox hexFind;
        private FlowLayoutPanel flowLayoutPanel2;
        private Button btnCancel;
        private Button btnOK;
        private Label lblFinding;
        private Label lblPercent;
    }
}