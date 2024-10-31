using System.Data.SQLite;

namespace IAB251_Assignment_2_Project_Final.Models
{
    public class ConnectionControler
    {
        private static string _connectionString =  $"Data Source=database.db";
        private bool _conState;

        //HARRYS TEST DB PATH
        //static string _connectionString = $"Data Source=D:\\Team-10\\IAB251 Assignment 2 Project Final\\Models\\testDB.db";

        public ConnectionControler()
        {
            if (File.Exists(_connectionString))
            {
                _conState = true ;
            }
            else
            {
                _conState= false ;
                initaliseBlankDB();
            }

        }
        private void initaliseBlankDB()
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open(); //creates an empty DB file
                if (File.Exists(getConnectionString()))
                {
                    _conState = true;
                    connection.Close();
                }
            }
        }

        public static string getConnectionString() { return _connectionString; }

        public static void setConnectionString(string conn) { _connectionString = conn; }


    }
}
