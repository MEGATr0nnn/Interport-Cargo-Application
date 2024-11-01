namespace IAB251_Assignment_2_Project_Final.Models
{
    /// <summary>
    /// This class allows a single instance of user to be accessed across the session, it utalises dependency injection principals and is called in program.cs
    /// I chose to implement this as it makes it easier to inject dependencies rather than casting or creating them directly
    /// </summary>
    public interface IUserSessionControl
    {
        Customer currentCustomerUser { get; set; }
        Employee currentEmployeeUser { get; set; }
    }

    public class UserSessionService : IUserSessionControl
    {
        public Customer currentCustomerUser { get; set; }
        public Employee currentEmployeeUser { get; set; }
    }
}
