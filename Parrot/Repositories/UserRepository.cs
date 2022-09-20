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
            SqlCommand cmd = new SqlCommand("SELECT * FROM user_list", con);
            SqlDataReader rdr = cmd.ExecuteReader();
            List<User> users = new List<User>();
            while (rdr.Read())
            {
                string name = rdr["name"].ToString();
                string email = rdr["email"].ToString();
                string password = rdr["password"].ToString();
                string nativeLanguage = rdr["native_language"].ToString();
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
            string queryInsert = "INSERT INTO user_list (name, email, password, native_language) VALUES (@name, @email, @password, @native_language)";
            
            using (SqlCommand cmd = new(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@name", user.Name);
                    cmd.Parameters.AddWithValue("@email", user.Email);
                    cmd.Parameters.AddWithValue("@password", user.Password);
                    cmd.Parameters.AddWithValue("@native_language", user.NativeLanguage);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
        }
    }

    public void UpdateUser(User user)
    {
        using (SqlConnection con = new(databaseConnection))
        {
            string queryUpdateBody = "UPDATE users SET UserID = @UserID, UserName = @UserName, UserEmail = @UserEmail, UserPassword = @UserPassword WHERE UserID = @UserID";

            using (SqlCommand cmd = new(queryUpdateBody, con))
            {
                cmd.Parameters.AddWithValue("@UserName", user.Name);
                cmd.Parameters.AddWithValue("@UserEmail", user.NativeLanguage);
                cmd.Parameters.AddWithValue("@UserPassword", user.Password);

                con.Open();

                cmd.ExecuteNonQuery();
            }
        }
    }
}