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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HexFormFind));
            this.txtFind = new System.Windows.Forms.TextBox();
            this.rbString = new System.Windows.Forms.RadioButton();
            this.rbHex = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblPercent = new System.Windows.Forms.Label();
            this.lblFinding = new System.Windows.Forms.Label();
            this.chkMatchCase = new System.Windows.Forms.CheckBox();
            this.timerPercent = new System.Windows.Forms.Timer(this.components);
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.hexFind = new HexBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.line = new System.Windows.Forms.Panel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtFind
            // 
            resources.ApplyResources(this.txtFind, "txtFind");
            this.txtFind.Name = "txtFind";
            this.txtFind.TextChanged += new System.EventHandler(this.txtString_TextChanged);
            // 
            // rbString
            // 
            resources.ApplyResources(this.rbString, "rbString");
            this.rbString.Checked = true;
            this.rbString.Name = "rbString";
            this.rbString.TabStop = true;
            // 
            // rbHex
            // 
            resources.ApplyResources(this.rbHex, "rbHex");
            this.rbHex.Name = "rbHex";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Name = "label1";
            // 
            // btnOK
            // 
            resources.ApplyResources(this.btnOK, "btnOK");
            this.btnOK.Name = "btnOK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblPercent
            // 
            resources.ApplyResources(this.lblPercent, "lblPercent");
            this.lblPercent.Name = "lblPercent";
            // 
            // lblFinding
            // 
            this.lblFinding.ForeColor = System.Drawing.Color.Blue;
            resources.ApplyResources(this.lblFinding, "lblFinding");
            this.lblFinding.Name = "lblFinding";
            // 
            // chkMatchCase
            // 
            resources.ApplyResources(this.chkMatchCase, "chkMatchCase");
            this.chkMatchCase.Name = "chkMatchCase";
            this.chkMatchCase.UseVisualStyleBackColor = true;
            // 
            // timerPercent
            // 
            this.timerPercent.Tick += new System.EventHandler(this.timerPercent_Tick);
            // 
            // timer
            // 
            this.timer.Interval = 50;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // hexFind
            // 
            resources.ApplyResources(this.hexFind, "hexFind");
            // 
            // 
            // 
            this.hexFind.BuiltInContextMenu.CopyMenuItemImage = Properties.Resources.CopyHS;
            this.hexFind.BuiltInContextMenu.CopyMenuItemText = "Copy";
            this.hexFind.BuiltInContextMenu.CutMenuItemImage = Properties.Resources.CutHS;
            this.hexFind.BuiltInContextMenu.CutMenuItemText = "Cut";
            this.hexFind.BuiltInContextMenu.PasteMenuItemImage = Properties.Resources.PasteHS;
            this.hexFind.BuiltInContextMenu.PasteMenuItemText = "Paste";
            this.hexFind.BuiltInContextMenu.SelectAllMenuItemText = "Select All";
            this.hexFind.InfoForeColor = System.Drawing.Color.Empty;
            this.hexFind.Name = "hexFind";
            this.hexFind.ShadowSelectionColor = System.Drawing.Color.FromArgb(100, 60, 188, 255);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.line);
            resources.ApplyResources(this.flowLayoutPanel1, "flowLayoutPanel1");
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            // 
            // line
            // 
            resources.ApplyResources(this.line, "line");
            this.line.BackColor = System.Drawing.Color.LightGray;
            this.line.Name = "line";
            // 
            // flowLayoutPanel2
            // 
            resources.ApplyResources(this.flowLayoutPanel2, "flowLayoutPanel2");
            this.flowLayoutPanel2.Controls.Add(this.btnCancel);
            this.flowLayoutPanel2.Controls.Add(this.btnOK);
            this.flowLayoutPanel2.Controls.Add(this.lblFinding);
            this.flowLayoutPanel2.Controls.Add(this.lblPercent);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            // 
            // FormFind
            // 
            this.AcceptButton = this.btnOK;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.btnCancel;
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.chkMatchCase);
            this.Controls.Add(this.rbHex);
            this.Controls.Add(this.rbString);
            this.Controls.Add(this.txtFind);
            this.Controls.Add(this.hexFind);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormFind";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Activated += new System.EventHandler(this.FormFind_Activated);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}