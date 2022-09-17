using System;
using Parrot.ViewActivity;
using Parrot.Models;
namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool end = false;
            string option = "";
            List<User> users = new List<User>();
            int userId = 0;

            while (!end) 
            {
                Console.WriteLine("Welcome to Parrot");
                Console.WriteLine("            .------.\r\n" +
                    "           /  ~ ~   \\,------.      ______\r\n" +
                    "         ,'  ~ ~ ~  /  (@)   \\   ,'      \\\r\n" +
                    "       ,'          /`.    ~ ~ \\ /         \\\r\n" +
                    "     ,'           | ,'\\  ~ ~ ~ X     \\  \\  \\\r\n" +
                    "   ,'  ,'          V--<       (       \\  \\  \\\r\n" +
                    " ,'  ,'               (vv      \\/\\  \\  \\  |  |\r\n" +
                    "(__,'  ,'   /         (vv   \"\"    \\  \\  | |  |\r\n" +
                    "  (__,'    /   /       vv   \"\"\"    \\ |  / / /\r\n" +
                    "      \\__,'   /  |     vv          / / / / /\r\n" +
                    "          \\__/   / |  | \\         / /,',','\r\n" +
                    "             \\__/\\_^  |  \\       /,'',','\\\r\n" +
                    "                    `-^.__>.____/  ' ,'   \\\r\n" +
                    "                            // //---'      |\r\n" +
                    "          ===============(((((((=================\r\n" +
                    "                                     | \\ \\  \\\r\n" +
                    "                                     / |  |  \\\r\n" +
                    "                                    / /  / \\  \\\r\n" +
                    "                                    `.     |   \\\r\n" +
                    "                                      `--------'");
                Console.WriteLine("Type an option:");
                Console.WriteLine("\t1 - Register");
                Console.WriteLine("\t0 - Quit");
                option = Console.ReadLine();
                Console.Write("\n");

                if (option == "1") 
                {
                    Console.WriteLine("Type the username:");
                    string username = Console.ReadLine();
                    Console.WriteLine("Type your native Language: ");
                    string language = Console.ReadLine();
                    Console.WriteLine("Type the email: ");
                    string email = Console.ReadLine();
                    Console.WriteLine("Type the password: ");
                    string password = Console.ReadLine();
                    User user = new User(username, userId++,language,email,password);
                    users.Add(user);

                    // Chama funcao de registrar
                    View.ViewUsers(users);
                    Console.WriteLine("\nUsername registered with sucess\n");
                }
                else
                {
                    Console.WriteLine("\nParrot says goodbye!\n");
                    end = true;
                }
            }
        }
    }
}