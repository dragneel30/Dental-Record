using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;


namespace DentalRecordApplication
{
    public partial class TeethModifier : Form
    {
        public Teeth getTeeth()
        {
            return patientTeeth;
        }
        public void teethClick(object sender, EventArgs e)
        {
            PictureBox pic = (PictureBox)sender;
            if (!patientTeeth.Images.Exists(delegate(Image image) { return pic.Image == image; }))
            {
                patientTeeth.Colors.Add(selectedColor);
                patientTeeth.Images.Add(pic.Image);
                patientTeeth.Indexes.Add(teeths.ToList().IndexOf(pic));
            }
            else
            {
                int index = patientTeeth.Images.IndexOf(pic.Image);
                patientTeeth.Images.Remove(pic.Image);
                patientTeeth.Colors.RemoveAt(index);
                patientTeeth.Indexes.RemoveAt(teeths.ToList().IndexOf(pic));
            }
            patientTeeth.Refresh();

        }
        public TeethModifier(Teeth teeth, String iPatient_id)
        {
            InitializeComponent();
            modified = false;
            teeths = new PictureBox[] { teeth1, teeth2, teeth3, teeth4, teeth5, teeth6, teeth7, teeth8, teeth9, teeth0 };
            for (int a = 0; a < teeths.Length; a++)
            {
                teeths[a].Click += new EventHandler(teethClick);
            }
            controls = new Control[] { lblToothNumber, lblPart , cmbLabel, lblArea };
            taskControls = new Control[] { cmbTask, txtCost, txtNotes };
    
            teeth.copyTo(patientTeeth);

            lblToothNumber.Text = teeth.Number;
            patient_id = iPatient_id;
            id = DatabaseHandler.getInstance().getIntData(String.Format(Queries.select_teeth_info_id_based_patient_id_and_number, iPatient_id, teeth.Number));
            teethTaskInfoList.fill(DatabaseHandler.getInstance().getTable(String.Format(Queries.select_teeth_task_info_based_teeth_id, id)));

            List<DataRow> rows = DatabaseHandler.getInstance().getListRow(Queries.select_task_info);
            if (!Utils.isObjectNull(rows))
            {
                for (int a = 0; a < rows.Count; a++)
                {
                    cmbTask.Items.Add(rows[a]["code"].ToString() + ":" + rows[a]["name"].ToString());
                }
            }
            teethTaskInfoList.setEditorHandler(new EventHandler(editor_lostFocus));
            teethTaskInfoList.setSelectedIndexChanged(new EventHandler(list_SelectedIndexChanged));
            teethTaskInfoList.setViewItemDeleted(new EventHandler(list_itemDeleted));
            cmbLabel.SelectedIndex = teeth.IsPermanent == true ? 0 : 1;

        }
        public void editor_lostFocus(object sender, EventArgs e)
        {
            CustomListview.EditedCell editedCell = teethTaskInfoList.getEditedCell();
            if (!DatabaseHandler.getInstance().modifyTable(String.Format(Queries.update_teeth_task_info_single_data_based_id, editedCell.columnName, editedCell.newVal, editedCell.id)))
            {
                MessageBox.Show("Editing failed.....");
            }
        }
        public void list_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        public void list_itemDeleted(object sender, EventArgs e)
        {
            if (!DatabaseHandler.getInstance().modifyTable(String.Format(Queries.delete_teeth_task_info_based_id, teethTaskInfoList.getDeletedId())))
            {
                MessageBox.Show("Couldnt delete....");

            }
        }
        
        int id;
        PictureBox[] teeths;
        Control[] taskControls;
        Control[] controls;

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            changeColor("black");
            selectedColor = Color.Black;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            changeColor("blue");
            selectedColor = Color.Blue;

        }

        private void TeethModifier_Load(object sender, EventArgs e)
        {
            changeColor("red");
            selectedColor = Color.Red;
        }

        void changeColor(string color)
        {
            for (int a = 0; a < teeths.Length; a++)
            {
                teeths[a].ImageLocation = Utils.toCWD("Assets\\" + color + "\\" + color + Convert.ToString(a + 1) + ".png");
                teeths[a].BackColor = selectedColor;
                
            }


             
        }
        bool modified;

        Color selectedColor;
        public bool isModified()
        {
            return modified;
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            changeColor("red");
            selectedColor = Color.Red;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            bool is_permanent = cmbLabel.SelectedIndex == 0 ? true : false;
            if (!DatabaseHandler.getInstance().modifyTable(String.Format(Queries.update_teeth_info_is_permanent_based_id, is_permanent, id)))
            {
                MessageBox.Show("failed...");
            }
            else
            {
                patientTeeth.IsPermanent = is_permanent;
                modified = true;
            }

            DatabaseHandler.getInstance().modifyTable(String.Format(Queries.update_teeth_diagram_info_turn_off_based_teeth_id, id));
            for ( int a = 0; a < patientTeeth.Images.Count; a++ )
            {
                  if (!DatabaseHandler.getInstance().modifyTable(String.Format(Queries.update_teeth_diagram_info_is_activated_based_teeth_id_and_number, 
                      Utils.colorToStr(patientTeeth.Colors[a]), true, patientTeeth.ID, patientTeeth.Number, patientTeeth.Indexes[a] + 1)))
                  {
                       MessageBox.Show("cant update teeth");
                  }
                  else
                  {
                       modified = true;
                  }
            }
                
        }

        string patient_id;

        private void button3_Click(object sender, EventArgs e)
        {
            if (!Utils.isEmpty(cmbTask.Text))
            {
                if (!DatabaseHandler.getInstance().modifyTable(String.Format(Queries.insert_teeth_task_info, id, cmbTask.Text.Split(':')[0], txtCost.Text, txtNotes.Text)))
                {
                }
            }
            else
            {
                MessageBox.Show("Choose a task first");
            }
        }

        private void cmbTask_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!Utils.isEmpty(cmbTask.Text))
            {
                String[] split = cmbTask.Text.Split(':');
                double cost = DatabaseHandler.getInstance().getDoubleData(String.Format(Queries.select_task_info_cost_based_code_and_name, split[0], split[1]));
                txtCost.Text = Convert.ToString(cost);
            }
        }

        private void txtCost_TextChanged(object sender, EventArgs e)
        {
            Utils.limitedNumberInputOnly(sender, 10000);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void teeth6_Click(object sender, EventArgs e)
        {

        }

        private void teethTaskInfoList_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            patientTeeth.Images.Clear();
            patientTeeth.Colors.Clear();
            patientTeeth.Indexes.Clear();
            patientTeeth.Refresh();
        }
    }
}
