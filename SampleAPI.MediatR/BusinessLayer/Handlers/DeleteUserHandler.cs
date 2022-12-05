using MediatR;
using SampleAPI.MediatR.BusinessLayer.Commands;
using SampleAPI.MediatR.DataAccessLayer.Services;
using SampleAPI.MediatR.Models.Requests;

namespace SampleAPI.MediatR.BusinessLayer.Handlers;

public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, bool>
{
    private readonly IUserService userService;

    public DeleteUserHandler(IUserService userService)
    {
        this.userService = userService;
    }

    public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var entity = await userService.GetUserAsync(request.Id);

        if (entity == null)
        {
            return false;
        }

        UserRequest user = new()
        {
            Id = entity.Id,
            Cognome = entity.Cognome,
            Nome = entity.Nome,
            Telefono = entity.Telefono,
            Email = entity.Email
        };

        var result = await userService.DeleteUser(user);

        if (!result)
        {
            return false;
        }

        return await Task.FromResult(true);
    }
}
