using Application.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Infrastructures;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructures(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<ApplicationDbContext>(opt =>
            opt.UseSqlServer(config.GetConnectionString("CarManagementDB")
            , b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName))
            , ServiceLifetime.Transient);

        return services;
    }

    
}
