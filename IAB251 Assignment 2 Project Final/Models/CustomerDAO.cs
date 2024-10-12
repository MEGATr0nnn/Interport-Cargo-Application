using EFB225_Assignment_2___Enterprise_Solution.Database_Model;
using System.Data.SQLite;
namespace IAB251_Assignment_2_Project_Final.Models
{
    public class CustomerDAO : UserDAO
    {
        private SQLiteConnection connection;
        private DBConnect connect;

        public CustomerDAO()
        {
            connect = new DBConnect();
            connection = connect.establishConnection();
            createTable();
        }

        public void createTable()
        {
            string createTableQuery = @"
                        CREATE TABLE IF NOT EXISTS user (
                            customer_Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            customer_First_Name VARCHAR NOT NULL,
                            customer_Last_Name VARCHAR NOT NULL,
                            customer_Email VARCHAR NOT NULL,
                            customer_PhoneNumber INTEGER NOT NULL
                        )";
            connect.executeQuery(createTableQuery, connection);
        }

        public void delete(User user)
        {
            throw new NotImplementedException();
        }

        public List<User> get(User user)
        {
            throw new NotImplementedException();
        }

        public void insertNew(User user)
        {
            throw new NotImplementedException();
        }

        public void update(User user)
        {
            throw new NotImplementedException();
        }
    }
}