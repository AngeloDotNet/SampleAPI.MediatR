using SampleAPI.MediatR.DataAccessLayer.Repository;

namespace SampleAPI.MediatR.DataAccessLayer.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly DataDbContext dbContext;
    public IUserRepository userRepository { get; set; }

    public UnitOfWork(DataDbContext dbContext, IUserRepository userRepository)
    {
        this.dbContext = dbContext;
        this.userRepository = userRepository;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            dbContext.Dispose();
        }
    }
}