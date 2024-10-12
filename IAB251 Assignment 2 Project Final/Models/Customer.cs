namespace IAB251_Assignment_2_Project_Final.Models
{
    public class Customer : User
    {
        public Customer(string first_Name, string last_Name, string email, int phoneNumber) : base(first_Name, last_Name, email, phoneNumber)
        {
            setFirstName(first_Name);
            setLastName(last_Name);
            setEmail(email);
            setPhoneNumber(phoneNumber);
        }
    }
}
