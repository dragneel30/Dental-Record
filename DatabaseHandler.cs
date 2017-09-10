using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace DentalRecordApplication
{
    class DatabaseHandler
    {

        void backup(String query)
        {

        }
        void restore(String query)
        {

        }

        private static DatabaseHandler instance = new DatabaseHandler();

        public static DatabaseHandler getInstance() { return instance; }

        public bool modifyTable(String query)
        {
            return createCommand(query).ExecuteNonQuery() > 0;
        }

        private MySqlCommand createCommand(String query)
        {
            
            return new MySqlCommand(query, ServerConnector.getInstance().getConnection());
        }

        public DataTable getTable(String query)
        {
            MySqlCommand command = createCommand(query);

            DataTable rows = new DataTable();

            rows.Load(command.ExecuteReader());

            if (rows.Rows.Count <= 0)
            {
                return null;
            }

            return rows;
        }

        public List<DataRow> getListRow(String query)
        {
            DataTable table = getTable(query);
            if (!Utils.isObjectNull(table))
            {
                List<DataRow> list = new List<DataRow>();
                for (int a = 0; a < table.Rows.Count; a++)
                {
                    list.Add(table.Rows[a]);
                }
                return list;
            }
            return null;
            
        }
        public DataRow getRow(String query)
        {
            DataTable table = getTable(query);
            if (!Utils.isObjectNull(table))
            {
                return table.Rows[0];
            }
            return null;
        }
        public String getStringData(String query, String column)
        {
            return (String)getData(query, column);
        }
        public Object getData(String query, String column)
        {
            DataRow row = getRow(query);
            if (!Utils.isObjectNull(row))
            {
                return row[column];
            }
            return null;
        }
      
        public Object getSingleData(String query)
        {
            DataRow row = getRow(query);
            if (!Utils.isObjectNull(row))
            {
                return row[0];
            }
            return null;
        }
        public double getDoubleData(String query)
        {
            Object obj = getSingleData(query);
            if (!Utils.isObjectNull(obj))
                return Convert.ToDouble(obj);
            return 0.0;
        }
        public String getStringData(String query)
        {
            Object obj = getSingleData(query);
            if (!Utils.isObjectNull(obj))
               return Convert.ToString(getSingleData(query));
            return "";
        }
        public int getIntData(String query)
        {
            Object obj = getSingleData(query);
            if (!Utils.isObjectNull(obj))
                return Convert.ToInt32(getSingleData(query));
            return 0;
        }
        public bool getBoolData(String query)
        {
            Object obj = getSingleData(query);
            if (!Utils.isObjectNull(obj))
                return Convert.ToBoolean(getSingleData(query));
            return false;
        }
        public List<String> getListStringSingleData(String query)
        {
            List<String> data = new List<String>();
            List<DataRow> row = getListRow(query);
            if (!Utils.isObjectNull(row))
            {
                for (int a = 0; a < row.Count; a++)
                {
                    data.Add(row[a][0].ToString());
                }
            }
            return data;
        }
    }
}
