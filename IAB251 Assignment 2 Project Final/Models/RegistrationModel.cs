namespace IAB251_Assignment_2_Project_Final.Models
{
    public class RegistrationModel
    {
        public string inputFirst { get; set; }
        public string inputLast { get; set; }
        public string inputEmail { get; set; }
        public string inputPhone { get; set; }
        public string inputCompany { get; set; }
        public string inputAddress { get; set; }
        public string inputPassword { get; set; }


        public RegistrationModel() { }

        public void checkAllInformation()
        {
            Console.WriteLine(inputAddress);

            Console.WriteLine(inputFirst);

            Console.WriteLine(inputLast);

            Console.WriteLine(inputEmail);
        }

        private bool checkAccountValid()
        {
            string email = inputEmail;

            string password = inputPassword;


            return false;
        }
    }
}
