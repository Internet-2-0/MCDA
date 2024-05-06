namespace MCDA_APP.Controls
{
    public partial class IconTextBox : UserControl
    {
        private PictureBox pictureBox;
        private TextBox textBox;

        public IconTextBox()
        {
            InitializeComponent();

            pictureBox = new PictureBox();
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.Image = Properties.Resources.paper_clip;
            pictureBox.Size = new Size(24, 24);
            pictureBox.Location = new Point(8, 8); 
            pictureBox.BackColor = Color.FromArgb(40, 47, 53);
            Controls.Add(pictureBox);

            textBox = new TextBox();
            textBox.Location = new Point(40, 8);
            textBox.Size = new Size(240, 24);
            textBox.BorderStyle = BorderStyle.None;
            textBox.BackColor = Color.FromArgb(40, 47, 53);
            textBox.ForeColor = Color.FromArgb(150, 160, 170);
            textBox.Padding = new Padding(10, 7, 10, 7);
            textBox.Font = new Font("Segoe UI", 12);
            textBox.Enabled = false;

            Controls.Add(textBox);

            Size = new Size(100, 40);
            BackColor = Color.FromArgb(40, 47, 53);

            //textBox.AllowDrop = true;
            //this.DragEnter += IconTextBox_DragEnter;
            //this.DragDrop += IconTextBox_DragDrop;
        }

        private void IconTextBox_DragEnter(object? sender, DragEventArgs e)
        {
            if (e.Data!.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void IconTextBox_DragDrop(object? sender, DragEventArgs e)
        {
            if (e.Data!.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (files.Length > 0)
                {
                    textBox.Text = files[0];
                }
            }
        }

        //public Image Icon
        //{
        //    get { return pictureBox.Image; }
        //    set { pictureBox.Image = value; }
        //}

        public override Color ForeColor
        {
            get { return base.ForeColor; }
            set
            {
                base.ForeColor = value;
                textBox.ForeColor = value;
            }
        }

        public string TextBoxText
        {
            get { return textBox.Text; }
            set 
            {
                base.Text = value;
                textBox.Text = value; 
            }
        }

        public float TextBoxFontSize
        {
            get { return textBox.Font.Size; }
            set { textBox.Font = new Font(textBox.Font.FontFamily, value); }
        }

        public void SetSize(Size size)
        {
            pictureBox.Size = size;
        }


    }
}
