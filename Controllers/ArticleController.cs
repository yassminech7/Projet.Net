using System.Collections.Generic;
using MySql.Data.MySqlClient;
using ProjetCsharp.Models;

namespace ProjetCsharp.Controllers
{
    public class ArticleController
    {
        private string connectionString = "Server=localhost;Database=projetcsharp;User ID=root;Password=root;";

        // Récupérer tous les articles
        public List<Article> GetAllArticles()
        {
            var articles = new List<Article>();

            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM articles";
                var command = new MySqlCommand(query, connection);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        articles.Add(new Article
                        {
                            Id = reader.GetInt32("Id"),
                            Name = reader.GetString("Name"),
                            Price = reader.GetDouble("Price"),
                            Stock = reader.GetInt32("Stock")
                        });
                    }
                }
            }

            return articles;
        }

        // Ajouter un article
        public void AddArticle(Article article)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO articles (Name, Price, Stock) VALUES (@Name, @Price, @Stock)";
                var command = new MySqlCommand(query, connection);

                command.Parameters.AddWithValue("@Name", article.Name);
                command.Parameters.AddWithValue("@Price", article.Price);
                command.Parameters.AddWithValue("@Stock", article.Stock);

                command.ExecuteNonQuery();
            }
        }

        // Mettre à jour un article
        public void UpdateArticle(Article article)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE articles SET Name = @Name, Price = @Price, Stock = @Stock WHERE Id = @Id";
                var command = new MySqlCommand(query, connection);

                command.Parameters.AddWithValue("@Id", article.Id);
                command.Parameters.AddWithValue("@Name", article.Name);
                command.Parameters.AddWithValue("@Price", article.Price);
                command.Parameters.AddWithValue("@Stock", article.Stock);

                command.ExecuteNonQuery();
            }
        }

        // Supprimer un article
        public void DeleteArticle(int id)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM articles WHERE Id = @Id";
                var command = new MySqlCommand(query, connection);

                command.Parameters.AddWithValue("@Id", id);

                command.ExecuteNonQuery();
            }
        }

        // Rechercher des articles par nom
        public List<Article> SearchArticles(string searchTerm)
        {
            var articles = new List<Article>();

            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM articles WHERE Name LIKE @SearchTerm";
                var command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@SearchTerm", $"%{searchTerm}%");

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        articles.Add(new Article
                        {
                            Id = reader.GetInt32("Id"),
                            Name = reader.GetString("Name"),
                            Price = reader.GetDouble("Price"),
                            Stock = reader.GetInt32("Stock")
                        });
                    }
                }
            }

            return articles;
        }
    }
}
