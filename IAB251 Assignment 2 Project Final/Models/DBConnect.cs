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
        private string connectionString = "Data Source=database.db;";

        public string getConnectionString () { return connectionString; }

        public SQLiteConnection establishConnection()
        {
            try
            {
                var connection = new SQLiteConnection(connectionString);
                connection.Open();
                return connection;
            }
            catch (Exception e)
            {
                string err = "We've had a problem connecting";
            }
            return null;
        }

        public void executeQuery(string query, SQLiteConnection connection)
        {
            try
            {
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { connection.Close (); }
        }

        public void executeQuery(string query, SQLiteConnection connection, SQLiteParameter[] parameters)
        {
            try
            {
                using(var command = new SQLiteCommand(query, connection))
                {
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }
                    command.ExecuteNonQuery();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { connection.Close(); }
        }

        public int ?executeScalarQuery(string query, SQLiteConnection connection, SQLiteParameter[] parameters)
        {
            try
            {
                using (var command = new SQLiteCommand(query, connection))
                {
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }
                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
            catch(Exception)
            {
                string errMsg = "There was a problem";
                Console.WriteLine(errMsg);
                return null;
            }
            finally { connection.Close(); }
        }

        /// <summary>
        /// A generic method that uses reflection to execute a fetch of whatever class goes into it.
        /// </summary>
        /// <typeparam name="T">The class type</typeparam>
        /// <param name="query">SQL query</param>
        /// <param name="connection">SQL connection</param>
        /// <param name="parameters">SQL parameters</param>
        /// <returns></returns>
        public List<T> executeFetchAll<T>(string query, SQLiteConnection connection, SQLiteParameter[] parameters) where T : new()
        {
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

        public void severConnection(SQLiteConnection connection)
        {
            connection.Close();
        }
    }
}
