using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using IAB251_Assignment_2_Project_Final.Models;

namespace EFB225_Assignment_2___Enterprise_Solution.Database_Model
{
    /// <summary>
    /// This is the DB connect class, which is used to abstract and protect DB methods, executing the whole argument or if the execution fails, rolling back to the last stable version of the DB.
    /// This is where the majority of DB code goes and provides a stable link between the backend and the DB.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DBConnect<T>
    {
        private string _connectionString = $"Data Source=database.db";
        //DO NOT CHANGE UNLESS USING TESTDB
        //private string _connectionString = $"Data Source=D:\\Team-10\\IAB251 Assignment 2 Project Final\\Models\\testDB.db";
        public string getConnectionString () { return _connectionString; }

        public void setConnectionString(string conn) { _connectionString = conn; }

        //=================================================================================
        //Generics Bloc
        //=================================================================================
        /// <summary>
        /// This is the original executeQuery method, which executes an SQL query to the DB, this is usually the first command called when instantising the DB.
        /// </summary>
        /// <param name="query">This is the SQL query you want executed</param>
        public void executeQuery(string query)
        {
            var connection = new SQLiteConnection(_connectionString);
            try
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        using (var command = new SQLiteCommand(query, connection))
                        {
                            command.ExecuteNonQuery();
                        }
                        transaction.Commit();
                        Console.WriteLine("Transaction executed correctly"); //for testing
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Console.WriteLine($"Error executing transaction {ex.Message}");
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"We've had a problem connecting {ex.Message}");
            }
            finally { connection.Close(); }
        }

        /// <summary>
        /// This is the execute query method overload which executes an SQL query based on the query and parameters, this is the most commonly used command in the DB architecture.
        /// </summary>
        /// <param name="query">This is the SQL query you want executed</param>
        /// <param name="parameters">This is the list of parameters you want executed</param>
        public void executeQuery(string query, SQLiteParameter[] parameters)
        {
            var connection = new SQLiteConnection(_connectionString);
            try
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        using (var command = new SQLiteCommand(query, connection))
                        {
                            if (parameters != null)
                            {
                                command.Parameters.AddRange(parameters);
                            }
                            command.ExecuteNonQuery();
                        }
                        transaction.Commit();
                        Console.WriteLine("Transaction executed correctly"); //for testing
                    }
                    catch( Exception ex)
                    {
                        transaction.Rollback();
                        Console.WriteLine($"Error executing transaction {ex.Message}");
                    }
                }
                
            }
            catch(Exception ex)
            {
                Console.WriteLine($"We've had a problem connecting {ex.Message}");
            }
            finally { connection.Close(); }
        }

        /// <summary>
        /// This command executes a scalar query returning an integer value (usally the ID Primary Key) of an object from the DB.
        /// This can only be used to return integer values.
        /// </summary>
        /// <param name="query">This is the SQL query you want executed</param>
        /// <param name="parameters">This is the list of parameters you want executed</param>
        /// <returns>This command returns an integer value</returns>
        public int executeScalarQuery(string query, SQLiteParameter[] parameters)
        {
            var connection = new SQLiteConnection(_connectionString);
            try
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                { 
                    try
                    {
                        using (var command = new SQLiteCommand(query, connection))
                        {
                            if (parameters != null)
                            {
                                command.Parameters.AddRange(parameters);
                            }
                            var result = command.ExecuteScalar();

                            transaction.Commit();

                            return result != null ? Convert.ToInt32(result) : -1;
                        }
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Console.WriteLine($"Error executing transaction {ex.Message}");
                        return -1;
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"We've had a problem connecting {ex.Message}");
                return -1;
            }
            finally { connection.Close(); }
        }

        public bool isExistQuery(string query, params SQLiteParameter[] parameters)
        {
            var connection = new SQLiteConnection(_connectionString);
            try
            {
                connection.Open();

                using (var command = new SQLiteCommand(query, connection))
                {
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }

                    using (var reader = command.ExecuteReader())
                    {
                        //returns true if has rows ie rows exist
                        return reader.HasRows;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"We've had a problem connecting {ex.Message}");
                return false;
            }
            finally { connection.Close(); }
        }


        //=================================================================================
        //Customer Bloc
        //=================================================================================
        public Customer customerExecuteFetch(string query, SQLiteParameter[] parameters)
        {
            Customer customer = null;
            var connection = new SQLiteConnection(_connectionString);
            connection.Open();
            try
            {
                using(var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddRange(parameters);

                    using (var reader = command.ExecuteReader()) //use reader to check if value exists
                    {
                        if (reader.Read())
                        {
                            int id = reader.GetInt32(reader.GetOrdinal("id"));
                                

                            string firstName = reader.GetString(reader.GetOrdinal("firstName")),
                                lastName = reader.GetString(reader.GetOrdinal("lastName")),
                                phoneNumber = reader.GetString(reader.GetOrdinal("phoneNumber")),
                                email = reader.GetString(reader.GetOrdinal("email")),
                                password = reader.GetString(reader.GetOrdinal("password"));

                            customer = new Customer(firstName, lastName, email, phoneNumber, password);
                            customer.setId(id);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            finally { connection.Close(); }
            return customer;
        }

        //finish when needed if needed
        /*
        public Customer customerExecuteIdFetch(string query, SQLiteParameter[] parameters)
        {
            Customer customer;

            var connection = new SQLiteConnection(connectionString);
            connection.Open();
            try
            {

            }
        }
        */

        //=================================================================================
        //Employee Bloc
        //=================================================================================

    }
}
