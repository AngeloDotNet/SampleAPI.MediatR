using MediatR;
using SampleAPI.MediatR.Shared.Models.InputModels;

namespace SampleAPI.MediatR.BusinessLayer.Commands;

public class UpdateUserCommand : IRequest<bool>
{
    public int Id { get; set; }
    public string Cognome { get; set; }
    public string Nome { get; set; }
    public string Telefono { get; set; }
    public string Email { get; set; }

    public UpdateUserCommand(UserEditInputModel inputModel)
    {
        Id = inputModel.Id;
        Cognome = inputModel.Cognome;
        Nome = inputModel.Nome;
        Telefono = inputModel.Telefono;
        Email = inputModel.Email;
    }
}