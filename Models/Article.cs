namespace ProjetCsharp.Models
{
    public class Article
    {
        public int Id { get; set; }         // ID unique de l'article
        public string Name { get; set; }    // Nom de l'article
        public double Price { get; set; }   // Prix de l'article
        public int Stock { get; set; }      // Quantité en stock

        public Article(int id, string name, double price, int stock)
    {
        Id = id;
        Name = name;
        Price = price;
        Stock = stock;
    }

    // Constructeur par défaut (nécessaire pour certaines utilisations)
    public Article()
    {
    }
    }
}
