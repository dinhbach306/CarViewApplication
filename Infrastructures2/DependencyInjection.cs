using Application2;
using Application2.IRepository;
using Application2.IService;
using Application2.Service;
using Azure.Storage.Blobs;
using Infrastructures.Repository;
using Infrastructures2;
using Infrastructures2.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructures2;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructures(this IServiceCollection services, IConfiguration config)
    {
        services.AddTransient<IUnitOfWork, UnitOfWork>();
        services.AddTransient<ICarBrandRepository, CarBrandRepository>();
        services.AddTransient<ICarBrandService, CarBrandService>();
        services.AddTransient<ICarTypeRepository, CarTypeRepository>();
        services.AddTransient<ICarTypeService, CarTypeService>();
        //FileService
        services.AddScoped(_ => new BlobServiceClient(config.GetConnectionString("AzureBlobStorage")));
        
        services.AddDbContext<ApplicationDbContext>(opt =>
            opt.UseSqlServer(config.GetConnectionString("CarManagementDB")));
        return services;
    }
}