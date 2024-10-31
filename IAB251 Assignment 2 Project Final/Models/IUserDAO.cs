using System.Data.SQLite;
namespace IAB251_Assignment_2_Project_Final.Models
{
    public interface IUserDAO<T>
    {
        void createTable();
        void insertNew(T entity);
        void delete(T entity);
        void update(T entity);
        T getFromEmailPword(string email, string password);

    }
}