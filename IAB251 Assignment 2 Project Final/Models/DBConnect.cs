using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using IAB251_Assignment_2_Project_Final.Models;

namespace EFB225_Assignment_2___Enterprise_Solution.Database_Model
{
    public class DBConnect<T>
    {
        private string connectionString = "Data Source=Team-10\\IAB251 Assignment 2 Project Final\\Models\\database.db;"; //fix

        public string getConnectionString () { return connectionString; }

        public void setConnectionString(string conn) { connectionString = conn; }

        public void executeQuery(string query)
        {
            var connection = new SQLiteConnection(connectionString);
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

        public void executeQuery(string query, SQLiteParameter[] parameters)
        {
            var connection = new SQLiteConnection(connectionString);
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

        public int executeScalarQuery(string query, SQLiteParameter[] parameters)
        {
            var connection = new SQLiteConnection(connectionString);
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

        /// <summary>
        /// A generic method that uses reflection to execute a fetch of whatever class goes into it.
        /// </summary>
        /// <typeparam name="T">The class type</typeparam>
        /// <param name="query">SQL query</param>
        /// <param name="parameters">SQL parameters</param>
        /// <returns></returns>
        public List<T> executeFetchAll<T>(string query, SQLiteParameter[] parameters) where T : new()
        {
            var connection = new SQLiteConnection(connectionString);
            connection.Open();
            try
            {
                List<T> list = new List<T>();
                using (var command = new SQLiteCommand(query,connection))
                {
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }
                    using(var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            T entity = new T();

                            foreach(var property in typeof(T).GetProperties())
                            {
                                property.SetValue(entity, reader[property.Name]);
                            }

                            list.Add(entity);
                        }
                    }
                }
                return list;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            finally { connection.Close(); }
        }
    }
}
