using MediatR;
using SampleAPI.MediatR.Shared.Models.InputModels;

namespace SampleAPI.MediatR.BusinessLayer.Commands;

public class DeleteUserCommand : IRequest<bool>
{
    public int Id { get; set; }

    public DeleteUserCommand(UserDeleteInputModel inputModel)
    {
        Id = inputModel.Id;
    }
}