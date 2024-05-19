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
            toolStripSeparator = new ToolStripSeparator();
            toolStripSeparator2 = new ToolStripSeparator();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripSeparator3 = new ToolStripSeparator();
            toolStripSeparator4 = new ToolStripSeparator();
            toolStripSeparator5 = new ToolStripSeparator();
            toolStripSeparator6 = new ToolStripSeparator();
            encodingToolStripComboBox = new ToolStripComboBox();
            statusStrip = new StatusStrip();
            toolStripStatusLabel = new ToolStripStatusLabel();
            fileSizeToolStripStatusLabel = new ToolStripStatusLabel();
            bitToolStripStatusLabel = new ToolStripStatusLabel();
            openFileDialog = new OpenFileDialog();
            bodyPanel = new Panel();
            statusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // toolStripSeparator
            // 
            toolStripSeparator.Name = "toolStripSeparator";
            toolStripSeparator.Size = new Size(6, 6);
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 6);
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 6);
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(6, 6);
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(6, 6);
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new Size(6, 6);
            // 
            // toolStripSeparator6
            // 
            toolStripSeparator6.Name = "toolStripSeparator6";
            toolStripSeparator6.Size = new Size(6, 6);
            // 
            // encodingToolStripComboBox
            // 
            encodingToolStripComboBox.BackColor = SystemColors.Control;
            encodingToolStripComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            encodingToolStripComboBox.DropDownWidth = 180;
            encodingToolStripComboBox.Name = "encodingToolStripComboBox";
            encodingToolStripComboBox.Size = new Size(121, 23);
            encodingToolStripComboBox.SelectedIndexChanged += toolStripEncoding_SelectedIndexChanged;
            // 
            // statusStrip
            // 
            statusStrip.BackColor = SystemColors.Control;
            statusStrip.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel, fileSizeToolStripStatusLabel, bitToolStripStatusLabel });
            statusStrip.Location = new Point(0, 239);
            statusStrip.Name = "statusStrip";
            statusStrip.RenderMode = ToolStripRenderMode.ManagerRenderMode;
            statusStrip.Size = new Size(284, 22);
            statusStrip.SizingGrip = false;
            statusStrip.TabIndex = 1;
            // 
            // toolStripStatusLabel
            // 
            toolStripStatusLabel.Margin = new Padding(5, 3, 0, 2);
            toolStripStatusLabel.Name = "toolStripStatusLabel";
            toolStripStatusLabel.Padding = new Padding(7, 0, 0, 0);
            toolStripStatusLabel.Size = new Size(7, 17);
            // 
            // fileSizeToolStripStatusLabel
            // 
            fileSizeToolStripStatusLabel.Name = "fileSizeToolStripStatusLabel";
            fileSizeToolStripStatusLabel.Padding = new Padding(4, 0, 4, 0);
            fileSizeToolStripStatusLabel.Size = new Size(8, 17);
            // 
            // bitToolStripStatusLabel
            // 
            bitToolStripStatusLabel.Name = "bitToolStripStatusLabel";
            bitToolStripStatusLabel.Size = new Size(0, 17);
            // 
            // bodyPanel
            // 
            bodyPanel.Location = new Point(0, 0);
            bodyPanel.Name = "bodyPanel";
            bodyPanel.Size = new Size(200, 100);
            bodyPanel.TabIndex = 0;
            // 
            // HexDump
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = SystemColors.Control;
            ClientSize = new Size(284, 261);
            Controls.Add(bodyPanel);
            Controls.Add(statusStrip);
            Name = "HexDump";
            FormClosing += FormHexEditor_FormClosing;
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem findToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton openToolStripButton;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton cutToolStripButton;
        private System.Windows.Forms.StatusStrip statusStrip;
        
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripStatusLabel fileSizeToolStripStatusLabel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem copyHexStringToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteHexToolStripMenuItem;
        private System.Windows.Forms.ToolStripSplitButton copyToolStripSplitButton;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem copyHexToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSplitButton pasteToolStripSplitButton;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem pasteHexToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel bitToolStripStatusLabel;
        private System.Windows.Forms.ToolStripComboBox encodingToolStripComboBox;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem encodingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bitsToolStripMenuItem;
        //private BitControl bitControl1;
        private System.Windows.Forms.Panel bodyPanel;
    }
}