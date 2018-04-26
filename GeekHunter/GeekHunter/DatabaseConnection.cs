using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeekHunter
{
    class DatabaseConnection
    {
        public SQLiteConnection myConnection;

        public DatabaseConnection()
        {
            try
            {
                myConnection = new SQLiteConnection("Data Source=GeekHunter.sqlite;Version=3;New=False;Compress=True;");
            }
            catch (Exception e)
            {
                //Cannot open File
                Console.WriteLine("Exception: " + e.Message);
                throw e;
            }
        }

        public DataTable SelectQuery(String query, SQLiteParameter[] parameters)
        {
            OpenConnection();
            SQLiteDataAdapter dataAdapter;
            DataSet dataSet = new DataSet();
            DataTable dataTable = new DataTable();

            using (SQLiteCommand command = new SQLiteCommand(query))
            {
                //Adding the parameters if it exists
                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }

                //Executing the command and getting data from the database
                command.Connection = myConnection;
                dataAdapter = new SQLiteDataAdapter(command);
                dataSet.Reset();
                dataAdapter.Fill(dataSet);
                dataTable = dataSet.Tables[0];
            }

            CloseConnection();
            return dataTable;
        }

        public int InsertQuery(String query, SQLiteParameter[] parameters)
        {
            int result;
            OpenConnection();
            using (SQLiteCommand command = new SQLiteCommand(query, myConnection))
            {
                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }
                result = command.ExecuteNonQuery();
            }
            CloseConnection();
            return result;
        }

        private void OpenConnection()
        {
            if (myConnection.State != System.Data.ConnectionState.Open)
            {
                myConnection.Open();
            }
        }

        private void CloseConnection()
        {
            if (myConnection.State != System.Data.ConnectionState.Closed)
            {
                myConnection.Close();
            }
        }
    }
}
