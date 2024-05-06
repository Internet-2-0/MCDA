namespace MCDA_APP.Forms
{
    partial class CodeReuse
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
            iconTextBox1 = new Controls.IconTextBox();
            iconTextBox2 = new Controls.IconTextBox();
            SuspendLayout();
            // 
            // iconTextBox1
            // 
            iconTextBox1.BackColor = Color.FromArgb(40, 47, 53);
            iconTextBox1.Cursor = Cursors.Hand;
            iconTextBox1.Location = new Point(559, 201);
            iconTextBox1.Name = "iconTextBox1";
            iconTextBox1.Size = new Size(272, 40);
            iconTextBox1.TabIndex = 0;
            iconTextBox1.TextBoxFontSize = 12F;
            iconTextBox1.TextBoxText = "File";
            // 
            // iconTextBox2
            // 
            iconTextBox2.BackColor = Color.FromArgb(40, 47, 53);
            iconTextBox2.Cursor = Cursors.Hand;
            iconTextBox2.Location = new Point(559, 261);
            iconTextBox2.Name = "iconTextBox2";
            iconTextBox2.Size = new Size(272, 40);
            iconTextBox2.TabIndex = 1;
            iconTextBox2.TextBoxFontSize = 12F;
            iconTextBox2.TextBoxText = "Secondary File";
            // 
            // CodeReuse
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(26, 26, 34);
            ClientSize = new Size(843, 545);
            Controls.Add(iconTextBox2);
            Controls.Add(iconTextBox1);
            Name = "CodeReuse";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CodeReuse";
            Load += CodeReuse_Load;
            ResumeLayout(false);
        }

        #endregion

        private Controls.IconTextBox iconTextBox1;
        private Controls.IconTextBox iconTextBox2;
    }
}