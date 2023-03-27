namespace MCDA_APP.Forms
{
    partial class DetailsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DetailsForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panelDetailItem = new System.Windows.Forms.Panel();
            this.removeButton = new System.Windows.Forms.Button();
            this.releaseButton = new System.Windows.Forms.Button();
            this.folderLabel = new System.Windows.Forms.Label();
            this.percentLabel = new System.Windows.Forms.Label();
            this.fileLabel = new System.Windows.Forms.Label();
            this.colorPanel = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.labelEmail = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblTerms = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblMalcore = new System.Windows.Forms.Label();
            this.flowLayoutPanelDetails = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.labelFullPath = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panelDetailItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
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
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // panelDetailItem
            // 
            this.panelDetailItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.panelDetailItem.Controls.Add(this.removeButton);
            this.panelDetailItem.Controls.Add(this.releaseButton);
            this.panelDetailItem.Controls.Add(this.folderLabel);
            this.panelDetailItem.Controls.Add(this.percentLabel);
            this.panelDetailItem.Controls.Add(this.fileLabel);
            this.panelDetailItem.Controls.Add(this.colorPanel);
            this.panelDetailItem.Location = new System.Drawing.Point(6, 82);
            this.panelDetailItem.Name = "panelDetailItem";
            this.panelDetailItem.Size = new System.Drawing.Size(516, 44);
            this.panelDetailItem.TabIndex = 36;
            // 
            // removeButton
            // 
            this.removeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(5)))), ((int)(((byte)(5)))));
            this.removeButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.removeButton.FlatAppearance.BorderSize = 0;
            this.removeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.removeButton.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.removeButton.ForeColor = System.Drawing.Color.White;
            this.removeButton.Location = new System.Drawing.Point(333, 7);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(85, 31);
            this.removeButton.TabIndex = 37;
            this.removeButton.Text = "DELETE";
            this.removeButton.UseVisualStyleBackColor = false;
            // 
            // releaseButton
            // 
            this.releaseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(144)))), ((int)(((byte)(24)))));
            this.releaseButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.releaseButton.FlatAppearance.BorderSize = 0;
            this.releaseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.releaseButton.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.releaseButton.ForeColor = System.Drawing.Color.White;
            this.releaseButton.Location = new System.Drawing.Point(424, 7);
            this.releaseButton.Name = "releaseButton";
            this.releaseButton.Size = new System.Drawing.Size(85, 31);
            this.releaseButton.TabIndex = 37;
            this.releaseButton.Text = "RELEASE";
            this.releaseButton.UseVisualStyleBackColor = false;
            // 
            // folderLabel
            // 
            this.folderLabel.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.folderLabel.ForeColor = System.Drawing.Color.White;
            this.folderLabel.Location = new System.Drawing.Point(33, 22);
            this.folderLabel.Name = "folderLabel";
            this.folderLabel.Size = new System.Drawing.Size(210, 15);
            this.folderLabel.TabIndex = 32;
            this.folderLabel.Text = "My Documents";
            // 
            // percentLabel
            // 
            this.percentLabel.AutoSize = true;
            this.percentLabel.Font = new System.Drawing.Font("Calibri", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.percentLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(122)))), ((int)(((byte)(0)))));
            this.percentLabel.Location = new System.Drawing.Point(248, 4);
            this.percentLabel.Name = "percentLabel";
            this.percentLabel.Size = new System.Drawing.Size(66, 36);
            this.percentLabel.TabIndex = 31;
            this.percentLabel.Text = "33%";
            this.percentLabel.Click += new System.EventHandler(this.lblFileName_Click);
            // 
            // fileLabel
            // 
            this.fileLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.fileLabel.ForeColor = System.Drawing.Color.White;
            this.fileLabel.Location = new System.Drawing.Point(32, 5);
            this.fileLabel.Name = "fileLabel";
            this.fileLabel.Size = new System.Drawing.Size(200, 19);
            this.fileLabel.TabIndex = 31;
            this.fileLabel.Text = "Duolin.apk";
            this.fileLabel.Click += new System.EventHandler(this.lblFileName_Click);
            // 
            // colorPanel
            // 
            this.colorPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(122)))), ((int)(((byte)(0)))));
            this.colorPanel.Location = new System.Drawing.Point(1, 2);
            this.colorPanel.Name = "colorPanel";
            this.colorPanel.Size = new System.Drawing.Size(26, 44);
            this.colorPanel.TabIndex = 0;
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
            this.btnLogout.TabIndex = 44;
            this.btnLogout.Text = "Log Out";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
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
            this.btnSettings.TabIndex = 43;
            this.btnSettings.Text = "Settings";
            this.btnSettings.UseVisualStyleBackColor = false;
            this.btnSettings.Visible = false;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.label1.Location = new System.Drawing.Point(18, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 21);
            this.label1.TabIndex = 41;
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
            this.labelEmail.TabIndex = 42;
            this.labelEmail.Text = "mkovalch@gmail.com";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(23, 440);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(143, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 40;
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
            this.lblTerms.TabIndex = 37;
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
            this.label3.TabIndex = 38;
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
            this.lblMalcore.TabIndex = 39;
            this.lblMalcore.Text = "malcore.io";
            // 
            // flowLayoutPanelDetails
            // 
            this.flowLayoutPanelDetails.AutoScroll = true;
            this.flowLayoutPanelDetails.ForeColor = System.Drawing.Color.White;
            this.flowLayoutPanelDetails.Location = new System.Drawing.Point(7, 158);
            this.flowLayoutPanelDetails.Name = "flowLayoutPanelDetails";
            this.flowLayoutPanelDetails.Size = new System.Drawing.Size(511, 263);
            this.flowLayoutPanelDetails.TabIndex = 45;
            this.flowLayoutPanelDetails.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel1_Paint);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(51, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 18);
            this.label2.TabIndex = 46;
            this.label2.Text = "File Path";
            // 
            // labelFullPath
            // 
            this.labelFullPath.AutoSize = true;
            this.labelFullPath.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelFullPath.ForeColor = System.Drawing.Color.White;
            this.labelFullPath.Location = new System.Drawing.Point(152, 133);
            this.labelFullPath.Name = "labelFullPath";
            this.labelFullPath.Size = new System.Drawing.Size(209, 18);
            this.labelFullPath.TabIndex = 38;
            this.labelFullPath.Text = "C:/Users/username/Downloads/";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(101)))), ((int)(((byte)(101)))));
            this.panel6.Location = new System.Drawing.Point(15, 155);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(501, 1);
            this.panel6.TabIndex = 28;
            // 
            // DetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(34)))));
            this.ClientSize = new System.Drawing.Size(527, 504);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.labelFullPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.flowLayoutPanelDetails);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelEmail);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblTerms);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblMalcore);
            this.Controls.Add(this.panelDetailItem);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "DetailsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DetailsForm";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.DetailsForm_Load);
            this.panelDetailItem.ResumeLayout(false);
            this.panelDetailItem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Panel panel1;
        private Panel panel3;
        private OpenFileDialog openFileDialog1;
        private Panel panelDetailItem;
        private Panel colorPanel;
        private Label fileLabel;
        private Button removeButton;
        private Button releaseButton;
        private Label folderLabel;
        private Label percentLabel;
        private Button btnLogout;
        private Button btnSettings;
        private Label label1;
        private Label labelEmail;
        private PictureBox pictureBox1;
        private Label lblTerms;
        private Label label3;
        private Label lblMalcore;
        private FlowLayoutPanel flowLayoutPanelDetails;
        private Label label2;
        private Label labelFullPath;
        private Panel panel6;
    }
}