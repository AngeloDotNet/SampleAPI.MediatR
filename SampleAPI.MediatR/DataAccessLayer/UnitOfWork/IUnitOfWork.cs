using SampleAPI.MediatR.DataAccessLayer.Repository;

namespace SampleAPI.MediatR.DataAccessLayer.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    IUserRepository userRepository { get; set; }
}