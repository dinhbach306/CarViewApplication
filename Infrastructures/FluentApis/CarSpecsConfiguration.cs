using Domain.Model.Entity;
using Infrastructures.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructures.FluentApis;

public class CarSpecsConfiguration : IEntityTypeConfiguration<CarSpecs>
{
    public void Configure(EntityTypeBuilder<CarSpecs> builder)
    {
        builder.ToTable("car_specs_tbl");
        builder.HasKey(x => x.Id).HasName("car_specs_id");
        builder.Property(x => x.Version).ValueGeneratedOnAdd().HasDefaultValue(1).IsConcurrencyToken();
        builder.Property(x => x.IsDeleted).ValueGeneratedOnAdd().HasDefaultValue(false);
        builder.Property(x => x.CreatedDate).HasColumnType("datetime")
            .ValueGeneratedOnAdd()
            .HasValueGenerator<CreatedAtTimeGenerator>();
        builder.Property(x => x.ModifiedDate).HasColumnType("datetime")
            .ValueGeneratedOnUpdate()
            .HasValueGenerator<ModifiedAtTimeGenerator>();
        builder.Property(x => x.Power).IsRequired().HasMaxLength(100);
        builder.Property(x => x.MaximumTorque).IsRequired().HasPrecision(4, 2);
        builder.Property(x => x.Acceleration).IsRequired().HasPrecision(4, 2);
        builder.Property(x => x.Speed).IsRequired().HasPrecision(4, 2);
        builder.Property(x => x.FuelConsumption).IsRequired().HasPrecision(4, 2);
        builder.Property(x => x.Emissions).IsRequired().HasPrecision(4, 2);
        
        builder.HasOne(x => x.CarDetail)
            .WithOne(x => x.CarSpecs)
            .OnDelete(DeleteBehavior.Cascade);
    }
}