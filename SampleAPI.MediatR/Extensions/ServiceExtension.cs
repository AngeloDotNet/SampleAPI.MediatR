using Microsoft.EntityFrameworkCore;
using SampleAPI.MediatR.DataAccessLayer;
using SampleAPI.MediatR.DataAccessLayer.Repository;
using SampleAPI.MediatR.DataAccessLayer.UnitOfWork;

namespace SampleAPI.MediatR.Extensions;

public static class ServiceExtension
{
    public static IServiceCollection AddDIServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContextPool<DataDbContext>(optionsBuilder =>
        {
            string connectionString = configuration.GetSection("ConnectionStrings").GetValue<string>("Default");
            optionsBuilder.UseSqlite(connectionString);
        });

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}