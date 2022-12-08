using MediatR;
using SampleAPI.MediatR.BusinessLayer.Queries;
using SampleAPI.MediatR.DataAccessLayer.Services;
using SampleAPI.MediatR.Shared.Models.DTO;

namespace SampleAPI.MediatR.BusinessLayer.Handlers;

public class GetUsersListHandler : IRequestHandler<GetUsersListQuery, List<UserDTO>>
{
    private readonly IUserService userService;

    public GetUsersListHandler(IUserService userService)
    {
        this.userService = userService;
    }

    public async Task<List<UserDTO>> Handle(GetUsersListQuery request, CancellationToken cancellationToken)
    {
        List<UserDTO> result = await userService.GetAllUsersAsync();

        return await Task.FromResult(result);
    }
}