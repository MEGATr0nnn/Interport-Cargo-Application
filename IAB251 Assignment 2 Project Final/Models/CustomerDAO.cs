using EFB225_Assignment_2___Enterprise_Solution.Database_Model;
using System.Data.SQLite;
namespace IAB251_Assignment_2_Project_Final.Models
{
    public class CustomerDAO : IUserDAO<Customer>
    {
        private DBConnect<Customer> connect;

        public CustomerDAO()
        {
            connect = new DBConnect<Customer>();
            createTable();
        }

        public void createTable()
        {
            string createTableQuery = @"
                        CREATE TABLE IF NOT EXISTS customer (
                            id INTEGER PRIMARY KEY AUTOINCREMENT,
                            first_Name VARCHAR NOT NULL,
                            last_Name VARCHAR NOT NULL,
                            email VARCHAR NOT NULL,
                            phoneNumber INTEGER NOT NULL,
                            password VARCHAR NOT NULL
                        )";
            connect.executeQuery(createTableQuery);
        }

        public void delete(Customer customer)
        {
            string deleteQuery = "DELETE * FROM customer where id = @id";
            SQLiteParameter[] parameters = new SQLiteParameter[] 
            { 
                new SQLiteParameter("@id", customer.getId())
            };
            connect.executeQuery(deleteQuery, parameters);
        }

        //currently basic, if the DB gets too large this will crash out, need a quicker way to get customers instead of getting ALL users which is insane (ie two more arguments, email and password, that corrolate to relevent email and pword)
        public List<Customer> get(Customer customer)
        {

            string getQuery = "SELECT * FROM customer WHERE id = @id";
            SQLiteParameter[] parameters = new SQLiteParameter[]
            {
                new SQLiteParameter("@id", customer.getId())
            };
            List<Customer> customers = connect.executeFetchAll<Customer>(getQuery, parameters); 
            return customers;
        }

        public void insertNew(Customer customer)
        {
            string insertUserQuery = @"
                    INSERT INTO customer (first_Name, last_Name, email, phoneNumber, password)
                    VALUES (@first_Name, @last_Name, @email, @phoneNumber, @password)
                    RETURNING id";

            SQLiteParameter[] parameters = new SQLiteParameter[] 
            { 
                new SQLiteParameter("@first_Name", customer.getFirstName()),
                new SQLiteParameter("@last_Name", customer.getLastName()),
                new SQLiteParameter("@email", customer.getEmail()), 
                new SQLiteParameter("@phoneNumber", customer.getPhoneNumber()),
                new SQLiteParameter("@password", customer.getPassword())
            };
            customer.setId(connect.executeScalarQuery(insertUserQuery, parameters));
            
        }

        public void update(Customer customer)
        {
            string updateQuery = @"UPDATE customer SET first_Name = @first_Name, last_Name = @last_Name, email = @email WHERE id = @id";
            SQLiteParameter[] parameters = new SQLiteParameter[] 
            {
                new SQLiteParameter("@first_Name", customer.getFirstName()),
                new SQLiteParameter("@last_Name", customer.getLastName()),
                new SQLiteParameter("@email", customer.getEmail()),
                new SQLiteParameter("@phoneNumber", customer.getPhoneNumber()),
                new SQLiteParameter("@customer_Id", customer.getId())
            };
            connect.executeQuery(updateQuery, parameters);
        }
    }
}