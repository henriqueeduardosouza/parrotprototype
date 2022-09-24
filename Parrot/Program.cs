using System;
using Parrot.ViewActivity;
using Parrot.Models;
using Parrot.Repositories;
using Newtonsoft.Json;

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
            var repo = new UserRepository();

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
                    repo.CreateUser(user);

                        Console.WriteLine("\nUsername registered with sucess\n");
                    }
                    else if (option == "2") 
                    {
                        Console.WriteLine("Type your email:");
                        string email = Console.ReadLine();
                        Console.WriteLine("Type your password:");
                        string password = Console.ReadLine();
                        //Query usuario
                        User user = repo.GetUserByEmail(email);

                        //Console.WriteLine(users2[0].Name);

                        if (email == user.Email && password == user.Password)
                        {
                            logged = true;
                            loggedUser = user;
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
                    Console.WriteLine("2 - Send message");
                    Console.WriteLine("0 - Exit program");
                    option = Console.ReadLine();

                    if (option == "1") 
                    {
                        users = repo.GetUsers();
                        //var jsonString = JsonConvert.SerializeObject(users);
                        //Console.WriteLine(jsonString);
                        View.ViewUsers(users);

                    }
                    else if (option == "2")
                    {
                        Console.WriteLine("Type the user's email: ");
                        string receiverEmail = Console.ReadLine();
                        bool stoppedChat = false;
                        while (!stoppedChat) {
                            Console.Clear();
                            Console.WriteLine("You are chatting with " + receiverEmail + ". Type \\q to stop chatting.");
                            View.ShowChat(loggedUser.Email, receiverEmail);
                            Console.Write("Type your message: ");
                            string text = Console.ReadLine();
                            if (text == "\\q")
                            {
                                stoppedChat = true;
                            }
                            else {
                                
                                Message message = new Message(loggedUser.Email, receiverEmail, text, DateTime.Now);
                                repo.SendMessage(message);
                            }
                        }
                    }

                    else if (option == "0")
                    {
                        end = true;
                    }
                }
            }
        }
    }
}