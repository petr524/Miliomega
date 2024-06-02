using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace pvrocnikovka
{
    public class UserManager
    {
        private Dictionary<string, User> users;
        private DatabaseConnect dbConnect;

        public UserManager(DatabaseConnect dbConnect)
        {
            users = new Dictionary<string, User>();
            this.dbConnect = dbConnect;
        }

        public void AddUser(User user)
        {
            if (!users.ContainsKey(user.Username))
            {
                users.Add(user.Username, user);
            }
            else
            {
                Console.WriteLine("Uživatel s tímto uživatelským jménem již existuje.");
            }
        }

        public User AuthenticateUser(string username, string password)
        {
            if (users.ContainsKey(username) && users[username].Password == password)
            {
                return users[username];
            }
            else
            {
                return null;
            }
        }

        public void DisplayUsers()
        {
            foreach (var user in users.Values)
            {
                Console.WriteLine($"Username: {user.Username}, Full Name: {user.FirstName} {user.LastName}");
            }
        }

       public bool Register(string username, string password)
{
    try
    {
        using (MySqlConnection connection = new MySqlConnection(dbConnect.ConnectionString))
        {
            connection.Open();
            string query = "INSERT INTO user (username, password) VALUES (@username, @password)";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);
            int result = cmd.ExecuteNonQuery();

            if (result > 0)
            {
                Console.WriteLine("Registrace byla úspěšná.");
                return true;
            }
            else
            {
                Console.WriteLine("Registrace se nezdařila.");
                return false;
            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An error occurred: {ex.Message}");
        return false;
    }
}
    }
}
