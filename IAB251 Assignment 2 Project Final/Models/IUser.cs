namespace IAB251_Assignment_2_Project_Final.Models
{
    /// <summary>
    /// The interface for all objects of type user, pre populates the class with the base neccessities.
    /// </summary>
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

        public string getPhoneNumber();
        public void setPhoneNumber(string phoneNumber);

        public string getPassword();
        public void setPassword(string password);
    }
}