using SampleAPI.MediatR.DataAccessLayer.Repository.Generic;

namespace SampleAPI.MediatR.DataAccessLayer.Repository
{
    public class UserRepository : GenericRepository, IUserRepository
    {
        public UserRepository(DataDbContext context) : base(context)
        {
        }
    }
}