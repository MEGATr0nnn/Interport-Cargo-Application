using System.Data.SQLite;

namespace IAB251_Assignment_2_Project_Final.Models
{
    public class ConnectionControler
    {
        //private static string _dbName = "database.db";
        //private static string _connectionString =  $"Data Source=database.db";
        private bool _conState = false;
        private int _connectionAttempts = 0;

        //HARRYS TEST DB PATH
        private static string _dbName = "testDB.db";
        static string _connectionString = $"Data Source=testDB.db";

        public ConnectionControler()
        {
            if (File.Exists(_dbName))
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
                if (File.Exists(_dbName))
                {
                    setConState(true);
                    connection.Close();//close sequence
                }
                else if(_connectionAttempts < 5)
                {
                    _connectionAttempts++;
                    initaliseBlankDB(); //retry
                }
                else
                {
                    throw new Exception();//throwing exception out to catch
                }
            }
        }

        public static string getConnectionString() { return _connectionString; }

        public static void setConnectionString(string conn) { _connectionString = conn; }

        private void setConState(bool conState) { _conState =  conState; }

        public bool checkConState() { return _conState; }

    }
}
