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
            dbCred = ServerConnector.getInstance().getDatabaseCredential();
        }
        DatabaseCredential dbCred;
        private void BackupClient_Load(object sender, EventArgs e)
        {
            txtDestination.Text = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\";
            
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string mysqldump_path = DatabaseHandler.getInstance().getStringData(String.Format(Queries.select_mysql_base_dir_bin, "mysqldump.exe"));
            MessageBox.Show(String.Format(Queries.backup_database, mysqldump_path, dbCred.username, dbCred.password, dbCred.database, "\"" + txtDestination.Text + "\""));
            Process backupProcess = Process.Start("cmd.exe", "/C " + String.Format(Queries.backup_database, mysqldump_path, dbCred.username, dbCred.password, dbCred.database, "\"" + txtDestination.Text + "\""));
            backupProcess.WaitForExit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                txtDestination.Text = folderBrowser.SelectedPath;
            }
        }

        private void cmbDatabase_SelectedIndexChanged(object sender, EventArgs e)
        {
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
            if (File.Exists(txtSource.Text))
            {
                string mysqldump_path = DatabaseHandler.getInstance().getStringData(String.Format(Queries.select_mysql_base_dir_bin, "mysql.exe"));
                Process backupProcess = Process.Start("cmd.exe", "/C " + String.Format(Queries.restore_database, mysqldump_path, dbCred.username, dbCred.password, dbCred.database, txtSource.Text));
                backupProcess.WaitForExit();
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void txtSource_TextChanged(object sender, EventArgs e)
        {
            btnRestore.Enabled = File.Exists(txtSource.Text);
        }

        private void txtDestination_TextChanged(object sender, EventArgs e)
        {
            btnBackup.Enabled = Directory.Exists(txtDestination.Text);
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
