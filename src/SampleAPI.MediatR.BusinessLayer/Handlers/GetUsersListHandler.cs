using MediatR;
using SampleAPI.MediatR.BusinessLayer.Queries;
using SampleAPI.MediatR.DataAccessLayer.Services;
using SampleAPI.MediatR.Shared.Models.ViewModels;

namespace SampleAPI.MediatR.BusinessLayer.Handlers;

public class GetUsersListHandler : IRequestHandler<GetUsersListQuery, List<UserViewModel>>
{
    private readonly IUserService userService;

    public GetUsersListHandler(IUserService userService)
    {
        this.userService = userService;
    }

    public async Task<List<UserViewModel>> Handle(GetUsersListQuery request, CancellationToken cancellationToken)
    {
        var result = await userService.GetAllUsersAsync();

        return await Task.FromResult(result);
    }
}