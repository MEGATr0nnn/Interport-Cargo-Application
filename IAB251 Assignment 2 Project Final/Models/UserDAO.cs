using System.Data.SQLite;
namespace IAB251_Assignment_2_Project_Final.Models
{
    public abstract class UserDAO
    {
        string connectionString = "Data Source=database.db;";
        SQLiteConnection connection;
        public UserDAO()
        {
            connection = new SQLiteConnection(connectionString);
            createTableUser();
        }
        public void createTableUser()
        {
            try
            {
                connection.Open();
                string createTableQuery = @"
                        CREATE TABLE IF NOT EXISTS user (
                            user_Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            user_First_Name VARCHAR NOT NULL,
                            user_Last_Name VARCHAR NOT NULL,
                            user_Email VARCHAR NOT NULL
                        )";
                SQLiteCommand command = new SQLiteCommand(createTableQuery, connection);
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally { connection.Close(); }
        }

        public void insertNewUser(User user)
        {
            try
            {
                connection.Open();
                string insertUserQuery = @"
                    INSERT INTO user (user_Id, user_First_Name, user_Last_Name, user_Email) 
                    VALUES (@user_Id, @user_First_Name, @user_Last_Name, @user_Email)";
               
                using (SQLiteCommand command = new SQLiteCommand(insertUserQuery, connection))
                {
                    command.Parameters.AddWithValue("@user_Id", user.getId());
                    command.Parameters.AddWithValue("@user_First_Name", user.getFirstName());
                    command.Parameters.AddWithValue("@user_Last_Name", user.getLastName());
                    command.Parameters.AddWithValue("@user_Email", user.getEmail());
                    command.ExecuteNonQuery();
                }


            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally { connection.Close(); }
        }

        public void deleteUser(User user)
        {
            try
            {
                connection.Open();
                string deleteQuery = "DELETE * FROM users where user_Id = @user_Id";

                using (SQLiteCommand command = new SQLiteCommand(deleteQuery, connection))
                {
                    command.Parameters.AddWithValue("@user_Id", user.getId);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally { connection.Close(); }
        }

        public void updateUser(User user)
        {
            try
            {
                connection.Open();
                string updateQuery = @"UPDATE users SET user_First_Name = @user_First_Name, user_Last_Name = @user_Last_Name, user_Email = @user_Email WHERE user_Id = @user_Id";
                
                using (SQLiteCommand command = new SQLiteCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@user_First_Name", user.getFirstName());
                    command.Parameters.AddWithValue("@user_Last_Name", user.getLastName());
                    command.Parameters.AddWithValue("@user_Email", user.getEmail());
                    command.ExecuteNonQuery();
                }
            }
            catch(Exception e) 
            { 
                Console.Write(e.ToString()); 
            }
            finally { connection.Close(); }
        }

        public void selectUser(User user)
        {
            try
            {
                connection.Open();
                string selectQuery = "SELECT * FROM user WHERE user_Id = @user_ID";
                using (SQLiteCommand command = new SQLiteCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@user_Id", user.getId());

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {

                        }
                    }
                }
            }
            catch( Exception e)
            {
                Console.Write(e.ToString());
            }
            finally { connection.Close(); }
        }
    }
}