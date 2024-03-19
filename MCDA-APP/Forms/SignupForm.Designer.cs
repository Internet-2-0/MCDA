namespace MCDA_APP.Forms
{
    partial class SignupForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SignupForm));
            BtnLogin = new Button();
            LabelError = new Label();
            TxtRegEmail = new TextBox();
            PanelEmail = new Panel();
            LabelPassword = new Label();
            TxtRegPassword = new TextBox();
            PanelPassword = new Panel();
            LabelEmail = new Label();
            pictureRegister = new PictureBox();
            PanelEmail.SuspendLayout();
            PanelPassword.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureRegister).BeginInit();
            SuspendLayout();
            // 
            // BtnLogin
            // 
            BtnLogin.BackColor = Color.FromArgb(244, 7, 3);
            BtnLogin.Cursor = Cursors.Hand;
            BtnLogin.FlatAppearance.BorderSize = 0;
            BtnLogin.FlatStyle = FlatStyle.Popup;
            BtnLogin.Font = new Font("Calibri", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            BtnLogin.ForeColor = Color.White;
            BtnLogin.Location = new Point(271, 257);
            BtnLogin.Name = "BtnLogin";
            BtnLogin.Size = new Size(132, 40);
            BtnLogin.TabIndex = 19;
            BtnLogin.Text = "LOGIN";
            BtnLogin.UseVisualStyleBackColor = false;
            // 
            // LabelError
            // 
            LabelError.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point);
            LabelError.ForeColor = Color.FromArgb(244, 7, 3);
            LabelError.Location = new Point(78, 302);
            LabelError.Name = "LabelError";
            LabelError.Size = new Size(371, 30);
            LabelError.TabIndex = 16;
            LabelError.TextAlign = ContentAlignment.MiddleCenter;
            LabelError.UseMnemonic = false;
            // 
            // TxtRegEmail
            // 
            TxtRegEmail.BackColor = Color.FromArgb(33, 43, 53);
            TxtRegEmail.BorderStyle = BorderStyle.None;
            TxtRegEmail.Font = new Font("Microsoft Sans Serif", 12.75F, FontStyle.Regular, GraphicsUnit.Point);
            TxtRegEmail.ForeColor = Color.White;
            TxtRegEmail.Location = new Point(6, 7);
            TxtRegEmail.Name = "TxtRegEmail";
            TxtRegEmail.Size = new Size(268, 20);
            TxtRegEmail.TabIndex = 2;
            TxtRegEmail.TextChanged += TxtRegEmail_TextChanged;
            // 
            // PanelEmail
            // 
            PanelEmail.BackColor = Color.FromArgb(33, 43, 53);
            PanelEmail.BorderStyle = BorderStyle.Fixed3D;
            PanelEmail.Controls.Add(TxtRegEmail);
            PanelEmail.Location = new Point(122, 91);
            PanelEmail.Name = "PanelEmail";
            PanelEmail.Size = new Size(282, 40);
            PanelEmail.TabIndex = 13;
            // 
            // LabelPassword
            // 
            LabelPassword.AutoSize = true;
            LabelPassword.Font = new Font("Microsoft Sans Serif", 12.75F, FontStyle.Regular, GraphicsUnit.Point);
            LabelPassword.ForeColor = Color.White;
            LabelPassword.Location = new Point(118, 150);
            LabelPassword.Name = "LabelPassword";
            LabelPassword.Size = new Size(83, 20);
            LabelPassword.TabIndex = 14;
            LabelPassword.Text = "Password";
            // 
            // TxtRegPassword
            // 
            TxtRegPassword.BackColor = Color.FromArgb(33, 43, 53);
            TxtRegPassword.BorderStyle = BorderStyle.None;
            TxtRegPassword.Font = new Font("Microsoft Sans Serif", 12.75F, FontStyle.Regular, GraphicsUnit.Point);
            TxtRegPassword.ForeColor = Color.White;
            TxtRegPassword.Location = new Point(6, 8);
            TxtRegPassword.Name = "TxtRegPassword";
            TxtRegPassword.PasswordChar = '*';
            TxtRegPassword.Size = new Size(268, 20);
            TxtRegPassword.TabIndex = 5;
            // 
            // PanelPassword
            // 
            PanelPassword.BackColor = Color.FromArgb(33, 43, 53);
            PanelPassword.BorderStyle = BorderStyle.Fixed3D;
            PanelPassword.Controls.Add(TxtRegPassword);
            PanelPassword.Location = new Point(122, 171);
            PanelPassword.Name = "PanelPassword";
            PanelPassword.Size = new Size(282, 40);
            PanelPassword.TabIndex = 15;
            // 
            // LabelEmail
            // 
            LabelEmail.AutoSize = true;
            LabelEmail.Font = new Font("Microsoft Sans Serif", 12.75F, FontStyle.Regular, GraphicsUnit.Point);
            LabelEmail.ForeColor = Color.White;
            LabelEmail.Location = new Point(118, 70);
            LabelEmail.Name = "LabelEmail";
            LabelEmail.Size = new Size(51, 20);
            LabelEmail.TabIndex = 12;
            LabelEmail.Text = "Email";
            // 
            // pictureRegister
            // 
            pictureRegister.Cursor = Cursors.Hand;
            pictureRegister.Image = Properties.Resources.btn_register;
            pictureRegister.Location = new Point(271, 257);
            pictureRegister.Name = "pictureRegister";
            pictureRegister.Size = new Size(139, 48);
            pictureRegister.TabIndex = 22;
            pictureRegister.TabStop = false;
            pictureRegister.Click += PictureRegister_Click;
            // 
            // SignupForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(16, 27, 38);
            ClientSize = new Size(527, 444);
            Controls.Add(PanelEmail);
            Controls.Add(LabelEmail);
            Controls.Add(PanelPassword);
            Controls.Add(LabelPassword);
            Controls.Add(pictureRegister);
            Controls.Add(LabelError);
            Controls.Add(BtnLogin);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "SignupForm";
            RightToLeft = RightToLeft.No;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Malcore Agent 1.2 | Register";
            TopMost = true;
            Load += SignupForm_Load;
            PanelEmail.ResumeLayout(false);
            PanelEmail.PerformLayout();
            PanelPassword.ResumeLayout(false);
            PanelPassword.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureRegister).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button BtnLogin;
        private Label LabelError;
        private TextBox TxtRegEmail;
        private Panel PanelEmail;
        private Label LabelPassword;
        private TextBox TxtRegPassword;
        private Panel PanelPassword;
        private Label LabelEmail;
        private PictureBox pictureRegister;
    }
}