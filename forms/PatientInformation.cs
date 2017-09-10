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
            controls = new Control[] { txtid, txtfname, txtmi, txtlname, txtadd, txtoccupation, txtcontact, txtage, cmbstatus, cmbGender, txtcomplain };
            diseases = new Disease[] { disease1, disease2, disease3, disease4, disease5, disease6, disease7, disease8, disease9, disease10, disease11, disease12 };
            allControl = new Control[] { diseaseList, question1, question2, question3, question4, question5, question6, question7, txtid, txtfname, txtmi, txtlname, txtadd, txtoccupation, txtcontact, txtage, cmbstatus, cmbGender, txtcomplain, disease1, disease2, disease3, disease4, disease5, disease6, disease7, disease8, disease9, disease10, disease11, disease12 };
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
            if (Utils.isFilledUp(controls))
            {
                if (Utils.isObjectNull(DatabaseHandler.getInstance().getTable(String.Format(Queries.select_patient_info_based_patient_id, txtid.Text))))
                {

                    if (!DatabaseHandler.getInstance().modifyTable(String.Format(Queries.insert_patient_info, txtid.Text, txtfname.Text, txtmi.Text, txtlname.Text, txtadd.Text,
                        txtoccupation.Text, txtcontact.Text, txtage.Text, cmbstatus.Text, cmbGender.Text, txtcomplain.Text)))
                    {
                        MessageBox.Show("wasnt able to insert rolling back......");
                        return;
                    }
                    for (int a = 0; a < diseaseList.Items.Count; a++)
                    {
                        if (!DatabaseHandler.getInstance().modifyTable(String.Format(Queries.insert_history_info, txtid.Text, diseaseList.Items[a])))
                        {
                            MessageBox.Show("wasnt able to insert rolling back......");
                            break;
                        }
                    }
                    for (int a = 0; a < questions.Length; a++)
                    {
                        if (!DatabaseHandler.getInstance().modifyTable(String.Format(Queries.insert_question_info, txtid.Text, questions[a].Question_, questions[a].Answer)))
                        {
                            MessageBox.Show("wasnt able to insert rolling back......");
                            break;
                        }
                    }
                    registerTeeths(11, 18);
                    registerTeeths(21, 28);
                    registerTeeths(31, 38);
                    registerTeeths(41, 48);
                    registerTeeths(51, 56);
                    registerTeeths(61, 66);
                    registerTeeths(81, 86);
                    registerTeeths(71, 76);

                    patientInfoList.fill(DatabaseHandler.getInstance().getTable(Queries.select_patient_info));


                }
                else
                {
                    MessageBox.Show(txtid.Text + " already exist");
                }
            }
            else
            {
                MessageBox.Show("Please fill up all the textboxes!");
            }
        }
        private void registerTeeths(int start, int end)
        {
            end = end + 1;

            for (int a = start; a < end; a++)
            {
                String number = Convert.ToString(a);
                if (!DatabaseHandler.getInstance().modifyTable(String.Format(Queries.insert_teeth_info, txtid.Text, number, "canine", '1', "test area")))
                {
                    MessageBox.Show("teeth wont register");
                }
                int id = DatabaseHandler.getInstance().getIntData(String.Format(Queries.select_teeth_info_id_based_patient_id_and_number, txtid.Text, number));
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
            patientInfoList.fillRow(DatabaseHandler.getInstance().getTable(String.Format(Queries.select_patient_info_based_lastname, key.Text)));
        }

        private void menuItem3_Click(object sender, EventArgs e)
        {
            Utils.toggleDisabilityControl(allControl);
        }


        TextBox editor;
        private void records_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView records = (ListView)sender;
            if (records.SelectedItems.Count > 0)
            {

                ListViewItem item = records.SelectedItems[0];
                
                for (int a = 0; a < item.SubItems.Count; a++)
                {
                    controls[a].Text = item.SubItems[a].Text;
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
                            diseases[b].Check = diseases[b].Type == history.Rows[a][0].ToString();
                        }
                    }
                }
            }
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

     
    }
}
