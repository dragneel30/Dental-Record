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
    public partial class PatientDiagnosis : Form
    { 
        public PatientDiagnosis()
        {
            InitializeComponent();
            controls = new Control[]
            {
                txtCode, txtName, txtCost, txtDesc
            };
            taskList.setEditorHandler(new EventHandler(editor_lostFocus));
            taskList.setSelectedIndexChanged(new EventHandler(task_selectedIndexChanged));
            taskList.setViewItemDeleted(new EventHandler(task_itemDeleted));
        }

        private void PatientDiagnosis_Load(object sender, EventArgs e)
        {
           

            taskList.fill(DatabaseHandler.getInstance().getTable(Queries.select_task_info));
        }

        void editor_lostFocus(object sender, EventArgs e)
        {
            CustomListview.EditedCell editedCell = taskList.getEditedCell();

            if (!DatabaseHandler.getInstance().modifyTable(String.Format(Queries.update_task_info_single_data_based_id, editedCell.columnName, editedCell.newVal, editedCell.id)))
            {
                MessageBox.Show("editing failed....");
            }
        }
        void task_selectedIndexChanged(object sender, EventArgs e)
        {
            ListView view = (ListView)sender;
            if (view.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = view.SelectedItems[0];
                for (int a = 0; a < controls.Length; a++)
                {
                    controls[a].Text = selectedItem.SubItems[a].Text;
                }
            }
        }
        void task_itemDeleted(object sender, EventArgs e)
        {
            if (!DatabaseHandler.getInstance().modifyTable(String.Format(Queries.delete_task_info_based_id, taskList.getDeletedId())))
            {
                MessageBox.Show("deletion failed....");
            }
        }
        Control[] controls;
        private void button1_Click(object sender, EventArgs e)
        {

            if (!DatabaseHandler.getInstance().modifyTable(String.Format(Queries.insert_task_info, txtCode.Text, txtName.Text, txtCost.Text, txtDesc.Text)))
            {
                MessageBox.Show("insert failed....");
            }
            else
            {
                taskList.fillRow(DatabaseHandler.getInstance().getTable(Queries.select_task_info));
            }
        }

        private void menuItem4_Click(object sender, EventArgs e)
        {

            Utils.toggleDisabilityControl(controls);
        }

        private void txtCost_TextChanged(object sender, EventArgs e)
        {
            Utils.limitedNumberInputOnly(sender, 10000);
        }
    }
}
