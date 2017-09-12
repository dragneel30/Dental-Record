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
namespace UserSetup
{
    public partial class Setup : Form
    {
        public Setup()
        {
            InitializeComponent();
        }

        
        private void button2_Click(object sender, EventArgs e)
        {
            if (txtUser.Text.Length == 0 || txtPassword.Text.Length == 0)
            {
                MessageBox.Show("fill up");
                return;
            }
            Configuration config = new Configuration();
            config.username = txtUser.Text;
            config.password = txtPassword.Text;
            string json = JsonConvert.SerializeObject(config);
            File.WriteAllText("usersetup.json", json);
            this.Close();
        }

        private void Setup_Load(object sender, EventArgs e)
        {

        }
    }
    class Configuration
    {
        public string username;
        public string password;
    }
}
