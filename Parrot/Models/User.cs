using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parrot.Models {
    public class User {
        public string Name { get; set; }
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string NativeLanguage { get; set; }
        public List<string> Friends { get; set; }
        public User(string name, int id, string nativeLanguage, string email, string password/*, List<string> friends*/) {
            Name = name;
            Id = id;
            Email = email;
            Password = password;
            NativeLanguage = nativeLanguage;
            //Friends = friends;
        }
        public void ShowUserInfo(){
            Console.WriteLine($"User id:{Id}\n User name: {Name}\n User email: {Email}\n User password: {Password}\n");
            Console.WriteLine($"{Friends}");
        }

    }
}
