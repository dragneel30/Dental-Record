using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;
namespace DatabaseConfigurator
{
    public partial class maincs : Form
    {
        public maincs()
        {
            InitializeComponent();
        }

        class Conf
        {
            public Conf(string db, string h, string u, string p)
            {
                database = db;
                host = h;
                username = u;
                password = p;
            }
            public string database;
            public string host;
            public string username;
            public string password;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text.Length == 0 || txtHost.Text.Length == 0 )
            {
                MessageBox.Show("no input can be empty");
            }
            else
            {

               DialogResult result = MessageBox.Show("Are you sure?", "Warning", MessageBoxButtons.YesNo);
               if (result == DialogResult.Yes)
               {
                   Conf dbconf = new Conf("dental", txtHost.Text, txtUsername.Text, txtPassword.Text);
                   string serializedobj = JsonConvert.SerializeObject(dbconf);
                   File.WriteAllText("dbconf.json", serializedobj);
                   this.Close();
               }
            }
        }
    }
}
