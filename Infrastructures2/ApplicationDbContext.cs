using System.Reflection;
using Domain2.Model.Entity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructures2;

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
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opt) : base(opt) {}

}