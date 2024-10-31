using System.Data.SqlClient;
using System.Data.SQLite;

namespace IAB251_Assignment_2_Project_Final.Models
{
    public class EmployeeDAO : IUserDAO<Employee>
    {
        private DBConnect _connect;

        public EmployeeDAO()
        {
            _connect = new DBConnect();
            createTable();
        }
        public void createTable()
        {
            string creatTableQuery = @"
                        CREATE TABLE IF NOT EXISTS employee (
                            id INTEGER PRIMARY KEY AUTOINCREMENT,
                            firstName VARCHAR NOT NULL,
                            lastName VARCHAR NOT NULL,
                            email VARCHAR NOT NULL,
                            phoneNumber INTEGER NOT NULL,
                            password VARCHAR NOT NULL
                        )";
            _connect.executeQuery(creatTableQuery);
        }

        public void delete(Employee employee)
        {
            string deleteQuery = @"DELETE * FROM employee WHERE id = @id";
            SQLiteParameter[] param = new SQLiteParameter[]
            {
                new SQLiteParameter("@id", employee.getId())
            };
            _connect.executeQuery(deleteQuery, param);
        }

        public Employee getFromEmailPword(string email, string password)
        {
            string getQuery = @"SELECT * FROM employee WHERE email = @email AND password = @password";
            SQLiteParameter[] param = new SQLiteParameter[]
            {
                new SQLiteParameter("email", email),
                new SQLiteParameter("password", password)
            };
            return _connect.employeeExecuteFetch(getQuery, param);
        }

        public void insertNew(Employee employee)
        {
            throw new NotImplementedException();
        }

        public bool isExist(string email, string password)
        {
            throw new NotImplementedException();
        }

        public void update(Employee entity)
        {
            throw new NotImplementedException();
        }
    }
}
