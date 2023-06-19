using Application;
using Application.IRepository;
using Application.Repository;
using Application.Service;
using Infrastructures;
using Infrastructures.Repository;
using Microsoft.EntityFrameworkCore;

namespace UniCar;

public static class DependencyInjection
{
    public static void AddWebApiService(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddHttpContextAccessor();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<ICarBrandRepository, CarBrandRepository>();
        services.AddScoped<ICarTypeRepository, CarTypeRepository>();
        services.AddScoped<ICarModelRepository, CarModelRepository>();
        services.AddScoped<CarBrandService>();
        services.AddScoped<CarTypeService>();

    }
}