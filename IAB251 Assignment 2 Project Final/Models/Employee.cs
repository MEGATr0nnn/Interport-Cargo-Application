namespace IAB251_Assignment_2_Project_Final.Models
{
    /// <summary>
    /// This class creates an instance of Employee
    /// </summary>
    public class Employee : IUser
    {
        //fields
        private int _id;
        private string _firstName;
        private string _lastName;
        private string _email;
        private string _phoneNumber;
        private string _password;
        private string _type;
        private string _address;
        private string _joined;

        /// <summary>
        /// Constructor responsible for creating Employees.
        /// </summary>
        /// <param name="firstName">The Employees firstName</param>
        /// <param name="lastName">The Employees lastName</param>
        /// <param name="email">The Employees email</param>
        /// <param name="phoneNumber">The Employees phoneNumber</param>
        /// <param name="password">The Employees password</param>
        public Employee(string firstName, string lastName, string email, string phoneNumber, string password, string type, string address, string joined)
        {
            this._firstName = firstName;
            this._lastName = lastName;
            this._email = email;
            this._phoneNumber = phoneNumber;
            this._password = password;
            this._type = type;
            this._address = address;
            this._joined = joined;
        }

        /// <summary>
        /// Sets the join date for the employee automatically
        /// </summary>
        /// <returns>The date the employees account was created.</returns>
        public string joiningTiming()
        {
            string joinDate = DateTime.Now.ToString("yyyy-MM-dd");
            setJoinDate(joinDate);
            return getJoinDate();
        }

        //getters and setters
        public string getEmail()
        {
            return _email;
        }

        public string getFirstName()
        {
            return _firstName;
        }

        public int getId()
        {
            return _id;
        }

        public string getLastName()
        {
            return _lastName;
        }

        public string getPassword()
        {
            return _password;
        }

        public string getPhoneNumber()
        {
            return _phoneNumber;
        }

        public string getType()
        {
            return _type;
        }

        public void setEmail(string email)
        {
            this._email = email;
        }

        public void setFirstName(string firstName)
        {
            this._firstName = firstName;
        }

        public void setId(int id)
        {
            this._id = id;
        }

        public void setLastName(string lastName)
        {
            this._lastName = lastName;
        }

        public void setPassword(string password)
        {
            this._password = password;
        }

        public void setPhoneNumber(string phoneNumber)
        {
            this._phoneNumber = phoneNumber;
        }

        public void setType(string type)
        {
            this._type=type;
        }

        public void setAddress(string address) { this._address = address; }
        public string getAddress() { return _address; }

        public void setJoinDate(string joinDate) { this._joined = joinDate; }
        public string getJoinDate() { return _joined; }
    }
}
