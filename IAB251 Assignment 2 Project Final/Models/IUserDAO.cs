namespace IAB251_Assignment_2_Project_Final.Models
{
    /// <summary>
    /// This is the UserDAO interface that can be implemented of all DAOs for object types of User
    /// </summary>
    /// <typeparam name="T">The object you want to instantate the class around, will pre populate your methods to that object type</typeparam>
    public interface IUserDAO<T>
    {
        /// <summary>
        /// The method used to create the inital table, and to check the table exists
        /// </summary>
        void createTable();
        /// <summary>
        /// The method used to insert new instances of the passed object to the DB
        /// </summary>
        /// <param name="entity">The instance of the specific object (ie Customer customer)</param>
        void insertNew(T entity);
        /// <summary>
        /// The method used to delete a specified instance of the object from the DB
        /// </summary>
        /// <param name="entity">The instance of the specific object (ie Customer customer)</param>
        void delete(T entity);
        /// <summary>
        /// The method used to update the current instances details in the DB
        /// </summary>
        /// <param name="entity">The instance of the specific object (ie Customer customer)</param>
        void update(T entity);
        /// <summary>
        /// The method used to get an instance of the object from the DB based on login parameters
        /// </summary>
        /// <param name="email">The users email</param>
        /// <param name="password">The users password</param>
        /// <returns>An instance of the specified object</returns>
        T getFromEmailPword(string email, string password);
        /// <summary>
        /// The method used to check if a specified object exists in the DB based on login parameters
        /// </summary>
        /// <param name="email">The users email</param>
        /// <param name="password">The users password</param>
        /// <returns>A boolean value</returns>
        bool isExist(string email, string password);
    }
}