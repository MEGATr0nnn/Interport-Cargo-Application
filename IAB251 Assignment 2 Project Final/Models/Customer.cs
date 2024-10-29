using System.IO.Pipes;

namespace IAB251_Assignment_2_Project_Final.Models
{
    public class Customer : IUser
    {
        private int id { get; set; }

        private string first_Name { get; set; }

        private string last_Name { get; set; }

        private string email { get; set; }

        private int phoneNumber { get; set; }

        private string password { get; set; }

        public Customer() { }

        public Customer(string first_Name, string last_Name, string email, int phoneNumber, string password)
        {
            this.first_Name = first_Name;
            this.last_Name = last_Name;
            this.email = email;
            this.phoneNumber = phoneNumber;
            this.password = password;
        }

        public int getId() { return id; }
        public void setId(int id) { this.id = id;}

        public string getFirstName() { return first_Name;}
        public void setFirstName(string firstName) { this.first_Name = firstName;}

        public string getLastName() { return last_Name;}
        public void setLastName(string lastName) {  this.last_Name = lastName;}

        public string getEmail() { return email; }
        public void setEmail(string email) {  this.email = email;}

        public int getPhoneNumber() {  return phoneNumber;}
        public void setPhoneNumber(int phoneNumber) {  this.phoneNumber = phoneNumber;}

        public string getPassword() { return password; }
        public void setPassword(string password) {  this.password = password;}

    }
}
