using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parrot.Models {
    public abstract class User {
        string Name { get; set; }
        string Id { get; set; }
        string Email { get; set; }
        string Password { get; set; }
        string NativeLanguage { get; set; }
        List<string> Friends { get; set; }
        public User(string name, string id, string email, string password, List<string> friends) {
            Name = name;
            Id = id;
            Email = email;
            Password = password;
            Friends = friends;
        }
        public void ShowUserInfo(){
            Console.WriteLine($"User id:{Id}\n User name: {Name}\n User email: {Email}\n User password: {Password}\n");
            Console.WriteLine($"{Friends}");
        }

    }
}
