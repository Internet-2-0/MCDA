namespace MCDA_APP.Forms
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            labelEmail = new Label();
            labelPlan = new Label();
            panel1 = new Panel();
            btnLogout = new Button();
            label2 = new Label();
            checkEnableMonitor = new CheckBox();
            checkSendStatistics = new CheckBox();
            checkOpenOnStartup = new CheckBox();
            label4 = new Label();
            textMinScore = new TextBox();
            btnAdd = new Button();
            label5 = new Label();
            txtApikey = new TextBox();
            panel2 = new Panel();
            btnSave = new Button();
            btnCancel = new Button();
            panel4 = new Panel();
            openFileDialog = new OpenFileDialog();
            folderBrowserDialog = new FolderBrowserDialog();
            flowLayoutPanelForFolders = new FlowLayoutPanel();
            pictureBox2 = new PictureBox();
            notifyIcon1 = new NotifyIcon(components);
            contextMenuStrip1 = new ContextMenuStrip(components);
            quitMalcoreAgentToolStripMenuItem = new ToolStripMenuItem();
            btnClear = new Button();
            panel2.SuspendLayout();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // labelEmail
            // 
            labelEmail.AutoSize = true;
            labelEmail.Font = new Font("Calibri", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            labelEmail.ForeColor = Color.FromArgb(217, 217, 217);
            labelEmail.Location = new Point(17, 10);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new Size(59, 26);
            labelEmail.TabIndex = 13;
            labelEmail.Text = "Email";
            // 
            // labelPlan
            // 
            labelPlan.AutoSize = true;
            labelPlan.Font = new Font("Calibri", 12.75F, FontStyle.Regular, GraphicsUnit.Point);
            labelPlan.ForeColor = Color.FromArgb(217, 217, 217);
            labelPlan.Location = new Point(18, 37);
            labelPlan.Name = "labelPlan";
            labelPlan.Size = new Size(40, 21);
            labelPlan.TabIndex = 13;
            labelPlan.Text = "Plan";
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.BackColor = Color.FromArgb(111, 101, 101);
            panel1.Location = new Point(1, 70);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 1);
            panel1.TabIndex = 11;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.FromArgb(26, 26, 34);
            btnLogout.FlatAppearance.BorderColor = Color.Red;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnLogout.ForeColor = Color.FromArgb(244, 7, 3);
            btnLogout.Location = new Point(689, 21);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(85, 31);
            btnLogout.TabIndex = 15;
            btnLogout.Text = "Log Out";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Calibri", 12.75F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.White;
            label2.Location = new Point(20, 84);
            label2.Name = "label2";
            label2.Size = new Size(124, 21);
            label2.TabIndex = 13;
            label2.Text = "Monitor Folders";
            // 
            // checkEnableMonitor
            // 
            checkEnableMonitor.AutoSize = true;
            checkEnableMonitor.Checked = true;
            checkEnableMonitor.CheckState = CheckState.Checked;
            checkEnableMonitor.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point);
            checkEnableMonitor.ForeColor = Color.White;
            checkEnableMonitor.Location = new Point(528, 101);
            checkEnableMonitor.Name = "checkEnableMonitor";
            checkEnableMonitor.Size = new Size(156, 23);
            checkEnableMonitor.TabIndex = 17;
            checkEnableMonitor.Text = "Enable Monitoring";
            checkEnableMonitor.UseVisualStyleBackColor = true;
            // 
            // checkSendStatistics
            // 
            checkSendStatistics.AutoSize = true;
            checkSendStatistics.Checked = true;
            checkSendStatistics.CheckState = CheckState.Checked;
            checkSendStatistics.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point);
            checkSendStatistics.ForeColor = Color.White;
            checkSendStatistics.Location = new Point(528, 134);
            checkSendStatistics.Name = "checkSendStatistics";
            checkSendStatistics.Size = new Size(125, 23);
            checkSendStatistics.TabIndex = 17;
            checkSendStatistics.Text = "Send Statistics";
            checkSendStatistics.UseVisualStyleBackColor = true;
            // 
            // checkOpenOnStartup
            // 
            checkOpenOnStartup.AutoSize = true;
            checkOpenOnStartup.Checked = true;
            checkOpenOnStartup.CheckState = CheckState.Checked;
            checkOpenOnStartup.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point);
            checkOpenOnStartup.ForeColor = Color.White;
            checkOpenOnStartup.Location = new Point(528, 167);
            checkOpenOnStartup.Name = "checkOpenOnStartup";
            checkOpenOnStartup.Size = new Size(209, 23);
            checkOpenOnStartup.TabIndex = 17;
            checkOpenOnStartup.Text = "Open on Windows startup";
            checkOpenOnStartup.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Calibri", 12.75F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = Color.White;
            label4.Location = new Point(564, 207);
            label4.Name = "label4";
            label4.Size = new Size(147, 21);
            label4.TabIndex = 13;
            label4.Text = "Min % Threat Score";
            // 
            // textMinScore
            // 
            textMinScore.BackColor = Color.FromArgb(26, 26, 34);
            textMinScore.BorderStyle = BorderStyle.None;
            textMinScore.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textMinScore.ForeColor = Color.White;
            textMinScore.Location = new Point(6, 4);
            textMinScore.Name = "textMinScore";
            textMinScore.Size = new Size(20, 19);
            textMinScore.TabIndex = 18;
            textMinScore.Text = "15";
            textMinScore.TextAlign = HorizontalAlignment.Center;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(26, 26, 34);
            btnAdd.FlatAppearance.BorderColor = Color.White;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(397, 255);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(85, 28);
            btnAdd.TabIndex = 14;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Calibri", 12.75F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = Color.White;
            label5.Location = new Point(24, 292);
            label5.Name = "label5";
            label5.Size = new Size(172, 21);
            label5.TabIndex = 13;
            label5.Text = "Currently Using ApiKey";
            // 
            // txtApikey
            // 
            txtApikey.BackColor = Color.FromArgb(100, 79, 79);
            txtApikey.BorderStyle = BorderStyle.None;
            txtApikey.Font = new Font("Segoe MDL2 Assets", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtApikey.ForeColor = Color.White;
            txtApikey.Location = new Point(4, 5);
            txtApikey.Name = "txtApikey";
            txtApikey.ReadOnly = true;
            txtApikey.Size = new Size(469, 16);
            txtApikey.TabIndex = 2;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(100, 79, 79);
            panel2.BorderStyle = BorderStyle.Fixed3D;
            panel2.Controls.Add(txtApikey);
            panel2.Location = new Point(28, 314);
            panel2.Name = "panel2";
            panel2.Size = new Size(745, 35);
            panel2.TabIndex = 19;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.Black;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnSave.ForeColor = SystemColors.Control;
            btnSave.Location = new Point(644, 371);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(129, 39);
            btnSave.TabIndex = 20;
            btnSave.Text = "SAVE";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(100, 79, 79);
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnCancel.ForeColor = SystemColors.Control;
            btnCancel.Location = new Point(492, 371);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(129, 39);
            btnCancel.TabIndex = 20;
            btnCancel.Text = "CANCEL";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // panel4
            // 
            panel4.BorderStyle = BorderStyle.Fixed3D;
            panel4.Controls.Add(textMinScore);
            panel4.Location = new Point(523, 201);
            panel4.Name = "panel4";
            panel4.Size = new Size(32, 32);
            panel4.TabIndex = 21;
            // 
            // openFileDialog
            // 
            openFileDialog.FileName = "openFileDialog1";
            // 
            // flowLayoutPanelForFolders
            // 
            flowLayoutPanelForFolders.AllowDrop = true;
            flowLayoutPanelForFolders.AutoScroll = true;
            flowLayoutPanelForFolders.BorderStyle = BorderStyle.Fixed3D;
            flowLayoutPanelForFolders.Font = new Font("Cascadia Mono", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            flowLayoutPanelForFolders.Location = new Point(23, 108);
            flowLayoutPanelForFolders.Margin = new Padding(0);
            flowLayoutPanelForFolders.Name = "flowLayoutPanelForFolders";
            flowLayoutPanelForFolders.Size = new Size(459, 125);
            flowLayoutPanelForFolders.TabIndex = 22;
            flowLayoutPanelForFolders.DragDrop += settingsForm_DragDrop;
            flowLayoutPanelForFolders.DragEnter += settingsForm_DrapEnter;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(615, 281);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(20, 22);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 23;
            pictureBox2.TabStop = false;
            pictureBox2.Visible = false;
            // 
            // notifyIcon1
            // 
            notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
            notifyIcon1.BalloonTipText = "Malcore Agent";
            notifyIcon1.BalloonTipTitle = "MCDA";
            notifyIcon1.ContextMenuStrip = contextMenuStrip1;
            notifyIcon1.Icon = (Icon)resources.GetObject("notifyIcon1.Icon");
            notifyIcon1.Text = "Malcore Agent";
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { quitMalcoreAgentToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(179, 26);
            // 
            // quitMalcoreAgentToolStripMenuItem
            // 
            quitMalcoreAgentToolStripMenuItem.Name = "quitMalcoreAgentToolStripMenuItem";
            quitMalcoreAgentToolStripMenuItem.Size = new Size(178, 22);
            quitMalcoreAgentToolStripMenuItem.Text = "Quit Malcore Agent";
            quitMalcoreAgentToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.FromArgb(26, 26, 34);
            btnClear.FlatAppearance.BorderColor = Color.Red;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnClear.ForeColor = Color.FromArgb(244, 7, 3);
            btnClear.Location = new Point(554, 21);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(118, 31);
            btnClear.TabIndex = 24;
            btnClear.Text = "Clear History";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(26, 26, 34);
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(800, 504);
            Controls.Add(btnClear);
            Controls.Add(pictureBox2);
            Controls.Add(flowLayoutPanelForFolders);
            Controls.Add(panel4);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(panel2);
            Controls.Add(checkOpenOnStartup);
            Controls.Add(checkSendStatistics);
            Controls.Add(checkEnableMonitor);
            Controls.Add(btnLogout);
            Controls.Add(btnAdd);
            Controls.Add(label4);
            Controls.Add(label5);
            Controls.Add(label2);
            Controls.Add(labelPlan);
            Controls.Add(labelEmail);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "SettingsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Malcore Agent 1.1.1 | Settings";
            FormClosing += SettingsForm_FormClosing;
            Load += SettingsForm_Load;
            Resize += SettingsForm_Resize;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label labelEmail;
        private Label labelPlan;
        private Panel panel1;
        private Button btnLogout;
        private Label label2;
        private CheckBox checkEnableMonitor;
        private CheckBox checkSendStatistics;
        private CheckBox checkOpenOnStartup;
        private Label label4;
        private TextBox textMinScore;
        private Button btnAdd;
        private Label label5;
        private TextBox txtApikey;
        private Panel panel2;
        private Button btnSave;
        private Button btnCancel;
        private Panel panel4;
        private OpenFileDialog openFileDialog;
        private FolderBrowserDialog folderBrowserDialog;
        private FlowLayoutPanel flowLayoutPanelForFolders;
        private PictureBox pictureBox2;
        private NotifyIcon notifyIcon1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem quitMalcoreAgentToolStripMenuItem;
        private Button btnClear;
    }
}