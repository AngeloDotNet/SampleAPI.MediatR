namespace SampleAPI.MediatR.Shared.Models.InputModels;

public class UserEditInputModel
{
    public int Id { get; set; }
    public string Cognome { get; set; }
    public string Nome { get; set; }
    public string Telefono { get; set; }
    public string Email { get; set; }

    public UserEditInputModel(int id, string cognome, string nome, string telefono, string email)
    {
        Id = id;
        Cognome = cognome;
        Nome = nome;
        Telefono = telefono;
        Email = email;
    }
}
