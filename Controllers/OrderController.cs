using MySql.Data.MySqlClient;
using ProjetCsharp.Models;
using System;
using System.Collections.Generic;

namespace ProjetCsharp.Controllers
{
    public class OrderController
    {
        private string connectionString = "Server=localhost;Database=projetcsharp;User ID=root;Password=root;";

        // Créer une commande
        // Dans OrderController, dans la méthode CreateOrder
public void CreateOrder(Order order)
{
    using (var connection = new MySqlConnection(connectionString))
    {
        connection.Open();
        using (var transaction = connection.BeginTransaction())
        {
            try
            {
                // Insérer la commande
                var orderQuery = "INSERT INTO Orders (ClientId, OrderDate, IsDelivered) VALUES (@ClientId, @OrderDate, @IsDelivered)";
                var orderCommand = new MySqlCommand(orderQuery, connection, transaction);

                orderCommand.Parameters.AddWithValue("@ClientId", order.ClientId);
                orderCommand.Parameters.AddWithValue("@OrderDate", order.OrderDate);
                orderCommand.Parameters.AddWithValue("@IsDelivered", order.IsDelivered);

                orderCommand.ExecuteNonQuery();
                int orderId = (int)orderCommand.LastInsertedId;

                // Vérification des articles
                Console.WriteLine($"Order ID: {orderId}, Number of items: {order.OrderItems.Count}");

                // Insérer les articles de la commande
                foreach (var item in order.OrderItems)
                {
                    var itemQuery = "INSERT INTO OrderItems (OrderId, ArticleId, Quantity, ArticleName) VALUES (@OrderId, @ArticleId, @Quantity, @ArticleName)";
                    var itemCommand = new MySqlCommand(itemQuery, connection, transaction);

                    itemCommand.Parameters.AddWithValue("@OrderId", orderId);
                    itemCommand.Parameters.AddWithValue("@ArticleId", item.ArticleId);
                    itemCommand.Parameters.AddWithValue("@Quantity", item.Quantity);
                    itemCommand.Parameters.AddWithValue("@ArticleName", item.ArticleName);  // Ajout du nom de l'article

                    itemCommand.ExecuteNonQuery();
                }

                transaction.Commit();
                Console.WriteLine("Transaction committed successfully.");
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }
    }
}


        // Récupérer toutes les commandes
        public List<Order> GetAllOrders()
{
    var orders = new List<Order>();

    using (var connection = new MySqlConnection(connectionString))
    {
        connection.Open();

        // Récupérer les commandes
        var orderQuery = "SELECT * FROM Orders";
        var orderCommand = new MySqlCommand(orderQuery, connection);

        using (var reader = orderCommand.ExecuteReader())
        {
            while (reader.Read())
            {
                orders.Add(new Order
                {
                    Id = reader.GetInt32("Id"),
                    ClientId = reader.GetInt32("ClientId"),
                    OrderDate = reader.GetDateTime("OrderDate"),
                    IsDelivered = reader.GetBoolean("IsDelivered")
                });
            }
        }

        // Récupérer les articles pour chaque commande, avec les noms des articles
        foreach (var order in orders)
        {
            var itemQuery = @"
                SELECT oi.ArticleId, oi.Quantity, a.Name AS ArticleName
                FROM OrderItems oi
                JOIN Articles a ON oi.ArticleId = a.Id
                WHERE oi.OrderId = @OrderId";
            var itemCommand = new MySqlCommand(itemQuery, connection);
            itemCommand.Parameters.AddWithValue("@OrderId", order.Id);

            using (var reader = itemCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    order.OrderItems.Add(new OrderItem
                    {
                        ArticleId = reader.GetInt32("ArticleId"),
                        Quantity = reader.GetInt32("Quantity"),
                        ArticleName = reader.GetString("ArticleName") // Récupérer le nom de l'article
                    });
                }
            }
        }
    }

    return orders;
}


        // Mettre à jour le statut de livraison
        public void UpdateOrderStatus(int orderId, bool isDelivered)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "UPDATE Orders SET IsDelivered = @IsDelivered WHERE Id = @OrderId";
                var command = new MySqlCommand(query, connection);

                command.Parameters.AddWithValue("@OrderId", orderId);
                command.Parameters.AddWithValue("@IsDelivered", isDelivered);

