using MediatR;
using SampleAPI.MediatR.Shared.Models.DTO;

namespace SampleAPI.MediatR.BusinessLayer.Commands;

public class UpdateUserCommand : IRequest<bool>
{
    public int Id { get; set; }
    public string Cognome { get; set; }
    public string Nome { get; set; }
    public string Telefono { get; set; }
    public string Email { get; set; }

    public UpdateUserCommand(UserDTO request)
    {
        Id = request.Id;
        Cognome = request.Cognome;
        Nome = request.Nome;
        Telefono = request.Telefono;
        Email = request.Email;
    }
}
