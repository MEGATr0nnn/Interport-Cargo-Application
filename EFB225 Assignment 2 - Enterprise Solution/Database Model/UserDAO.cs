using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Net.Quic;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;

namespace EFB225_Assignment_2___Enterprise_Solution.Database_Model
{
    internal class UserDAO
    {
        string connectionString = "Data Source=database.db;";
        SQLiteConnection connection;

        public UserDAO()
        {
            connection = new SQLiteConnection(connectionString);
            createTableUser();
        }

        public void createTableUser()
        {
            try
            {
                connection.Open();

                string createTableQuery = @"
                        CREATE TABLE IF NOT EXISTS user (
                            user_Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            user_First_Name VARCHAR NOT NULL,
                            user_Last_Name VARCHAR NOT NULL,
                            user_Email VARCHAR NOT NULL
                        )";

                SQLiteCommand command = new SQLiteCommand(createTableQuery, connection);
                command.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally { connection.Close(); }
        }
    }
}