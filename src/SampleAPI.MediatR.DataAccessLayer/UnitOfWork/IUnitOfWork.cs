using SampleAPI.MediatR.DataAccessLayer.Repository;

namespace SampleAPI.MediatR.DataAccessLayer.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    IUserRepository Users { get; }

    //int Save();
}