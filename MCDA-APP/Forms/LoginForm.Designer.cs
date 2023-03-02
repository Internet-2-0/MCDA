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
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.chkAgree = new System.Windows.Forms.CheckBox();
            this.linkAgree = new System.Windows.Forms.LinkLabel();
            this.btnLogin = new System.Windows.Forms.Button();
            this.lblError = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblMalcore = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTerms = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Carlito", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(119, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Email";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(78)))), ((int)(((byte)(78)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.txtEmail);
            this.panel1.Location = new System.Drawing.Point(123, 110);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(282, 40);
            this.panel1.TabIndex = 1;
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(78)))), ((int)(((byte)(78)))));
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEmail.Font = new System.Drawing.Font("Roboto Condensed", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtEmail.ForeColor = System.Drawing.Color.White;
            this.txtEmail.Location = new System.Drawing.Point(6, 7);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(268, 21);
            this.txtEmail.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Carlito", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(119, 169);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "Password";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(78)))), ((int)(((byte)(78)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.txtPassword);
            this.panel2.Location = new System.Drawing.Point(123, 190);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(282, 40);
            this.panel2.TabIndex = 1;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(78)))), ((int)(((byte)(78)))));
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPassword.Font = new System.Drawing.Font("Roboto Condensed", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtPassword.ForeColor = System.Drawing.Color.White;
            this.txtPassword.Location = new System.Drawing.Point(6, 8);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(268, 21);
            this.txtPassword.TabIndex = 2;
            // 
            // chkAgree
            // 
            this.chkAgree.AutoSize = true;
            this.chkAgree.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.chkAgree.ForeColor = System.Drawing.Color.White;
            this.chkAgree.Location = new System.Drawing.Point(121, 235);
            this.chkAgree.Name = "chkAgree";
            this.chkAgree.Size = new System.Drawing.Size(90, 23);
            this.chkAgree.TabIndex = 2;
            this.chkAgree.Text = "I agree to";
            this.chkAgree.UseVisualStyleBackColor = true;
            // 
            // linkAgree
            // 
            this.linkAgree.AutoSize = true;
            this.linkAgree.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linkAgree.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.linkAgree.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(245)))), ((int)(((byte)(14)))));
            this.linkAgree.Location = new System.Drawing.Point(203, 236);
            this.linkAgree.Name = "linkAgree";
            this.linkAgree.Size = new System.Drawing.Size(136, 19);
            this.linkAgree.TabIndex = 3;
            this.linkAgree.TabStop = true;
            this.linkAgree.Text = "terms & conditions ";
            this.linkAgree.UseMnemonic = false;
            this.linkAgree.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkAgree_LinkClicked);
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(7)))), ((int)(((byte)(3)))));
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLogin.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(272, 276);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(132, 40);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "LOGIN";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click_1);
            // 
            // lblError
            // 
            this.lblError.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblError.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(7)))), ((int)(((byte)(3)))));
            this.lblError.Location = new System.Drawing.Point(79, 344);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(371, 30);
            this.lblError.TabIndex = 5;
            this.lblError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblError.UseMnemonic = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(101)))), ((int)(((byte)(101)))));
            this.panel3.Location = new System.Drawing.Point(0, 423);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(543, 1);
            this.panel3.TabIndex = 6;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(21, 438);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(143, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // lblMalcore
            // 
            this.lblMalcore.AutoSize = true;
            this.lblMalcore.Font = new System.Drawing.Font("Carlito", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblMalcore.ForeColor = System.Drawing.Color.White;
            this.lblMalcore.Location = new System.Drawing.Point(240, 458);
            this.lblMalcore.Name = "lblMalcore";
            this.lblMalcore.Size = new System.Drawing.Size(63, 15);
            this.lblMalcore.TabIndex = 0;
            this.lblMalcore.Text = "malcore.io";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Carlito", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(415, 458);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Privacy Policy";
            // 
            // lblTerms
            // 
            this.lblTerms.AutoSize = true;
            this.lblTerms.Font = new System.Drawing.Font("Carlito", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTerms.ForeColor = System.Drawing.Color.White;
            this.lblTerms.Location = new System.Drawing.Point(322, 458);
            this.lblTerms.Name = "lblTerms";
            this.lblTerms.Size = new System.Drawing.Size(74, 15);
            this.lblTerms.TabIndex = 0;
            this.lblTerms.Text = "Terms of Use";
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(34)))));
            this.ClientSize = new System.Drawing.Size(523, 500);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.linkAgree);
            this.Controls.Add(this.chkAgree);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblTerms);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblMalcore);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Malcore Agent 1.0.0 | Log in";
            this.TopMost = true;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}