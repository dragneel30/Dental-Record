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
    public partial class FrequentPattern : Form
    {
        public FrequentPattern()
        {
            InitializeComponent();
        }

        private void FrequentPattern_Load(object sender, EventArgs e)
        {
            for (int a = 1; a <= 100; a++)
                cmbSupport.Items.Add(a.ToString());
            cmbSupport.SelectedIndex = 0;

        }


        void reScan()
        {
            analysis.TabPages.Clear();
            List<DataRow> rows = DatabaseHandler.getInstance().getListRow(Queries.select_teeth_task_info_task_code_and_teeth_id);
            DataTable table = new DataTable();
            table.Columns.Add("PATIENT ID");
            table.Columns.Add("ITEM");
            if (!Utils.isObjectNull(rows))
            {
                for (int a = 0; a < rows.Count; a++)
                {
                    DataRow row = rows[a];
                    bool found = false;
                    String id = DatabaseHandler.getInstance().getStringData(String.Format(Queries.select_teeth_info_patient_id_based_id, row["teeth_id"]));

                    for (int b = 0; b < table.Rows.Count; b++)
                    {
                        DataRow currRow = table.Rows[b];
                        if (currRow[0].ToString() == id)
                        {
                            currRow[1] = currRow[1] + "," + row["task_code"].ToString();
                            found = true;
                            break;
                        }
                    }
                    if (!found)
                    {
                        table.Rows.Add(id, row["task_code"].ToString());
                    }
                }
            }

            Set<String> rootSet = new Set<String>();
            for (int a = 0; a < table.Rows.Count; a++)
            {
                Item<String> newItem = new Item<String>();
                String[] items = table.Rows[a]["ITEM"].ToString().Split(',');
                for (int b = 0; b < items.Length; b++)
                {
                    newItem.add(new Data<String>(items[b]));
                }
                rootSet.add(newItem);
            }

            Utils.fillRowListView(ref root, table);
            AprioriAlgorithm<String> aa = AprioriAlgorithm<String>.createInstance(rootSet, Utils.toInt(cmbSupport.Items[cmbSupport.SelectedIndex].ToString()));

            Set<String> next = new Set<String>();
            int scanCount = 1;

            while (next != null)
            {
                if ((next = aa.nextScan()) != null)
                {
                    TabPage newPage = new TabPage("Scan " + scanCount);
                    analysis.TabPages.Add(newPage);
                    ScanResultView resultView = new ScanResultView();
                    ListView halfResultView = resultView.View1;
                    Utils.fillListView(ref halfResultView, mapScanResultToTable(next));
                    if ((next = aa.finalizeCurrentScan()) != null)
                    {
                        ListView finalResultView = resultView.View2;
                        Utils.fillListView(ref finalResultView, mapScanResultToTable(next));
                        scanCount++;
                    }
                    resultView.Size = newPage.Size;
                    newPage.Controls.Add(resultView);
                }
            }
        }
        DataTable mapScanResultToTable(Set<String> set)
        {
            DataTable table = new DataTable();
            table.Columns.Add("ITEM");
            table.Columns.Add("SUPPORT");
           
            for (int a = 0; a < set.Items.Count; a++)
            {
                String items = "";
                for (int b = 0; b < set.Items[a].Datas.Count; b++)
                {
                        
                    items += set.Items[a].Datas[b].Internal.ToString();
                    if (b != set.Items[a].Datas.Count - 1)
                        items += ",";
                }
                table.Rows.Add(items, set.Items[a].Support);
            }
            return table;
        }


        private void fontDialog1_Apply(object sender, EventArgs e)
        {

        }

        private void cmbSupport_SelectedIndexChanged(object sender, EventArgs e)
        {
            reScan();
        }
    }
}
