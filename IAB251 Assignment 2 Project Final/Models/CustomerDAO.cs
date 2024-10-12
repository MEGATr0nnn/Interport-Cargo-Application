using EFB225_Assignment_2___Enterprise_Solution.Database_Model;
using System.Data.SQLite;
namespace IAB251_Assignment_2_Project_Final.Models
{
    public class CustomerDAO : UserDAO<Customer>
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

        public void delete(Customer customer)
        {
            string deleteQuery = "DELETE * FROM users where user_Id = @user_Id";
            SQLiteParameter[] parameters = new SQLiteParameter[] 
            { 
                new SQLiteParameter("@user_Id", customer.getId())
            };
            connect.executeQuery(deleteQuery, connection, parameters);
        }

        public List<Customer> get(Customer customer)
        {
            throw new NotImplementedException();
        }

        public void insertNew(Customer customer)
        {
            throw new NotImplementedException();
        }

        public void update(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}