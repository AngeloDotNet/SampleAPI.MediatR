using MediatR;
using SampleAPI.MediatR.BusinessLayer.Queries;
using SampleAPI.MediatR.DataAccessLayer.Services;
using SampleAPI.MediatR.Shared.Models.DTO;

namespace SampleAPI.MediatR.BusinessLayer.Handlers;

public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, UserDTO>
{
    private readonly IMediator mediator;
    private readonly IUserService userService;

    public GetUserByIdHandler(IMediator mediator, IUserService userService)
    {
        this.mediator = mediator;
        this.userService = userService;
    }

    public async Task<UserDTO> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        UserDTO result = await userService.GetUserAsync(request.Id);

        return await Task.FromResult(result);
    }
}
