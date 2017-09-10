using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DentalRecordApplication
{
    class Configuration
    {
        public Configuration()
        {
            configured = 0;
            server = "";
            username = "";
            password = "";
        }
        public int configured;
        public string server;

        public string username;
        public string password;
    }
}
