using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
namespace DentalRecordApplication
{
    class ServerConnector
    {
        private ServerConnector()
        {
        }

        private MySqlConnection connection;
        public MySqlConnection getConnection()
        {
            return connection;
        }
        private static ServerConnector instance = new ServerConnector();
        public static ServerConnector getInstance()
        {
            return instance;
        }

        public void setDatabaseCredential(DatabaseCredential dbcred)
        {
            databaseCredential = dbcred;
            connection = new MySqlConnection(String.Format(Queries.connection, dbcred.host, dbcred.username, dbcred.password, dbcred.database));
            connection.Open();
        }

        DatabaseCredential databaseCredential;
        public DatabaseCredential getDatabaseCredential()
        {
            return databaseCredential;
        }


        
    }
}
