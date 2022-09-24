using System.Data.SqlClient;
using Parrot.Interface;
using Parrot.Models;

namespace Parrot.Repositories;

public class UserRepository : IUser
{
    private static readonly string databaseConnection =
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
    
    public User GetUserByEmail(string email)
    {
        string query = "SELECT * FROM user_list WHERE email = @Email";
        
        using (SqlConnection con = new SqlConnection(databaseConnection))
        {
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Email", email);
            SqlDataReader rdr = cmd.ExecuteReader();
            User user = new User();
            while (rdr.Read())
            {
                user.Name = rdr["name"].ToString();
                user.Email = rdr["email"].ToString();
                user.Password = rdr["password"].ToString();
                user.NativeLanguage = rdr["native_language"].ToString();
            }
            return user;
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
            string queryUpdateBody = "UPDATE user_list SET name = @name, email = @email, password = @password, native_language = @native_language WHERE email = @email";

            using (SqlCommand cmd = new(queryUpdateBody, con))
            {
                cmd.Parameters.AddWithValue("@name", user.Name);
                cmd.Parameters.AddWithValue("@email", user.Email);
                cmd.Parameters.AddWithValue("@native_language", user.NativeLanguage);
                cmd.Parameters.AddWithValue("@password", user.Password);

                con.Open();

                cmd.ExecuteNonQuery();
            }
        }
    }

    public void DeleteUser(string email)
    {
        using (SqlConnection con = new(databaseConnection))
        {
            string queryDelete = "DELETE FROM user_list WHERE email = @email";

            using (SqlCommand cmd = new(queryDelete, con))
            {
                cmd.Parameters.AddWithValue("@email", email);

                con.Open();

                cmd.ExecuteNonQuery();
            }
        }
    }

    public void SendMessage (Message message)
    {
        using(SqlConnection con = new SqlConnection(databaseConnection))
        {
            string queryInsert = "INSERT INTO messages (sender, receiver, text, date) VALUES (@sender, @receiver, @text, @date)";
            
            using (SqlCommand cmd = new(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@sender", message.Sender);
                    cmd.Parameters.AddWithValue("@receiver", message.Receiver);
                    cmd.Parameters.AddWithValue("@text", message.Text);
                    cmd.Parameters.AddWithValue("@date", DateTime.Now);
                    
                    con.Open();

                    cmd.ExecuteNonQuery();
                }
        }
    }

    public static List<string> GetChat (string sender, string receiver)
    {
        List<string> list = new();
        using (SqlConnection con = new SqlConnection(databaseConnection))
        {
            string queryFindMessage = "SELECT * FROM MESSAGES WHERE (receiver = @receiver AND sender = @sender) OR (receiver = @sender AND sender = @receiver) ORDER BY id";

            con.Open();

            SqlDataReader rdr;

            using (SqlCommand cmd = new(queryFindMessage, con))
            {
                cmd.Parameters.AddWithValue("@receiver", receiver);
                cmd.Parameters.AddWithValue("@sender", sender);

                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Message msg = new()
                    {
                        Sender = rdr["sender"].ToString(),
                        Receiver = rdr["receiver"].ToString(),
                        Text = rdr["text"].ToString(),
                        Date = DateTime.Parse(rdr["date"].ToString())
                    };

                    list.Add($"{msg.Date} : {msg.Sender} - {msg.Text}");
                }
            }
        }

        return list;
    }
}