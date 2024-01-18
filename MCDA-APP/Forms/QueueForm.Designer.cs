namespace MCDA_APP.Forms
{
    partial class QueueForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QueueForm));
            labelPlan = new Label();
            labelEmail = new Label();
            panel1 = new Panel();
            lblStatus = new Label();
            labelInQueueFiles = new Label();
            label2 = new Label();
            viewQueueFlowLayoutPanel = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // labelPlan
            // 
            labelPlan.AutoSize = true;
            labelPlan.Font = new Font("Calibri", 12.75F, FontStyle.Regular, GraphicsUnit.Point);
            labelPlan.ForeColor = Color.FromArgb(217, 217, 217);
            labelPlan.Location = new Point(18, 37);
            labelPlan.Name = "labelPlan";
            labelPlan.Size = new Size(40, 21);
            labelPlan.TabIndex = 45;
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
            labelEmail.TabIndex = 46;
            labelEmail.Text = "Email";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(111, 101, 101);
            panel1.Location = new Point(1, 71);
            panel1.Name = "panel1";
            panel1.Size = new Size(798, 1);
            panel1.TabIndex = 49;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Calibri", 12.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblStatus.ForeColor = Color.FromArgb(149, 215, 161);
            lblStatus.Location = new Point(132, 84);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(60, 21);
            lblStatus.TabIndex = 54;
            lblStatus.Text = "ACTIVE";
            // 
            // labelInQueueFiles
            // 
            labelInQueueFiles.AutoSize = true;
            labelInQueueFiles.Font = new Font("Calibri", 12.75F, FontStyle.Bold, GraphicsUnit.Point);
            labelInQueueFiles.ForeColor = Color.White;
            labelInQueueFiles.Location = new Point(660, 84);
            labelInQueueFiles.Name = "labelInQueueFiles";
            labelInQueueFiles.Size = new Size(120, 21);
            labelInQueueFiles.TabIndex = 55;
            labelInQueueFiles.Text = "IN QUEUE FILES";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Calibri", 12.75F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.White;
            label2.Location = new Point(22, 84);
            label2.Name = "label2";
            label2.Size = new Size(115, 21);
            label2.TabIndex = 56;
            label2.Text = "MONITORING:";
            // 
            // viewQueueFlowLayoutPanel
            // 
            viewQueueFlowLayoutPanel.AutoScroll = true;
            viewQueueFlowLayoutPanel.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point);
            viewQueueFlowLayoutPanel.Location = new Point(3, 116);
            viewQueueFlowLayoutPanel.Name = "viewQueueFlowLayoutPanel";
            viewQueueFlowLayoutPanel.RightToLeft = RightToLeft.No;
            viewQueueFlowLayoutPanel.Size = new Size(795, 307);
            viewQueueFlowLayoutPanel.TabIndex = 58;
            // 
            // QueueForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(26, 26, 34);
            ClientSize = new Size(804, 508);
            Controls.Add(viewQueueFlowLayoutPanel);
            Controls.Add(lblStatus);
            Controls.Add(labelInQueueFiles);
            Controls.Add(label2);
            Controls.Add(panel1);
            Controls.Add(labelPlan);
            Controls.Add(labelEmail);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "QueueForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "%placeholder%";
            Load += QueueForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label labelPlan;
        private Label labelEmail;
        private Panel panel1;
        private Label lblStatus;
        private Label labelInQueueFiles;
        private Label label2;
        private FlowLayoutPanel viewQueueFlowLayoutPanel;
    }
}