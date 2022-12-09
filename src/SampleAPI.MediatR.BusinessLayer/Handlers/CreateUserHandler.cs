using MediatR;
using SampleAPI.MediatR.BusinessLayer.Commands;
using SampleAPI.MediatR.DataAccessLayer.Services;
using SampleAPI.MediatR.Shared.Models.DTO;

namespace SampleAPI.MediatR.BusinessLayer.Handlers;

public class CreateUserHandler : IRequestHandler<CreateUserCommand, bool>
{
    private readonly IUserService userService;

    public CreateUserHandler(IUserService userService)
    {
        this.userService = userService;
    }

    public async Task<bool> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var entity = new UserDTO(0, request.Cognome, request.Nome, request.Telefono, request.Email);

        var result = await userService.CreateUser(entity);

        if (!result)
        {
            return false;
        }

        return await Task.FromResult(true);
    }
}