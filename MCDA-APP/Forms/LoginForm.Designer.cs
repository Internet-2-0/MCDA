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
            label1 = new Label();
            panel1 = new Panel();
            txtEmail = new TextBox();
            label2 = new Label();
            panel2 = new Panel();
            txtPassword = new TextBox();
            chkAgree = new CheckBox();
            linkAgree = new LinkLabel();
            btnLogin = new Button();
            lblError = new Label();
            panel3 = new Panel();
            pictureBox1 = new PictureBox();
            lblMalcore = new Label();
            label3 = new Label();
            lblTerms = new Label();
            label4 = new Label();
            labelSignup = new LinkLabel();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 12.75F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(136, 119);
            label1.Name = "label1";
            label1.Size = new Size(68, 26);
            label1.TabIndex = 0;
            label1.Text = "Email";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(82, 78, 78);
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(txtEmail);
            panel1.Location = new Point(141, 147);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(322, 52);
            panel1.TabIndex = 1;
            // 
            // txtEmail
            // 
            txtEmail.BackColor = Color.FromArgb(82, 78, 78);
            txtEmail.BorderStyle = BorderStyle.None;
            txtEmail.Font = new Font("Microsoft Sans Serif", 12.75F, FontStyle.Regular, GraphicsUnit.Point);
            txtEmail.ForeColor = Color.White;
            txtEmail.Location = new Point(7, 9);
            txtEmail.Margin = new Padding(3, 4, 3, 4);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(306, 25);
            txtEmail.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 12.75F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.White;
            label2.Location = new Point(136, 225);
            label2.Name = "label2";
            label2.Size = new Size(108, 26);
            label2.TabIndex = 0;
            label2.Text = "Password";
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(82, 78, 78);
            panel2.BorderStyle = BorderStyle.Fixed3D;
            panel2.Controls.Add(txtPassword);
            panel2.Location = new Point(141, 253);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(322, 52);
            panel2.TabIndex = 1;
            panel2.Paint += panel2_Paint;
            // 
            // txtPassword
            // 
            txtPassword.BackColor = Color.FromArgb(82, 78, 78);
            txtPassword.BorderStyle = BorderStyle.None;
            txtPassword.Font = new Font("Microsoft Sans Serif", 12.75F, FontStyle.Regular, GraphicsUnit.Point);
            txtPassword.ForeColor = Color.White;
            txtPassword.Location = new Point(7, 11);
            txtPassword.Margin = new Padding(3, 4, 3, 4);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(306, 25);
            txtPassword.TabIndex = 2;
            // 
            // chkAgree
            // 
            chkAgree.AutoSize = true;
            chkAgree.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point);
            chkAgree.ForeColor = Color.White;
            chkAgree.Location = new Point(138, 313);
            chkAgree.Margin = new Padding(3, 4, 3, 4);
            chkAgree.Name = "chkAgree";
            chkAgree.Size = new Size(111, 28);
            chkAgree.TabIndex = 2;
            chkAgree.Text = "I agree to";
            chkAgree.UseVisualStyleBackColor = true;
            // 
            // linkAgree
            // 
            linkAgree.AutoSize = true;
            linkAgree.Cursor = Cursors.Hand;
            linkAgree.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point);
            linkAgree.LinkColor = Color.FromArgb(255, 245, 14);
            linkAgree.Location = new Point(241, 314);
            linkAgree.Name = "linkAgree";
            linkAgree.Size = new Size(174, 24);
            linkAgree.TabIndex = 3;
            linkAgree.TabStop = true;
            linkAgree.Text = "terms & conditions ";
            linkAgree.UseMnemonic = false;
            linkAgree.LinkClicked += linkAgree_LinkClicked;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(244, 7, 3);
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Popup;
            btnLogin.Font = new Font("Calibri", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(311, 368);
            btnLogin.Margin = new Padding(3, 4, 3, 4);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(151, 53);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "LOGIN";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click_1;
            // 
            // lblError
            // 
            lblError.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblError.ForeColor = Color.FromArgb(244, 7, 3);
            lblError.Location = new Point(90, 428);
            lblError.Name = "lblError";
            lblError.Size = new Size(424, 40);
            lblError.TabIndex = 5;
            lblError.TextAlign = ContentAlignment.MiddleCenter;
            lblError.UseMnemonic = false;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(111, 101, 101);
            panel3.Location = new Point(0, 564);
            panel3.Margin = new Padding(3, 4, 3, 4);
            panel3.Name = "panel3";
            panel3.Size = new Size(621, 1);
            panel3.TabIndex = 6;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(24, 584);
            pictureBox1.Margin = new Padding(3, 4, 3, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(163, 67);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            // 
            // lblMalcore
            // 
            lblMalcore.AutoSize = true;
            lblMalcore.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            lblMalcore.ForeColor = Color.White;
            lblMalcore.Location = new Point(274, 611);
            lblMalcore.Name = "lblMalcore";
            lblMalcore.Size = new Size(86, 20);
            lblMalcore.TabIndex = 0;
            lblMalcore.Text = "malcore.io";
            lblMalcore.Click += lblMalcore_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = Color.White;
            label3.Location = new Point(474, 611);
            label3.Name = "label3";
            label3.Size = new Size(114, 20);
            label3.TabIndex = 0;
            label3.Text = "Privacy Policy";
            label3.Click += label3_Click;
            // 
            // lblTerms
            // 
            lblTerms.AutoSize = true;
            lblTerms.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            lblTerms.ForeColor = Color.White;
            lblTerms.Location = new Point(368, 611);
            lblTerms.Name = "lblTerms";
            lblTerms.Size = new Size(111, 20);
            lblTerms.TabIndex = 0;
            lblTerms.Text = "Terms of Use";
            lblTerms.Click += lblTerms_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = SystemColors.ButtonHighlight;
            label4.Location = new Point(238, 485);
            label4.Name = "label4";
            label4.Size = new Size(163, 20);
            label4.TabIndex = 8;
            label4.Text = "Don't have an account?";
            // 
            // labelSignup
            // 
            labelSignup.AutoSize = true;
            labelSignup.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelSignup.LinkColor = Color.FromArgb(255, 245, 14);
            labelSignup.Location = new Point(391, 480);
            labelSignup.Name = "labelSignup";
            labelSignup.Size = new Size(80, 24);
            labelSignup.TabIndex = 9;
            labelSignup.TabStop = true;
            labelSignup.Text = "Sign Up!";
            labelSignup.LinkClicked += labelSignup_LinkClicked;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(26, 26, 34);
            ClientSize = new Size(598, 667);
            Controls.Add(labelSignup);
            Controls.Add(label4);
            Controls.Add(pictureBox1);
            Controls.Add(panel3);
            Controls.Add(lblError);
            Controls.Add(btnLogin);
            Controls.Add(linkAgree);
            Controls.Add(chkAgree);
            Controls.Add(panel2);
            Controls.Add(label2);
            Controls.Add(panel1);
            Controls.Add(lblTerms);
            Controls.Add(label3);
            Controls.Add(lblMalcore);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Malcore Agent 1.1.1 | Log in";
            FormClosing += LoginFormClosing;
            FormClosed += LoginFormClosed;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Panel panel1;
        private TextBox txtEmail;
        private Label label2;
        private Panel panel2;
        private TextBox txtPassword;
        private CheckBox chkAgree;
        private LinkLabel linkAgree;
        private Button btnLogin;
        private Label lblError;
        private Panel panel3;
        private PictureBox pictureBox1;
        private Label lblMalcore;
        private Label label3;
        private Label lblTerms;
        private Label label4;
        private LinkLabel labelSignup;
    }
}