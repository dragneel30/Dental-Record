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
    public partial class Graph : Form
    {
        public Graph()
        {
            InitializeComponent();

            bargraph2.ChartAreas[0].AxisY.Maximum = 100;
            bargraph1.ChartAreas[0].AxisX.LabelStyle.Interval = 1;
            bargraph2.ChartAreas[0].AxisX.LabelStyle.Interval = 1;
            List<String> tasks = DatabaseHandler.getInstance().getListStringSingleData(Queries.select_task_info_code);

            DataTable teeth_task_info = DatabaseHandler.getInstance().getTable(Queries.select_teeth_task_info);
            if (!Utils.isObjectNull(teeth_task_info))
            {
                for (int a = 0; a < tasks.Count; a++)
                {
                    string task = tasks[a];
                    bargraph1.Series[0].Points.AddXY(task, DatabaseHandler.getInstance().getDoubleData(String.Format(Queries.select_total_teeth_task_info_based_task_code, task)));
                    bargraph2.Series[0].Points.AddXY(task, DatabaseHandler.getInstance().getDoubleData(String.Format(Queries.select_percentage_teeth_task_info_based_task_code, task)));
                }
            }
        }

        private void Graph_Load(object sender, EventArgs e)
        {

        }
    }
}
