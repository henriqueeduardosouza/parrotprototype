using Parrot.Models;
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
            Console.WriteLine("Lista de usuários: \n");
            foreach (var user in usersList)
            {
                Console.WriteLine($"Usuário: {user.Name} - Lingua nativa: {user.NativeLanguage} - Email: {user.Email}");
            }
            return;
        }

        public static void ShowChat(string sender, string receiver)
        {
            List<string> chat = new List<string>();
            chat = getchat(sender, receiver);
            Console.WriteLine($"Conversa entre {sender} e {receiver}: \n");
            foreach (var item in chat)
            {
                Console.WriteLine(item);
            }
        }
    }

    
}
