namespace MCDA_APP.Forms
{
    partial class MonitoringForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MonitoringForm));
            label2 = new Label();
            panel1 = new Panel();
            panel3 = new Panel();
            lblStatus = new Label();
            labelRemaining = new Label();
            lblRequestNumber = new Label();
            btnLogout = new Button();
            btnSettings = new Button();
            labelPlan = new Label();
            labelEmail = new Label();
            monitoringFlowLayoutPanel = new FlowLayoutPanel();
            queuePanel = new Panel();
            labelQueuedFiles = new Label();
            btnViewQueue = new Button();
            labelInactiveDescription = new Label();
            panelInactive = new Panel();
            label5 = new Label();
            fileSystemWatcherMain = new FileSystemWatcher();
            fileSystemWatcher1 = new FileSystemWatcher();
            fileSystemWatcher2 = new FileSystemWatcher();
            fileSystemWatcher3 = new FileSystemWatcher();
            fileSystemWatcher4 = new FileSystemWatcher();
            fileSystemWatcher5 = new FileSystemWatcher();
            fileSystemWatcher6 = new FileSystemWatcher();
            fileSystemWatcher7 = new FileSystemWatcher();
            fileSystemWatcher8 = new FileSystemWatcher();
            fileSystemWatcher9 = new FileSystemWatcher();
            fileSystemWatcher10 = new FileSystemWatcher();
            fileSystemWatcher11 = new FileSystemWatcher();
            fileSystemWatcher12 = new FileSystemWatcher();
            fileSystemWatcher13 = new FileSystemWatcher();
            fileSystemWatcher14 = new FileSystemWatcher();
            fileSystemWatcher15 = new FileSystemWatcher();
            fileSystemWatcher16 = new FileSystemWatcher();
            fileSystemWatcher17 = new FileSystemWatcher();
            fileSystemWatcher18 = new FileSystemWatcher();
            fileSystemWatcher19 = new FileSystemWatcher();
            notifyIcon1 = new NotifyIcon(components);
            contextMenuStrip1 = new ContextMenuStrip(components);
            exitToolStripMenuItem = new ToolStripMenuItem();
            pictureSettings = new PictureBox();
            pictureLogout = new PictureBox();
            pictureHexdump = new PictureBox();
            monitoringFlowLayoutPanel.SuspendLayout();
            queuePanel.SuspendLayout();
            panelInactive.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcherMain).BeginInit();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher8).BeginInit();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher9).BeginInit();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher10).BeginInit();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher11).BeginInit();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher12).BeginInit();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher13).BeginInit();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher14).BeginInit();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher15).BeginInit();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher16).BeginInit();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher17).BeginInit();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher18).BeginInit();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher19).BeginInit();
            contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureSettings).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureLogout).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureHexdump).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Calibri", 12.75F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.White;
            label2.Location = new Point(10, 78);
            label2.Name = "label2";
            label2.Size = new Size(115, 21);
            label2.TabIndex = 30;
            label2.Text = "MONITORING:";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(111, 101, 101);
            panel1.Location = new Point(-1, 72);
            panel1.Name = "panel1";
            panel1.Size = new Size(840, 1);
            panel1.TabIndex = 26;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(111, 101, 101);
            panel3.Location = new Point(-8, 427);
            panel3.Name = "panel3";
            panel3.Size = new Size(543, 1);
            panel3.TabIndex = 25;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Calibri", 12.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblStatus.ForeColor = Color.FromArgb(149, 215, 161);
            lblStatus.Location = new Point(130, 78);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(60, 21);
            lblStatus.TabIndex = 30;
            lblStatus.Text = "ACTIVE";
            // 
            // labelRemaining
            // 
            labelRemaining.AutoSize = true;
            labelRemaining.Font = new Font("Calibri", 12.75F, FontStyle.Bold, GraphicsUnit.Point);
            labelRemaining.ForeColor = Color.White;
            labelRemaining.Location = new Point(522, 78);
            labelRemaining.Name = "labelRemaining";
            labelRemaining.Size = new Size(149, 21);
            labelRemaining.TabIndex = 30;
            labelRemaining.Text = "Request remaining:";
            // 
            // lblRequestNumber
            // 
            lblRequestNumber.AutoSize = true;
            lblRequestNumber.Font = new Font("Calibri", 12.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblRequestNumber.ForeColor = Color.FromArgb(149, 215, 161);
            lblRequestNumber.Location = new Point(455, 79);
            lblRequestNumber.Name = "lblRequestNumber";
            lblRequestNumber.Size = new Size(0, 21);
            lblRequestNumber.TabIndex = 30;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.FromArgb(26, 26, 34);
            btnLogout.FlatAppearance.BorderColor = Color.Red;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnLogout.ForeColor = Color.FromArgb(244, 7, 3);
            btnLogout.Location = new Point(724, 21);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(85, 31);
            btnLogout.TabIndex = 38;
            btnLogout.Text = "Log Out";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += BtnLogout_Click_1;
            // 
            // btnSettings
            // 
            btnSettings.AutoEllipsis = true;
            btnSettings.BackColor = Color.FromArgb(26, 26, 34);
            btnSettings.FlatAppearance.BorderColor = Color.White;
            btnSettings.FlatStyle = FlatStyle.Flat;
            btnSettings.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnSettings.ForeColor = Color.White;
            btnSettings.Location = new Point(616, 21);
            btnSettings.Name = "btnSettings";
            btnSettings.Size = new Size(85, 31);
            btnSettings.TabIndex = 37;
            btnSettings.Text = "Settings";
            btnSettings.UseVisualStyleBackColor = false;
            btnSettings.Click += BtnSettings_Click_1;
            // 
            // labelPlan
            // 
            labelPlan.AutoSize = true;
            labelPlan.Font = new Font("Calibri", 12.75F, FontStyle.Regular, GraphicsUnit.Point);
            labelPlan.ForeColor = Color.FromArgb(217, 217, 217);
            labelPlan.Location = new Point(18, 37);
            labelPlan.Name = "labelPlan";
            labelPlan.Size = new Size(40, 21);
            labelPlan.TabIndex = 35;
            labelPlan.Text = "Plan";
            // 
            // labelEmail
            // 
            labelEmail.AutoSize = true;
            labelEmail.Font = new Font("Calibri", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            labelEmail.ForeColor = Color.FromArgb(217, 217, 217);
            labelEmail.Location = new Point(17, 10);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new Size(59, 26);
            labelEmail.TabIndex = 36;
            labelEmail.Text = "Email";
            // 
            // monitoringFlowLayoutPanel
            // 
            monitoringFlowLayoutPanel.AllowDrop = true;
            monitoringFlowLayoutPanel.AutoScroll = true;
            monitoringFlowLayoutPanel.Controls.Add(queuePanel);
            monitoringFlowLayoutPanel.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point);
            monitoringFlowLayoutPanel.Location = new Point(0, 106);
            monitoringFlowLayoutPanel.Name = "monitoringFlowLayoutPanel";
            monitoringFlowLayoutPanel.RightToLeft = RightToLeft.No;
            monitoringFlowLayoutPanel.Size = new Size(797, 328);
            monitoringFlowLayoutPanel.TabIndex = 39;
            monitoringFlowLayoutPanel.DragDrop += MonitoringForm_DragDrop;
            monitoringFlowLayoutPanel.DragEnter += MonitoringForm_DragEnter;
            // 
            // queuePanel
            // 
            queuePanel.BackColor = Color.FromArgb(45, 42, 42);
            queuePanel.BackgroundImageLayout = ImageLayout.None;
            queuePanel.Controls.Add(labelQueuedFiles);
            queuePanel.Controls.Add(btnViewQueue);
            queuePanel.Location = new Point(3, 3);
            queuePanel.Name = "queuePanel";
            queuePanel.Size = new Size(770, 38);
            queuePanel.TabIndex = 9;
            // 
            // labelQueuedFiles
            // 
            labelQueuedFiles.AutoSize = true;
            labelQueuedFiles.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            labelQueuedFiles.ForeColor = Color.FromArgb(252, 239, 123);
            labelQueuedFiles.Location = new Point(21, 8);
            labelQueuedFiles.Name = "labelQueuedFiles";
            labelQueuedFiles.Size = new Size(236, 20);
            labelQueuedFiles.TabIndex = 6;
            labelQueuedFiles.Text = "3 files were queued for processing";
            // 
            // btnViewQueue
            // 
            btnViewQueue.BackColor = Color.FromArgb(244, 7, 3);
            btnViewQueue.Cursor = Cursors.Hand;
            btnViewQueue.FlatAppearance.BorderSize = 0;
            btnViewQueue.FlatStyle = FlatStyle.Popup;
            btnViewQueue.Font = new Font("Calibri", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnViewQueue.ForeColor = Color.White;
            btnViewQueue.Location = new Point(593, 6);
            btnViewQueue.Name = "btnViewQueue";
            btnViewQueue.Size = new Size(170, 25);
            btnViewQueue.TabIndex = 5;
            btnViewQueue.Text = "VIEW QUEUE";
            btnViewQueue.UseVisualStyleBackColor = false;
            btnViewQueue.Click += BtnViewQueue_Click;
            // 
            // labelInactiveDescription
            // 
            labelInactiveDescription.AutoSize = true;
            labelInactiveDescription.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point);
            labelInactiveDescription.ForeColor = Color.White;
            labelInactiveDescription.Location = new Point(0, 0);
            labelInactiveDescription.Name = "labelInactiveDescription";
            labelInactiveDescription.Size = new Size(333, 38);
            labelInactiveDescription.TabIndex = 40;
            labelInactiveDescription.Text = "Go to Settings to enable or disable monitoring. \r\n \r\n";
            // 
            // panelInactive
            // 
            panelInactive.Controls.Add(label5);
            panelInactive.Controls.Add(labelInactiveDescription);
            panelInactive.Location = new Point(12, 109);
            panelInactive.Name = "panelInactive";
            panelInactive.Size = new Size(776, 223);
            panelInactive.TabIndex = 0;
            panelInactive.Visible = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Calibri", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = Color.Red;
            label5.Location = new Point(2, 28);
            label5.Name = "label5";
            label5.Size = new Size(235, 18);
            label5.TabIndex = 41;
            label5.Text = "You are out of requests on your plan.\r\n";
            // 
            // fileSystemWatcherMain
            // 
            fileSystemWatcherMain.EnableRaisingEvents = true;
            fileSystemWatcherMain.IncludeSubdirectories = true;
            fileSystemWatcherMain.SynchronizingObject = this;
            fileSystemWatcherMain.Changed += FileSystemWatcherMain_Changed;
            fileSystemWatcherMain.Created += FileSystemWatcherMain_Created_1;
            // 
            // fileSystemWatcher1
            // 
            fileSystemWatcher1.EnableRaisingEvents = true;
            fileSystemWatcher1.IncludeSubdirectories = true;
            fileSystemWatcher1.SynchronizingObject = this;
            fileSystemWatcher1.Created += FileSystemWatcherMain_Created_1;
            // 
            // fileSystemWatcher2
            // 
            fileSystemWatcher2.EnableRaisingEvents = true;
            fileSystemWatcher2.IncludeSubdirectories = true;
            fileSystemWatcher2.SynchronizingObject = this;
            fileSystemWatcher2.Created += FileSystemWatcherMain_Created_1;
            // 
            // fileSystemWatcher3
            // 
            fileSystemWatcher3.EnableRaisingEvents = true;
            fileSystemWatcher3.IncludeSubdirectories = true;
            fileSystemWatcher3.SynchronizingObject = this;
            fileSystemWatcher3.Created += FileSystemWatcherMain_Created_1;
            // 
            // fileSystemWatcher4
            // 
            fileSystemWatcher4.EnableRaisingEvents = true;
            fileSystemWatcher4.IncludeSubdirectories = true;
            fileSystemWatcher4.SynchronizingObject = this;
            fileSystemWatcher4.Created += FileSystemWatcherMain_Created_1;
            // 
            // fileSystemWatcher5
            // 
            fileSystemWatcher5.EnableRaisingEvents = true;
            fileSystemWatcher5.IncludeSubdirectories = true;
            fileSystemWatcher5.SynchronizingObject = this;
            fileSystemWatcher5.Created += FileSystemWatcherMain_Created_1;
            // 
            // fileSystemWatcher6
            // 
            fileSystemWatcher6.EnableRaisingEvents = true;
            fileSystemWatcher6.IncludeSubdirectories = true;
            fileSystemWatcher6.SynchronizingObject = this;
            fileSystemWatcher6.Created += FileSystemWatcherMain_Created_1;
            // 
            // fileSystemWatcher7
            // 
            fileSystemWatcher7.EnableRaisingEvents = true;
            fileSystemWatcher7.IncludeSubdirectories = true;
            fileSystemWatcher7.SynchronizingObject = this;
            fileSystemWatcher7.Created += FileSystemWatcherMain_Created_1;
            // 
            // fileSystemWatcher8
            // 
            fileSystemWatcher8.EnableRaisingEvents = true;
            fileSystemWatcher8.IncludeSubdirectories = true;
            fileSystemWatcher8.SynchronizingObject = this;
            fileSystemWatcher8.Created += FileSystemWatcherMain_Created_1;
            // 
            // fileSystemWatcher9
            // 
            fileSystemWatcher9.EnableRaisingEvents = true;
            fileSystemWatcher9.IncludeSubdirectories = true;
            fileSystemWatcher9.SynchronizingObject = this;
            fileSystemWatcher9.Created += FileSystemWatcherMain_Created_1;
            // 
            // fileSystemWatcher10
            // 
            fileSystemWatcher10.EnableRaisingEvents = true;
            fileSystemWatcher10.IncludeSubdirectories = true;
            fileSystemWatcher10.SynchronizingObject = this;
            fileSystemWatcher10.Created += FileSystemWatcherMain_Created_1;
            // 
            // fileSystemWatcher11
            // 
            fileSystemWatcher11.EnableRaisingEvents = true;
            fileSystemWatcher11.IncludeSubdirectories = true;
            fileSystemWatcher11.SynchronizingObject = this;
            fileSystemWatcher11.Created += FileSystemWatcherMain_Created_1;
            // 
            // fileSystemWatcher12
            // 
            fileSystemWatcher12.EnableRaisingEvents = true;
            fileSystemWatcher12.IncludeSubdirectories = true;
            fileSystemWatcher12.SynchronizingObject = this;
            fileSystemWatcher12.Created += FileSystemWatcherMain_Created_1;
            // 
            // fileSystemWatcher13
            // 
            fileSystemWatcher13.EnableRaisingEvents = true;
            fileSystemWatcher13.IncludeSubdirectories = true;
            fileSystemWatcher13.SynchronizingObject = this;
            fileSystemWatcher13.Created += FileSystemWatcherMain_Created_1;
            // 
            // fileSystemWatcher14
            // 
            fileSystemWatcher14.EnableRaisingEvents = true;
            fileSystemWatcher14.IncludeSubdirectories = true;
            fileSystemWatcher14.SynchronizingObject = this;
            fileSystemWatcher14.Created += FileSystemWatcherMain_Created_1;
            // 
            // fileSystemWatcher15
            // 
            fileSystemWatcher15.EnableRaisingEvents = true;
            fileSystemWatcher15.IncludeSubdirectories = true;
            fileSystemWatcher15.SynchronizingObject = this;
            fileSystemWatcher15.Created += FileSystemWatcherMain_Created_1;
            // 
            // fileSystemWatcher16
            // 
            fileSystemWatcher16.EnableRaisingEvents = true;
            fileSystemWatcher16.IncludeSubdirectories = true;
            fileSystemWatcher16.SynchronizingObject = this;
            fileSystemWatcher16.Created += FileSystemWatcherMain_Created_1;
            // 
            // fileSystemWatcher17
            // 
            fileSystemWatcher17.EnableRaisingEvents = true;
            fileSystemWatcher17.IncludeSubdirectories = true;
            fileSystemWatcher17.SynchronizingObject = this;
            fileSystemWatcher17.Created += FileSystemWatcherMain_Created_1;
            // 
            // fileSystemWatcher18
            // 
            fileSystemWatcher18.EnableRaisingEvents = true;
            fileSystemWatcher18.IncludeSubdirectories = true;
            fileSystemWatcher18.SynchronizingObject = this;
            fileSystemWatcher18.Created += FileSystemWatcherMain_Created_1;
            // 
            // fileSystemWatcher19
            // 
            fileSystemWatcher19.EnableRaisingEvents = true;
            fileSystemWatcher19.IncludeSubdirectories = true;
            fileSystemWatcher19.SynchronizingObject = this;
            fileSystemWatcher19.Created += FileSystemWatcherMain_Created_1;
            // 
            // notifyIcon1
            // 
            notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
            notifyIcon1.BalloonTipText = "Malcore Agent";
            notifyIcon1.BalloonTipTitle = "MCDA";
            notifyIcon1.ContextMenuStrip = contextMenuStrip1;
            notifyIcon1.Icon = (Icon)resources.GetObject("notifyIcon1.Icon");
            notifyIcon1.Text = "Malcore Agent";
            notifyIcon1.MouseDoubleClick += NotifyIcon1_MouseDoubleClick;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { exitToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(179, 26);
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(178, 22);
            exitToolStripMenuItem.Text = "Quit Malcore Agent";
            exitToolStripMenuItem.Click += ExitToolStripMenuItem_Click;
            // 
            // pictureSettings
            // 
            pictureSettings.Cursor = Cursors.Hand;
            pictureSettings.Image = Properties.Resources.btn_settings;
            pictureSettings.Location = new Point(616, 20);
            pictureSettings.Name = "pictureSettings";
            pictureSettings.Size = new Size(95, 38);
            pictureSettings.TabIndex = 40;
            pictureSettings.TabStop = false;
            pictureSettings.Click += PictureSettings_Click;
            // 
            // pictureLogout
            // 
            pictureLogout.BackgroundImage = Properties.Resources.btn_logout;
            pictureLogout.Cursor = Cursors.Hand;
            pictureLogout.Location = new Point(719, 21);
            pictureLogout.Name = "pictureLogout";
            pictureLogout.Size = new Size(90, 38);
            pictureLogout.TabIndex = 41;
            pictureLogout.TabStop = false;
            pictureLogout.Click += PictureLogout_Click;
            // 
            // pictureHexdump
            // 
            pictureHexdump.Cursor = Cursors.Hand;
            pictureHexdump.Image = Properties.Resources.btn_hexdump;
            pictureHexdump.Location = new Point(515, 20);
            pictureHexdump.Name = "pictureHexdump";
            pictureHexdump.Size = new Size(92, 38);
            pictureHexdump.TabIndex = 42;
            pictureHexdump.TabStop = false;
            pictureHexdump.Click += PictureHexdump_Click;
            // 
            // MonitoringForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(16, 27, 38);
            ClientSize = new Size(830, 517);
            Controls.Add(pictureHexdump);
            Controls.Add(pictureLogout);
            Controls.Add(pictureSettings);
            Controls.Add(panelInactive);
            Controls.Add(monitoringFlowLayoutPanel);
            Controls.Add(btnLogout);
            Controls.Add(btnSettings);
            Controls.Add(labelPlan);
            Controls.Add(labelEmail);
            Controls.Add(lblRequestNumber);
            Controls.Add(lblStatus);
            Controls.Add(labelRemaining);
            Controls.Add(label2);
            Controls.Add(panel1);
            Controls.Add(panel3);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "MonitoringForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Malcore Agent 1.2 | Monitoring";
            FormClosing += MonitoringForm_FormClosing;
            Load += MonitoringForm_Load;
            Resize += MonitoringForm_Resize;
            monitoringFlowLayoutPanel.ResumeLayout(false);
            queuePanel.ResumeLayout(false);
            queuePanel.PerformLayout();
            panelInactive.ResumeLayout(false);
            panelInactive.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcherMain).EndInit();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher1).EndInit();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher2).EndInit();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher3).EndInit();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher4).EndInit();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher5).EndInit();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher6).EndInit();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher7).EndInit();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher8).EndInit();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher9).EndInit();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher10).EndInit();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher11).EndInit();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher12).EndInit();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher13).EndInit();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher14).EndInit();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher15).EndInit();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher16).EndInit();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher17).EndInit();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher18).EndInit();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher19).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureSettings).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureLogout).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureHexdump).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label2;
        private Panel panel1;
        private Panel panel3;
        private Label lblStatus;
        private Label labelRemaining;
        private Label lblRequestNumber;
        private Panel panel2;
        private Button btnLogout;
        private Button btnSettings;
        private Label labelPlan;
        private Label labelEmail;
        private FlowLayoutPanel monitoringFlowLayoutPanel;
        private Label labelInactiveDescription;
        private Panel panelInactive;
        private Label label5;
        private FileSystemWatcher fileSystemWatcherMain;
        private FileSystemWatcher fileSystemWatcher1;
        private FileSystemWatcher fileSystemWatcher2;
        private FileSystemWatcher fileSystemWatcher3;
        private FileSystemWatcher fileSystemWatcher4;
        private FileSystemWatcher fileSystemWatcher5;
        private FileSystemWatcher fileSystemWatcher6;
        private FileSystemWatcher fileSystemWatcher7;
        private FileSystemWatcher fileSystemWatcher8;
        private FileSystemWatcher fileSystemWatcher9;
        private FileSystemWatcher fileSystemWatcher10;
        private FileSystemWatcher fileSystemWatcher11;
        private FileSystemWatcher fileSystemWatcher12;
        private FileSystemWatcher fileSystemWatcher13;
        private FileSystemWatcher fileSystemWatcher14;
        private FileSystemWatcher fileSystemWatcher15;
        private FileSystemWatcher fileSystemWatcher16;
        private FileSystemWatcher fileSystemWatcher17;
        private FileSystemWatcher fileSystemWatcher18;
        private FileSystemWatcher fileSystemWatcher19;
        private NotifyIcon notifyIcon1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem exitToolStripMenuItem;
        private Panel queuePanel;
        private Label labelQueuedFiles;
        private Button btnViewQueue;
        private PictureBox pictureSettings;
        private PictureBox pictureLogout;
        private PictureBox pictureHexdump;
    }
}