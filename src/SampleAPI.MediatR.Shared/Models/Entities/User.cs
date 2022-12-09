namespace SampleAPI.MediatR.Shared.Models.Entities;

public partial class User
{
    public int Id { get; set; }
    public string Cognome { get; set; }
    public string Nome { get; set; }
    public string Telefono { get; set; }
    public string Email { get; set; }

    public User(int id, string cognome, string nome, string telefono, string email)
    {
        Id = id;
        Cognome = cognome;
        Nome = nome;
        Telefono = telefono;
        Email = email;
    }
}