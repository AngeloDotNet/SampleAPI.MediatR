using SampleAPI.MediatR.DataAccessLayer.Repository.Generic;
using SampleAPI.MediatR.Shared.Models.DTO;

namespace SampleAPI.MediatR.DataAccessLayer.Repository
{
    public class UserRepository : GenericRepository<UserDTO>, IUserRepository
    {
        public UserRepository(DataDbContext dbContext) : base(dbContext)
        {
        }
    }
}