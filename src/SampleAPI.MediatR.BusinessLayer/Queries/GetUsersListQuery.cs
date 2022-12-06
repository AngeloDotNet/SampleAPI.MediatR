using MediatR;
using SampleAPI.MediatR.Shared.Models.Response;

namespace SampleAPI.MediatR.BusinessLayer.Queries;

public class GetUsersListQuery : IRequest<List<UserResponse>>
{
}