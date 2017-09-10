using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DentalRecordApplication
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPersonal_Information_Click(object sender, EventArgs e)
        {
            Utils.hideAndShow(this, new PatientInformation());
        }

        private void btndiagnosis_Click(object sender, EventArgs e)
        {
            Utils.hideAndShow(this, new PatientDiagnosis());
        }

        private void btnreports_Click(object sender, EventArgs e)
        {
            Utils.hideAndShow(this, new Graph());
        }

        private void btnstatistical_Click(object sender, EventArgs e)
        {
            Utils.hideAndShow(this, new BackupClient());
        }

        private void btnsettings_Click(object sender, EventArgs e)
        {
            Utils.hideAndShow(this, new FrequentPattern());
        }
    }
}
