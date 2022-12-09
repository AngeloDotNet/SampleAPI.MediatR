using Microsoft.EntityFrameworkCore;
using SampleAPI.MediatR.DataAccessLayer;
using SampleAPI.MediatR.DataAccessLayer.Repository;
using SampleAPI.MediatR.DataAccessLayer.Services;
using SampleAPI.MediatR.DataAccessLayer.UnitOfWork;

namespace SampleAPI.MediatR.Extensions;

public static class ServiceExtension
{
    public static IServiceCollection AddDependencyInjectionServices(this IServiceCollection services, IConfiguration configuration)
    {
        string connectionString = configuration.GetSection("ConnectionStrings").GetValue<string>("Default");

        services.AddDbContext<DataDbContext>(options =>
            options.UseSqlite(connectionString, migration =>
                migration.MigrationsAssembly(typeof(DataDbContext).Assembly.FullName))
        );

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserService, UserService>();

        return services;
    }
}