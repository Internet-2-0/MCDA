using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCDA_APP.Forms
{
    public partial class HexFormGoTo : Form
    {
        public HexFormGoTo()
        {
            InitializeComponent();
        }

        public void SetDefaultValue(long byteIndex)
        {
            nup.Value = byteIndex + 1;
        }

        public void SetMaxByteIndex(long maxByteIndex)
        {
            nup.Maximum = maxByteIndex + 1;
        }

        public long GetByteIndex()
        {
            return Convert.ToInt64(nup.Value) - 1;
        }

        private void HexFormGoTo_Activated(object sender, EventArgs e)
        {
            nup.Focus();
            nup.Select(0, nup.Value.ToString().Length);
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
