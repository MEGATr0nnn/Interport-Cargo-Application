﻿using System.Data.SQLite;
namespace IAB251_Assignment_2_Project_Final.Models
{
    /// <summary>
    /// This is the Data Access Object that is used to simplify and scale SQL queries and execute them using the specified functions in DBConnect, this class has no error handling as its all done in 
    /// DB connect. This results in a streamlined and simple DAO that makes scaling easy.
    /// </summary>
    public class CustomerDAO : IUserDAO<Customer>
    {
        private DBConnect _connect;

        public CustomerDAO()
        {
            _connect = new DBConnect();
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
                            phoneNumber VARCHAR NOT NULL,
                            password VARCHAR NOT NULL
                        )";
            _connect.executeQuery(createTableQuery);
        }

        /*
        public void delete(Customer customer)
        {
            string deleteQuery = "DELETE * FROM customer WHERE id = @id";
            SQLiteParameter[] parameters = new SQLiteParameter[] 
            { 
                new SQLiteParameter("@id", customer.getId())
            };
            _connect.executeQuery(deleteQuery, parameters);
        }
        */

        /// <summary>
        /// Delete cascade query, SQLite DB hasnt had PRAGMA = ON yet so this is a temp fix for cascading quotation deletions.
        /// </summary>
        /// <param name="customer">Instance of Customer</param>
        /// <param name="quotation">Instance of Quotation</param>
        public void delete(Customer customer)
        {
            //delete all associations first as there linked
            string deleteQuotationQuery = @"DELETE * FROM quotation WHERE customerId = @customerId";
            SQLiteParameter[] parameters = new SQLiteParameter[]
            {
                new SQLiteParameter("@customerId", customer.getId())
            };
            _connect.executeQuery(deleteQuotationQuery, parameters);

            //once associated objs are deleted delete base object
            string deleteCustomerQuery = "DELETE * FROM customer WHERE id = @id";
            SQLiteParameter[] parameters1 = new SQLiteParameter[]
            {
                new SQLiteParameter("@id", customer.getId())
            };
            _connect.executeQuery(deleteCustomerQuery, parameters1);
        }

        public Customer getFromEmailPword(string email, string password)
        {
            string getQuery = @"SELECT * FROM customer WHERE email = @email AND password = @password";
            SQLiteParameter[] parameters = new SQLiteParameter[]
            {
                new SQLiteParameter("@email", email),
                new SQLiteParameter("@password", password)
            };
            return _connect.customerExecuteFetch(getQuery, parameters);
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
                new SQLiteParameter("@email", email),
                new SQLiteParameter("@password", password)
            };
            return _connect.isExistQuery(existQuery, param);
        }

        public void update(Customer customer)
        {
            string updateQuery = @"UPDATE customer SET firstName = @firstName, lastName = @lastName, email = @email, phoneNumber = @phoneNumber, password = @password WHERE id = @id";
            SQLiteParameter[] parameters = new SQLiteParameter[] 
            {
                new SQLiteParameter("@firstName", customer.getFirstName()),
                new SQLiteParameter("@lastName", customer.getLastName()),
                new SQLiteParameter("@email", customer.getEmail()),
                new SQLiteParameter("@phoneNumber", customer.getPhoneNumber()),
                new SQLiteParameter("@password", customer.getPassword()),
                new SQLiteParameter("@id", customer.getId())
            };
            _connect.executeQuery(updateQuery, parameters);
        }
    }
}