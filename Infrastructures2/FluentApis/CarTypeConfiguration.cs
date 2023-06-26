using Domain2.Model.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructures2.FluentApis;

public class CarTypeConfiguration : IEntityTypeConfiguration<CarType>
{
    public void Configure(EntityTypeBuilder<CarType> builder)
    {
        builder.ToTable("car_type_tbl");
        builder.HasKey(k => k.Id).HasName("car_type_id");
        builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
        builder.Property(x => x.Version).HasDefaultValue(1);
        builder.Property(x => x.IsDeleted).HasDefaultValue(false);
        
        builder.HasMany(x => x.CarModels)
            .WithOne(x => x.CarType)
            .OnDelete(DeleteBehavior.Cascade);
    }
}