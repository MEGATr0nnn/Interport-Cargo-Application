using EFB225_Assignment_2___Enterprise_Solution.Database_Model;

namespace IAB251_Assignment_2_Project_Final.Models
{
    public class EmployeeDAO : IUserDAO<Employee>
    {
        private DBConnect<Employee> _connect;

        public EmployeeDAO()
        {
            _connect = new DBConnect<Employee>();
            createTable();
        }
        public void createTable()
        {
            string creatTableQuery = @"
                        CREATE TABLE IF NOT EXISTS customer (
                            id INTEGER PRIMARY KEY AUTOINCREMENT,
                            firstName VARCHAR NOT NULL,
                            lastName VARCHAR NOT NULL,
                            email VARCHAR NOT NULL,
                            phoneNumber INTEGER NOT NULL,
                            password VARCHAR NOT NULL
                        )";
            _connect.executeQuery(creatTableQuery);
        }

        public void delete(Employee entity)
        {
            throw new NotImplementedException();
        }

        public Employee getFromEmailPword(string email, string password)
        {
            throw new NotImplementedException();
        }

        public void insertNew(Employee entity)
        {
            throw new NotImplementedException();
        }

        public void update(Employee entity)
        {
            throw new NotImplementedException();
        }
    }
}
