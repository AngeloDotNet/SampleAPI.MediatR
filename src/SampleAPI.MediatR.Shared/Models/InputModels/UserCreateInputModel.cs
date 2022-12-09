namespace SampleAPI.MediatR.Shared.Models.InputModels;

public partial class UserCreateInputModel
{
    public string Cognome { get; set; }
    public string Nome { get; set; }
    public string Telefono { get; set; }
    public string Email { get; set; }

    public UserCreateInputModel(string cognome, string nome, string telefono, string email)
    {
        Cognome = cognome;
        Nome = nome;
        Telefono = telefono;
        Email = email;
    }
}
