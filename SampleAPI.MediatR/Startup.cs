using MediatR;
using Microsoft.OpenApi.Models;
using SampleAPI.MediatR.BusinessLayer.Handlers;
using SampleAPI.MediatR.DataAccessLayer.Services;
using SampleAPI.MediatR.Extensions;

namespace SampleAPI.MediatR;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();

        services.AddSwaggerGen(config =>
        {
            config.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "SampleAPI MediatR",
                Version = "v1"
            });
        });

        services.AddDIServices(Configuration);
        services.AddScoped<IUserService, UserService>();

        services.AddMediatR(typeof(CreateUserHandler).Assembly);
    }

    public void Configure(WebApplication app)
    {
        IWebHostEnvironment env = app.Environment;
        IHostApplicationLifetime lifetime = app.Lifetime;

        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SampleAPI.MediatR v1"));
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}