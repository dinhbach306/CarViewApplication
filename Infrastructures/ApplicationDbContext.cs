using System.Reflection;
using Domain.Model.Entity;
using Infrastructures.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructures;

public class ApplicationDbContext : DbContext
{

    // Init DBSet for each entity
    public DbSet<Car>? Cars { get; set; }
    public DbSet<CarBrand>? CarBrands { get; set; }
    public DbSet<CarDetail>? CarDetails { get; set; }
    public DbSet<CarDetailEquipment>? CarDetailEquipments { get; set; }
    public DbSet<CarEquipment>? CarEquipments { get; set; }
    public DbSet<CarImage>? CarImages { get; set; }
    public DbSet<CarModel>? CarModels { get; set; }
    public DbSet<CarSpecs>? CarSpecs { get; set; }
    public DbSet<CarType>? CarTypes { get; set; }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        //Take all configurations of entities from Infrastructures.FluentAPIs
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opt) : base(opt) {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
    {
        if (!dbContextOptionsBuilder.IsConfigured)
        {

            dbContextOptionsBuilder.UseSqlServer("Data Source=localhost; Initial Catalog=dotnet-6-crud-api; User Id=sa; Password=12345; Database=CarManagement; TrustServerCertificate=True; Trusted_Connection=True",
                b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName));
        }
    }
}