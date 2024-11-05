using Microsoft.Data.Sqlite;

namespace IAB251_Assignment_2_Project_Final.Models
{
    /// <summary>
    /// This class is used to manage the connection state of the DB, its placed in program.cs
    /// </summary>
    public class ConnectionControler
    {
        private static string _dbName = "database.db";
        private static string _connectionString =  $"Data Source=database.db";
        private bool _conState = false;
        private int _connectionAttempts = 0;

        //HARRYS TEST DB PATH
        //private static string _dbName = "testDB.db";
        //private static string _connectionString = $"Data Source=testDB.db";

        /// <summary>
        /// Constructor that initalises the DB connection, creates the DB table if it doesnt exist
        /// </summary>
        public ConnectionControler()
        {
            if (File.Exists(getDBname()))
            {
                setConState(true);
                Console.WriteLine($"File: {getDBname()} exists in your repository");
            }
            else
            {
                try
                {
                    Console.WriteLine($"File: {getDBname()} does not exist in your repository, attempting to generate it now.");
                    initaliseBlankDB();
                }
                catch(Exception ex)
                {
                    setConState(false);
                    Console.WriteLine($"An issue occured while trying to initalise the DataBase from string '{getConnectionString()}', the following error mesage has been relayed: {ex.Message}"); //dont want to display this to user
                }
            }

        }

        /// <summary>
        /// Initalises a Blank DB
        /// </summary>
        /// <exception cref="Exception">Throws an exception if there is any SQL connection problems</exception>
        private void initaliseBlankDB()
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open(); //creates an empty DB file
                if (File.Exists(_dbName))
                {
                    setConState(true);
                    connection.Close();//close sequence
                    Console.WriteLine($"File: {_dbName} sucessfully created in your repository.");
                }
                else if(_connectionAttempts < 5)
                {
                    _connectionAttempts++;
                    Console.WriteLine($"File not created, attempting again, after 5 attempts this process will time out.");
                    initaliseBlankDB(); //retry
                }
                else
                {
                    throw new Exception();//throwing exception out to catch
                }
            }
        }

        //getters and setters
        public static string getConnectionString() { return _connectionString; }

        public static void setConnectionString(string conn) { _connectionString = conn; }

        private void setConState(bool conState) { _conState =  conState; }

        public bool checkConState() { return _conState; }

        public string getDBname() { return _dbName; }

    }
}