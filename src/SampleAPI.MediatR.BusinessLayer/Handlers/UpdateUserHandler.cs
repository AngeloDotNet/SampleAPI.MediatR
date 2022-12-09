using MediatR;
using SampleAPI.MediatR.BusinessLayer.Commands;
using SampleAPI.MediatR.DataAccessLayer.Services;
using SampleAPI.MediatR.Shared.Models.Entities;

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
        var user = await userService.GetUserAsync(request.Id);

        if (user == null)
        {
            return false;
        }

        var entity = new User(request.Id, request.Cognome, request.Nome, request.Telefono, request.Email);

        var result = await userService.UpdateUser(entity);

        if (!result)
        {
            return false;
        }

        return await Task.FromResult(true);
    }
}
