using MediatR;
using SampleAPI.MediatR.BusinessLayer.Queries;
using SampleAPI.MediatR.DataAccessLayer.Services;
using SampleAPI.MediatR.Shared.Models.Response;

namespace SampleAPI.MediatR.BusinessLayer.Handlers;

public class GetUsersListHandler : IRequestHandler<GetUsersListQuery, List<UserResponse>>
{
    private readonly IUserService userService;

    public GetUsersListHandler(IUserService userService)
    {
        this.userService = userService;
    }

    public async Task<List<UserResponse>> Handle(GetUsersListQuery request, CancellationToken cancellationToken)
    {
        List<UserResponse> result = await userService.GetAllUsersAsync();

        return await Task.FromResult(result);
    }
}