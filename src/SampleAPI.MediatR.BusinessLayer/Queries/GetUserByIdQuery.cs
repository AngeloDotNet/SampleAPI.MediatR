using MediatR;
using SampleAPI.MediatR.Shared.Models.DTO;

namespace SampleAPI.MediatR.BusinessLayer.Queries;

public class GetUserByIdQuery : IRequest<UserDTO>
{
    public int Id { get; set; }

    public GetUserByIdQuery(int id)
    {
        Id = id;
    }
}