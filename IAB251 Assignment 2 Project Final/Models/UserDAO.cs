using System.Data.SQLite;
namespace IAB251_Assignment_2_Project_Final.Models
{
    public interface UserDAO<T>
    {
        void createTable();
        void insertNew(T entity);
        void delete(T entity);
        void update(T entity);
        List<T> get(T entity);
    }
}