namespace IAB251_Assignment_2_Project_Final.Models
{
    public interface IUserSessionControl
    {
        Customer currentUser { get; set; }
    }

    public class UserSessonService : IUserSessionControl
    {
        public Customer currentUser { get; set; }
    }
}
