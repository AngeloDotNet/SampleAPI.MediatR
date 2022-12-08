using MediatR;
using SampleAPI.MediatR.Shared.Models.DTO;

namespace SampleAPI.MediatR.BusinessLayer.Commands;

public class CreateUserCommand : IRequest<bool>
{
    public string Cognome { get; set; }
    public string Nome { get; set; }
    public string Telefono { get; set; }
    public string Email { get; set; }

    public CreateUserCommand(UserDTO request)
    {
        Cognome = request.Cognome;
        Nome = request.Nome;
        Telefono = request.Telefono;
        Email = request.Email;
    }
}