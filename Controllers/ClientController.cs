using System.Collections.Generic;
using MySql.Data.MySqlClient;
using ProjetCsharp.Models;

namespace ProjetCsharp.Controllers
{
    public class ClientController
    {
        private string connectionString = "Server=localhost;Database=projetcsharp;User ID=root;Password=root;";

        // Récupérer tous les clients
        public List<Client> GetAllClients()
        {
            var clients = new List<Client>();

            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM clients";
                var command = new MySqlCommand(query, connection);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        clients.Add(new Client
                        {
                            Id = reader.GetInt32("Id"),
                            Name = reader.GetString("Name"),
                            Address = reader.GetString("Address"),
                            Phone = reader.GetString("Phone")
                        });
                    }
                }
            }

            return clients;
        }

        // Ajouter un client
        public void AddClient(Client client)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO clients (Name, Address, Phone) VALUES (@Name, @Address, @Phone)";
                var command = new MySqlCommand(query, connection);

                command.Parameters.AddWithValue("@Name", client.Name);
                command.Parameters.AddWithValue("@Address", client.Address);
                command.Parameters.AddWithValue("@Phone", client.Phone);

                command.ExecuteNonQuery();
            }
        }

        // Mettre à jour un client
        public void UpdateClient(Client client)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE clients SET Name = @Name, Address = @Address, Phone = @Phone WHERE Id = @Id";
                var command = new MySqlCommand(query, connection);

                command.Parameters.AddWithValue("@Id", client.Id);
                command.Parameters.AddWithValue("@Name", client.Name);
                command.Parameters.AddWithValue("@Address", client.Address);
                command.Parameters.AddWithValue("@Phone", client.Phone);

                command.ExecuteNonQuery();
            }
        }

        // Supprimer un client
        public void DeleteClient(int id)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM clients WHERE Id = @Id";
                var command = new MySqlCommand(query, connection);

                command.Parameters.AddWithValue("@Id", id);

                command.ExecuteNonQuery();
            }
        }

        // Rechercher des clients par nom
        public List<Client> SearchClients(string searchTerm)
        {
            var clients = new List<Client>();

            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM clients WHERE Name LIKE @SearchTerm";
                var command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@SearchTerm", $"%{searchTerm}%");

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        clients.Add(new Client
                        {
                            Id = reader.GetInt32("Id"),
                            Name = reader.GetString("Name"),
                            Address = reader.GetString("Address"),
                            Phone = reader.GetString("Phone")
                        });
                    }
                }
            }

            return clients;
        }
    }
}
