using MediatR;
using SampleAPI.MediatR.BusinessLayer.Commands;
using SampleAPI.MediatR.DataAccessLayer.Services;
using SampleAPI.MediatR.Shared.Models.DTO;

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

        UserDTO user = new()
        {
            Id = request.Id,
            Cognome = request.Cognome,
            Nome = request.Nome,
            Telefono = request.Telefono,
            Email = request.Email
        };

        var result = await userService.UpdateUser(user);

        if (!result)
        {
            return false;
        }

        return await Task.FromResult(true);
    }
}
