using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool end = false;
            string option = "";

            while (!end) 
            {
                Console.WriteLine("Welcome to Parrot");
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
                    Console.WriteLine("Type the password: ");
                    string password = Console.ReadLine();


                    // Chama funcao de registrar
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