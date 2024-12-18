using ProjetCsharp.Models;
using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace ProjetCsharp.Controllers
{
    public class LoginController
    {
        private string connectionString = "Server=localhost;Database=projetcsharp;User ID=root;Password=root;"; // Connexion à la base de données

        // Méthode pour authentifier l'utilisateur
        public User AuthenticateUser(string email, string password)
        {
            User user = null;

            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM users WHERE Email = @Email AND Password = @Password";
                var command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Password", password);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        user = new User
                        {
                            Id = reader.GetInt32("Id"),
                            Email = reader.GetString("Email"),
                            Password = reader.GetString("Password"),
                            Role = reader.GetString("Role")
                        };
                    }
                }
            }

            return user;
        }
    }
}
