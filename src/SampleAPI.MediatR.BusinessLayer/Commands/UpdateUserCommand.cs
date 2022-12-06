using MediatR;

namespace SampleAPI.MediatR.BusinessLayer.Commands;

public class UpdateUserCommand : IRequest<bool>
{
    public int Id { get; set; }
    public string Cognome { get; set; }
    public string Nome { get; set; }
    public string Telefono { get; set; }
    public string Email { get; set; }

    public UpdateUserCommand(int id, string cognome, string nome, string telefono, string email)
    {
        Id = id;
        Cognome = cognome;
        Nome = nome;
        Telefono = telefono;
        Email = email;
    }
}
