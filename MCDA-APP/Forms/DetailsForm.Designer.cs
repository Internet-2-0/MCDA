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
            panel1 = new Panel();
            openFileDialog1 = new OpenFileDialog();
            panelDetailItem = new Panel();
            removeButton = new Button();
            releaseButton = new Button();
            folderLabel = new Label();
            percentLabel = new Label();
            fileLabel = new Label();
            colorPanel = new Panel();
            btnLogout = new Button();
            btnSettings = new Button();
            labelPlan = new Label();
            labelEmail = new Label();
            flowLayoutPanelDetails = new FlowLayoutPanel();
            label2 = new Label();
            labelFullPath = new Label();
            panel6 = new Panel();
            panelDetailItem.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(111, 101, 101);
            panel1.Location = new Point(-9, 72);
            panel1.Name = "panel1";
            panel1.Size = new Size(740, 1);
            panel1.TabIndex = 26;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // panelDetailItem
            // 
            panelDetailItem.BackColor = Color.FromArgb(45, 42, 42);
            panelDetailItem.Controls.Add(removeButton);
            panelDetailItem.Controls.Add(releaseButton);
            panelDetailItem.Controls.Add(folderLabel);
            panelDetailItem.Controls.Add(percentLabel);
            panelDetailItem.Controls.Add(fileLabel);
            panelDetailItem.Controls.Add(colorPanel);
            panelDetailItem.Location = new Point(6, 82);
            panelDetailItem.Name = "panelDetailItem";
            panelDetailItem.Size = new Size(716, 44);
            panelDetailItem.TabIndex = 36;
            // 
            // removeButton
            // 
            removeButton.BackColor = Color.FromArgb(220, 5, 5);
            removeButton.FlatAppearance.BorderColor = Color.White;
            removeButton.FlatAppearance.BorderSize = 0;
            removeButton.FlatStyle = FlatStyle.Flat;
            removeButton.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point);
            removeButton.ForeColor = Color.White;
            removeButton.Location = new Point(532, 7);
            removeButton.Name = "removeButton";
            removeButton.Size = new Size(85, 31);
            removeButton.TabIndex = 37;
            removeButton.Text = "DELETE";
            removeButton.UseVisualStyleBackColor = false;
            // 
            // releaseButton
            // 
            releaseButton.BackColor = Color.FromArgb(187, 144, 24);
            releaseButton.FlatAppearance.BorderColor = Color.White;
            releaseButton.FlatAppearance.BorderSize = 0;
            releaseButton.FlatStyle = FlatStyle.Flat;
            releaseButton.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point);
            releaseButton.ForeColor = Color.White;
            releaseButton.Location = new Point(623, 7);
            releaseButton.Name = "releaseButton";
            releaseButton.Size = new Size(85, 31);
            releaseButton.TabIndex = 37;
            releaseButton.Text = "RELEASE";
            releaseButton.UseVisualStyleBackColor = false;
            // 
            // folderLabel
            // 
            folderLabel.Font = new Font("Calibri", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            folderLabel.ForeColor = Color.White;
            folderLabel.Location = new Point(33, 22);
            folderLabel.Name = "folderLabel";
            folderLabel.Size = new Size(199, 16);
            folderLabel.TabIndex = 32;
            folderLabel.Text = "My Documents";
            // 
            // percentLabel
            // 
            percentLabel.Font = new Font("Calibri", 21.75F, FontStyle.Bold, GraphicsUnit.Point);
            percentLabel.ForeColor = Color.FromArgb(255, 122, 0);
            percentLabel.Location = new Point(408, 4);
            percentLabel.Name = "percentLabel";
            percentLabel.Size = new Size(120, 34);
            percentLabel.TabIndex = 31;
            percentLabel.Text = "33%";
            percentLabel.TextAlign = ContentAlignment.TopRight;
            percentLabel.Click += lblFileName_Click;
            // 
            // fileLabel
            // 
            fileLabel.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point);
            fileLabel.ForeColor = Color.White;
            fileLabel.Location = new Point(32, 5);
            fileLabel.Name = "fileLabel";
            fileLabel.Size = new Size(200, 19);
            fileLabel.TabIndex = 31;
            fileLabel.Text = "Duolin.apk";
            fileLabel.Click += lblFileName_Click;
            // 
            // colorPanel
            // 
            colorPanel.BackColor = Color.FromArgb(255, 122, 0);
            colorPanel.Location = new Point(1, 2);
            colorPanel.Name = "colorPanel";
            colorPanel.Size = new Size(26, 44);
            colorPanel.TabIndex = 0;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.FromArgb(26, 26, 34);
            btnLogout.FlatAppearance.BorderColor = Color.Red;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnLogout.ForeColor = Color.FromArgb(244, 7, 3);
            btnLogout.Location = new Point(619, 21);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(85, 31);
            btnLogout.TabIndex = 44;
            btnLogout.Text = "Log Out";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Visible = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnSettings
            // 
            btnSettings.BackColor = Color.FromArgb(26, 26, 34);
            btnSettings.FlatAppearance.BorderColor = Color.White;
            btnSettings.FlatStyle = FlatStyle.Flat;
            btnSettings.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnSettings.ForeColor = Color.White;
            btnSettings.Location = new Point(511, 21);
            btnSettings.Name = "btnSettings";
            btnSettings.Size = new Size(85, 31);
            btnSettings.TabIndex = 43;
            btnSettings.Text = "Settings";
            btnSettings.UseVisualStyleBackColor = false;
            btnSettings.Visible = false;
            btnSettings.Click += btnSettings_Click;
            // 
            // labelPlan
            // 
            labelPlan.AutoSize = true;
            labelPlan.Font = new Font("Calibri", 12.75F, FontStyle.Regular, GraphicsUnit.Point);
            labelPlan.ForeColor = Color.FromArgb(217, 217, 217);
            labelPlan.Location = new Point(18, 37);
            labelPlan.Name = "labelPlan";
            labelPlan.Size = new Size(40, 21);
            labelPlan.TabIndex = 41;
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
            labelEmail.TabIndex = 42;
            labelEmail.Text = "Email";
            // 
            // flowLayoutPanelDetails
            // 
            flowLayoutPanelDetails.AutoScroll = true;
            flowLayoutPanelDetails.ForeColor = Color.White;
            flowLayoutPanelDetails.Location = new Point(7, 158);
            flowLayoutPanelDetails.Name = "flowLayoutPanelDetails";
            flowLayoutPanelDetails.Size = new Size(711, 263);
            flowLayoutPanelDetails.TabIndex = 45;
            flowLayoutPanelDetails.Paint += flowLayoutPanel1_Paint;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Calibri", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.White;
            label2.Location = new Point(14, 133);
            label2.Name = "label2";
            label2.Size = new Size(72, 18);
            label2.TabIndex = 46;
            label2.Text = "File Path : ";
            // 
            // labelFullPath
            // 
            labelFullPath.AutoSize = true;
            labelFullPath.Font = new Font("Calibri", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            labelFullPath.ForeColor = Color.White;
            labelFullPath.Location = new Point(115, 133);
            labelFullPath.Name = "labelFullPath";
            labelFullPath.Size = new Size(209, 18);
            labelFullPath.TabIndex = 38;
            labelFullPath.Text = "C:/Users/username/Downloads/";
            // 
            // panel6
            // 
            panel6.BackColor = Color.FromArgb(111, 101, 101);
            panel6.Location = new Point(15, 155);
            panel6.Name = "panel6";
            panel6.Size = new Size(701, 1);
            panel6.TabIndex = 28;
            // 
            // DetailsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(26, 26, 34);
            ClientSize = new Size(727, 504);
            Controls.Add(panel6);
            Controls.Add(labelFullPath);
            Controls.Add(label2);
            Controls.Add(flowLayoutPanelDetails);
            Controls.Add(btnLogout);
            Controls.Add(btnSettings);
            Controls.Add(labelPlan);
            Controls.Add(labelEmail);
            Controls.Add(panelDetailItem);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "DetailsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Malcore Agent 1.1.1 | Details";
            Load += DetailsForm_Load;
            panelDetailItem.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel panel1;
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
        private Label labelPlan;
        private Label labelEmail;
        private FlowLayoutPanel flowLayoutPanelDetails;
        private Label label2;
        private Label labelFullPath;
        private Panel panel6;
    }
}