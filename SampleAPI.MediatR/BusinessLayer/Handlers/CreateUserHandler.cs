using MediatR;
using SampleAPI.MediatR.BusinessLayer.Commands;
using SampleAPI.MediatR.DataAccessLayer.Services;
using SampleAPI.MediatR.Models.Requests;

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
        UserRequest user = new()
        {
            Cognome = request.Cognome,
            Nome = request.Nome,
            Telefono = request.Telefono,
            Email = request.Email
        };

        var result = await userService.CreateUser(user);

        if (!result)
        {
            return false;
        }

        return await Task.FromResult(true);
    }
}