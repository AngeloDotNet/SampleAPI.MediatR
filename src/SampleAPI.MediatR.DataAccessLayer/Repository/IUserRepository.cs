using SampleAPI.MediatR.DataAccessLayer.Repository.Generic;
using SampleAPI.MediatR.Shared.Models.DTO;

namespace SampleAPI.MediatR.DataAccessLayer.Repository
{
    public interface IUserRepository : IGenericRepository<UserDTO>
    {
    }
}
