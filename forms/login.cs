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
namespace DentalRecordApplication
{

    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            string dbcredstr = File.ReadAllText(Queries.user_setup_conf_file);
            UserCredential cred = JsonConvert.DeserializeObject<UserCredential>(dbcredstr);

            if (txtuser.Text == cred.username && txtpass.Text == cred.password)
            {
                MessageBox.Show("success");
                Utils.hideAndShow(this, new Admin());
            }
            else
            {
                MessageBox.Show("wrong credentials try again");
                attempts++;
            }
            if (attempts == 3)
            {
                MessageBox.Show("you attempted 3 wrong logins, app is exiting");
                btnexit.PerformClick();
            }
        }
        int attempts = 0;

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtpass.UseSystemPasswordChar = true;

            }
            else
            {
                txtpass.UseSystemPasswordChar = false;
            }
        }
    }

    class UserCredential
    {
        public UserCredential()
        {
            username = "";
            password = "";
        }
        public string username;
        public string password;
    }
}
