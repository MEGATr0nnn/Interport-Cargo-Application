using Microsoft.Data.Sqlite;

namespace IAB251_Assignment_2_Project_Final.Models
{
    /// <summary>
    /// This is the DB connect class, which is used to abstract and protect DB methods, executing the whole argument or if the execution fails, rolling back to the last stable version of the DB.
    /// This is where the majority of DB code goes and provides a stable link between the backend and the DB.
    /// 
    /// THIS PARTIAL CLASS IS FOR QUOTATION DAO RELATED CODE ONLY
    /// </summary>
    public partial class DBConnect : ConnectionControler
    {
        /// <summary>
        /// This method fetches all records of quotations associated with the applied query and parameters
        /// </summary>
        /// <param name="query">The SQL query you want executed</param>
        /// <param name="parameters">The constraints/parameters you want to execute your query by</param>
        /// <returns>A list of type Quotation, containing quotation objects and there relevent attributes, fields and methods</returns>
        /// <exception cref="InvalidOperationException">Thrown when the query or parameters inputted is invalid</exception>
        /// <exception cref="SQLiteException">Thrown when there is an issue with the SQL connection to the DB, this should be rarely executed as the Connection Controler should ensure that this doesnt happen</exception>
        public List<Quotation> quotationExecuteFetchAll(string query, SqliteParameter[] parameters)
        {
            List<Quotation> quotationList = new List<Quotation>();
            var connection = new SqliteConnection(getConnectionString());
            connection.Open();
            //attempt to execute the command and fetch details, if the user has no details it will throw an exception, this should never occur as its mitigated by the isExist logic (ie if no quotes exist, prompt user to make one).
            try
            {
                using (var command = new SqliteCommand(query, connection))
                {
                    command.Parameters.AddRange(parameters);

                    using (var reader = command.ExecuteReader()) //use reader to check if value exists
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(reader.GetOrdinal("id")),
                                numOfContainers = reader.GetInt32(reader.GetOrdinal("numOfContainers")),
                                sizeOfContainers = reader.GetInt32(reader.GetOrdinal("sizeOfContainers")),
                                customerId = reader.GetInt32(reader.GetOrdinal("customerId"));

                            string customerInformation = reader.GetString(reader.GetOrdinal("customerInformation")),
                                source = reader.GetString(reader.GetOrdinal("source")),
                                destination = reader.GetString(reader.GetOrdinal("destination")),
                                natureOfPackage = reader.GetString(reader.GetOrdinal("natureOfPackage")),
                                quarantineReq = reader.GetString(reader.GetOrdinal("quarantineReq")),
                                status = reader.GetString(reader.GetOrdinal("status"));

                            bool isImport = reader.GetBoolean(reader.GetOrdinal("isImport")),
                                isPacking = reader.GetBoolean(reader.GetOrdinal("isPacking")),
                                fumigation = reader.GetBoolean(reader.GetOrdinal("fumigation")),
                                crane = reader.GetBoolean(reader.GetOrdinal("crane"));


                            var quotation = new Quotation(customerInformation, source, destination, numOfContainers, sizeOfContainers, natureOfPackage, isImport, isPacking, quarantineReq, fumigation, crane, status); //create new instance to be added, then loops
                            quotation.setId(id);
                            quotation.setCustomerId(customerId);

                            quotationList.Add(quotation);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new InvalidOperationException($"Error finding your details, please ensure you've created an account with us.");
            }
            finally { connection.Close(); }
            return quotationList;
        }



        /// <summary>
        /// This method is designed to return single instances of quotation associated with the applied query and parameters
        /// </summary>
        /// <param name="query">The SQL query you want executed</param>
        /// <param name="parameters">The constraints/parameters you want to execute your query by</param>
        /// <returns>A single instance of object Quotation</returns>
        /// <exception cref="InvalidOperationException">Thrown when the query or parameters inputted is invalid</exception>
        /// <exception cref="SQLiteException">Thrown when there is an issue with the SQL connection to the DB, this should be rarely executed as the Connection Controler should ensure that this doesnt happen</exception>
        public Quotation quotationExecuteFetch(string query, SqliteParameter[] parameters)
        {
            Quotation quotation = null;
            var connection = new SqliteConnection(getConnectionString());

            connection.Open();
            try
            {
                using (var command = new SqliteCommand(query, connection))
                {
                    command.Parameters.AddRange(parameters);

                    using (var reader = command.ExecuteReader()) //use reader to check if value exists
                    {
                        if (reader.Read())
                        {
                            int id = reader.GetInt32(reader.GetOrdinal("id")),
                                numOfContainers = reader.GetInt32(reader.GetOrdinal("numOfContainers")),
                                sizeOfContainers = reader.GetInt32(reader.GetOrdinal("sizeOfContainers")),
                                customerId = reader.GetInt32(reader.GetOrdinal("customerId"));

                            string customerInformation = reader.GetString(reader.GetOrdinal("customerInformation")),
                                source = reader.GetString(reader.GetOrdinal("source")),
                                destination = reader.GetString(reader.GetOrdinal("destination")),
                                natureOfPackage = reader.GetString(reader.GetOrdinal("natureOfPackage")),
                                quarantineReq = reader.GetString(reader.GetOrdinal("quarantineReq")),
                                status = reader.GetString(reader.GetOrdinal("status"));

                            bool isImport = reader.GetBoolean(reader.GetOrdinal("isImport")),
                                isPacking = reader.GetBoolean(reader.GetOrdinal("isPacking")),
                                fumigation = reader.GetBoolean(reader.GetOrdinal("fumigation")),
                                crane = reader.GetBoolean(reader.GetOrdinal("crane"));

                            quotation = new Quotation(customerInformation, source, destination, numOfContainers, sizeOfContainers, natureOfPackage, isImport, isPacking, quarantineReq, fumigation, crane, status); //create new instance to be returned to the user
                            quotation.setId(id);
                            quotation.setCustomerId(customerId);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new InvalidOperationException($"Error finding your details, please ensure you've created an account with us.");
            }
            finally { connection.Close(); }
            return quotation;
        }

    }
}
