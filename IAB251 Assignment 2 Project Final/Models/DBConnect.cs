using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IAB251_Assignment_2_Project_Final.Models;
using Microsoft.Data.Sqlite;

namespace IAB251_Assignment_2_Project_Final.Models
{
    /// <summary>
    /// This is the DB connect class, which is used to abstract and protect DB methods, executing the whole argument or if the execution fails, rolling back to the last stable version of the DB.
    /// This is where the majority of DB code goes and provides a stable link between the backend and the DB.
    /// 
    /// THIS PARTIAL CLASS IS FOR GENERIC REUSEABLE CODE SEGEMENTS FOR ALL QUERY EXECUTION
    /// </summary>
    public partial class DBConnect : ConnectionControler
    {
        /// <summary>
        /// This is the original executeQuery method, which executes an SQL query to the DB, this is usually the first command called when instantising the DB.
        /// </summary>
        /// <param name="query">This is the SQL query you want executed</param>
        /// <exception cref="InvalidOperationException">Thrown when the query or parameters inputted is invalid</exception>
        /// <exception cref="SQLiteException">Thrown when there is an issue with the SQL connection to the DB, this should be rarely executed as the Connection Controler should ensure that this doesnt happen</exception>
        public void executeQuery(string query)
        {
            var connection = new SqliteConnection(getConnectionString());
            connection.Open();

            using (var transaction = connection.BeginTransaction())
            {
                try
                {
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = query;
                        command.ExecuteNonQuery();
                    }
                    transaction.Commit();
                    Console.WriteLine("Transaction executed correctly: table created"); //for testing FIX ERROR LOGIC
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Console.WriteLine(ex.Message); //hidden from user, this is for Admin debugging only
                    throw new InvalidOperationException($"Error executing your request, please try again."); //displayed to user
                                                                                                             //all other catch blocks follow this structure :)
                }

                finally { connection.Close(); }
            }

        }

        /// <summary>
        /// This is the execute query method overload which executes an SQL query based on the query and parameters, this is the most commonly used command in the DB architecture.
        /// </summary>
        /// <param name="query">This is the SQL query you want executed</param>
        /// <param name="parameters">This is the list of parameters you want executed</param>
        /// <exception cref="InvalidOperationException">Thrown when the query or parameters inputted is invalid</exception>
        /// <exception cref="SQLiteException">Thrown when there is an issue with the SQL connection to the DB, this should be rarely executed as the Connection Controler should ensure that this doesnt happen</exception>
        public void executeQuery(string query, SqliteParameter[] parameters)
        {
            var connection = new SqliteConnection(getConnectionString());
            connection.Open();

            using (var transaction = connection.BeginTransaction())
            {
                try
                {
                    using (var command = new SqliteCommand(query, connection, transaction))
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
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Console.WriteLine(ex.Message);
                    throw new InvalidOperationException($"Error executing your request, please try again.");
                }
                finally { connection.Close(); }
            }
        }

        /// <summary>
        /// This command executes a scalar query returning an integer value (usally the ID Primary Key) of an object from the DB.
        /// This can only be used to return integer values.
        /// </summary>
        /// <param name="query">This is the SQL query you want executed</param>
        /// <param name="parameters">This is the list of parameters you want executed</param>
        /// <returns>This command returns an integer value</returns>
        /// <exception cref="InvalidOperationException">Thrown when the query or parameters inputted is invalid</exception>
        /// <exception cref="SQLiteException">Thrown when there is an issue with the SQL connection to the DB, this should be rarely executed as the Connection Controler should ensure that this doesnt happen</exception>
        public int executeScalarQuery(string query, SqliteParameter[] parameters)
        {
            var connection = new SqliteConnection(getConnectionString());
            connection.Open();

            using (var transaction = connection.BeginTransaction())
            {
                try
                {
                    using (var command = new SqliteCommand(query, connection, transaction))
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
                    Console.WriteLine(ex.Message);
                    throw new InvalidOperationException($"Error executing your request, please try again.");
                }
                finally { connection.Close(); }
            }
        }

        /// <summary>
        /// This method checks to see if the specified query and parameters exists within the context applied to it
        /// </summary>
        /// <param name="query">This is the SQL query you want executed</param>
        /// <param name="parameters">This is the list of parameters you want executed</param>
        /// <returns>A boolean</returns>
        /// <exception cref="InvalidOperationException">Thrown when the query or parameters inputted is invalid</exception>
        /// <exception cref="SQLiteException">Thrown when there is an issue with the SQL connection to the DB, this should be rarely executed as the Connection Controler should ensure that this doesnt happen</exception>
        public bool isExistQuery(string query, params SqliteParameter[] parameters)
        {
            var connection = new SqliteConnection(getConnectionString());
            connection.Open();
            try
            {
                using (var transaction = connection.BeginTransaction())
                {
                    using (var command = new SqliteCommand(query, connection, transaction))
                    {

                        if (parameters != null)
                        {
                            command.Parameters.AddRange(parameters);
                        }
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                //returns true if has rows ie rows exist
                                return reader.HasRows;

                            }
                            else
                            {
                                throw new InvalidOperationException();
                            }
                        }
                    }
                }
            }            
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
                throw new InvalidOperationException($"Error finding your details, please ensure you've created an account with us.");
            }
            finally { connection.Close(); }

        }
    }
}
