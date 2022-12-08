using MediatR;
using SampleAPI.MediatR.Shared.Models.DTO;

namespace SampleAPI.MediatR.BusinessLayer.Queries;

public class GetUsersListQuery : IRequest<List<UserDTO>>
{
}