using MediatR;
using SampleAPI.MediatR.Shared.Models.ViewModels;

namespace SampleAPI.MediatR.BusinessLayer.Queries;

public class GetUsersListQuery : IRequest<List<UserViewModel>>
{
}