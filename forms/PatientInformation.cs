using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DentalRecordApplication.UserControls;
namespace DentalRecordApplication
{
    public partial class PatientInformation : Form
    {
        public PatientInformation()
        {
            InitializeComponent();


            editor = new TextBox();
                
            editor.BorderStyle = BorderStyle.None;
            patientInfoList.setEditorHandler(new EventHandler(editor_lostFocus));
            patientInfoList.setSelectedIndexChanged(new EventHandler(records_SelectedIndexChanged));
            patientInfoList.setViewItemDeleted(new EventHandler(records_itemDeleted));
            patientInfoList.setItemDoubleClicked(new MouseEventHandler(records_itemDoubleClicked));
            questions = new Question[] { question1, question2, question3, question4, question5, question6 };
            controls = new Control[] { txtfname, txtmi, txtlname, txtadd, txtoccupation, txtcontact, txtage, cmbstatus, cmbGender, txtcomplain };
            diseases = new Disease[] { disease1, disease2, disease3, disease4, disease5, disease6, disease7, disease8, disease9, disease10, disease11, disease12 };
            allControl = new Control[] { diseaseList, question1, question2, question3, question4, question5, question6, question7, txtfname, txtmi, txtlname, txtadd, txtoccupation, txtcontact, txtage, cmbstatus, cmbGender, txtcomplain, disease1, disease2, disease3, disease4, disease5, disease6, disease7, disease8, disease9, disease10, disease11, disease12, button1 };
        }

        void records_itemDoubleClicked(object sender, MouseEventArgs e)
        {
            ListView view = (ListView)sender;
            if (view.SelectedItems.Count > 0)
            {
                ListViewItem clickedItem = view.SelectedItems[0];
                Diagram diagram = new Diagram(clickedItem.SubItems[0].Text);
                diagram.ShowDialog();
            }
        }

        void records_itemDeleted(object sender, EventArgs e)
        {
            int id = patientInfoList.getDeletedId();
            if (!deleteRecord(Queries.delete_patient_info_based_id,  id))
            {
                MessageBox.Show("Couldnt delete patient....");
            }
            List<String> teeth_ids = DatabaseHandler.getInstance().getListStringSingleData(String.Format(Queries.select_teeth_info_id_based_patient_id, id));
           
            if (!Utils.isObjectNull(teeth_ids))
            {
                for (int a = 0; a < teeth_ids.Count; a++)
                {
                    String teeth_id = teeth_ids[a];
                    if (!deleteRecord(Queries.delete_teeth_task_info_based_teeth_id, Utils.toInt(teeth_id)))
                    {
                       // MessageBox.Show("couldnt delete teeth tasks");
                    }
                    else
                    {
                       // MessageBox.Show(String.Format(Queries.delete_teeth_task_info_based_teeth_id, Utils.toInt(teeth_id)));
                    }
                    if (!deleteRecord(Queries.delete_teeth_diagram_info_based_teeth_id, Utils.toInt(teeth_id)))
                    {
                      //  MessageBox.Show("couldnt delete teeth diagram");
                    }

                }
            }
            else
            {
                //MessageBox.Show("null");
            }

            List<String> teeth_task_info_teeth_ids = DatabaseHandler.getInstance().getListStringSingleData(String.Format(Queries.select_teeth_task_info_teeth_id));

            for (int a = 0; a < teeth_task_info_teeth_ids.Count; a++)
            {
                
            }

            if (!deleteRecord(Queries.delete_teeth_info_based_patient_id, id)) 
            {
               // MessageBox.Show("couldnt delete teeths");
            }
            if (!deleteRecord(Queries.delete_question_info_based_patient_id, id))
            {
             //5  MessageBox.Show("couldnt delete question infos");
            }
            if (!deleteRecord(Queries.delete_history_info_based_patient_id, id))
            {
              //  MessageBox.Show("couldnt delete history infos");
            }
        }
        bool deleteRecord(String query, int id)
        {
            return DatabaseHandler.getInstance().modifyTable(String.Format(query, id));
        }
        Control[] allControl;
        Control[] controls;
        Question[] questions;
        Disease[] diseases;
        

