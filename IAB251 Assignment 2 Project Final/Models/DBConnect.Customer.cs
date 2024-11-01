﻿using System.Data.SQLite;

namespace IAB251_Assignment_2_Project_Final.Models
{
    /// <summary>
    /// This is the DB connect class, which is used to abstract and protect DB methods, executing the whole argument or if the execution fails, rolling back to the last stable version of the DB.
    /// This is where the majority of DB code goes and provides a stable link between the backend and the DB.
    /// 
    /// THIS PARTIAL CLASS IS FOR CUSTOMER DAO RELATED CODE ONLY
    /// </summary>
    public partial class DBConnect : ConnectionControler
    {
        public Customer customerExecuteFetch(string query, SQLiteParameter[] parameters)
        {
            Customer customer = null;
            var connection = new SQLiteConnection(getConnectionString());
            try
            {
                connection.Open();
                try
                {
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddRange(parameters);

                        using (var reader = command.ExecuteReader()) //use reader to check if value exists
                        {
                            if (reader.Read())
                            {
                                int id = reader.GetInt32(reader.GetOrdinal("id"));


                                string firstName = reader.GetString(reader.GetOrdinal("firstName")),
                                    lastName = reader.GetString(reader.GetOrdinal("lastName")),
                                    email = reader.GetString(reader.GetOrdinal("email")),
                                    password = reader.GetString(reader.GetOrdinal("password")),
                                    phoneNumber = reader.GetString(reader.GetOrdinal("phoneNumber"));

                                customer = new Customer(firstName, lastName, email, phoneNumber, password);
                                customer.setId(id);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException($"Error finding your details{ex.Message}");
                }
            }
            catch(Exception ex)
            {
                throw new SQLiteException($"Error connecting to the server, please wait and then try again{ex.Message}");
            }
            finally { connection.Close(); }
            return customer;
        }
    }
}

