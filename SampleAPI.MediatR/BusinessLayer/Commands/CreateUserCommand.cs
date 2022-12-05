using MediatR;

namespace SampleAPI.MediatR.BusinessLayer.Commands;

public class CreateUserCommand : IRequest<bool>
{
    public string Cognome { get; set; }
    public string Nome { get; set; }
    public string Telefono { get; set; }
    public string Email { get; set; }

    public CreateUserCommand(string cognome, string nome, string telefono, string email)
    {
        Cognome = cognome;
        Nome = nome;
        Telefono = telefono;
        Email = email;
    }
}