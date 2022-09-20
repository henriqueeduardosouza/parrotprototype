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
            bool logged = false;
            User loggedUser = null;

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
            while (!end) 
            {   
                
                if (!logged) {
                    Console.WriteLine("Type an option:");
                    Console.WriteLine("\t1 - Register");
                    Console.WriteLine("\t2 - Log in");
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
                    User user = new User(username,language,email,password);
                    users.Add(user);

                        Console.WriteLine("\nUsername registered with sucess\n");
                    }
                    else if (option == "2") 
                    {
                        Console.WriteLine("Type your email:");
                        string email = Console.ReadLine();
                        Console.WriteLine("Type your password:");
                        string password = Console.ReadLine();
                        //Query usuario
                        if (email == "teste@teste.com" && password == "123")
                        {
                            logged = true;
                            Console.WriteLine("\nLogged in successfully\n");
                        }
                        else
                        {
                            Console.WriteLine("\nLog in failed\n");
                        }

                    }
                    else if (option == "0")
                    {
                        Console.WriteLine("\nParrot says goodbye!\n");
                        end = true;
                    }

                    else {
                        Console.WriteLine("Opção não reconhecida. Tente novamente");
                    }
                } else {
                    Console.WriteLine("Type an option:");
                    Console.WriteLine("1 - List registered users");
                    Console.WriteLine("0 - Exit program");
                    option = Console.ReadLine();

                    if (option == "0")
                    {
                        end = true;
                    }
                }
            }
        }
    }
}