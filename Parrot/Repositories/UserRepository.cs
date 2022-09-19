using System.Data.SqlClient;
using Parrot.Interface;
using Parrot.Models;

namespace Parrot.Repositories;

public class UserRepository : IUser
{
    private readonly string databaseConnection =
        "Server=labsoft.pcs.usp.br;Database=db_5;User Id=usuario_5;Password=44323442882;";
    public List<User> GetUsers()
    {
        using (SqlConnection con = new SqlConnection(databaseConnection))
        { 
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM users", con);
            SqlDataReader rdr = cmd.ExecuteReader();
            List<User> users = new List<User>();
            while (rdr.Read())
            {
                string name = rdr["UserName"].ToString();
                string email = rdr["UserEmail"].ToString();
                string password = rdr["UserPassword"].ToString();
                string nativeLanguage = rdr["UserNativeLanguage"].ToString();
                User user = new User(name, nativeLanguage, email, password);
                users.Add(user);
            }
            return users;
        }
        
    }

    public void CreateUser(User user)
    {
        using(SqlConnection con = new SqlConnection(databaseConnection))
        {
            string queryInsert = "INSERT INTO UserList (UserName, UserPassword, UserEmail, UserNativeLanguage) VALUES (@UserName, @UserPassword, @UserEmail, @UserNativeLanguage)";
            
            using (SqlCommand cmd = new(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@UserName", user.Name);
                    cmd.Parameters.AddWithValue("@UserPassword", user.Password);
                    cmd.Parameters.AddWithValue("@UserEmail", user.Email);
                    cmd.Parameters.AddWithValue("@UserNativeLanguage", user.NativeLanguage);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
        }
    }
}