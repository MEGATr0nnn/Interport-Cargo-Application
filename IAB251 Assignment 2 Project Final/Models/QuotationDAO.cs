using System.Data.SQLite;

namespace IAB251_Assignment_2_Project_Final.Models
{
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
                            natureOfPackage VARCHAR NOT NULL,
                            natureOfJob VARCHAR NOT NULL,
                            customerId INTEGER NOT NULL
                        )";
            _connect.executeQuery(query);
        }

        /// <summary>
        /// This is the delete method for deleting quotations associated with an Id, this should be rarely used, only by administrators who can see the quotations id
        /// </summary>
        /// <param name="quotation"></param>
        public void delete(Quotation quotation)
        {
            string query = @"DELETE * FROM quotation WHERE id = @id";
            SQLiteParameter[] parameters = new SQLiteParameter[]
            {
                new SQLiteParameter(@"id", quotation.getId())
            };
            _connect.executeQuery(query, parameters);
        }

        public List<Quotation> getAllFromCustomerId(int customerId)
        {
            string query = @"SELECT * FROM quotation WHERE customerId = @customerId";
            SQLiteParameter[] parameter = new SQLiteParameter[]
            {
                new SQLiteParameter("@customerId", customerId)
            };

            return _connect.quotationExecuteFetchAll(query, parameter);
        }

        public Quotation getSpecificQuotation(int quotationId)
        {
            string query = @"SELECT * FROM quotation WHERE id = @id";
            SQLiteParameter[] parameters = new SQLiteParameter[]
            {
                new SQLiteParameter("@id", quotationId)
            };
            return _connect.quotationExecuteFetch(query, parameters);
        }
    }
}
