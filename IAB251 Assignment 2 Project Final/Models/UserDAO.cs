using System.Data.SQLite;
namespace IAB251_Assignment_2_Project_Final.Models
{
    public interface UserDAO
    {
        void createTable();
        void insertNew(User user);
        void delete(User user);
        void update(User user);
        List<User> get(User user);
    }
}