using Microsoft.Data.Sqlite;

namespace IAB251_Assignment_2_Project_Final.Models
{
    /// <summary>
    /// This is the Data Access Object that is used to simplify and scale SQL queries and execute them using the specified functions in DBConnect, this class has no error handling as its all done in 
    /// DB connect. This results in a streamlined and simple DAO that makes scaling easy.
    /// </summary>
    public class QuotationDAO
    {
        private DBConnect _connect;

        public QuotationDAO()
        {
            _connect = new DBConnect();
            createTable();
        }

        public void createTable()
        {
            string query = @"CREATE TABLE IF NOT EXISTS quotation (
                            id INTEGER PRIMARY KEY AUTOINCREMENT,
                            customerInformation VARCHAR NOT NULL,
                            source VARCHAR NOT NULL,
                            destination VARCHAR NOT NULL,
                            numOfContainers INTEGER NOT NULL,
                            sizeOfContainers INTEGER NOT NULL,
                            natureOfPackage VARCHAR NOT NULL,
                            isImport INTEGER NOT NULL,
                            isPacking INTEGER NOT NULL,
                            quarantineReq INTEGER NOT NULL,
                            fumigation INTEGER NOT NULL,
                            crane INTEGER NOT NULL,
                            status VARCHAR NOT NULL,
                            customerId INTEGER NOT NULL
                        )";
            _connect.executeQuery(query);
        }

        /// <summary>
        /// This is the delete method for deleting quotations associated with an Id, this should be rarely used, only by administrators who can see the quotations id
        /// </summary>
        /// <param name="quotation">Instance of Quotation</param>
        public void delete(Quotation quotation)
        {
            string query = @"DELETE * FROM quotation WHERE id = @id";
            SqliteParameter[] parameters = new SqliteParameter[]
            {
                new SqliteParameter(@"id", quotation.getId())
            };
            _connect.executeQuery(query, parameters);
        }

        /// <summary>
        /// Returns a list of all quotations that are associated with the sessions current customer
        /// </summary>
        /// <param name="customerId">The ID of the current customer in the session</param>
        /// <returns>A list of all quotations associated with the refrenced customers specific Id</returns>
        public List<Quotation> getAllFromCustomerId(int customerId)
        {
            string query = @"SELECT * FROM quotation WHERE customerId = @customerId";
            SqliteParameter[] parameter = new SqliteParameter[]
            {
                new SqliteParameter("@customerId", customerId)
            };

            return _connect.quotationExecuteFetchAll(query, parameter);
        }

        /// <summary>
        /// Returns a list of all quotations that are associated with the sessions current customer
        /// </summary>
        /// <param name="customerId">The ID of the current customer in the session</param>
        /// <returns>A list of all quotations associated with the refrenced customers specific Id</returns>
        public List<Quotation> getAllQuotations()
        {
            string query = @"SELECT * FROM quotation";
            SqliteParameter[] parameter = new SqliteParameter[]
            {
                //new SqliteParameter("@customerId", customerId)
            };

            return _connect.quotationExecuteFetchAll(query, parameter);
        }

        /// <summary>
        /// Gets a specific quotation from the DB based on the unique identifier ID attatched to the quotation
        /// </summary>
        /// <param name="quotationId">The unique auto-generated identifier</param>
        /// <returns>Returns a single instance of the quotation</returns>
        public Quotation getSpecificQuotation(int quotationId)
        {
            string query = @"SELECT * FROM quotation WHERE id = @id";
            SqliteParameter[] parameters = new SqliteParameter[]
            {
                new SqliteParameter("@id", quotationId)
            };
            return _connect.quotationExecuteFetch(query, parameters);
        }

        /// <summary>
        /// Inserts new quotations into the DB using the current users Id as a foreign key.
        /// </summary>
        /// <param name="quotation">Instance of Quotation</param>
        /// <param name="customer">Instance of Customer</param>
        public void insertNew(Quotation quotation, Customer customer)
        {
            string insertUserQuery = @"
                    INSERT INTO quotation (customerInformation, source, destination, numOfContainers, sizeOfContainers, natureOfPackage, isImport, isPacking, quarantineReq, fumigation, crane, status, customerId)
                    VALUES (@customerInformation, @source, @destination, @numOfContainers, @sizeOfContainers, @natureOfPackage, @isImport, @isPacking, @quarantineReq, @fumigation, @crane, @status, @customerId)
                    RETURNING id";

            SqliteParameter[] parameters = new SqliteParameter[]
            {
                new SqliteParameter("@customerInformation", quotation.getCustomerInformation()),
                new SqliteParameter("@source", quotation.getSource()),
                new SqliteParameter("@destination", quotation.getDestination()),
                new SqliteParameter("@numOfContainers", quotation.getNumOfContainers()),
                new SqliteParameter("@sizeOfContainers", quotation.getsizeOfContainers()),
                new SqliteParameter("@natureOfPackage", quotation.getNatureOfPackage()),
                new SqliteParameter("@isImport", quotation.getImport()),
                new SqliteParameter("@isPacking", quotation.getPacking()),
                new SqliteParameter("@quarantineReq", quotation.getQuarantineRequirements()),
                new SqliteParameter("@fumigation", quotation.getFumigation()),
                new SqliteParameter("@crane", quotation.getCrane()),
                new SqliteParameter("@status", quotation.getStatus()),
                new SqliteParameter("@customerId", customer.getId())
            };
            quotation.setId(_connect.executeScalarQuery(insertUserQuery, parameters));
        }
    }
}
