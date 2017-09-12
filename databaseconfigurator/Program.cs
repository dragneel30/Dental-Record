using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DatabaseConfigurator
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                if (args[0] == "dentalrecord")
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new maincs());
                }
            }
        }
    }
}
