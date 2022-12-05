using MediatR;
using SampleAPI.MediatR.Models.Response;

namespace SampleAPI.MediatR.BusinessLayer.Queries;

public class GetUserByIdQuery : IRequest<UserResponse>
{
	public int Id { get; set; }

	public GetUserByIdQuery(int id)
	{
		Id = id;
	}
}