using EFB225_Assignment_2___Enterprise_Solution.Database_Model;
using System.Data.SQLite;
namespace IAB251_Assignment_2_Project_Final.Models
{
    public class CustomerDAO : IUserDAO<Customer>
    {
        private SQLiteConnection connection;
        private DBConnect connect;

        public CustomerDAO()
        {
            connect = new DBConnect();
            createTable();
        }

        public void createTable()
        {
            string createTableQuery = @"
                        CREATE TABLE IF NOT EXISTS customer (
                            customer_Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            customer_First_Name VARCHAR NOT NULL,
                            customer_Last_Name VARCHAR NOT NULL,
                            customer_Email VARCHAR NOT NULL,
                            customer_PhoneNumber INTEGER NOT NULL,
                            customer_Password VARCHAR NOT NULL
                        )";
            connection = connect.establishConnection();
            connect.executeQuery(createTableQuery, connection);
        }

        public void delete(Customer customer)
        {
            string deleteQuery = "DELETE * FROM customer where customer_Id = @customer_Id";
            SQLiteParameter[] parameters = new SQLiteParameter[] 
            { 
                new SQLiteParameter("@customer_Id", customer.getId())
            };
            connection = connect.establishConnection();
            connect.executeQuery(deleteQuery, connection, parameters);
        }

        //currently basic, if the DB gets too large this will crash out, need a quicker way to get customers instead of getting ALL users which is insane (ie two more arguments, email and password, that corrolate to relevent email and pword)
        public List<Customer> get(Customer customer)
        {
            try
            {
                string getQuery = "SELECT * FROM customer WHERE customer_Id = @customer_Id";
                
                using(var command = new SQLitequer)
            }
        }

        public void insertNew(Customer customer)
        {
            string insertUserQuery = @"
                    INSERT INTO customer (customer_First_Name, customer_Last_Name, customer_Email, customer_PhoneNumber) 
                    VALUES (@customer_First_Name, @customer_Last_Name, @customer_Email, @customer_PhoneNumber)
                    RETURNING customer_Id";
            SQLiteParameter[] parameters = new SQLiteParameter[] 
            { 
                new SQLiteParameter("@customer_First_Name", customer.getFirstName()),
                new SQLiteParameter("@customer_Last_Name", customer.getLastName()),
                new SQLiteParameter("@customer_Email", customer.getEmail()), 
                new SQLiteParameter("@customer_PhoneNumber", customer.getPhoneNumber())
            };
            connection = connect.establishConnection();
            customer.setId((int)connect.executeScalarQuery(insertUserQuery, connection, parameters));
        }

        public void update(Customer customer)
        {
            string updateQuery = @"UPDATE customer SET customer_First_Name = @customer_First_Name, customer_Last_Name = @customer_Last_Name, customer_Email = @customer_Email WHERE customer_Id = @customer_Id";
            SQLiteParameter[] parameters = new SQLiteParameter[] 
            {
                new SQLiteParameter("@customer_First_Name", customer.getFirstName()),
                new SQLiteParameter("@customer_Last_Name", customer.getLastName()),
                new SQLiteParameter("@customer_Email", customer.getEmail()),
                new SQLiteParameter("@customer_PhoneNumber", customer.getPhoneNumber()),
                new SQLiteParameter("@customer_Id", customer.getId())
            };
            connection = connect.establishConnection();
            connect.executeQuery(updateQuery, connection, parameters);
        }
    }
}