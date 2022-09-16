using Parrot.Models;

namespace Parrot.Interface;

public interface IUser
{
    List<User> GetUsers();
    public void CreateUser(User user);
}