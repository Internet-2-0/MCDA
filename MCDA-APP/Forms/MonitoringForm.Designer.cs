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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MonitoringForm));
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.labelRemaining = new System.Windows.Forms.Label();
            this.lblRequestNumber = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.labelEmail = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblTerms = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblMalcore = new System.Windows.Forms.Label();
            this.monitoringFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.labelInactiveDescription = new System.Windows.Forms.Label();
            this.panelInactive = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelInactive.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(10, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 21);
            this.label2.TabIndex = 30;
            this.label2.Text = "MONITORING:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(101)))), ((int)(((byte)(101)))));
            this.panel1.Location = new System.Drawing.Point(-9, 72);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(540, 1);
            this.panel1.TabIndex = 26;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(101)))), ((int)(((byte)(101)))));
            this.panel3.Location = new System.Drawing.Point(-8, 427);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(543, 1);
            this.panel3.TabIndex = 25;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Calibri", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(215)))), ((int)(((byte)(161)))));
            this.lblStatus.Location = new System.Drawing.Point(120, 78);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(60, 21);
            this.lblStatus.TabIndex = 30;
            this.lblStatus.Text = "ACTIVE";
            this.lblStatus.Click += new System.EventHandler(this.lblStatus_Click);
            // 
            // labelRemaining
            // 
            this.labelRemaining.AutoSize = true;
            this.labelRemaining.Font = new System.Drawing.Font("Calibri", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelRemaining.ForeColor = System.Drawing.Color.White;
            this.labelRemaining.Location = new System.Drawing.Point(310, 78);
            this.labelRemaining.Name = "labelRemaining";
            this.labelRemaining.Size = new System.Drawing.Size(149, 21);
            this.labelRemaining.TabIndex = 30;
            this.labelRemaining.Text = "Request remaining:";
            // 
            // lblRequestNumber
            // 
            this.lblRequestNumber.AutoSize = true;
            this.lblRequestNumber.Font = new System.Drawing.Font("Calibri", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblRequestNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(215)))), ((int)(((byte)(161)))));
            this.lblRequestNumber.Location = new System.Drawing.Point(455, 79);
            this.lblRequestNumber.Name = "lblRequestNumber";
            this.lblRequestNumber.Size = new System.Drawing.Size(59, 21);
            this.lblRequestNumber.TabIndex = 30;
            this.lblRequestNumber.Text = "20,000";
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(34)))));
            this.btnLogout.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnLogout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(7)))), ((int)(((byte)(3)))));
            this.btnLogout.Location = new System.Drawing.Point(428, 21);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(85, 31);
            this.btnLogout.TabIndex = 38;
            this.btnLogout.Text = "Log Out";
            this.btnLogout.UseVisualStyleBackColor = false;
            // 
            // btnSettings
            // 
            this.btnSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(34)))));
            this.btnSettings.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSettings.ForeColor = System.Drawing.Color.White;
            this.btnSettings.Location = new System.Drawing.Point(320, 21);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(85, 31);
            this.btnSettings.TabIndex = 37;
            this.btnSettings.Text = "Settings";
            this.btnSettings.UseVisualStyleBackColor = false;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.label1.Location = new System.Drawing.Point(18, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 21);
            this.label1.TabIndex = 35;
            this.label1.Text = "Enterprise 2.0 Plan";
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.labelEmail.Location = new System.Drawing.Point(17, 10);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(201, 26);
            this.labelEmail.TabIndex = 36;
            this.labelEmail.Text = "mkovalch@gmail.com";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(23, 440);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(143, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 34;
            this.pictureBox1.TabStop = false;
            // 
            // lblTerms
            // 
            this.lblTerms.AutoSize = true;
            this.lblTerms.Font = new System.Drawing.Font("Carlito", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTerms.ForeColor = System.Drawing.Color.White;
            this.lblTerms.Location = new System.Drawing.Point(324, 460);
            this.lblTerms.Name = "lblTerms";
            this.lblTerms.Size = new System.Drawing.Size(74, 15);
            this.lblTerms.TabIndex = 31;
            this.lblTerms.Text = "Terms of Use";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Carlito", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(417, 460);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 15);
            this.label3.TabIndex = 32;
            this.label3.Text = "Privacy Policy";
            // 
            // lblMalcore
            // 
            this.lblMalcore.AutoSize = true;
            this.lblMalcore.Font = new System.Drawing.Font("Carlito", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblMalcore.ForeColor = System.Drawing.Color.White;
            this.lblMalcore.Location = new System.Drawing.Point(242, 460);
            this.lblMalcore.Name = "lblMalcore";
            this.lblMalcore.Size = new System.Drawing.Size(63, 15);
            this.lblMalcore.TabIndex = 33;
            this.lblMalcore.Text = "malcore.io";
            // 
            // monitoringFlowLayoutPanel
            // 
            this.monitoringFlowLayoutPanel.AutoScroll = true;
            this.monitoringFlowLayoutPanel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.monitoringFlowLayoutPanel.Location = new System.Drawing.Point(0, 106);
            this.monitoringFlowLayoutPanel.Name = "monitoringFlowLayoutPanel";
            this.monitoringFlowLayoutPanel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.monitoringFlowLayoutPanel.Size = new System.Drawing.Size(525, 322);
            this.monitoringFlowLayoutPanel.TabIndex = 39;
            // 
            // labelInactiveDescription
            // 
            this.labelInactiveDescription.AutoSize = true;
            this.labelInactiveDescription.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelInactiveDescription.ForeColor = System.Drawing.Color.White;
            this.labelInactiveDescription.Location = new System.Drawing.Point(0, 0);
            this.labelInactiveDescription.Name = "labelInactiveDescription";
            this.labelInactiveDescription.Size = new System.Drawing.Size(333, 38);
            this.labelInactiveDescription.TabIndex = 40;
            this.labelInactiveDescription.Text = "Go to Settings to enable or disable monitoring. \r\n \r\n";
            this.labelInactiveDescription.Click += new System.EventHandler(this.labelInactiveDescription_Click);
            // 
            // panelInactive
            // 
            this.panelInactive.Controls.Add(this.label5);
            this.panelInactive.Controls.Add(this.labelInactiveDescription);
            this.panelInactive.Location = new System.Drawing.Point(12, 109);
            this.panelInactive.Name = "panelInactive";
            this.panelInactive.Size = new System.Drawing.Size(483, 217);
            this.panelInactive.TabIndex = 0;
            this.panelInactive.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(2, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(235, 18);
            this.label5.TabIndex = 41;
            this.label5.Text = "You are out of requests on your plan.\r\n";
            // 
            // MonitoringForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(34)))));
            this.ClientSize = new System.Drawing.Size(527, 504);
            this.Controls.Add(this.panelInactive);
            this.Controls.Add(this.monitoringFlowLayoutPanel);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelEmail);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblTerms);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblMalcore);
            this.Controls.Add(this.lblRequestNumber);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.labelRemaining);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MonitoringForm";
            this.Text = "Malcore Agent 1.0.0 | Monitoring";
            this.Load += new System.EventHandler(this.MonitoringForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelInactive.ResumeLayout(false);
            this.panelInactive.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private Label label1;
        private Label labelEmail;
        private PictureBox pictureBox1;
        private Label lblTerms;
        private Label label3;
        private Label lblMalcore;
        private FlowLayoutPanel monitoringFlowLayoutPanel;
        private Label labelInactiveDescription;
        private Panel panelInactive;
        private Label label5;
    }
}