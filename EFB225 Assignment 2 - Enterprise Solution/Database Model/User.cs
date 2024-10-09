using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFB225_Assignment_2___Enterprise_Solution.Database_Model
{
    internal class User
    {
        private int id;
        private string first_Name;
        private string last_Name;
        private string email;

        public User(String first_Name, String last_Name, string email)
        {
            this.first_Name = first_Name;
            this.last_Name = last_Name;
            this.email = email;
        }

        public int getId() { return id; }
        public void setId(int id) { this.id = id;}

        public string getFirstName() { return first_Name; }
        public void setFirstName(String first_Name) {  this.first_Name = first_Name;}

        public String getLastName() { return last_Name;}
        public void setLastName(String last_Name) { this.last_Name = last_Name;}

        public String getEmail() { return email; }
        public void setEmail(String email) { this.email = email;}
    }
}
