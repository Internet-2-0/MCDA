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
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {

        } 

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Hide();
            MonitoringForm monitoringForm = new MonitoringForm();
            monitoringForm.Show(this);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Hide();
            MonitoringForm monitoringForm = new MonitoringForm();
            monitoringForm.Show(this);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.Show(this);
        }
    }
}
