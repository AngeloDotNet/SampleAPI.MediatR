using MediatR;
using SampleAPI.MediatR.Shared.Models.ViewModels;

namespace SampleAPI.MediatR.BusinessLayer.Queries;

public class GetUserByIdQuery : IRequest<UserViewModel>
{
    public int Id { get; set; }

    public GetUserByIdQuery(int id)
    {
        Id = id;
    }
}