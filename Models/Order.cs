namespace ProjetCsharp.Models
{
    public class Order
    {
        public int Id { get; set; } // ID unique de la commande
        public int ClientId { get; set; } // Référence au client
        public DateTime OrderDate { get; set; } // Date de la commande
        public bool IsDelivered { get; set; } // Statut de la commande
        public List<OrderItem> OrderItems { get; set; } // Liste des articles de la commande

        public Order()
        {
            OrderItems = new List<OrderItem>();
        }
    }

    public class OrderItem
    {
        public int ArticleId { get; set; } // Référence à l'article
        public int Quantity { get; set; } // Quantité commandée
        public string ArticleName { get; set; }
    }
}
