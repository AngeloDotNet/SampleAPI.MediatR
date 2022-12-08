using SampleAPI.MediatR.DataAccessLayer.Repository;

namespace SampleAPI.MediatR.DataAccessLayer.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly DataDbContext dbContext;
    public IUserRepository Users { get; }

    public UnitOfWork(DataDbContext dbContext, IUserRepository users)
    {
        this.dbContext = dbContext;
        Users = users;
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