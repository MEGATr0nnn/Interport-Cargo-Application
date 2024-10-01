namespace EFB225_Assignment_2___Enterprise_Solution;

class Program
{
    static void Main(string[] args)
    {


        Console.WriteLine("_______________________________________");
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine("|                                      |");
        }

        Console.WriteLine("|     Welcome to Interport Cargo!      |");

        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine("|                                      |");
        }


        Console.WriteLine("|    Press 1 to create a new account   |");
        Console.WriteLine("|                                      |");
        Console.WriteLine("|                 OR                   |");
        Console.WriteLine("|                                      |");
        Console.WriteLine("|    Press 2 to Sign into an account   |");
        Console.WriteLine("|                                      |");
        Console.WriteLine("|                 OR                   |");
        Console.WriteLine("|                                      |");
        Console.WriteLine("|           Press 0 to exit            |");

        for (int i = 0; i < 4; i++)
        {
            Console.WriteLine("|                                      |");
        }
        Console.WriteLine("----------------------------------------");


        int signIn = Convert.ToInt32(Console.ReadLine());

        switch (signIn)
            {

            case 0:
                Environment.Exit(0);
                break;

            case 1:
                Console.WriteLine("Create new account selected!");
                    LoginPage.createLoginPage();
                    break;

                case 2:
                    Console.WriteLine("Sign into account selected!");
                    break;

                default:
                    Console.WriteLine("Testing default case.");
                    break;

            }
        }
    }

