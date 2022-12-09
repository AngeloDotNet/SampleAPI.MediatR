using SampleAPI.MediatR.Shared.Models.Entities;
using SampleAPI.MediatR.Shared.Repository;

namespace SampleAPI.MediatR.DataAccessLayer.Repository;

public interface IUserRepository : IGenericRepository<User>
{
}
