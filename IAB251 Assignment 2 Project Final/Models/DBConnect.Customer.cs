using System.Data.SQLite;

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
        /// <summary>
        /// This method fetches a specific Customer associated with the applied query and parameters
        /// </summary>
        /// <param name="query">The SQL query you want executed</param>
        /// <param name="parameters">The constraints/parameters you want to execute your query by</param>
        /// <returns>An instance of Customer</returns>
        /// <exception cref="InvalidOperationException">Thrown when the query or parameters inputted is invalid</exception>
        /// <exception cref="SQLiteException">Thrown when there is an issue with the SQL connection to the DB, this should be rarely executed as the Connection Controler should ensure that this doesnt happen</exception>
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
                    Console.WriteLine(ex.Message);
                    throw new InvalidOperationException($"Error finding your details, please ensure you've created an account with us.");
                }
            }
            catch(SQLiteException ex)
            {
                Console.WriteLine(ex.Message);
                throw new SQLiteException($"Error connecting to the server, please wait and then try again.");
            }
            finally { connection.Close(); }
            return customer;
        }
    }
}

