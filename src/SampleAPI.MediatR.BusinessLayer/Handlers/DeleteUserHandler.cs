using MediatR;
using SampleAPI.MediatR.BusinessLayer.Commands;
using SampleAPI.MediatR.DataAccessLayer.Services;

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

        var result = await userService.DeleteUser(entity.Id);

        if (!result)
        {
            return false;
        }

        return await Task.FromResult(true);
    }
}
