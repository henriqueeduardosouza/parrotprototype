using Parrot.Models;
using Parrot.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parrot.ViewActivity
{
    public class View
    {
       public static void ViewUsers(List<User> usersList)
        {
            Console.WriteLine("------------------------------------------ Users --------------------------------------------");
            Console.WriteLine("Name".PadRight(20) + "|".PadRight(5) + "Native language".PadRight(20) + "|".PadRight(5) + "Email".PadRight(20));
            Console.WriteLine("---------------------------------------------------------------------------------------------");
            foreach (var user in usersList)
            {
                Console.WriteLine(user.Name.PadRight(20) + "|".PadRight(5) + user.NativeLanguage.PadRight(20) + "|".PadRight(5) + user.Email.PadRight(20));
            }
            Console.WriteLine("---------------------------------------------------------------------------------------------\n");
            
            return;
        }

        public static void ShowChat(string sender, string receiver)
        {
            UserRepository userRepository = new();
            List<string> chat = new List<string>();
            chat = UserRepository.GetChat(sender, receiver);
            Console.WriteLine($"Chat between {sender} and {receiver}: \n");
            foreach (var item in chat)
            {
                Console.WriteLine(item);
            }
        }
    }

    
}
