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
    public partial class Diagram : Form
    {
        public Diagram(String patient_id)
        {
            InitializeComponent();
            teeths = new Teeth[] { teeth1, teeth2, teeth3, teeth4, teeth5, teeth6, teeth7, teeth8, teeth9, teeth10, teeth11, teeth12, teeth13, teeth14, teeth15, teeth16, teeth17, teeth18, teeth19, teeth20, teeth21, teeth22, teeth23, teeth24, teeth25, teeth26, teeth27, teeth28, teeth29, teeth30, teeth31, teeth32, teeth33, teeth34, teeth35, teeth36, teeth37, teeth38, teeth39, teeth40, teeth41, teeth42, teeth43, teeth44, teeth45, teeth46, teeth47, teeth48, teeth49, teeth50, teeth51, teeth52, teeth53, teeth54, teeth55, teeth56};
            List<DataRow> teeth_infos = DatabaseHandler.getInstance().getListRow(String.Format(Queries.select_teeth_info_based_patient_id, patient_id));
                       

            /////////////////unoptimized
            if (!Utils.isObjectNull(teeth_infos))
            {
                for (int a = 0; a < teeth_infos.Count; a++)
                {
                    for (int b = 0; b < teeths.Length; b++)
                    {
                        if (teeth_infos[a]["number"].ToString() == teeths[b].Number)
                        {
                            teeths[b].ID = (int)teeth_infos[a]["id"];
                            teeths[b].IsPermanent = (bool)teeth_infos[a]["is_permanent"];
                            teeths[b].Part = teeth_infos[a]["part"].ToString();
                            teeths[b].Area = teeth_infos[a]["area"].ToString();
                            List<DataRow> teeth_diagram_infos = DatabaseHandler.getInstance().getListRow(String.Format(Queries.select_teeth_diagram_info_path_based_teeth_id_and_is_activated, teeths[b].ID));
                            if (!Utils.isObjectNull(teeth_diagram_infos))
                            {
                                for (int d = 0; d < teeth_diagram_infos.Count; d++)
                                {
                                    String path = teeth_diagram_infos[d]["color"].ToString();
                                    path = "Assets\\" + path + "\\" + path + teeth_diagram_infos[d]["diagram"].ToString() + ".png";
                                    teeths[b].Images.Add(Utils.loadImageFromFileRelativeToCWD(path));
                                    teeths[b].Colors.Add(Utils.strToColor(path));
                                    teeths[b].Indexes.Add(Utils.toInt(teeth_diagram_infos[d]["diagram"].ToString()) - 1);
                                }
                                teeths[b].Refresh();
                            }
                            break;
                        }
                    }
                }
            }



            for (int a = 0; a < teeths.Length; a++)
            {
                teeths[a].setClickHandler(clickHandler);
            }
            patientID = patient_id;
        }
        

        String patientID;
        void clickHandler(object sender, EventArgs e)
        {
            Teeth clickedTeeth = (Teeth)sender;
            TeethModifier modifier = new TeethModifier(clickedTeeth, patientID);
            modifier.ShowDialog();
            if (modifier.isModified())
            {
                modifier.getTeeth().copyTo(clickedTeeth);
            }
        }

        Teeth[] teeths;
        private void Diagram_Load(object sender, EventArgs e)
        {
        }

        private void teeth18_Load(object sender, EventArgs e)
        {

        }

        private void teeth37_Load(object sender, EventArgs e)
        {

        }
    }
}
