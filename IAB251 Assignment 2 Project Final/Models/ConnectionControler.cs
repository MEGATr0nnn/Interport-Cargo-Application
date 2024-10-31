using System.Data.SQLite;

namespace IAB251_Assignment_2_Project_Final.Models
{
    public class ConnectionControler
    {
        private static string _connectionString =  $"Data Source=database.db";
        private static bool _conState = false;

        //HARRYS TEST DB PATH
        //static string _connectionString = $"Data Source=D:\\Team-10\\IAB251 Assignment 2 Project Final\\Models\\testDB.db";

        public ConnectionControler()
        {
            if (File.Exists(_connectionString))
            {
                setConState(true);
            }
            else
            {
                try
                {
                    initaliseBlankDB();
                }
                catch(Exception ex)
                {
                    setConState(false);
                    Console.WriteLine($"An issue occured while trying to initalise the DataBase from string '{getConnectionString()}', the following error mesage has been relayed: {ex.Message}");
                }
            }

        }
        private void initaliseBlankDB()
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open(); //creates an empty DB file
                if (File.Exists(getConnectionString()))
                {
                    setConState(true);
                    connection.Close();//close sequence
                }
                else
                {
                    throw new Exception(); //throwing exception out to catch
                }
            }
        }

        public static string getConnectionString() { return _connectionString; }

        public static void setConnectionString(string conn) { _connectionString = conn; }

        private static void setConState(bool conState) { _conState =  conState; }

        public static bool checkConState() { return _conState; }

    }
}
