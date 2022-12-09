using SampleAPI.MediatR.Shared.Models.Entities;
using SampleAPI.MediatR.Shared.Repository;

namespace SampleAPI.MediatR.DataAccessLayer.Repository;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(DataDbContext dbContext) : base(dbContext)
    {
    }
}