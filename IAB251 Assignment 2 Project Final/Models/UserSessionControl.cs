namespace IAB251_Assignment_2_Project_Final.Models
{
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