        void editor_lostFocus(object sender, EventArgs e)
        {
            CustomListview.EditedCell editedCell = patientInfoList.getEditedCell();
            if (!DatabaseHandler.getInstance().modifyTable(String.Format(Queries.update_patient_info_single_data, editedCell.columnName, editedCell.newVal, editedCell.id)))
            {
                MessageBox.Show("Editing failed.....");
            }
        }

        public ListBox getDiseaseList()
        {
            return diseaseList;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void txtage_TextChanged(object sender, EventArgs e)
        {
            Utils.limitedNumberInputOnly(sender, 2);
        }

    

        private void txtage_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            
        }

        private void txtcontact_TextChanged(object sender, EventArgs e)
        {
            Utils.limitedNumberInputOnly(sender, 12);
        }

        private void patientInfoList_Load(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void cmbGender_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtid_TextChanged(object sender, EventArgs e)
        {
        }

        private void patientInfoList_Load_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int a = 0; a < controls.Length; a++)
            {
                controls[a].ResetText();
            }
            for (int a = 0; a < questions.Length; a++)
            {
                questions[a].Answer = false;
            }
            cmbstatus.SelectedIndex = -1;
            cmbGender.SelectedIndex = -1;

            for (int a = 0; a < diseases.Length; a++)
            {
                diseases[a].Check = false;
            }
            diseaseList.Items.Clear();
        }

        private void menuItem4_Click(object sender, EventArgs e)
        {
            Utils.toggleDisabilityControl(allControl);
            menuAdd.Enabled = !menuAdd.Enabled;
            menuReset.Enabled = !menuReset.Enabled;
        }

        private void menuItem5_Click(object sender, EventArgs e)
        {
            if (Utils.isFilledUp(controls))
            {
                if (!DatabaseHandler.getInstance().modifyTable(String.Format(Queries.insert_patient_info, txtfname.Text, txtmi.Text, txtlname.Text, txtadd.Text,
                    txtoccupation.Text, txtcontact.Text, txtage.Text, cmbstatus.Text, cmbGender.Text, txtcomplain.Text)))
                {
                    MessageBox.Show("wasnt able to insert rolling back......");
                    return;
                }
                int id = DatabaseHandler.getInstance().getIntData(Queries.select_patient_info_id_latest);

                for (int a = 0; a < diseaseList.Items.Count; a++)
                {
                    if (!DatabaseHandler.getInstance().modifyTable(String.Format(Queries.insert_history_info, id, diseaseList.Items[a])))
                    {
                        MessageBox.Show("wasnt able to insert rolling back......");
                        break;
                    }
                }
                for (int a = 0; a < questions.Length; a++)
                {
                    if (!DatabaseHandler.getInstance().modifyTable(String.Format(Queries.insert_question_info, id, questions[a].Question_, questions[a].Answer)))
                    {
                        MessageBox.Show("wasnt able to insert rolling back......");
                        break;
                    }
                }
                registerTeeths(id, 11, 18, true);
                registerTeeths(id, 21, 28, true);
                registerTeeths(id, 31, 38, true);
                registerTeeths(id, 41, 48, true);
                registerTeeths(id, 51, 56, false);
                registerTeeths(id, 61, 66, false);
                registerTeeths(id, 81, 86, false);
                registerTeeths(id, 71, 76, false);

                patientInfoList.fill(DatabaseHandler.getInstance().getTable(Queries.select_patient_info));



            }
            else
            {
                MessageBox.Show("Please fill up all the textboxes!");
            }
        }
        private void registerTeeths(int patient_id, int start, int end, bool is_permanent)
        {
            end = end + 1;

            for (int a = start; a < end; a++)
            {
                String number = Convert.ToString(a);
                if (!DatabaseHandler.getInstance().modifyTable(String.Format(Queries.insert_teeth_info, patient_id, number, "PART_dummy", is_permanent, "AREA_dummy")))
                {
                    MessageBox.Show("teeth wont register");
                }
                int id = DatabaseHandler.getInstance().getIntData(String.Format(Queries.select_teeth_info_id_based_patient_id_and_number, patient_id, number));
                for (int b = 0; b < 10; b++)
                {
                    if (!DatabaseHandler.getInstance().modifyTable(String.Format(Queries.insert_teeth_diagram_info, b + 1, number, id)))
                    {
                        MessageBox.Show("diagram wont register");
                    }
                }
            }
        }
        private void PatientInformation_Load(object sender, EventArgs e)
        {
            patientInfoList.fill(DatabaseHandler.getInstance().getTable(Queries.select_patient_info));
        }

