using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DentalRecordApplication.UserControls
{
    public partial class Disease : UserControl
    {
        public Disease()
        {
            InitializeComponent();
        }

        private void checkbox_CheckedChanged(object sender, EventArgs e)
        {
            Control parent = this.Parent;
            while (parent.Parent != null)
            {
                parent = parent.Parent;
            }
            if (checkbox.Checked)
            {
                ((PatientInformation)parent).getDiseaseList().Items.Add(checkbox.Text);
            }
            else
            {
                ((PatientInformation)parent).getDiseaseList().Items.Remove(checkbox.Text);
            }
        }


        [Description("Disease type"), Category("Data")]
        public string Type
        {
            get { return checkbox.Text; }
            set { checkbox.Text = value; }
        }
        public bool Check
        {
            get { return checkbox.Checked; }
            set { checkbox.Checked = value; }
        }

        private void Disease_Load(object sender, EventArgs e)
        {

        }
    }
}
