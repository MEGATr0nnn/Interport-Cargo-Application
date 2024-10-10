namespace IAB251_Assignment_2_Project_Final.Models
{
    internal class User
    {
        private int id;

        private string first_Name;

        private string last_Name;

        private string email;

        private int phoneNumber;

        public User(string first_Name, string last_Name, string email, int phoneNumber)
        {
            this.first_Name = first_Name;
            this.last_Name = last_Name;
            this.email = email;
            this.phoneNumber = phoneNumber;
        }


        public int getId() { return id; }
        public void setId(int id) { this.id = id; }


        public string getFirstName() { return first_Name; }
        public void setFirstName(string first_Name) { this.first_Name = first_Name; }


        public string getLastName() { return last_Name; }
        public void setLastName(string last_Name) { this.last_Name = last_Name; }


        public string getEmail() { return email; }
        public void setEmail(string email) { this.email = email; }

        public int getPhoneNumber() { return phoneNumber; }
        public void setPhoneNumber(int phoneNumber) { this.phoneNumber = phoneNumber; }

    }
}