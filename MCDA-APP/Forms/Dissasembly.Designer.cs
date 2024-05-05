using MCDA_APP.Rendering;

namespace MCDA_APP.Forms
{
    partial class Dissasembly
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dissasembly));
            FunctionsListView = new ListView();
            FunctionNameHeader = new ColumnHeader();
            AddressHeader = new ColumnHeader();
            customTabControl2 = new TabControl.CustomTabControl();
            InformationTab = new TabPage();
            ImportsTab = new TabPage();
            ImportsListView = new ListView();
            ImportNameColumn = new ColumnHeader();
            ImportAddressColumn = new ColumnHeader();
            ImportLibraryColumn = new ColumnHeader();
            ExportsTab = new TabPage();
            ExportsListView = new ListView();
            ExportNameColumn = new ColumnHeader();
            AddressColumn = new ColumnHeader();
            StringsTab = new TabPage();
            StringsListView = new ListView();
            StringAddressColumn = new ColumnHeader();
            StringLengthColumn = new ColumnHeader();
            StringSectionColumn = new ColumnHeader();
            StringTypeColumn = new ColumnHeader();
            StringColumn = new ColumnHeader();
            DisassemblyTab = new TabPage();
            richTextBox1 = new RichTextBox();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            OptionsMenu = new MenuStrip();
            FileToolStripMenuItem = new ToolStripMenuItem();
            OpenToolStripMenuItem = new ToolStripMenuItem();
            splitContainer1 = new SplitContainer();
            label1 = new Label();
            label2 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label3 = new Label();
            customTabControl2.SuspendLayout();
            InformationTab.SuspendLayout();
            ImportsTab.SuspendLayout();
            ExportsTab.SuspendLayout();
            StringsTab.SuspendLayout();
            DisassemblyTab.SuspendLayout();
            OptionsMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // FunctionsListView
            // 
            FunctionsListView.BackColor = Color.FromArgb(26, 26, 34);
            FunctionsListView.Columns.AddRange(new ColumnHeader[] { FunctionNameHeader, AddressHeader });
            FunctionsListView.Dock = DockStyle.Fill;
            FunctionsListView.ForeColor = Color.White;
            FunctionsListView.FullRowSelect = true;
            FunctionsListView.Location = new Point(0, 0);
            FunctionsListView.Name = "FunctionsListView";
            FunctionsListView.Size = new Size(280, 579);
            FunctionsListView.TabIndex = 0;
            FunctionsListView.UseCompatibleStateImageBehavior = false;
            FunctionsListView.View = View.Details;
            FunctionsListView.DoubleClick += FunctionsListView_DoubleClick;
            // 
            // FunctionNameHeader
            // 
            FunctionNameHeader.Text = "Function Name";
            FunctionNameHeader.Width = 110;
            // 
            // AddressHeader
            // 
            AddressHeader.Text = "Address";
            AddressHeader.Width = 110;
            // 
            // customTabControl2
            // 
            customTabControl2.Controls.Add(InformationTab);
            customTabControl2.Controls.Add(ImportsTab);
            customTabControl2.Controls.Add(ExportsTab);
            customTabControl2.Controls.Add(StringsTab);
            customTabControl2.Controls.Add(DisassemblyTab);
            customTabControl2.DisplayStyle = TabControl.TabStyle.VS2010;
            // 
            // 
            // 
            customTabControl2.DisplayStyleProvider.BlendStyle = TabControl.BlendStyle.Normal;
            customTabControl2.DisplayStyleProvider.BorderColorDisabled = Color.FromArgb(41, 57, 85);
            customTabControl2.DisplayStyleProvider.BorderColorFocused = Color.FromArgb(255, 243, 205);
            customTabControl2.DisplayStyleProvider.BorderColorHighlighted = Color.FromArgb(155, 167, 183);
            customTabControl2.DisplayStyleProvider.BorderColorSelected = Color.FromArgb(206, 212, 223);
            customTabControl2.DisplayStyleProvider.BorderColorUnselected = Color.Transparent;
            customTabControl2.DisplayStyleProvider.CloserButtonFillColorFocused = Color.Empty;
            customTabControl2.DisplayStyleProvider.CloserButtonFillColorFocusedActive = Color.White;
            customTabControl2.DisplayStyleProvider.CloserButtonFillColorHighlighted = Color.Empty;
            customTabControl2.DisplayStyleProvider.CloserButtonFillColorHighlightedActive = Color.White;
            customTabControl2.DisplayStyleProvider.CloserButtonFillColorSelected = Color.Empty;
            customTabControl2.DisplayStyleProvider.CloserButtonFillColorSelectedActive = Color.White;
            customTabControl2.DisplayStyleProvider.CloserButtonFillColorUnselected = Color.Empty;
            customTabControl2.DisplayStyleProvider.CloserButtonOutlineColorFocused = Color.Empty;
            customTabControl2.DisplayStyleProvider.CloserButtonOutlineColorFocusedActive = SystemColors.ActiveCaption;
            customTabControl2.DisplayStyleProvider.CloserButtonOutlineColorHighlighted = Color.Empty;
            customTabControl2.DisplayStyleProvider.CloserButtonOutlineColorHighlightedActive = SystemColors.ActiveCaption;
            customTabControl2.DisplayStyleProvider.CloserButtonOutlineColorSelected = Color.Empty;
            customTabControl2.DisplayStyleProvider.CloserButtonOutlineColorSelectedActive = SystemColors.ActiveCaption;
            customTabControl2.DisplayStyleProvider.CloserButtonOutlineColorUnselected = Color.Empty;
            customTabControl2.DisplayStyleProvider.CloserColorFocused = Color.FromArgb(117, 99, 61);
            customTabControl2.DisplayStyleProvider.CloserColorFocusedActive = Color.Black;
            customTabControl2.DisplayStyleProvider.CloserColorHighlighted = Color.FromArgb(206, 212, 221);
            customTabControl2.DisplayStyleProvider.CloserColorHighlightedActive = Color.Black;
            customTabControl2.DisplayStyleProvider.CloserColorSelected = Color.FromArgb(95, 102, 115);
            customTabControl2.DisplayStyleProvider.CloserColorSelectedActive = Color.Black;
            customTabControl2.DisplayStyleProvider.CloserColorUnselected = Color.Empty;
            customTabControl2.DisplayStyleProvider.FocusColor = SystemColors.ActiveCaption;
            customTabControl2.DisplayStyleProvider.FocusTrack = false;
            customTabControl2.DisplayStyleProvider.HotTrack = true;
            customTabControl2.DisplayStyleProvider.ImageAlign = ContentAlignment.MiddleLeft;
            customTabControl2.DisplayStyleProvider.Opacity = 1F;
            customTabControl2.DisplayStyleProvider.Overlap = 0;
            customTabControl2.DisplayStyleProvider.Padding = new Point(6, 5);
            customTabControl2.DisplayStyleProvider.PageBackgroundColorDisabled = Color.FromArgb(41, 57, 85);
            customTabControl2.DisplayStyleProvider.PageBackgroundColorFocused = SystemColors.ActiveCaption;
            customTabControl2.DisplayStyleProvider.PageBackgroundColorHighlighted = Color.FromArgb(75, 92, 116);
            customTabControl2.DisplayStyleProvider.PageBackgroundColorSelected = Color.FromArgb(206, 212, 223);
            customTabControl2.DisplayStyleProvider.PageBackgroundColorUnselected = Color.Transparent;
            customTabControl2.DisplayStyleProvider.Radius = 3;
            customTabControl2.DisplayStyleProvider.SelectedTabIsLarger = false;
            customTabControl2.DisplayStyleProvider.ShowTabCloser = true;
            customTabControl2.DisplayStyleProvider.TabColorDisabled1 = Color.FromArgb(41, 57, 85);
            customTabControl2.DisplayStyleProvider.TabColorDisabled2 = Color.FromArgb(41, 57, 85);
            customTabControl2.DisplayStyleProvider.TabColorFocused1 = SystemColors.ActiveCaption;
            customTabControl2.DisplayStyleProvider.TabColorFocused2 = SystemColors.Window;
            customTabControl2.DisplayStyleProvider.TabColorHighLighted1 = Color.FromArgb(75, 92, 116);
            customTabControl2.DisplayStyleProvider.TabColorHighLighted2 = Color.FromArgb(75, 92, 116);
            customTabControl2.DisplayStyleProvider.TabColorSelected1 = Color.FromArgb(206, 212, 223);
            customTabControl2.DisplayStyleProvider.TabColorSelected2 = Color.FromArgb(206, 212, 223);
            customTabControl2.DisplayStyleProvider.TabColorUnSelected1 = Color.Transparent;
            customTabControl2.DisplayStyleProvider.TabColorUnSelected2 = Color.Transparent;
            customTabControl2.DisplayStyleProvider.TabPageMargin = new Padding(0, 4, 0, 4);
            customTabControl2.DisplayStyleProvider.TabPageRadius = 2;
            customTabControl2.DisplayStyleProvider.TextColorDisabled = Color.WhiteSmoke;
            customTabControl2.DisplayStyleProvider.TextColorFocused = SystemColors.ControlText;
            customTabControl2.DisplayStyleProvider.TextColorHighlighted = Color.White;
            customTabControl2.DisplayStyleProvider.TextColorSelected = SystemColors.ControlText;
            customTabControl2.DisplayStyleProvider.TextColorUnselected = Color.White;
            customTabControl2.Dock = DockStyle.Fill;
            customTabControl2.HotTrack = true;
            customTabControl2.Location = new Point(0, 0);
            customTabControl2.Name = "customTabControl2";
            customTabControl2.SelectedIndex = 0;
            customTabControl2.Size = new Size(708, 579);
            customTabControl2.TabIndex = 1;
            customTabControl2.TabStop = false;
            // 
            // InformationTab
            // 
            InformationTab.BackColor = Color.FromArgb(26, 26, 34);
            InformationTab.Controls.Add(textBox2);
            InformationTab.Controls.Add(label3);
            InformationTab.Controls.Add(textBox1);
            InformationTab.Controls.Add(label2);
            InformationTab.Controls.Add(label1);
            InformationTab.Location = new Point(4, 30);
            InformationTab.Name = "InformationTab";
            InformationTab.Padding = new Padding(3);
            InformationTab.Size = new Size(700, 545);
            InformationTab.TabIndex = 0;
            InformationTab.Text = "Information";
            // 
            // ImportsTab
            // 
            ImportsTab.BackColor = Color.FromArgb(26, 26, 34);
            ImportsTab.Controls.Add(ImportsListView);
            ImportsTab.ForeColor = Color.White;
            ImportsTab.Location = new Point(4, 30);
            ImportsTab.Name = "ImportsTab";
            ImportsTab.Padding = new Padding(3);
            ImportsTab.Size = new Size(700, 545);
            ImportsTab.TabIndex = 1;
            ImportsTab.Text = "Imports";
            // 
            // ImportsListView
            // 
            ImportsListView.BackColor = Color.FromArgb(26, 26, 34);
            ImportsListView.Columns.AddRange(new ColumnHeader[] { ImportNameColumn, ImportAddressColumn, ImportLibraryColumn });
            ImportsListView.Dock = DockStyle.Fill;
            ImportsListView.ForeColor = Color.White;
            ImportsListView.FullRowSelect = true;
            ImportsListView.Location = new Point(3, 3);
            ImportsListView.Name = "ImportsListView";
            ImportsListView.Size = new Size(694, 539);
            ImportsListView.TabIndex = 2;
            ImportsListView.UseCompatibleStateImageBehavior = false;
            ImportsListView.View = View.Details;
            // 
            // ImportNameColumn
            // 
            ImportNameColumn.Text = "Name";
            ImportNameColumn.Width = 210;
            // 
            // ImportAddressColumn
            // 
            ImportAddressColumn.Text = "Address";
            ImportAddressColumn.Width = 80;
            // 
            // ImportLibraryColumn
            // 
            ImportLibraryColumn.Text = "Library";
            ImportLibraryColumn.Width = 120;
            // 
            // ExportsTab
            // 
            ExportsTab.BackColor = Color.FromArgb(26, 26, 34);
            ExportsTab.Controls.Add(ExportsListView);
            ExportsTab.ForeColor = Color.White;
            ExportsTab.Location = new Point(4, 30);
            ExportsTab.Name = "ExportsTab";
            ExportsTab.Padding = new Padding(3);
            ExportsTab.Size = new Size(700, 545);
            ExportsTab.TabIndex = 2;
            ExportsTab.Text = "Exports";
            // 
            // ExportsListView
            // 
            ExportsListView.BackColor = Color.FromArgb(26, 26, 34);
            ExportsListView.Columns.AddRange(new ColumnHeader[] { ExportNameColumn, AddressColumn });
            ExportsListView.Dock = DockStyle.Fill;
            ExportsListView.ForeColor = Color.White;
            ExportsListView.FullRowSelect = true;
            ExportsListView.Location = new Point(3, 3);
            ExportsListView.Name = "ExportsListView";
            ExportsListView.Size = new Size(694, 539);
            ExportsListView.TabIndex = 1;
            ExportsListView.UseCompatibleStateImageBehavior = false;
            ExportsListView.View = View.Details;
            // 
            // ExportNameColumn
            // 
            ExportNameColumn.Text = "Name";
            ExportNameColumn.Width = 210;
            // 
            // AddressColumn
            // 
            AddressColumn.Text = "Address";
            AddressColumn.Width = 80;
            // 
            // StringsTab
            // 
            StringsTab.BackColor = Color.FromArgb(26, 26, 34);
            StringsTab.Controls.Add(StringsListView);
            StringsTab.Location = new Point(4, 30);
            StringsTab.Name = "StringsTab";
            StringsTab.Padding = new Padding(3);
            StringsTab.Size = new Size(700, 545);
            StringsTab.TabIndex = 3;
            StringsTab.Text = "Strings";
            // 
            // StringsListView
            // 
            StringsListView.BackColor = Color.FromArgb(26, 26, 34);
            StringsListView.Columns.AddRange(new ColumnHeader[] { StringAddressColumn, StringLengthColumn, StringSectionColumn, StringTypeColumn, StringColumn });
            StringsListView.Dock = DockStyle.Fill;
            StringsListView.ForeColor = Color.White;
            StringsListView.FullRowSelect = true;
            StringsListView.Location = new Point(3, 3);
            StringsListView.Name = "StringsListView";
            StringsListView.Size = new Size(694, 539);
            StringsListView.TabIndex = 0;
            StringsListView.UseCompatibleStateImageBehavior = false;
            StringsListView.View = View.Details;
            // 
            // StringAddressColumn
            // 
            StringAddressColumn.Text = "Address";
            StringAddressColumn.Width = 80;
            // 
            // StringLengthColumn
            // 
            StringLengthColumn.Text = "Length";
            // 
            // StringSectionColumn
            // 
            StringSectionColumn.Text = "Section";
            StringSectionColumn.Width = 70;
            // 
            // StringTypeColumn
            // 
            StringTypeColumn.Text = "Type";
            StringTypeColumn.Width = 70;
            // 
            // StringColumn
            // 
            StringColumn.Text = "String";
            StringColumn.Width = 300;
            // 
            // DisassemblyTab
            // 
            DisassemblyTab.BackColor = Color.FromArgb(26, 26, 34);
            DisassemblyTab.Controls.Add(richTextBox1);
            DisassemblyTab.ForeColor = Color.White;
            DisassemblyTab.Location = new Point(4, 30);
            DisassemblyTab.Name = "DisassemblyTab";
            DisassemblyTab.Padding = new Padding(3);
            DisassemblyTab.Size = new Size(700, 545);
            DisassemblyTab.TabIndex = 4;
            DisassemblyTab.Text = "View";
            // 
            // richTextBox1
            // 
            richTextBox1.BackColor = Color.FromArgb(26, 26, 34);
            richTextBox1.Dock = DockStyle.Fill;
            richTextBox1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            richTextBox1.ForeColor = Color.White;
            richTextBox1.Location = new Point(3, 3);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ReadOnly = true;
            richTextBox1.Size = new Size(694, 539);
            richTextBox1.TabIndex = 0;
            richTextBox1.Text = "";
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.FromArgb(26, 26, 34);
            tabPage1.Location = new Point(4, 30);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(730, 572);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "tabPage1";
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 30);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(730, 572);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "tabPage2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // OptionsMenu
            // 
            OptionsMenu.BackColor = Color.FromArgb(26, 26, 34);
            OptionsMenu.Items.AddRange(new ToolStripItem[] { FileToolStripMenuItem });
            OptionsMenu.Location = new Point(0, 0);
            OptionsMenu.Name = "OptionsMenu";
            OptionsMenu.Padding = new Padding(10, 7, 0, 7);
            OptionsMenu.RenderMode = ToolStripRenderMode.System;
            OptionsMenu.Size = new Size(992, 33);
            OptionsMenu.TabIndex = 0;
            OptionsMenu.Text = "menuStrip1";
            OptionsMenu.ItemClicked += OptionsMenu_ItemClicked;
            // 
            // FileToolStripMenuItem
            // 
            FileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { OpenToolStripMenuItem });
            FileToolStripMenuItem.ForeColor = Color.White;
            FileToolStripMenuItem.Margin = new Padding(30, 0, 0, 0);
            FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            FileToolStripMenuItem.Size = new Size(37, 19);
            FileToolStripMenuItem.Text = "File";
            // 
            // OpenToolStripMenuItem
            // 
            OpenToolStripMenuItem.Name = "OpenToolStripMenuItem";
            OpenToolStripMenuItem.Size = new Size(112, 22);
            OpenToolStripMenuItem.Text = "Open...";
            OpenToolStripMenuItem.Click += OpenToolStripMenuItem_Click;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 33);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(FunctionsListView);
            splitContainer1.Panel1MinSize = 15;
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(customTabControl2);
            splitContainer1.Size = new Size(992, 579);
            splitContainer1.SplitterDistance = 280;
            splitContainer1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(18, 15);
            label1.Name = "label1";
            label1.Size = new Size(69, 37);
            label1.TabIndex = 2;
            label1.Text = "Info";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.White;
            label2.Location = new Point(18, 83);
            label2.Name = "label2";
            label2.Size = new Size(28, 15);
            label2.TabIndex = 2;
            label2.Text = "File:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(72, 80);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(256, 23);
            textBox1.TabIndex = 3;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(72, 109);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(256, 23);
            textBox2.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.White;
            label3.Location = new Point(18, 112);
            label3.Name = "label3";
            label3.Size = new Size(48, 15);
            label3.TabIndex = 4;
            label3.Text = "Format:";
            // 
            // Dissasembly
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(26, 26, 34);
            ClientSize = new Size(992, 612);
            Controls.Add(splitContainer1);
            Controls.Add(OptionsMenu);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Dissasembly";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "%placeholder%";
            Load += Dissasembly_Load;
            customTabControl2.ResumeLayout(false);
            InformationTab.ResumeLayout(false);
            InformationTab.PerformLayout();
            ImportsTab.ResumeLayout(false);
            ExportsTab.ResumeLayout(false);
            StringsTab.ResumeLayout(false);
            DisassemblyTab.ResumeLayout(false);
            OptionsMenu.ResumeLayout(false);
            OptionsMenu.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.TabControl tabControl1;
        private TabControl.CustomTabControl customTabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabControl.CustomTabControl customTabControl2;
        private TabPage InformationTab;
        private TabPage ImportsTab;
        private MenuStrip OptionsMenu;
        private TabPage ExportsTab;
        private TabPage StringsTab;
        private ListView StringsListView;
        private TabPage DisassemblyTab;
        private ToolStripMenuItem FileToolStripMenuItem;
        private ToolStripMenuItem OpenToolStripMenuItem;
        private ListView FunctionsListView;
        private ColumnHeader FunctionNameHeader;
        private ColumnHeader AddressHeader;
        private SplitContainer splitContainer1;
        private ColumnHeader StringAddressColumn;
        private ColumnHeader StringLengthColumn;
        private ColumnHeader StringColumn;
        private ColumnHeader StringSectionColumn;
        private ColumnHeader StringTypeColumn;
        private ListView ExportsListView;
        private ColumnHeader ExportNameColumn;
        private ColumnHeader AddressColumn;
        private ListView ImportsListView;
        private ColumnHeader ImportNameColumn;
        private ColumnHeader ImportAddressColumn;
        private ColumnHeader ImportLibraryColumn;
        private RichTextBox richTextBox1;
        private Label label1;
        private TextBox textBox1;
        private Label label2;
        private TextBox textBox2;
        private Label label3;
    }
}