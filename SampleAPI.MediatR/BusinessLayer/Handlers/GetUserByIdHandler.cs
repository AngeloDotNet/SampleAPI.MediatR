using MediatR;
using SampleAPI.MediatR.BusinessLayer.Queries;
using SampleAPI.MediatR.Models.Response;

namespace SampleAPI.MediatR.BusinessLayer.Handlers;

public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, UserResponse>
{
    private readonly IMediator mediator;

    public GetUserByIdHandler(IMediator mediator)
    {
        this.mediator = mediator;
    }

    public async Task<UserResponse> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        List<UserResponse> users = await mediator.Send(new GetUsersListQuery(), cancellationToken);

        var result = users.FirstOrDefault(x => x.Id == request.Id);

        return result;
    }
}
