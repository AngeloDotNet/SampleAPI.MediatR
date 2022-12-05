using MediatR;
using SampleAPI.MediatR.Models.Response;

namespace SampleAPI.MediatR.BusinessLayer.Queries;

public class GetUsersListQuery : IRequest<List<UserResponse>>
{
}