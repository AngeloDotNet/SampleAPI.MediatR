using MediatR;
using SampleAPI.MediatR.Shared.Models.Response;

namespace SampleAPI.MediatR.BusinessLayer.Queries;

public class GetUserByIdQuery : IRequest<UserResponse>
{
    public int Id { get; set; }

    public GetUserByIdQuery(int id)
    {
        Id = id;
    }
}