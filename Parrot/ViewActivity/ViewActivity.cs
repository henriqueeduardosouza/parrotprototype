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
       public void ViewUsers(List<User> usersList)
        {
            Console.WriteLine("Lista de usuários: \n");
            foreach (var user in usersList)
            {
                Console.WriteLine($"ID: {user.Id} - Usuário: {user.Name} - Lingua nativa: {user.NativeLanguage} - Email: {user.Email}");
            }
            return;
        }
    }

    
}
