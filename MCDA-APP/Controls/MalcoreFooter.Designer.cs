namespace MCDA_APP.Controls
{
    partial class MalcoreFooter
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MalcoreFooter));
            PictureLogo = new PictureBox();
            LabelTerms = new Label();
            LabelPrivacyPolicy = new Label();
            LabelMalcore = new Label();
            ((System.ComponentModel.ISupportInitialize)PictureLogo).BeginInit();
            SuspendLayout();
            // 
            // PictureLogo
            // 
            PictureLogo.Image = (Image)resources.GetObject("PictureLogo.Image");
            PictureLogo.Location = new Point(26, 13);
            PictureLogo.Name = "PictureLogo";
            PictureLogo.Size = new Size(143, 50);
            PictureLogo.SizeMode = PictureBoxSizeMode.Zoom;
            PictureLogo.TabIndex = 14;
            PictureLogo.TabStop = false;
            // 
            // LabelTerms
            // 
            LabelTerms.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            LabelTerms.AutoSize = true;
            LabelTerms.Cursor = Cursors.Hand;
            LabelTerms.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            LabelTerms.ForeColor = Color.White;
            LabelTerms.Location = new Point(438, 32);
            LabelTerms.Name = "LabelTerms";
            LabelTerms.Size = new Size(88, 16);
            LabelTerms.TabIndex = 16;
            LabelTerms.Text = "Terms of Use";
            LabelTerms.Click += LabelTerms_Click;
            // 
            // LabelPrivacyPolicy
            // 
            LabelPrivacyPolicy.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            LabelPrivacyPolicy.AutoSize = true;
            LabelPrivacyPolicy.Cursor = Cursors.Hand;
            LabelPrivacyPolicy.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            LabelPrivacyPolicy.ForeColor = Color.White;
            LabelPrivacyPolicy.Location = new Point(531, 32);
            LabelPrivacyPolicy.Name = "LabelPrivacyPolicy";
            LabelPrivacyPolicy.Size = new Size(92, 16);
            LabelPrivacyPolicy.TabIndex = 17;
            LabelPrivacyPolicy.Text = "Privacy Policy";
            LabelPrivacyPolicy.Click += LabelPrivacyPolicy_Click;
            // 
            // LabelMalcore
            // 
            LabelMalcore.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            LabelMalcore.AutoSize = true;
            LabelMalcore.Cursor = Cursors.Hand;
            LabelMalcore.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            LabelMalcore.ForeColor = Color.White;
            LabelMalcore.Location = new Point(356, 32);
            LabelMalcore.Name = "LabelMalcore";
            LabelMalcore.Size = new Size(70, 16);
            LabelMalcore.TabIndex = 15;
            LabelMalcore.Text = "malcore.io";
            LabelMalcore.Click += LabelMalcore_Click;
            // 
            // MalcoreFooter
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            Controls.Add(PictureLogo);
            Controls.Add(LabelTerms);
            Controls.Add(LabelPrivacyPolicy);
            Controls.Add(LabelMalcore);
            Name = "MalcoreFooter";
            Size = new Size(651, 77);
            Paint += MalcoreFooter_Paint;
            ((System.ComponentModel.ISupportInitialize)PictureLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox PictureLogo;
        private Label LabelTerms;
        private Label LabelPrivacyPolicy;
        private Label LabelMalcore;
    }
}