                command.ExecuteNonQuery();
            }
        }

        public void DeleteOrder(int orderId)
{
    using (var connection = new MySqlConnection(connectionString))
    {
        connection.Open();
        
        // Supprimer d'abord les articles associés à la commande
        var deleteItemsQuery = "DELETE FROM OrderItems WHERE OrderId = @OrderId";
        using (var deleteItemsCommand = new MySqlCommand(deleteItemsQuery, connection))
        {
            deleteItemsCommand.Parameters.AddWithValue("@OrderId", orderId);
            deleteItemsCommand.ExecuteNonQuery();
        }
        
        // Ensuite, supprimer la commande
        var deleteOrderQuery = "DELETE FROM Orders WHERE Id = @OrderId";
        using (var deleteOrderCommand = new MySqlCommand(deleteOrderQuery, connection))
        {
            deleteOrderCommand.Parameters.AddWithValue("@OrderId", orderId);
            deleteOrderCommand.ExecuteNonQuery();
        }
    }
}

public void UpdateOrder(Order order)
{
    using (var connection = new MySqlConnection(connectionString))
    {
        connection.Open();

        // Mettre à jour les détails de la commande
        var query = "UPDATE Orders SET ClientId = @ClientId, OrderDate = @OrderDate, IsDelivered = @IsDelivered WHERE Id = @OrderId";
        var command = new MySqlCommand(query, connection);

        command.Parameters.AddWithValue("@OrderId", order.Id);
        command.Parameters.AddWithValue("@ClientId", order.ClientId);
        command.Parameters.AddWithValue("@OrderDate", order.OrderDate);
        command.Parameters.AddWithValue("@IsDelivered", order.IsDelivered);

        command.ExecuteNonQuery();

        // Mettre à jour ou insérer les articles de la commande
        foreach (var item in order.OrderItems)
        {
            // Vérifier si l'article existe déjà dans OrderItems
            var checkQuery = "SELECT COUNT(*) FROM OrderItems WHERE OrderId = @OrderId AND ArticleId = @ArticleId";
            var checkCommand = new MySqlCommand(checkQuery, connection);
            checkCommand.Parameters.AddWithValue("@OrderId", order.Id);
            checkCommand.Parameters.AddWithValue("@ArticleId", item.ArticleId);

            var exists = Convert.ToInt32(checkCommand.ExecuteScalar()) > 0;

            if (exists)
            {
                // Mettre à jour l'article existant
                var updateQuery = "UPDATE OrderItems SET Quantity = @Quantity WHERE OrderId = @OrderId AND ArticleId = @ArticleId";
                var updateCommand = new MySqlCommand(updateQuery, connection);
                updateCommand.Parameters.AddWithValue("@OrderId", order.Id);
                updateCommand.Parameters.AddWithValue("@ArticleId", item.ArticleId);
                updateCommand.Parameters.AddWithValue("@Quantity", item.Quantity);
                updateCommand.ExecuteNonQuery();
            }
            else
            {
                // Insérer un nouvel article
                var insertQuery = "INSERT INTO OrderItems (OrderId, ArticleId, Quantity, ArticleName) VALUES (@OrderId, @ArticleId, @Quantity, @ArticleName)";
                var insertCommand = new MySqlCommand(insertQuery, connection);
                insertCommand.Parameters.AddWithValue("@OrderId", order.Id);
                insertCommand.Parameters.AddWithValue("@ArticleId", item.ArticleId);
                insertCommand.Parameters.AddWithValue("@Quantity", item.Quantity);
                insertCommand.Parameters.AddWithValue("@ArticleName", item.ArticleName);
                insertCommand.ExecuteNonQuery();
            }
        }
    }
}



public void UpdateOrderItem(int orderId, OrderItem updatedItem)
{
    using (var connection = new MySqlConnection(connectionString))
    {
        connection.Open();
        var query = "UPDATE OrderItems SET Quantity = @Quantity WHERE OrderId = @OrderId AND ArticleId = @ArticleId";
        using (var command = new MySqlCommand(query, connection))
        {
            command.Parameters.AddWithValue("@Quantity", updatedItem.Quantity);
            command.Parameters.AddWithValue("@OrderId", orderId);
            command.Parameters.AddWithValue("@ArticleId", updatedItem.ArticleId);

            var rowsAffected = command.ExecuteNonQuery();
            if (rowsAffected == 0)
            {
                throw new Exception("No rows were updated. Please verify the OrderId and ArticleId.");
            }
        }
    }
}

public void DeleteOrderItem(int orderId, int articleId)
{
    using (var connection = new MySqlConnection(connectionString))
    {
        connection.Open();
        var query = "DELETE FROM OrderItems WHERE OrderId = @OrderId AND ArticleId = @ArticleId";
        using (var command = new MySqlCommand(query, connection))
        {
            command.Parameters.AddWithValue("@OrderId", orderId);
            command.Parameters.AddWithValue("@ArticleId", articleId);

            var rowsAffected = command.ExecuteNonQuery();
            if (rowsAffected == 0)
            {
                throw new Exception("No rows were deleted. Please verify the OrderId and ArticleId.");
            }
        }
    }
}



    }
}
