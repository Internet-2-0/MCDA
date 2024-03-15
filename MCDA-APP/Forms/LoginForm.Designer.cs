namespace MCDA_APP
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            LabelEmail = new Label();
            PanelEmail = new Panel();
            TxtEmail = new TextBox();
            LabelPassword = new Label();
            PanelPassword = new Panel();
            TxtPassword = new TextBox();
            CheckAgree = new CheckBox();
            LinkAgree = new LinkLabel();
            BtnLogin = new Button();
            LabelError = new Label();
            LabelNoAccount = new Label();
            LabelSignup = new LinkLabel();
            pictureLogin = new PictureBox();
            PanelEmail.SuspendLayout();
            PanelPassword.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureLogin).BeginInit();
            SuspendLayout();
            // 
            // LabelEmail
            // 
            LabelEmail.AutoSize = true;
            LabelEmail.Font = new Font("Microsoft Sans Serif", 12.75F, FontStyle.Regular, GraphicsUnit.Point);
            LabelEmail.ForeColor = Color.White;
            LabelEmail.Location = new Point(119, 91);
            LabelEmail.Name = "LabelEmail";
            LabelEmail.Size = new Size(51, 20);
            LabelEmail.TabIndex = 0;
            LabelEmail.Text = "Email";
            // 
            // PanelEmail
            // 
            PanelEmail.BackColor = Color.FromArgb(33, 43, 53);
            PanelEmail.BorderStyle = BorderStyle.Fixed3D;
            PanelEmail.Controls.Add(TxtEmail);
            PanelEmail.Location = new Point(123, 112);
            PanelEmail.Name = "PanelEmail";
            PanelEmail.Size = new Size(282, 40);
            PanelEmail.TabIndex = 1;
            // 
            // TxtEmail
            // 
            TxtEmail.BackColor = Color.FromArgb(33, 43, 53);
            TxtEmail.BorderStyle = BorderStyle.None;
            TxtEmail.Font = new Font("Microsoft Sans Serif", 12.75F, FontStyle.Regular, GraphicsUnit.Point);
            TxtEmail.ForeColor = Color.White;
            TxtEmail.Location = new Point(6, 7);
            TxtEmail.Name = "TxtEmail";
            TxtEmail.Size = new Size(268, 20);
            TxtEmail.TabIndex = 2;
            // 
            // LabelPassword
            // 
            LabelPassword.AutoSize = true;
            LabelPassword.Font = new Font("Microsoft Sans Serif", 12.75F, FontStyle.Regular, GraphicsUnit.Point);
            LabelPassword.ForeColor = Color.White;
            LabelPassword.Location = new Point(119, 171);
            LabelPassword.Name = "LabelPassword";
            LabelPassword.Size = new Size(83, 20);
            LabelPassword.TabIndex = 3;
            LabelPassword.Text = "Password";
            // 
            // PanelPassword
            // 
            PanelPassword.BackColor = Color.FromArgb(33, 43, 53);
            PanelPassword.BorderStyle = BorderStyle.Fixed3D;
            PanelPassword.Controls.Add(TxtPassword);
            PanelPassword.Location = new Point(123, 192);
            PanelPassword.Name = "PanelPassword";
            PanelPassword.Size = new Size(282, 40);
            PanelPassword.TabIndex = 4;
            // 
            // TxtPassword
            // 
            TxtPassword.BackColor = Color.FromArgb(33, 43, 53);
            TxtPassword.BorderStyle = BorderStyle.None;
            TxtPassword.Cursor = Cursors.Hand;
            TxtPassword.Font = new Font("Microsoft Sans Serif", 12.75F, FontStyle.Regular, GraphicsUnit.Point);
            TxtPassword.ForeColor = Color.White;
            TxtPassword.Location = new Point(6, 8);
            TxtPassword.Name = "TxtPassword";
            TxtPassword.PasswordChar = '*';
            TxtPassword.Size = new Size(268, 20);
            TxtPassword.TabIndex = 5;
            // 
            // CheckAgree
            // 
            CheckAgree.AutoSize = true;
            CheckAgree.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point);
            CheckAgree.ForeColor = Color.White;
            CheckAgree.Location = new Point(121, 237);
            CheckAgree.Name = "CheckAgree";
            CheckAgree.Size = new Size(90, 23);
            CheckAgree.TabIndex = 6;
            CheckAgree.Text = "I agree to";
            CheckAgree.UseVisualStyleBackColor = true;
            // 
            // LinkAgree
            // 
            LinkAgree.AutoSize = true;
            LinkAgree.Cursor = Cursors.Hand;
            LinkAgree.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point);
            LinkAgree.LinkColor = Color.FromArgb(255, 245, 14);
            LinkAgree.Location = new Point(211, 238);
            LinkAgree.Name = "LinkAgree";
            LinkAgree.Size = new Size(136, 19);
            LinkAgree.TabIndex = 7;
            LinkAgree.TabStop = true;
            LinkAgree.Text = "terms & conditions ";
            LinkAgree.UseMnemonic = false;
            LinkAgree.LinkClicked += LinkAgree_LinkClicked;
            // 
            // BtnLogin
            // 
            BtnLogin.BackColor = Color.FromArgb(244, 7, 3);
            BtnLogin.Cursor = Cursors.Hand;
            BtnLogin.FlatAppearance.BorderSize = 0;
            BtnLogin.FlatStyle = FlatStyle.Popup;
            BtnLogin.Font = new Font("Calibri", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            BtnLogin.ForeColor = Color.White;
            BtnLogin.Location = new Point(272, 278);
            BtnLogin.Name = "BtnLogin";
            BtnLogin.Size = new Size(132, 40);
            BtnLogin.TabIndex = 8;
            BtnLogin.Text = "LOGIN";
            BtnLogin.UseVisualStyleBackColor = false;
            BtnLogin.Click += BtnLogin_Click;
            // 
            // LabelError
            // 
            LabelError.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point);
            LabelError.ForeColor = Color.FromArgb(244, 7, 3);
            LabelError.Location = new Point(79, 323);
            LabelError.Name = "LabelError";
            LabelError.Size = new Size(371, 30);
            LabelError.TabIndex = 5;
            LabelError.TextAlign = ContentAlignment.MiddleCenter;
            LabelError.UseMnemonic = false;
            // 
            // LabelNoAccount
            // 
            LabelNoAccount.AutoSize = true;
            LabelNoAccount.ForeColor = SystemColors.ButtonHighlight;
            LabelNoAccount.Location = new Point(208, 366);
            LabelNoAccount.Name = "LabelNoAccount";
            LabelNoAccount.Size = new Size(131, 15);
            LabelNoAccount.TabIndex = 9;
            LabelNoAccount.Text = "Don't have an account?";
            // 
            // LabelSignup
            // 
            LabelSignup.AutoSize = true;
            LabelSignup.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point);
            LabelSignup.LinkColor = Color.FromArgb(255, 245, 14);
            LabelSignup.Location = new Point(342, 362);
            LabelSignup.Name = "LabelSignup";
            LabelSignup.Size = new Size(63, 19);
            LabelSignup.TabIndex = 10;
            LabelSignup.TabStop = true;
            LabelSignup.Text = "Sign Up!";
            LabelSignup.LinkClicked += LabelSignup_LinkClicked;
            // 
            // pictureLogin
            // 
            pictureLogin.Image = Properties.Resources.btn_login;
            pictureLogin.Location = new Point(272, 278);
            pictureLogin.Name = "pictureLogin";
            pictureLogin.Size = new Size(139, 48);
            pictureLogin.TabIndex = 11;
            pictureLogin.TabStop = false;
            pictureLogin.Click += pictureLogin_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(16, 27, 38);
            ClientSize = new Size(523, 500);
            Controls.Add(pictureLogin);
            Controls.Add(LabelSignup);
            Controls.Add(LabelNoAccount);
            Controls.Add(LabelError);
            Controls.Add(BtnLogin);
            Controls.Add(LinkAgree);
            Controls.Add(CheckAgree);
            Controls.Add(PanelPassword);
            Controls.Add(LabelPassword);
            Controls.Add(PanelEmail);
            Controls.Add(LabelEmail);
            Cursor = Cursors.Hand;
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Malcore Agent 1.2| Log in";
            FormClosing += LoginFormClosing;
            FormClosed += LoginFormClosed;
            Load += LoginForm_Load;
            PanelEmail.ResumeLayout(false);
            PanelEmail.PerformLayout();
            PanelPassword.ResumeLayout(false);
            PanelPassword.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureLogin).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LabelEmail;
        private Panel PanelEmail;
        private TextBox TxtEmail;
        private Label LabelPassword;
        private Panel PanelPassword;
        private TextBox TxtPassword;
        private CheckBox CheckAgree;
        private LinkLabel LinkAgree;
        private Button BtnLogin;
        private Label LabelError;
        private Label LabelNoAccount;
        private LinkLabel LabelSignup;
        private PictureBox pictureLogin;
    }
}