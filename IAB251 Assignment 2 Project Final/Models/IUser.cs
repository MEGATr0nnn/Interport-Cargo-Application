namespace IAB251_Assignment_2_Project_Final.Models
{
    public interface IUser
    {
        public int getId();
        public void setId(int id);

        public string getFirstName();
        public void setFirstName(string firstName);

        public string getLastName();
        public void setLastName(string lastName);

        public string getEmail();
        public void setEmail(string email);

        public int getPhoneNumber();
        public void setPhoneNumber(int phoneNumber);

        public string getPassword();
        public void setPassword(string password);
    }
}