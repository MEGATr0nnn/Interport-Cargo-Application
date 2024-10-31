using EFB225_Assignment_2___Enterprise_Solution.Database_Model;
using System.Data.SQLite;
namespace IAB251_Assignment_2_Project_Final.Models
{
    public class CustomerDAO : IUserDAO<Customer>
    {
        private DBConnect<Customer> _connect;

        public CustomerDAO()
        {
            _connect = new DBConnect<Customer>();
            createTable();
        }

        public void createTable()
        {
            string createTableQuery = @"
                        CREATE TABLE IF NOT EXISTS customer (
                            id INTEGER PRIMARY KEY AUTOINCREMENT,
                            firstName VARCHAR NOT NULL,
                            lastName VARCHAR NOT NULL,
                            email VARCHAR NOT NULL,
                            phoneNumber INTEGER NOT NULL,
                            password VARCHAR NOT NULL
                        )";
            _connect.executeQuery(createTableQuery);
        }

        public void delete(Customer customer)
        {
            string deleteQuery = "DELETE * FROM customer where id = @id";
            SQLiteParameter[] parameters = new SQLiteParameter[] 
            { 
                new SQLiteParameter("@id", customer.getId())
            };
            _connect.executeQuery(deleteQuery, parameters);
        }

        //fix when needed if needed
        /*
        public bool getFromId(Customer customer)
        {

            string getQuery = "SELECT * FROM customer WHERE id = @id";
            SQLiteParameter[] parameters = new SQLiteParameter[]
            {
                new SQLiteParameter("@id", customer.getId())
            };
            List<Customer> customers = connect.executeFetchAll<Customer>(getQuery, parameters);
            return customers;
        }
        */

        public Customer getFromEmailPword(string email, string password)
        {
            string getQuery = @"SELECT * FROM customer WHERE email = @email AND password = @password";
            SQLiteParameter[] parameters = new SQLiteParameter[]
            {
                new SQLiteParameter("@email", email),
                new SQLiteParameter("@password", password)
            };
            return _connect.customerExecuteFetch(getQuery, parameters); //return matched customer
        }

        public void insertNew(Customer customer)
        {
            string insertUserQuery = @"
                    INSERT INTO customer (firstName, lastName, email, phoneNumber, password)
                    VALUES (@firstName, @lastName, @email, @phoneNumber, @password)
                    RETURNING id";

            SQLiteParameter[] parameters = new SQLiteParameter[] 
            { 
                new SQLiteParameter("@firstName", customer.getFirstName()),
                new SQLiteParameter("@lastName", customer.getLastName()),
                new SQLiteParameter("@email", customer.getEmail()), 
                new SQLiteParameter("@phoneNumber", customer.getPhoneNumber()),
                new SQLiteParameter("@password", customer.getPassword())
            };
            customer.setId(_connect.executeScalarQuery(insertUserQuery, parameters));
            
        }

        public bool isExist(string email, string password)
        {
            string existQuery = @"SELECT * FROM customer WHERE email = @email AND password = @password";
            SQLiteParameter[] param = new SQLiteParameter[]
            {
                new SQLiteParameter("email", email),
                new SQLiteParameter("password", password)
            };
            return _connect.isExistQuery(existQuery, param);
        }

        public void update(Customer customer)
        {
            string updateQuery = @"UPDATE customer SET first_Name = @first_Name, last_Name = @last_Name, email = @email WHERE id = @id";

            SQLiteParameter[] parameters = new SQLiteParameter[] 
            {
                new SQLiteParameter("@firstName", customer.getFirstName()),
                new SQLiteParameter("@lastName", customer.getLastName()),
                new SQLiteParameter("@email", customer.getEmail()),
                new SQLiteParameter("@phoneNumber", customer.getPhoneNumber()),
                new SQLiteParameter("@id", customer.getId())
            };
            _connect.executeQuery(updateQuery, parameters);
        }
    }
}