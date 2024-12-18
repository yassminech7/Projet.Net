namespace ProjetCsharp.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        // Constructeur par défaut
        public Client() { }

        // Constructeur avec paramètres
        public Client(string name, string address, string phone)
        {
            Name = name;
            Address = address;
            Phone = phone;
        }
    }
}
