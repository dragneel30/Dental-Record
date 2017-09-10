using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Collections;
using Newtonsoft.Json;
namespace DentalRecordApplication
{
   
    public partial class BackupClient : Form
    {
        public BackupClient()
        {
           
            InitializeComponent();
        }

        private void BackupClient_Load(object sender, EventArgs e)
        {
            List<DataRow> databases = DatabaseHandler.getInstance().getListRow(Queries.select_database);
      
            for (int a = 0; a < databases.Count; a++)
            {
                cmbDatabase.Items.Add(databases[a][0].ToString());
            }
            
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (!Utils.isEmpty(cmbDatabase.Text))
            {
                if (Directory.Exists(txtDestination.Text.Substring(0, txtDestination.Text.LastIndexOf("\\") + 1)))
                {
                    DatabaseCredential dbCred = ServerConnector.getInstance().getDatabaseCredential();
                    String json = File.ReadAllText(Queries.mysqldump_path_conf_file);
                    MysqldumpPath path = JsonConvert.DeserializeObject<MysqldumpPath>(json);
                    Process backupProcess = Process.Start("cmd.exe", "/C " + String.Format(Queries.backup_database, path.path, dbCred.username, dbCred.password, cmbDatabase.Text, txtDestination.Text)); 
                    
                }
                else
                {
                    MessageBox.Show("Please select a valid destination");
                }
            }
            else
            {
                MessageBox.Show("Select a database first");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                txtDestination.Text = folderBrowser.SelectedPath + "\\";
                if (!Utils.isEmpty(cmbDatabase.Text))
                {
                    txtDestination.Text += cmbDatabase.Text + ".sql";
                }
            }
        }

        private void cmbDatabase_SelectedIndexChanged(object sender, EventArgs e)
        {
            String destination = txtDestination.Text;
            if (!Utils.isEmpty(destination))
            {
                destination = destination.Substring(0, destination.LastIndexOf("\\") + 1) + cmbDatabase.Text + ".sql";
                txtDestination.Text = destination;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtSource.Text = openFileDialog.FileName;
                txtSource.SelectionStart = txtSource.Text.Length - 1;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
        }
    }
    class MysqldumpPath
    {
        public MysqldumpPath()
        {
            path = "";
        }
        public String path;
    }
}
