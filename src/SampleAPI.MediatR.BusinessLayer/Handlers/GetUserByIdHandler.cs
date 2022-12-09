using MediatR;
using SampleAPI.MediatR.BusinessLayer.Queries;
using SampleAPI.MediatR.DataAccessLayer.Services;
using SampleAPI.MediatR.Shared.Models.ViewModels;

namespace SampleAPI.MediatR.BusinessLayer.Handlers;

public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, UserViewModel>
{
    private readonly IUserService userService;

    public GetUserByIdHandler(IUserService userService)
    {
        this.userService = userService;
    }

    public async Task<UserViewModel> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await userService.GetUserAsync(request.Id);

        return await Task.FromResult(result);
    }
}