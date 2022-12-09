using MediatR;
using SampleAPI.MediatR.Shared.Models.InputModels;

namespace SampleAPI.MediatR.BusinessLayer.Commands;

public class CreateUserCommand : IRequest<bool>
{
    public string Cognome { get; set; }
    public string Nome { get; set; }
    public string Telefono { get; set; }
    public string Email { get; set; }

    public CreateUserCommand(UserCreateInputModel inputModel)
    {
        Cognome = inputModel.Cognome;
        Nome = inputModel.Nome;
        Telefono = inputModel.Telefono;
        Email = inputModel.Email;
    }
}