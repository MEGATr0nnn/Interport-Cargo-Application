using System.Data.SQLite;

namespace IAB251_Assignment_2_Project_Final.Models
{
    public partial class DBConnect : ConnectionControler
    {
        public List<Quotation> quotationExecuteFetchAll(string query, SQLiteParameter[] parameters)
        {
            List<Quotation> quotationList = new List<Quotation>();
            var connection = new SQLiteConnection(getConnectionString());
            //attempt to open the connection to the DB, this should never fail unless the DB is deleted mid transaction
            try
            {
                connection.Open();
                //attempt to execute the command and fetch details, if the user has no details it will throw an exception, this should never occur as its mitigated by the isExist logic (ie if no quotes exist, prompt user to make one).
                try
                {
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddRange(parameters);

                        using (var reader = command.ExecuteReader()) //use reader to check if value exists
                        {
                            while (reader.Read())
                            {
                                int id = reader.GetInt32(reader.GetOrdinal("id")),
                                    numOfContainers = reader.GetInt32(reader.GetOrdinal("numOfContainers")),
                                    customerId = reader.GetInt32(reader.GetOrdinal("customerId"));

                                string customerInformation = reader.GetString(reader.GetOrdinal("customerInformation")),
                                    source = reader.GetString(reader.GetOrdinal("source")),
                                    destination = reader.GetString(reader.GetOrdinal("destination")),
                                    natureOfPackage = reader.GetString(reader.GetOrdinal("natureOfPackage")),
                                    natureOfJob = reader.GetString(reader.GetOrdinal("natureOfJob"));

                                var quotation = new Quotation(customerInformation, source, destination, numOfContainers, natureOfPackage, natureOfJob);
                                quotation.setId(id);
                                quotation.setCustomerId(customerId);

                                quotationList.Add(quotation);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException($"Error finding your details - your account might not have any quotations associated with it, if you dont have any quotations, please create one{ex.Message}");
                }
            }
            catch(Exception ex)
            {
                throw new SQLiteException($"Error connecting to the server, please wait and then try again{ex.Message}");
            }
            finally { connection.Close(); }
            return quotationList;
        }

        public Quotation quotationExecuteFetch(string query, SQLiteParameter[] parameters)
        {
            Quotation quotation = null;
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
                                int id = reader.GetInt32(reader.GetOrdinal("id")),
                                    numOfContainers = reader.GetInt32(reader.GetOrdinal("numOfContainers")),
                                    customerId = reader.GetInt32(reader.GetOrdinal("customerId"));

                                string customerInformation = reader.GetString(reader.GetOrdinal("customerInformation")),
                                    source = reader.GetString(reader.GetOrdinal("source")),
                                    destination = reader.GetString(reader.GetOrdinal("destination")),
                                    natureOfPackage = reader.GetString(reader.GetOrdinal("natureOfPackage")),
                                    natureOfJob = reader.GetString(reader.GetOrdinal("natureOfJob"));

                                quotation = new Quotation(customerInformation, source, destination, numOfContainers, natureOfPackage, natureOfJob);
                                quotation.setId(id);
                                quotation.setCustomerId(customerId);
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
            return quotation;
        }

    }
}
