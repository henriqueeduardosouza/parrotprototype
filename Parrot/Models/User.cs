using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parrot.Models {
    public class User {
<<<<<<< HEAD
        public Guid Id { get; set; }
        public string Name { get; set; }
=======
        public string Name { get; set; }
        public int Id { get; set; }
>>>>>>> backup
        public string Email { get; set; }
        public string Password { get; set; }
        public string NativeLanguage { get; set; }
        public List<string> Friends { get; set; }
<<<<<<< HEAD
        
        public User() {
        }
        public User(string name, Guid id, string email, string password, List<string> friends) {
=======
        public User(string name, int id, string nativeLanguage, string email, string password/*, List<string> friends*/) {
>>>>>>> backup
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
