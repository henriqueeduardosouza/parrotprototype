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
                // User user = new User();
                // user.Id = Guid.Parse(rdr["UserID"].ToString());
                // user.Name = rdr["UserName"].ToString();
                // user.Email = rdr["UserEmail"].ToString();
                // user.Password = rdr["UserPassword"].ToString();
                // users.Add(user);
            }
            return users;
        }
        
    }

    public void CreateUser(User user)
    {
        throw new NotImplementedException();
    }

    public void UpdateUser(User user)
    {
        using (SqlConnection con = new(databaseConnection))
        {
            string queryUpdateBody = "UPDATE users SET UserID = @UserID, UserName = @UserName, UserEmail = @UserEmail, UserPassword = @UserPassword WHERE UserID = @UserID";

            using (SqlCommand cmd = new(queryUpdateBody, con))
            {
                cmd.Parameters.AddWithValue("@UserID", user.Id);
                cmd.Parameters.AddWithValue("@UserName", user.Name);
                cmd.Parameters.AddWithValue("@UserEmail", user.NativeLanguage);
                cmd.Parameters.AddWithValue("@UserPassword", user.Password);

                con.Open();

                cmd.ExecuteNonQuery();
            }
        }
    }
}