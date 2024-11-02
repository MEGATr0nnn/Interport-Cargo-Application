using System.Security.Cryptography;

namespace IAB251_Assignment_2_Project_Final.Models
{
    /// <summary>
    /// Class to allow for the generation of Password Hashing       
    /// </summary>
    public class PasswordHasher
    {
        /// <summary>
        /// Method to hash passwords via SHA256
        /// </summary>
        /// <param name="password">The users inputted password</param>
        /// <returns>A hashed string via SHA256</returns>
        public string hashPassword(string password)
        {
            Byte[] inputBytes = System.Text.Encoding.UTF8.GetBytes(password);

            Byte[] hashedBytes = SHA256.Create().ComputeHash(inputBytes);

            return BitConverter.ToString(hashedBytes);
        }
    }
}