        private void key_TextChanged(object sender, EventArgs e)
        {
            DataTable table = DatabaseHandler.getInstance().getTable(String.Format(Queries.select_patient_info));
            int length = key.Text.Length;
            for (int a = 0; a < table.Rows.Count; a++)
            {
                DataRow currRow = table.Rows[a];
                string lastname = currRow["lastname"].ToString();
                if (lastname.Length >= length)
                {
                    if (key.Text != currRow["lastname"].ToString().Substring(0, length))
                    {
                        table.Rows.Remove(currRow);
                        a--;
                    }
                }
                else
                {
                    table.Rows.Remove(currRow);
                    a--;
                }

            }
            patientInfoList.fill(table);
        }



        TextBox editor;
        private void records_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView records = (ListView)sender;
            if (records.SelectedItems.Count > 0)
            {
                button1.Enabled = true;
                diseaseList.Items.Clear();
                ListViewItem item = records.SelectedItems[0];

                for (int a = 1; a < item.SubItems.Count; a++)
                {
                    controls[a - 1].Text = item.SubItems[a].Text;
                }
                DataTable question = DatabaseHandler.getInstance().getTable(String.Format(Queries.select_question_info_answer_based_patient_id, item.SubItems[0].Text));
                if (!Utils.isObjectNull(question))
                {
                    for (int a = 0; a < 6; a++)
                    {
                        questions[a].Answer = (bool)question.Rows[a][0];
                    }
                }
                DataTable history = DatabaseHandler.getInstance().getTable(String.Format(Queries.select_history_info_disease_based_id, item.SubItems[0].Text));

                if (!Utils.isObjectNull(history))
                {
                    for (int a = 0; a < history.Rows.Count; a++)
                    {
                        for (int b = 0; b < diseases.Length; b++)
                        {
                            diseases[b].Check = false;
                            if (diseases[b].Type == history.Rows[a][0].ToString())
                            {
                                diseases[b].Check = true;
                                break;
                            }
                        }
                    }
                }
            }
            else
            {
                button1.Enabled = false;
            }
        }

        private void menuItem6_Click(object sender, EventArgs e)
        {
            for (int a = 0; a < controls.Length; a++)
            {
                controls[a].ResetText();
            }
            for (int a = 0; a < questions.Length; a++)
            {
                questions[a].Answer = false;
            }
            cmbstatus.SelectedIndex = -1;
            cmbGender.SelectedIndex = -1;

            for (int a = 0; a < diseases.Length; a++)
            {
                diseases[a].Check = false;
            }
            diseaseList.Items.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id = patientInfoList.SelectedID;
            for (int a = 0; a < questions.Length; a++)
            {
                if (!DatabaseHandler.getInstance().modifyTable(String.Format(Queries.update_question_info_answer_based_patient_id_and_question, questions[a].Answer, id, questions[a].Question_)))
                {
                }
            }
            DatabaseHandler.getInstance().modifyTable(String.Format(Queries.delete_history_info_based_patient_id, id));
            for (int a = 0; a < diseaseList.Items.Count; a++)
            {
                if (!DatabaseHandler.getInstance().modifyTable(String.Format(Queries.insert_history_info, id, diseaseList.Items[a].ToString())))
                {
                }
            }
        }

     
    }
}
