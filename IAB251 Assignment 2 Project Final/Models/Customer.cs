using System.IO.Pipes;

namespace IAB251_Assignment_2_Project_Final.Models
{
    /// <summary>
    /// This class creates an instance of Customer
    /// </summary>
    public class Customer : IUser
    {
        private int _id { get; set; }

        private string _firstName { get; set; }

        private string _lastName { get; set; }

        private string _email { get; set; }

        private string _phoneNumber { get; set; }

        private string _password { get; set; }

        /// <summary>
        /// This is the constructor for customer, that instantises a new customer
        /// </summary>
        /// <param name="firstName">The Customers firstName</param>
        /// <param name="lastName">The Customers lastName</param>
        /// <param name="email">The Customers email</param>
        /// <param name="phoneNumber">The Customers phoneNumber</param>
        /// <param name="password">The Customers password</param>
        public Customer(string firstName, string lastName, string email, string phoneNumber, string password)
        {
            this._firstName = firstName;
            this._lastName = lastName;
            this._email = email;
            this._phoneNumber = phoneNumber;
            this._password = password;
        }

        public int getId() { return _id; }
        public void setId(int id) { this._id = id;}

        public string getFirstName() { return _firstName;}
        public void setFirstName(string firstName) { this._firstName = firstName;}

        public string getLastName() { return _lastName;}
        public void setLastName(string lastName) {  this._lastName = lastName;}

        public string getEmail() { return _email; }
        public void setEmail(string email) {  this._email = email;}

        public string getPhoneNumber() {  return _phoneNumber;}
        public void setPhoneNumber(string phoneNumber) {  this._phoneNumber = phoneNumber;}

        public string getPassword() { return _password; }
        public void setPassword(string password) {  this._password = password;}

    }
}
