namespace UniCar;

public static class DependencyInjection
{
    public static void AddWebApiService(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddHttpContextAccessor();
    }
}