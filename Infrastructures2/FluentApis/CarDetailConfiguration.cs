using Domain.Model.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructures.FluentApis;

public class CarDetailConfiguration : IEntityTypeConfiguration<CarDetail>
{
    public void Configure(EntityTypeBuilder<CarDetail> builder)
    {
        builder.ToTable("car_detail_tbl");
        builder.HasKey(x => x.Id).HasName("car_detail_id");
        builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
        builder.Property(x => x.Price).HasPrecision(12, 0).IsRequired();
        builder.Property(x => x.Color).IsRequired();
        builder.Property(x => x.WheelBase).IsRequired().HasColumnType("float");
        builder.Property(x => x.Length).IsRequired().HasColumnType("float");
        builder.Property(x => x.Height).IsRequired().HasColumnType("float");
        builder.Property(x => x.Weight).IsRequired().HasColumnType("float");
        builder.Property(x => x.Version).HasDefaultValue(1);
        builder.Property(x => x.IsDeleted).HasDefaultValue(false);
        builder.HasOne<Car>(x => x.Car)
            .WithOne(x => x.CarDetail)
            .HasForeignKey<CarDetail>(x => x.CarId);
        
        builder.HasOne<CarSpecs>(x => x.CarSpecs)
            .WithOne(x => x.CarDetail)
            .HasForeignKey<CarDetail>(x => x.CarSpecsId);

        builder.HasMany(x => x.CarDetailEquipments)
            .WithOne(x => x.CarDetail)
            .OnDelete(DeleteBehavior.Cascade);
    }
}