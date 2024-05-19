namespace MCDA_APP.Forms
{
    partial class HexDump
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HexDump));
            statusStrip = new StatusStrip();
            toolStripStatusLabel = new ToolStripStatusLabel();
            fileSizeToolStripStatusLabel = new ToolStripStatusLabel();
            menuStrip1 = new MenuStrip();
            searchToolStripMenuItem = new ToolStripMenuItem();
            cutToolStripMenuItem = new ToolStripMenuItem();
            coToolStripMenuItem = new ToolStripMenuItem();
            pasteToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            copyHexToolStripMenuItem = new ToolStripMenuItem();
            pasteHexToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            findToolStripMenuItem = new ToolStripMenuItem();
            findNextToolStripMenuItem = new ToolStripMenuItem();
            goToToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripMenuItem();
            optionsToolStripMenuItem = new ToolStripMenuItem();
            themeToolStripMenuItem = new ToolStripMenuItem();
            statusStrip.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // statusStrip
            // 
            statusStrip.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel, fileSizeToolStripStatusLabel });
            statusStrip.Location = new Point(0, 499);
            statusStrip.Name = "statusStrip";
            statusStrip.RenderMode = ToolStripRenderMode.ManagerRenderMode;
            statusStrip.Size = new Size(834, 22);
            statusStrip.TabIndex = 0;
            statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            toolStripStatusLabel.BackColor = Color.Transparent;
            toolStripStatusLabel.ForeColor = Color.Black;
            toolStripStatusLabel.Margin = new Padding(5, 3, 0, 2);
            toolStripStatusLabel.Name = "toolStripStatusLabel";
            toolStripStatusLabel.Size = new Size(0, 17);
            // 
            // fileSizeToolStripStatusLabel
            // 
            fileSizeToolStripStatusLabel.BackColor = Color.Transparent;
            fileSizeToolStripStatusLabel.ForeColor = Color.Black;
            fileSizeToolStripStatusLabel.Name = "fileSizeToolStripStatusLabel";
            fileSizeToolStripStatusLabel.Size = new Size(0, 17);
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { searchToolStripMenuItem, toolStripMenuItem1, optionsToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(834, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // searchToolStripMenuItem
            // 
            searchToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { cutToolStripMenuItem, coToolStripMenuItem, pasteToolStripMenuItem, toolStripSeparator1, copyHexToolStripMenuItem, pasteHexToolStripMenuItem, toolStripSeparator2, findToolStripMenuItem, findNextToolStripMenuItem, goToToolStripMenuItem });
            searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            searchToolStripMenuItem.Size = new Size(54, 20);
            searchToolStripMenuItem.Text = "Search";
            // 
            // cutToolStripMenuItem
            // 
            cutToolStripMenuItem.Image = Properties.Resources.Cut16;
            cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            cutToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.X;
            cutToolStripMenuItem.Size = new Size(200, 22);
            cutToolStripMenuItem.Text = "&Cut";
            cutToolStripMenuItem.Click += cutToolStripMenuItem_Click;
            // 
            // coToolStripMenuItem
            // 
            coToolStripMenuItem.Image = Properties.Resources.Copy16;
            coToolStripMenuItem.Name = "coToolStripMenuItem";
            coToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.C;
            coToolStripMenuItem.Size = new Size(200, 22);
            coToolStripMenuItem.Text = "&Copy";
            coToolStripMenuItem.Click += coToolStripMenuItem_Click;
            // 
            // pasteToolStripMenuItem
            // 
            pasteToolStripMenuItem.Image = Properties.Resources.Paste16;
            pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            pasteToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.V;
            pasteToolStripMenuItem.Size = new Size(200, 22);
            pasteToolStripMenuItem.Text = "&Paste";
            pasteToolStripMenuItem.Click += pasteToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(197, 6);
            // 
            // copyHexToolStripMenuItem
            // 
            copyHexToolStripMenuItem.Name = "copyHexToolStripMenuItem";
            copyHexToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Shift | Keys.C;
            copyHexToolStripMenuItem.Size = new Size(200, 22);
            copyHexToolStripMenuItem.Text = "Copy Hex";
            copyHexToolStripMenuItem.Click += copyHexToolStripMenuItem_Click;
            // 
            // pasteHexToolStripMenuItem
            // 
            pasteHexToolStripMenuItem.Name = "pasteHexToolStripMenuItem";
            pasteHexToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Shift | Keys.V;
            pasteHexToolStripMenuItem.Size = new Size(200, 22);
            pasteHexToolStripMenuItem.Text = "Paste Hex";
            pasteHexToolStripMenuItem.Click += pasteHexToolStripMenuItem_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(197, 6);
            // 
            // findToolStripMenuItem
            // 
            findToolStripMenuItem.Image = Properties.Resources.Find16;
            findToolStripMenuItem.Name = "findToolStripMenuItem";
            findToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.F;
            findToolStripMenuItem.Size = new Size(200, 22);
            findToolStripMenuItem.Text = "Find";
            // 
            // findNextToolStripMenuItem
            // 
            findNextToolStripMenuItem.Image = Properties.Resources.FindNext16;
            findNextToolStripMenuItem.Name = "findNextToolStripMenuItem";
            findNextToolStripMenuItem.ShortcutKeys = Keys.F3;
            findNextToolStripMenuItem.Size = new Size(200, 22);
            findNextToolStripMenuItem.Text = "Find Next";
            // 
            // goToToolStripMenuItem
            // 
            goToToolStripMenuItem.Name = "goToToolStripMenuItem";
            goToToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.G;
            goToToolStripMenuItem.Size = new Size(200, 22);
            goToToolStripMenuItem.Text = "Go To";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(12, 20);
            // 
            // optionsToolStripMenuItem
            // 
            optionsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { themeToolStripMenuItem });
            optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            optionsToolStripMenuItem.Size = new Size(61, 20);
            optionsToolStripMenuItem.Text = "Options";
            // 
            // themeToolStripMenuItem
            // 
            themeToolStripMenuItem.Name = "themeToolStripMenuItem";
            themeToolStripMenuItem.Size = new Size(110, 22);
            themeToolStripMenuItem.Text = "Theme";
            // 
            // HexDump
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(26, 26, 34);
            ClientSize = new Size(834, 521);
            Controls.Add(statusStrip);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            Name = "HexDump";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Malcore Agent 1.1.1 | HexDump";
            Load += HexDump_Load;
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private StatusStrip statusStrip;
        private ToolStripStatusLabel toolStripStatusLabel;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem searchToolStripMenuItem;
        private ToolStripMenuItem findToolStripMenuItem;
        private ToolStripStatusLabel fileSizeToolStripStatusLabel;
        private ToolStripMenuItem findNextToolStripMenuItem;
        private ToolStripMenuItem goToToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem optionsToolStripMenuItem;
        private ToolStripMenuItem themeToolStripMenuItem;
        private ToolStripMenuItem cutToolStripMenuItem;
        private ToolStripMenuItem coToolStripMenuItem;
        private ToolStripMenuItem pasteToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem copyHexToolStripMenuItem;
        private ToolStripMenuItem pasteHexToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
    }
}