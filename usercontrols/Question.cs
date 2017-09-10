using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DentalRecordApplication
{
    public partial class Question : UserControl
    {
        public Question()
        {
            InitializeComponent();
        }


       [Description("Put your question here for patient"), Category("Data")] 
        public string Question_
        {
            get { return q.Text; }
            set { q.Text = value; }
        }

       public bool Answer
       {
           get { if (yes.Checked) return true; return false; }
           set { if (value) yes.Checked = true; else No.Checked = true; }
       }

    

       private void Question_Load(object sender, EventArgs e)
       {

       }
    }
}
