using MCDA_APP.Rendering;

namespace MCDA_APP.Forms
{
    partial class Disasembly
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Disasembly));
            FunctionsListView = new ListView();
            FunctionNameHeader = new ColumnHeader();
            AddressHeader = new ColumnHeader();
            DisassemblerTab = new TabControl.CustomTabControl();
            InformationTab = new TabPage();
            groupBox2 = new GroupBox();
            label1 = new Label();
            Sha1Textbox = new TextBox();
            Sha256Textbox = new TextBox();
            Md5Textbox = new TextBox();
            label15 = new Label();
            label14 = new Label();
            groupBox1 = new GroupBox();
            label2 = new Label();
            BitsTextbox = new TextBox();
            FileTextbox = new TextBox();
            label13 = new Label();
            label3 = new Label();
            PicTextbox = new TextBox();
            FormatTextbox = new TextBox();
            label12 = new Label();
            label4 = new Label();
            NxTextbox = new TextBox();
            SizeTextbox = new TextBox();
            label7 = new Label();
            label5 = new Label();
            CryptoTextbox = new TextBox();
            TypeTextbox = new TextBox();
            label8 = new Label();
            label6 = new Label();
            CanaryTextbox = new TextBox();
            LanguageTextbox = new TextBox();
            label9 = new Label();
            label11 = new Label();
            BaseAddrTextbox = new TextBox();
            FdTextbox = new TextBox();
            label10 = new Label();
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
            flowLayoutPanel1 = new FlowLayoutPanel();
            SearchStringLabel = new Label();
            SearchStringTextbox = new TextBox();
            DisassemblyTab = new TabPage();
            AssemblyTextBox = new RichTextBox();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            OptionsMenu = new MenuStrip();
            FileToolStripMenuItem = new ToolStripMenuItem();
            OpenToolStripMenuItem = new ToolStripMenuItem();
            splitContainer1 = new SplitContainer();
            DisassemblerTab.SuspendLayout();
            InformationTab.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            ImportsTab.SuspendLayout();
            ExportsTab.SuspendLayout();
            StringsTab.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
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
            // DisassemblerTab
            // 
            DisassemblerTab.Controls.Add(InformationTab);
            DisassemblerTab.Controls.Add(ImportsTab);
            DisassemblerTab.Controls.Add(ExportsTab);
            DisassemblerTab.Controls.Add(StringsTab);
            DisassemblerTab.Controls.Add(DisassemblyTab);
            DisassemblerTab.DisplayStyle = TabControl.TabStyle.VS2010;
            // 
            // 
            // 
            DisassemblerTab.DisplayStyleProvider.BlendStyle = TabControl.BlendStyle.Normal;
            DisassemblerTab.DisplayStyleProvider.BorderColorDisabled = Color.FromArgb(41, 57, 85);
            DisassemblerTab.DisplayStyleProvider.BorderColorFocused = Color.FromArgb(255, 243, 205);
            DisassemblerTab.DisplayStyleProvider.BorderColorHighlighted = Color.FromArgb(155, 167, 183);
            DisassemblerTab.DisplayStyleProvider.BorderColorSelected = Color.FromArgb(206, 212, 223);
            DisassemblerTab.DisplayStyleProvider.BorderColorUnselected = Color.Transparent;
            DisassemblerTab.DisplayStyleProvider.CloserButtonFillColorFocused = Color.Empty;
            DisassemblerTab.DisplayStyleProvider.CloserButtonFillColorFocusedActive = Color.White;
            DisassemblerTab.DisplayStyleProvider.CloserButtonFillColorHighlighted = Color.Empty;
            DisassemblerTab.DisplayStyleProvider.CloserButtonFillColorHighlightedActive = Color.White;
            DisassemblerTab.DisplayStyleProvider.CloserButtonFillColorSelected = Color.Empty;
            DisassemblerTab.DisplayStyleProvider.CloserButtonFillColorSelectedActive = Color.White;
            DisassemblerTab.DisplayStyleProvider.CloserButtonFillColorUnselected = Color.Empty;
            DisassemblerTab.DisplayStyleProvider.CloserButtonOutlineColorFocused = Color.Empty;
            DisassemblerTab.DisplayStyleProvider.CloserButtonOutlineColorFocusedActive = SystemColors.ActiveCaption;
            DisassemblerTab.DisplayStyleProvider.CloserButtonOutlineColorHighlighted = Color.Empty;
            DisassemblerTab.DisplayStyleProvider.CloserButtonOutlineColorHighlightedActive = SystemColors.ActiveCaption;
            DisassemblerTab.DisplayStyleProvider.CloserButtonOutlineColorSelected = Color.Empty;
            DisassemblerTab.DisplayStyleProvider.CloserButtonOutlineColorSelectedActive = SystemColors.ActiveCaption;
            DisassemblerTab.DisplayStyleProvider.CloserButtonOutlineColorUnselected = Color.Empty;
            DisassemblerTab.DisplayStyleProvider.CloserColorFocused = Color.FromArgb(117, 99, 61);
            DisassemblerTab.DisplayStyleProvider.CloserColorFocusedActive = Color.Black;
            DisassemblerTab.DisplayStyleProvider.CloserColorHighlighted = Color.FromArgb(206, 212, 221);
            DisassemblerTab.DisplayStyleProvider.CloserColorHighlightedActive = Color.Black;
            DisassemblerTab.DisplayStyleProvider.CloserColorSelected = Color.FromArgb(95, 102, 115);
            DisassemblerTab.DisplayStyleProvider.CloserColorSelectedActive = Color.Black;
            DisassemblerTab.DisplayStyleProvider.CloserColorUnselected = Color.Empty;
            DisassemblerTab.DisplayStyleProvider.FocusColor = SystemColors.ActiveCaption;
            DisassemblerTab.DisplayStyleProvider.FocusTrack = false;
            DisassemblerTab.DisplayStyleProvider.HotTrack = true;
            DisassemblerTab.DisplayStyleProvider.ImageAlign = ContentAlignment.MiddleLeft;
            DisassemblerTab.DisplayStyleProvider.Opacity = 1F;
            DisassemblerTab.DisplayStyleProvider.Overlap = 0;
            DisassemblerTab.DisplayStyleProvider.Padding = new Point(6, 5);
            DisassemblerTab.DisplayStyleProvider.PageBackgroundColorDisabled = Color.FromArgb(41, 57, 85);
            DisassemblerTab.DisplayStyleProvider.PageBackgroundColorFocused = SystemColors.ActiveCaption;
            DisassemblerTab.DisplayStyleProvider.PageBackgroundColorHighlighted = Color.FromArgb(75, 92, 116);
            DisassemblerTab.DisplayStyleProvider.PageBackgroundColorSelected = Color.FromArgb(206, 212, 223);
            DisassemblerTab.DisplayStyleProvider.PageBackgroundColorUnselected = Color.Transparent;
            DisassemblerTab.DisplayStyleProvider.Radius = 3;
            DisassemblerTab.DisplayStyleProvider.SelectedTabIsLarger = false;
            DisassemblerTab.DisplayStyleProvider.ShowTabCloser = true;
            DisassemblerTab.DisplayStyleProvider.TabColorDisabled1 = Color.FromArgb(41, 57, 85);
            DisassemblerTab.DisplayStyleProvider.TabColorDisabled2 = Color.FromArgb(41, 57, 85);
            DisassemblerTab.DisplayStyleProvider.TabColorFocused1 = SystemColors.ActiveCaption;
            DisassemblerTab.DisplayStyleProvider.TabColorFocused2 = SystemColors.Window;
            DisassemblerTab.DisplayStyleProvider.TabColorHighLighted1 = Color.FromArgb(75, 92, 116);
            DisassemblerTab.DisplayStyleProvider.TabColorHighLighted2 = Color.FromArgb(75, 92, 116);
            DisassemblerTab.DisplayStyleProvider.TabColorSelected1 = Color.FromArgb(206, 212, 223);
            DisassemblerTab.DisplayStyleProvider.TabColorSelected2 = Color.FromArgb(206, 212, 223);
            DisassemblerTab.DisplayStyleProvider.TabColorUnSelected1 = Color.Transparent;
            DisassemblerTab.DisplayStyleProvider.TabColorUnSelected2 = Color.Transparent;
            DisassemblerTab.DisplayStyleProvider.TabPageMargin = new Padding(0, 4, 0, 4);
            DisassemblerTab.DisplayStyleProvider.TabPageRadius = 2;
            DisassemblerTab.DisplayStyleProvider.TextColorDisabled = Color.WhiteSmoke;
            DisassemblerTab.DisplayStyleProvider.TextColorFocused = SystemColors.ControlText;
            DisassemblerTab.DisplayStyleProvider.TextColorHighlighted = Color.White;
            DisassemblerTab.DisplayStyleProvider.TextColorSelected = SystemColors.ControlText;
            DisassemblerTab.DisplayStyleProvider.TextColorUnselected = Color.White;
            DisassemblerTab.Dock = DockStyle.Fill;
            DisassemblerTab.HotTrack = true;
            DisassemblerTab.Location = new Point(0, 0);
            DisassemblerTab.Name = "DisassemblerTab";
            DisassemblerTab.SelectedIndex = 0;
            DisassemblerTab.Size = new Size(708, 579);
            DisassemblerTab.TabIndex = 1;
            DisassemblerTab.TabStop = false;
            // 
            // InformationTab
            // 
            InformationTab.BackColor = Color.FromArgb(26, 26, 34);
            InformationTab.Controls.Add(groupBox2);
            InformationTab.Controls.Add(groupBox1);
            InformationTab.Location = new Point(4, 30);
            InformationTab.Name = "InformationTab";
            InformationTab.Padding = new Padding(3);
            InformationTab.Size = new Size(700, 545);
            InformationTab.TabIndex = 0;
            InformationTab.Text = "Information";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(Sha1Textbox);
            groupBox2.Controls.Add(Sha256Textbox);
            groupBox2.Controls.Add(Md5Textbox);
            groupBox2.Controls.Add(label15);
            groupBox2.Controls.Add(label14);
            groupBox2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox2.ForeColor = Color.White;
            groupBox2.Location = new Point(6, 249);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(686, 148);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Hashes";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(10, 46);
            label1.Name = "label1";
            label1.Size = new Size(35, 15);
            label1.TabIndex = 26;
            label1.Text = "MD5:";
            // 
            // Sha1Textbox
            // 
            Sha1Textbox.BackColor = Color.FromArgb(46, 46, 65);
            Sha1Textbox.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Sha1Textbox.ForeColor = Color.White;
            Sha1Textbox.Location = new Point(78, 72);
            Sha1Textbox.Name = "Sha1Textbox";
            Sha1Textbox.ReadOnly = true;
            Sha1Textbox.Size = new Size(594, 23);
            Sha1Textbox.TabIndex = 31;
            Sha1Textbox.TabStop = false;
            // 
            // Sha256Textbox
            // 
            Sha256Textbox.BackColor = Color.FromArgb(46, 46, 65);
            Sha256Textbox.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Sha256Textbox.ForeColor = Color.White;
            Sha256Textbox.Location = new Point(78, 101);
            Sha256Textbox.Name = "Sha256Textbox";
            Sha256Textbox.ReadOnly = true;
            Sha256Textbox.Size = new Size(594, 23);
            Sha256Textbox.TabIndex = 29;
            Sha256Textbox.TabStop = false;
            // 
            // Md5Textbox
            // 
            Md5Textbox.BackColor = Color.FromArgb(46, 46, 65);
            Md5Textbox.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Md5Textbox.ForeColor = Color.White;
            Md5Textbox.Location = new Point(78, 43);
            Md5Textbox.Name = "Md5Textbox";
            Md5Textbox.ReadOnly = true;
            Md5Textbox.Size = new Size(594, 23);
            Md5Textbox.TabIndex = 27;
            Md5Textbox.TabStop = false;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label15.ForeColor = Color.White;
            label15.Location = new Point(10, 104);
            label15.Name = "label15";
            label15.Size = new Size(56, 15);
            label15.TabIndex = 28;
            label15.Text = "SHA-256:";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label14.ForeColor = Color.White;
            label14.Location = new Point(10, 75);
            label14.Name = "label14";
            label14.Size = new Size(44, 15);
            label14.TabIndex = 30;
            label14.Text = "SHA-1:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(BitsTextbox);
            groupBox1.Controls.Add(FileTextbox);
            groupBox1.Controls.Add(label13);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(PicTextbox);
            groupBox1.Controls.Add(FormatTextbox);
            groupBox1.Controls.Add(label12);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(NxTextbox);
            groupBox1.Controls.Add(SizeTextbox);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(CryptoTextbox);
            groupBox1.Controls.Add(TypeTextbox);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(CanaryTextbox);
            groupBox1.Controls.Add(LanguageTextbox);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(label11);
            groupBox1.Controls.Add(BaseAddrTextbox);
            groupBox1.Controls.Add(FdTextbox);
            groupBox1.Controls.Add(label10);
            groupBox1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox1.ForeColor = Color.White;
            groupBox1.Location = new Point(6, 22);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(686, 221);
            groupBox1.TabIndex = 26;
            groupBox1.TabStop = false;
            groupBox1.Text = "Info";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.White;
            label2.Location = new Point(10, 33);
            label2.Name = "label2";
            label2.Size = new Size(28, 15);
            label2.TabIndex = 2;
            label2.Text = "File:";
            // 
            // BitsTextbox
            // 
            BitsTextbox.BackColor = Color.FromArgb(46, 46, 65);
            BitsTextbox.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            BitsTextbox.ForeColor = Color.White;
            BitsTextbox.Location = new Point(78, 59);
            BitsTextbox.Name = "BitsTextbox";
            BitsTextbox.ReadOnly = true;
            BitsTextbox.Size = new Size(256, 23);
            BitsTextbox.TabIndex = 25;
            BitsTextbox.TabStop = false;
            // 
            // FileTextbox
            // 
            FileTextbox.BackColor = Color.FromArgb(46, 46, 65);
            FileTextbox.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            FileTextbox.ForeColor = Color.White;
            FileTextbox.Location = new Point(78, 30);
            FileTextbox.Name = "FileTextbox";
            FileTextbox.ReadOnly = true;
            FileTextbox.Size = new Size(256, 23);
            FileTextbox.TabIndex = 3;
            FileTextbox.TabStop = false;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label13.ForeColor = Color.White;
            label13.Location = new Point(10, 62);
            label13.Name = "label13";
            label13.Size = new Size(29, 15);
            label13.TabIndex = 24;
            label13.Text = "Bits:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = Color.White;
            label3.Location = new Point(10, 91);
            label3.Name = "label3";
            label3.Size = new Size(48, 15);
            label3.TabIndex = 4;
            label3.Text = "Format:";
            // 
            // PicTextbox
            // 
            PicTextbox.BackColor = Color.FromArgb(46, 46, 65);
            PicTextbox.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            PicTextbox.ForeColor = Color.White;
            PicTextbox.Location = new Point(416, 175);
            PicTextbox.Name = "PicTextbox";
            PicTextbox.ReadOnly = true;
            PicTextbox.Size = new Size(256, 23);
            PicTextbox.TabIndex = 23;
            PicTextbox.TabStop = false;
            // 
            // FormatTextbox
            // 
            FormatTextbox.BackColor = Color.FromArgb(46, 46, 65);
            FormatTextbox.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            FormatTextbox.ForeColor = Color.White;
            FormatTextbox.Location = new Point(78, 88);
            FormatTextbox.Name = "FormatTextbox";
            FormatTextbox.ReadOnly = true;
            FormatTextbox.Size = new Size(256, 23);
            FormatTextbox.TabIndex = 5;
            FormatTextbox.TabStop = false;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label12.ForeColor = Color.White;
            label12.Location = new Point(348, 178);
            label12.Name = "label12";
            label12.Size = new Size(28, 15);
            label12.TabIndex = 22;
            label12.Text = "PIC:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = Color.White;
            label4.Location = new Point(10, 120);
            label4.Name = "label4";
            label4.Size = new Size(30, 15);
            label4.TabIndex = 6;
            label4.Text = "Size:";
            // 
            // NxTextbox
            // 
            NxTextbox.BackColor = Color.FromArgb(46, 46, 65);
            NxTextbox.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            NxTextbox.ForeColor = Color.White;
            NxTextbox.Location = new Point(416, 146);
            NxTextbox.Name = "NxTextbox";
            NxTextbox.ReadOnly = true;
            NxTextbox.Size = new Size(256, 23);
            NxTextbox.TabIndex = 21;
            NxTextbox.TabStop = false;
            // 
            // SizeTextbox
            // 
            SizeTextbox.BackColor = Color.FromArgb(46, 46, 65);
            SizeTextbox.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            SizeTextbox.ForeColor = Color.White;
            SizeTextbox.Location = new Point(78, 117);
            SizeTextbox.Name = "SizeTextbox";
            SizeTextbox.ReadOnly = true;
            SizeTextbox.Size = new Size(256, 23);
            SizeTextbox.TabIndex = 7;
            SizeTextbox.TabStop = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label7.ForeColor = Color.White;
            label7.Location = new Point(348, 149);
            label7.Name = "label7";
            label7.Size = new Size(26, 15);
            label7.TabIndex = 20;
            label7.Text = "NX:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label5.ForeColor = Color.White;
            label5.Location = new Point(10, 149);
            label5.Name = "label5";
            label5.Size = new Size(34, 15);
            label5.TabIndex = 8;
            label5.Text = "Type:";
            // 
            // CryptoTextbox
            // 
            CryptoTextbox.BackColor = Color.FromArgb(46, 46, 65);
            CryptoTextbox.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            CryptoTextbox.ForeColor = Color.White;
            CryptoTextbox.Location = new Point(416, 117);
            CryptoTextbox.Name = "CryptoTextbox";
            CryptoTextbox.ReadOnly = true;
            CryptoTextbox.Size = new Size(256, 23);
            CryptoTextbox.TabIndex = 19;
            CryptoTextbox.TabStop = false;
            // 
            // TypeTextbox
            // 
            TypeTextbox.BackColor = Color.FromArgb(46, 46, 65);
            TypeTextbox.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            TypeTextbox.ForeColor = Color.White;
            TypeTextbox.Location = new Point(78, 146);
            TypeTextbox.Name = "TypeTextbox";
            TypeTextbox.ReadOnly = true;
            TypeTextbox.Size = new Size(256, 23);
            TypeTextbox.TabIndex = 9;
            TypeTextbox.TabStop = false;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label8.ForeColor = Color.White;
            label8.Location = new Point(348, 120);
            label8.Name = "label8";
            label8.Size = new Size(46, 15);
            label8.TabIndex = 18;
            label8.Text = "Crypto:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label6.ForeColor = Color.White;
            label6.Location = new Point(10, 178);
            label6.Name = "label6";
            label6.Size = new Size(62, 15);
            label6.TabIndex = 10;
            label6.Text = "Language:";
            // 
            // CanaryTextbox
            // 
            CanaryTextbox.BackColor = Color.FromArgb(46, 46, 65);
            CanaryTextbox.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            CanaryTextbox.ForeColor = Color.White;
            CanaryTextbox.Location = new Point(416, 88);
            CanaryTextbox.Name = "CanaryTextbox";
            CanaryTextbox.ReadOnly = true;
            CanaryTextbox.Size = new Size(256, 23);
            CanaryTextbox.TabIndex = 17;
            CanaryTextbox.TabStop = false;
            // 
            // LanguageTextbox
            // 
            LanguageTextbox.BackColor = Color.FromArgb(46, 46, 65);
            LanguageTextbox.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            LanguageTextbox.ForeColor = Color.White;
            LanguageTextbox.Location = new Point(78, 175);
            LanguageTextbox.Name = "LanguageTextbox";
            LanguageTextbox.ReadOnly = true;
            LanguageTextbox.Size = new Size(256, 23);
            LanguageTextbox.TabIndex = 11;
            LanguageTextbox.TabStop = false;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label9.ForeColor = Color.White;
            label9.Location = new Point(348, 91);
            label9.Name = "label9";
            label9.Size = new Size(47, 15);
            label9.TabIndex = 16;
            label9.Text = "Canary:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label11.ForeColor = Color.White;
            label11.Location = new Point(348, 33);
            label11.Name = "label11";
            label11.Size = new Size(24, 15);
            label11.TabIndex = 12;
            label11.Text = "FD:";
            // 
            // BaseAddrTextbox
            // 
            BaseAddrTextbox.BackColor = Color.FromArgb(46, 46, 65);
            BaseAddrTextbox.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            BaseAddrTextbox.ForeColor = Color.White;
            BaseAddrTextbox.Location = new Point(416, 59);
            BaseAddrTextbox.Name = "BaseAddrTextbox";
            BaseAddrTextbox.ReadOnly = true;
            BaseAddrTextbox.Size = new Size(256, 23);
            BaseAddrTextbox.TabIndex = 15;
            BaseAddrTextbox.TabStop = false;
            // 
            // FdTextbox
            // 
            FdTextbox.BackColor = Color.FromArgb(46, 46, 65);
            FdTextbox.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            FdTextbox.ForeColor = Color.White;
            FdTextbox.Location = new Point(416, 30);
            FdTextbox.Name = "FdTextbox";
            FdTextbox.ReadOnly = true;
            FdTextbox.Size = new Size(256, 23);
            FdTextbox.TabIndex = 13;
            FdTextbox.TabStop = false;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label10.ForeColor = Color.White;
            label10.Location = new Point(348, 62);
            label10.Name = "label10";
            label10.Size = new Size(63, 15);
            label10.TabIndex = 14;
            label10.Text = "Base Addr:";
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
            StringsTab.Controls.Add(flowLayoutPanel1);
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
            StringsListView.Size = new Size(694, 504);
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
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(SearchStringLabel);
            flowLayoutPanel1.Controls.Add(SearchStringTextbox);
            flowLayoutPanel1.Dock = DockStyle.Bottom;
            flowLayoutPanel1.Location = new Point(3, 507);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(694, 35);
            flowLayoutPanel1.TabIndex = 1;
            // 
            // SearchStringLabel
            // 
            SearchStringLabel.AutoSize = true;
            SearchStringLabel.ForeColor = Color.White;
            SearchStringLabel.Location = new Point(5, 10);
            SearchStringLabel.Margin = new Padding(5, 10, 3, 0);
            SearchStringLabel.Name = "SearchStringLabel";
            SearchStringLabel.Size = new Size(42, 15);
            SearchStringLabel.TabIndex = 0;
            SearchStringLabel.Text = "Search";
            // 
            // SearchStringTextbox
            // 
            SearchStringTextbox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            SearchStringTextbox.BackColor = Color.FromArgb(46, 46, 65);
            SearchStringTextbox.ForeColor = Color.White;
            SearchStringTextbox.Location = new Point(53, 6);
            SearchStringTextbox.Margin = new Padding(3, 6, 3, 3);
            SearchStringTextbox.Name = "SearchStringTextbox";
            SearchStringTextbox.Size = new Size(636, 23);
            SearchStringTextbox.TabIndex = 1;
            SearchStringTextbox.TextChanged += SearchStringTextbox_TextChanged;
            // 
            // DisassemblyTab
            // 
            DisassemblyTab.BackColor = Color.FromArgb(26, 26, 34);
            DisassemblyTab.Controls.Add(AssemblyTextBox);
            DisassemblyTab.ForeColor = Color.White;
            DisassemblyTab.Location = new Point(4, 30);
            DisassemblyTab.Name = "DisassemblyTab";
            DisassemblyTab.Padding = new Padding(3);
            DisassemblyTab.Size = new Size(700, 545);
            DisassemblyTab.TabIndex = 4;
            DisassemblyTab.Text = "View";
            // 
            // AssemblyTextBox
            // 
            AssemblyTextBox.BackColor = Color.FromArgb(26, 26, 34);
            AssemblyTextBox.Dock = DockStyle.Fill;
            AssemblyTextBox.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            AssemblyTextBox.ForeColor = Color.White;
            AssemblyTextBox.Location = new Point(3, 3);
            AssemblyTextBox.Name = "AssemblyTextBox";
            AssemblyTextBox.ReadOnly = true;
            AssemblyTextBox.Size = new Size(694, 539);
            AssemblyTextBox.TabIndex = 0;
            AssemblyTextBox.Text = "";
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
            splitContainer1.Panel2.Controls.Add(DisassemblerTab);
            splitContainer1.Size = new Size(992, 579);
            splitContainer1.SplitterDistance = 280;
            splitContainer1.TabIndex = 1;
            // 
            // Disasembly
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(26, 26, 34);
            ClientSize = new Size(992, 612);
            Controls.Add(splitContainer1);
            Controls.Add(OptionsMenu);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Disasembly";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "%placeholder%";
            Load += Dissasembly_Load;
            Resize += Disasembly_Resize;
            DisassemblerTab.ResumeLayout(false);
            InformationTab.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ImportsTab.ResumeLayout(false);
            ExportsTab.ResumeLayout(false);
            StringsTab.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
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
        private TabControl.CustomTabControl DisassemblerTab;
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
        private RichTextBox AssemblyTextBox;
        private TextBox FileTextbox;
        private Label label2;
        private TextBox FormatTextbox;
        private Label label3;
        private TextBox SizeTextbox;
        private Label label4;
        private TextBox LanguageTextbox;
        private Label label6;
        private TextBox TypeTextbox;
        private Label label5;
        private TextBox NxTextbox;
        private Label label7;
        private TextBox CryptoTextbox;
        private Label label8;
        private TextBox CanaryTextbox;
        private Label label9;
        private TextBox BaseAddrTextbox;
        private Label label10;
        private TextBox FdTextbox;
        private Label label11;
        private TextBox PicTextbox;
        private Label label12;
        private TextBox BitsTextbox;
        private Label label13;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label label1;
        private TextBox Sha1Textbox;
        private TextBox Sha256Textbox;
        private TextBox Md5Textbox;
        private Label label15;
        private Label label14;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label SearchStringLabel;
        private TextBox SearchStringTextbox;
    }
}