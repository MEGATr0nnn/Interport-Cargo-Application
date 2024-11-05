using Microsoft.Data.Sqlite;

namespace IAB251_Assignment_2_Project_Final.Models
{
    /// <summary>
    /// This is the Data Access Object that is used to simplify and scale SQL queries and execute them using the specified functions in DBConnect, this class has no error handling as its all done in 
    /// DB connect. This results in a streamlined and simple DAO that makes scaling easy.
    /// </summary>
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
                            phoneNumber VARCHAR NOT NULL,
                            password VARCHAR NOT NULL,
                            type VARCHAR NOT NULL,
                            address STRING NOT NULL,
                            dateJoined STRING NOT NULL
                        )";
            _connect.executeQuery(creatTableQuery);
        }

        public void delete(Employee employee)
        {
            string deleteQuery = @"DELETE * FROM employee WHERE id = @id";
            SqliteParameter[] param = new SqliteParameter[]
            {
                new SqliteParameter("@id", employee.getId())
            };
            _connect.executeQuery(deleteQuery, param);
        }

        public Employee getFromEmailPword(string email, string password)
        {
            string getQuery = @"SELECT * FROM employee WHERE email = @email AND password = @password";
            SqliteParameter[] param = new SqliteParameter[]
            {
                new SqliteParameter("@email", email),
                new SqliteParameter("@password", password)
            };
            return _connect.employeeExecuteFetch(getQuery, param);
        }

        public void insertNew(Employee employee)
        {
            string insertUserQuery = @"
                    INSERT INTO employee (firstName, lastName, email, phoneNumber, password, type, address, dateJoined)
                    VALUES (@firstName, @lastName, @email, @phoneNumber, @password, @type, @address, @dateJoined)
                    RETURNING id";

            SqliteParameter[] parameters = new SqliteParameter[]
            {
                new SqliteParameter("@firstName", employee.getFirstName()),
                new SqliteParameter("@lastName", employee.getLastName()),
                new SqliteParameter("@email", employee.getEmail()),
                new SqliteParameter("@phoneNumber", employee.getPhoneNumber()),
                new SqliteParameter("@password", employee.getPassword()),
                new SqliteParameter("@type", employee.getType()),
                new SqliteParameter("@address", employee.getAddress()),
                new SqliteParameter("@dateJoined", employee.joiningTiming())
            };
            employee.setId(_connect.executeScalarQuery(insertUserQuery, parameters));
        }

        public bool isExist(string email, string password)
        {
            string query = @"SELECT * FROM employee WHERE email = @email AND password = @password";
            SqliteParameter[] parameters = new SqliteParameter[]
            {
                new SqliteParameter("@email", email),
                new SqliteParameter("@password", password)
            };
            return _connect.isExistQuery(query, parameters);
        }

        public void update(Employee employee)
        {
            string updateQuery = @"UPDATE employee SET firstName = @firstName, lastName = @lastName, email = @email, phoneNumber = @phoneNumber, password = @password, type = @type WHERE id = @id";
            SqliteParameter[] parameters = new SqliteParameter[]
            {
                new SqliteParameter("@firstName", employee.getFirstName()),
                new SqliteParameter("@lastName", employee.getLastName()),
                new SqliteParameter("@email", employee.getEmail()),
                new SqliteParameter("@phoneNumber", employee.getPhoneNumber()),
                new SqliteParameter("@password", employee.getPassword()),
                new SqliteParameter("@type", employee.getType()),
                new SqliteParameter("@id", employee.getId())
            };
            _connect.executeQuery(updateQuery, parameters);
        }
    }
}
