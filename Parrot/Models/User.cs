using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parrot.Models {
    public class User {
        public string Name { get; set; }
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string NativeLanguage { get; set; }
        
        public List<Guid> Friends { get; set; }
        public User() {
            Friends = new List<Guid>();
        }

        public User(string name, Guid id, string nativeLanguage, string email, string password/*, List<string> friends*/) {
            Name = name;
            Id = id;
            Email = email;
            Password = password;
            NativeLanguage = nativeLanguage;
            //Friends = friends;
        }
        public void ShowUserInfo(){
            Console.WriteLine($"User id:{Id}\n User name: {Name}\n User email: {Email}\n User password: {Password}\n");
        //    Console.WriteLine($"{Friends}");
        }
        public void SetFriends(List<Guid> friends) {
            Friends = friends;
        }
        public void AddFriend(Guid id) {
            Friends.Add(id);
            Friends.Sort();
        }

        public void RemoveFriend(Guid id)
        {
            int position = Friends.BinarySearch(id);
            Friends.RemoveAt(position);
        }

        public void ShowFriendList() {
            Console.WriteLine($"Mostrando amigos do usuário {Name}");
            foreach (var friend in Friends) {
                Console.WriteLine(friend);
            }
        }
    }
}
