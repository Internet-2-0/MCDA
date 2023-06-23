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
            this.label1 = new System.Windows.Forms.Label();
            this.labelEmail = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblTerms = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblMalcore = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.labelInQueueFiles = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.viewQueueFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.label1.Location = new System.Drawing.Point(20, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 21);
            this.label1.TabIndex = 45;
            this.label1.Text = "Enterprise 2.0 Plan";
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.labelEmail.Location = new System.Drawing.Point(19, 12);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(201, 26);
            this.labelEmail.TabIndex = 46;
            this.labelEmail.Text = "mkovalch@gmail.com";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(101)))), ((int)(((byte)(101)))));
            this.panel1.Location = new System.Drawing.Point(1, 74);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(798, 1);
            this.panel1.TabIndex = 49;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(25, 442);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(143, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 53;
            this.pictureBox1.TabStop = false;
            // 
            // lblTerms
            // 
            this.lblTerms.AutoSize = true;
            this.lblTerms.Font = new System.Drawing.Font("Carlito", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTerms.ForeColor = System.Drawing.Color.White;
            this.lblTerms.Location = new System.Drawing.Point(567, 461);
            this.lblTerms.Name = "lblTerms";
            this.lblTerms.Size = new System.Drawing.Size(74, 15);
            this.lblTerms.TabIndex = 50;
            this.lblTerms.Text = "Terms of Use";
            this.lblTerms.Click += new System.EventHandler(this.lblTerms_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Carlito", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(660, 461);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 15);
            this.label3.TabIndex = 51;
            this.label3.Text = "Privacy Policy";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // lblMalcore
            // 
            this.lblMalcore.AutoSize = true;
            this.lblMalcore.Font = new System.Drawing.Font("Carlito", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblMalcore.ForeColor = System.Drawing.Color.White;
            this.lblMalcore.Location = new System.Drawing.Point(485, 461);
            this.lblMalcore.Name = "lblMalcore";
            this.lblMalcore.Size = new System.Drawing.Size(63, 15);
            this.lblMalcore.TabIndex = 52;
            this.lblMalcore.Text = "malcore.io";
            this.lblMalcore.Click += new System.EventHandler(this.lblMalcore_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Calibri", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(215)))), ((int)(((byte)(161)))));
            this.lblStatus.Location = new System.Drawing.Point(132, 84);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(60, 21);
            this.lblStatus.TabIndex = 54;
            this.lblStatus.Text = "ACTIVE";
            // 
            // labelInQueueFiles
            // 
            this.labelInQueueFiles.AutoSize = true;
            this.labelInQueueFiles.Font = new System.Drawing.Font("Calibri", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelInQueueFiles.ForeColor = System.Drawing.Color.White;
            this.labelInQueueFiles.Location = new System.Drawing.Point(660, 84);
            this.labelInQueueFiles.Name = "labelInQueueFiles";
            this.labelInQueueFiles.Size = new System.Drawing.Size(120, 21);
            this.labelInQueueFiles.TabIndex = 55;
            this.labelInQueueFiles.Text = "IN QUEUE FILES";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(22, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 21);
            this.label2.TabIndex = 56;
            this.label2.Text = "MONITORING:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(101)))), ((int)(((byte)(101)))));
            this.panel2.Location = new System.Drawing.Point(2, 429);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(798, 1);
            this.panel2.TabIndex = 57;
            // 
            // viewQueueFlowLayoutPanel
            // 
            this.viewQueueFlowLayoutPanel.AutoScroll = true;
            this.viewQueueFlowLayoutPanel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.viewQueueFlowLayoutPanel.Location = new System.Drawing.Point(3, 116);
            this.viewQueueFlowLayoutPanel.Name = "viewQueueFlowLayoutPanel";
            this.viewQueueFlowLayoutPanel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.viewQueueFlowLayoutPanel.Size = new System.Drawing.Size(795, 307);
            this.viewQueueFlowLayoutPanel.TabIndex = 58;
            // 
            // QueueForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(34)))));
            this.ClientSize = new System.Drawing.Size(804, 508);
            this.Controls.Add(this.viewQueueFlowLayoutPanel);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.labelInQueueFiles);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblTerms);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblMalcore);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelEmail);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "QueueForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Malcore Agent 1.1.0 | Queue";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label label1;
        private Label labelEmail;
        private Panel panel1;
        private PictureBox pictureBox1;
        private Label lblTerms;
        private Label label3;
        private Label lblMalcore;
        private Label lblStatus;
        private Label labelInQueueFiles;
        private Label label2;
        private Panel panel2;
        private FlowLayoutPanel viewQueueFlowLayoutPanel;
    }
}