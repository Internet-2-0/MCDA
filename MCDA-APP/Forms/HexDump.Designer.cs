using System.Windows.Forms;

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
            OptionsMenu = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            openToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
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
            OptionsToolMenu = new ToolStrip();
            openToolStripButton = new ToolStripButton();
            saveToolStripButton = new ToolStripButton();
            toolStripSeparator3 = new ToolStripSeparator();
            cutToolStripButton = new ToolStripButton();
            copyToolStripSplitButton = new ToolStripDropDownButton();
            copyToolStripMenuItem1 = new ToolStripMenuItem();
            copyHexToolStripMenuItem1 = new ToolStripMenuItem();
            pasteToolStripSplitButton = new ToolStripDropDownButton();
            pasteToolStripMenuItem1 = new ToolStripMenuItem();
            pasteHexToolStripMenuItem1 = new ToolStripMenuItem();
            statusStrip.SuspendLayout();
            OptionsMenu.SuspendLayout();
            OptionsToolMenu.SuspendLayout();
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
            // OptionsMenu
            // 
            OptionsMenu.BackColor = Color.FromArgb(26, 26, 34);
            OptionsMenu.ForeColor = Color.White;
            OptionsMenu.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, searchToolStripMenuItem, toolStripMenuItem1 });
            OptionsMenu.Location = new Point(0, 0);
            OptionsMenu.Name = "OptionsMenu";
            OptionsMenu.Padding = new Padding(10, 7, 0, 7);
            OptionsMenu.RenderMode = ToolStripRenderMode.System;
            OptionsMenu.Size = new Size(834, 33);
            OptionsMenu.TabIndex = 1;
            OptionsMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openToolStripMenuItem, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 19);
            fileToolStripMenuItem.Text = "&File";
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Image = Properties.Resources.FolderOpen_16;
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.O;
            openToolStripMenuItem.Size = new Size(146, 22);
            openToolStripMenuItem.Text = "&Open";
            openToolStripMenuItem.Click += OpenToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(146, 22);
            exitToolStripMenuItem.Text = "E&xit";
            exitToolStripMenuItem.Click += ExitToolStripMenuItem_Click;
            // 
            // searchToolStripMenuItem
            // 
            searchToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { cutToolStripMenuItem, coToolStripMenuItem, pasteToolStripMenuItem, toolStripSeparator1, copyHexToolStripMenuItem, pasteHexToolStripMenuItem, toolStripSeparator2, findToolStripMenuItem, findNextToolStripMenuItem, goToToolStripMenuItem });
            searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            searchToolStripMenuItem.Size = new Size(39, 19);
            searchToolStripMenuItem.Text = "&Edit";
            // 
            // cutToolStripMenuItem
            // 
            cutToolStripMenuItem.Image = Properties.Resources.Cut16;
            cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            cutToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.X;
            cutToolStripMenuItem.Size = new Size(200, 22);
            cutToolStripMenuItem.Text = "&Cut";
            cutToolStripMenuItem.Click += CutToolStripMenuItem_Click;
            // 
            // coToolStripMenuItem
            // 
            coToolStripMenuItem.Image = Properties.Resources.Copy16;
            coToolStripMenuItem.Name = "coToolStripMenuItem";
            coToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.C;
            coToolStripMenuItem.Size = new Size(200, 22);
            coToolStripMenuItem.Text = "&Copy";
            coToolStripMenuItem.Click += CoToolStripMenuItem_Click;
            // 
            // pasteToolStripMenuItem
            // 
            pasteToolStripMenuItem.Image = Properties.Resources.Paste16;
            pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            pasteToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.V;
            pasteToolStripMenuItem.Size = new Size(200, 22);
            pasteToolStripMenuItem.Text = "&Paste";
            pasteToolStripMenuItem.Click += PasteToolStripMenuItem_Click;
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
            copyHexToolStripMenuItem.Click += CopyHexToolStripMenuItem_Click;
            // 
            // pasteHexToolStripMenuItem
            // 
            pasteHexToolStripMenuItem.Name = "pasteHexToolStripMenuItem";
            pasteHexToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Shift | Keys.V;
            pasteHexToolStripMenuItem.Size = new Size(200, 22);
            pasteHexToolStripMenuItem.Text = "Paste Hex";
            pasteHexToolStripMenuItem.Click += PasteHexToolStripMenuItem_Click;
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
            findToolStripMenuItem.Click += FindToolStripMenuItem_Click;
            // 
            // findNextToolStripMenuItem
            // 
            findNextToolStripMenuItem.Image = Properties.Resources.FindNext16;
            findNextToolStripMenuItem.Name = "findNextToolStripMenuItem";
            findNextToolStripMenuItem.ShortcutKeys = Keys.F3;
            findNextToolStripMenuItem.Size = new Size(200, 22);
            findNextToolStripMenuItem.Text = "Find Next";
            findNextToolStripMenuItem.Click += FindNextToolStripMenuItem_Click;
            // 
            // goToToolStripMenuItem
            // 
            goToToolStripMenuItem.Name = "goToToolStripMenuItem";
            goToToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.G;
            goToToolStripMenuItem.Size = new Size(200, 22);
            goToToolStripMenuItem.Text = "Go To";
            goToToolStripMenuItem.Click += goToToolStripMenuItem_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(12, 19);
            // 
            // OptionsToolMenu
            // 
            OptionsToolMenu.BackColor = Color.FromArgb(26, 26, 34);
            OptionsToolMenu.Items.AddRange(new ToolStripItem[] { openToolStripButton, saveToolStripButton, toolStripSeparator3, cutToolStripButton, copyToolStripSplitButton, pasteToolStripSplitButton });
            OptionsToolMenu.Location = new Point(0, 33);
            OptionsToolMenu.Name = "OptionsToolMenu";
            OptionsToolMenu.RenderMode = ToolStripRenderMode.System;
            OptionsToolMenu.Size = new Size(834, 25);
            OptionsToolMenu.TabIndex = 2;
            OptionsToolMenu.Text = "toolStrip1";
            // 
            // openToolStripButton
            // 
            openToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            openToolStripButton.Image = Properties.Resources.openHS;
            openToolStripButton.ImageTransparentColor = Color.Magenta;
            openToolStripButton.Name = "openToolStripButton";
            openToolStripButton.Size = new Size(23, 22);
            openToolStripButton.Text = "Open";
            openToolStripButton.Click += openToolStripButton_Click;
            // 
            // saveToolStripButton
            // 
            saveToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            saveToolStripButton.Image = Properties.Resources.saveHS;
            saveToolStripButton.ImageTransparentColor = Color.Magenta;
            saveToolStripButton.Name = "saveToolStripButton";
            saveToolStripButton.Size = new Size(23, 22);
            saveToolStripButton.Text = "Save";
            saveToolStripButton.Click += saveToolStripButton_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(6, 25);
            // 
            // cutToolStripButton
            // 
            cutToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            cutToolStripButton.Image = Properties.Resources.CutHS;
            cutToolStripButton.ImageTransparentColor = Color.Magenta;
            cutToolStripButton.Name = "cutToolStripButton";
            cutToolStripButton.Size = new Size(23, 22);
            cutToolStripButton.Text = "Cut";
            cutToolStripButton.Click += cutToolStripButton_Click;
            // 
            // copyToolStripSplitButton
            // 
            copyToolStripSplitButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            copyToolStripSplitButton.DropDownItems.AddRange(new ToolStripItem[] { copyToolStripMenuItem1, copyHexToolStripMenuItem1 });
            copyToolStripSplitButton.Image = Properties.Resources.CopyHS;
            copyToolStripSplitButton.ImageTransparentColor = Color.Magenta;
            copyToolStripSplitButton.Name = "copyToolStripSplitButton";
            copyToolStripSplitButton.Size = new Size(29, 22);
            copyToolStripSplitButton.Text = "Copy";
            // 
            // copyToolStripMenuItem1
            // 
            copyToolStripMenuItem1.Image = Properties.Resources.CopyHS;
            copyToolStripMenuItem1.Name = "copyToolStripMenuItem1";
            copyToolStripMenuItem1.Size = new Size(126, 22);
            copyToolStripMenuItem1.Text = "Copy";
            copyToolStripMenuItem1.Click += copyToolStripMenuItem1_Click;
            // 
            // copyHexToolStripMenuItem1
            // 
            copyHexToolStripMenuItem1.Image = Properties.Resources.CopyHS;
            copyHexToolStripMenuItem1.Name = "copyHexToolStripMenuItem1";
            copyHexToolStripMenuItem1.Size = new Size(126, 22);
            copyHexToolStripMenuItem1.Text = "Copy Hex";
            copyHexToolStripMenuItem1.Click += copyHexToolStripMenuItem1_Click;
            // 
            // pasteToolStripSplitButton
            // 
            pasteToolStripSplitButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            pasteToolStripSplitButton.DropDownItems.AddRange(new ToolStripItem[] { pasteToolStripMenuItem1, pasteHexToolStripMenuItem1 });
            pasteToolStripSplitButton.Image = Properties.Resources.PasteHS;
            pasteToolStripSplitButton.ImageTransparentColor = Color.Magenta;
            pasteToolStripSplitButton.Name = "pasteToolStripSplitButton";
            pasteToolStripSplitButton.Size = new Size(29, 22);
            pasteToolStripSplitButton.Text = "Paste";
            // 
            // pasteToolStripMenuItem1
            // 
            pasteToolStripMenuItem1.Image = Properties.Resources.PasteHS;
            pasteToolStripMenuItem1.Name = "pasteToolStripMenuItem1";
            pasteToolStripMenuItem1.Size = new Size(126, 22);
            pasteToolStripMenuItem1.Text = "Paste";
            pasteToolStripMenuItem1.Click += pasteToolStripMenuItem1_Click;
            // 
            // pasteHexToolStripMenuItem1
            // 
            pasteHexToolStripMenuItem1.Image = Properties.Resources.PasteHS;
            pasteHexToolStripMenuItem1.Name = "pasteHexToolStripMenuItem1";
            pasteHexToolStripMenuItem1.Size = new Size(126, 22);
            pasteHexToolStripMenuItem1.Text = "Paste Hex";
            pasteHexToolStripMenuItem1.Click += pasteHexToolStripMenuItem1_Click;
            // 
            // HexDump
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(26, 26, 34);
            ClientSize = new Size(834, 521);
            Controls.Add(OptionsToolMenu);
            Controls.Add(statusStrip);
            Controls.Add(OptionsMenu);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = OptionsMenu;
            MaximizeBox = false;
            Name = "HexDump";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "%placeholder%";
            Load += HexDump_Load;
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            OptionsMenu.ResumeLayout(false);
            OptionsMenu.PerformLayout();
            OptionsToolMenu.ResumeLayout(false);
            OptionsToolMenu.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private StatusStrip statusStrip;
        private ToolStripStatusLabel toolStripStatusLabel;
        private MenuStrip OptionsMenu;
        private ToolStripMenuItem searchToolStripMenuItem;
        private ToolStripMenuItem findToolStripMenuItem;
        private ToolStripStatusLabel fileSizeToolStripStatusLabel;
        private ToolStripMenuItem findNextToolStripMenuItem;
        private ToolStripMenuItem goToToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem cutToolStripMenuItem;
        private ToolStripMenuItem coToolStripMenuItem;
        private ToolStripMenuItem pasteToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem copyHexToolStripMenuItem;
        private ToolStripMenuItem pasteHexToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStrip OptionsToolMenu;
        private ToolStripButton openToolStripButton;
        private ToolStripButton saveToolStripButton;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripButton cutToolStripButton;
        private ToolStripDropDownButton copyToolStripSplitButton;
        private ToolStripDropDownButton pasteToolStripSplitButton;
        private ToolStripMenuItem copyToolStripMenuItem1;
        private ToolStripMenuItem copyHexToolStripMenuItem1;
        private ToolStripMenuItem pasteToolStripMenuItem1;
        private ToolStripMenuItem pasteHexToolStripMenuItem1;
    }
}