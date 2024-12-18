namespace ProjetCsharp.Models
{
    public class User
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }

    public User(int id, string email, string password, string role)
    {
        Id = id;
        Email = email;
        Password = password;
        Role = role;
    }

    // Constructeur par défaut (nécessaire pour certaines utilisations)
    public User()
    {
    }
}
}
