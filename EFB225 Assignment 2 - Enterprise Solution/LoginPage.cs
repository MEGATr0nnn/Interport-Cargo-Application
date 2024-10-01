using System;
namespace EFB225_Assignment_2___Enterprise_Solution
{
	public class LoginPage
	{
		public LoginPage()
		{
		}

		public static void createLoginPage()
		{

            Console.WriteLine("_____________________________________");

			for(int i = 0; i < 5; i++)
			{
				Console.WriteLine("|                                  |");
			}

			Console.WriteLine("|    Enter the following details:  |");
            Console.WriteLine("|                                  |");
            Console.WriteLine("|                                  |");
			Console.WriteLine("|     1. First Name                |");
            Console.WriteLine("|     2. Family Name               |");
            Console.WriteLine("|     3. Email Address             |");
            Console.WriteLine("|     4. Phone Number              |");
            Console.WriteLine("|     5. Company Name (Optional)   |");
            Console.WriteLine("|     6. Address                   |");
            Console.WriteLine("|     7. Password                  |");
            Console.WriteLine("|                                  |");
            Console.WriteLine("|                                  |");
            Console.WriteLine("------------------------------------");

			string ?firstName = Console.ReadLine();
			Console.WriteLine("Firstname: " + firstName);

            string? secondName = Console.ReadLine();
            Console.WriteLine("Lastname: " + secondName);

            string? email = Console.ReadLine();
            Console.WriteLine("Email Address: " + email);

            string? phone = Console.ReadLine();
            Console.WriteLine("Phone Number: " + phone);

            string? companyName = Console.ReadLine();
            Console.WriteLine("Company Name: " + companyName);

            string? address = Console.ReadLine();
            Console.WriteLine("Address: " + address);

            var password = Console.ReadKey(intercept: true);
            Console.WriteLine("Password successfully set!");

        }
    }
}

