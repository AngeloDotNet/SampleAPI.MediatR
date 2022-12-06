using MediatR;
using SampleAPI.MediatR.BusinessLayer.Commands;
using SampleAPI.MediatR.DataAccessLayer.Services;
using SampleAPI.MediatR.Shared.Models.Requests;

namespace SampleAPI.MediatR.BusinessLayer.Handlers;

public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, bool>
{
    private readonly IUserService userService;

    public UpdateUserHandler(IUserService userService)
    {
        this.userService = userService;
    }

    public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
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

        var result = await userService.UpdateUser(user);

        if (!result)
        {
            return false;
        }

        return await Task.FromResult(true);
    }
}
