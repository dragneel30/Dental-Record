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
    public partial class ScanResultView : UserControl
    {
        public ScanResultView()
        {
            InitializeComponent();
        }

        private void ScanResultView_Load(object sender, EventArgs e)
        {

        }


        public ListView View1
        {
            get { return view1; }
        }
        public ListView View2
        {
            get { return view2; }
        }
    }
}
