using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Diagnostics;
using System.IO;
using System.Drawing;
namespace DentalRecordApplication
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static bool tryconfigure()
        {
            return (tryconfigure(Queries.database_conf_file, Queries.database_conf_exe) &&
                tryconfigure(Queries.user_setup_conf_file, Queries.user_setup_conf_exe));
        }
        public static bool tryconfigure(string resultfile, string exepath)
        {
            if (!File.Exists(resultfile))
            {
                if (!configure(resultfile, exepath, Queries.external_exe_arg))
                {
                    return false;
                }
            }
            return true;
        }
        public static bool configure(string resultfile, string exepath, string args)
        {
            if (File.Exists(exepath))
            {
                Process p = Process.Start(exepath, args);
                p.WaitForExit();
                MessageBox.Show("You can still change it by deleting " + resultfile + " in the installation directory");
                return true;
            }
            else
            {
                MessageBox.Show(exepath + " is missing please fix it or contact the developer");
                return false;
            }
        }

        
        [STAThread]
        static void Main()
        {
            
            if (tryconfigure())
            {
                string dbcredstr = File.ReadAllText(Queries.database_conf_file);
                ServerConnector.getInstance().setDatabaseCredential(JsonConvert.DeserializeObject<DatabaseCredential>(dbcredstr));

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Admin());
            }
        }
    }
}
