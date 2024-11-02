using System.Security.Cryptography;

namespace IAB251_Assignment_2_Project_Final.Models
{
    public class PasswordHasher
    {
        //hash logic here
        //ENSURE YOU'VE MADE THIS CLASS STATELESS (ie no fields), THERE SHOULD BE NO VARIABLES STORED BETWEEN STATES/METHOD EXECUTORS AS ITS A SEC RISK
        //IMPORT A SIMPLE HASH LIBRARY
        //hashing a password method

        public string hashPassword(string password)
        {
            Byte[] inputBytes = System.Text.Encoding.UTF8.GetBytes(password);

            Byte[] hashedBytes = SHA256.Create().ComputeHash(inputBytes);

            return BitConverter.ToString(hashedBytes);
        }
    }
}
