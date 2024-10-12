using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace EFB225_Assignment_2___Enterprise_Solution.Database_Model
{
    public class DBConnect
    {
        private string connectionString = "Data Source=database.db;";

        public string getConnectionString () { return connectionString; }

        public SQLiteConnection establishConnection()
        {
            var connection = new SQLiteConnection (connectionString);
            connection.Open ();
            return connection;
        }

        public void executeQuery(string query, SQLiteConnection connection)
        {
            try
            {
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { connection.Close (); }
        }

        public void executeQuery(string query, SQLiteConnection connection, SQLiteParameter[] parameters)
        {
            try
            {
                using(var command = new SQLiteCommand(query, connection))
                {
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }
                    command.ExecuteNonQuery();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { connection.Close(); }
        }

        public void severConnection(SQLiteConnection connection)
        {
            connection.Close();
        }
    }
}
