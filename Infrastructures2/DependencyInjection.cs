using Application;
using Application.IRepository;
using Application.IService;
using Application.Service;
using Azure.Storage.Blobs;
using Infrastructures.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructures;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructures(this IServiceCollection services, IConfiguration config)
    {
        services.AddTransient<IUnitOfWork, UnitOfWork>();
        services.AddTransient<ICarBrandRepository, CarBrandRepository>();
        services.AddTransient<ICarBrandService, CarBrandService>();
        
        //FileService
        services.AddScoped(_ => new BlobServiceClient(config.GetConnectionString("AzureBlobStorage")));
        
        services.AddDbContext<ApplicationDbContext>(opt =>
            opt.UseSqlServer(config.GetConnectionString("CarManagementDB")));
        return services;
    }
}