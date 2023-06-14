using Domain.Model.Entity;
using Infrastructures.Utils;
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
        builder.Property(x => x.WheelBase).IsRequired();
        builder.Property(x => x.Length).IsRequired().HasColumnType("double(10)");
        builder.Property(x => x.Height).IsRequired().HasColumnType("double(10)");
        builder.Property(x => x.Weight).IsRequired().HasColumnType("double(10)");
        builder.Property(x => x.Version).ValueGeneratedOnAdd().HasDefaultValue(1).IsConcurrencyToken();
        builder.Property(x => x.IsDeleted).ValueGeneratedOnAdd().HasDefaultValue(false);
        builder.Property(x => x.CreatedDate).HasColumnType("datetime")
            .ValueGeneratedOnAdd()
            .HasValueGenerator<CreatedAtTimeGenerator>();
        builder.Property(x => x.ModifiedDate).HasColumnType("datetime")
            .ValueGeneratedOnUpdate()
            .HasValueGenerator<ModifiedAtTimeGenerator>();

        builder.HasOne(x => x.Car)
            .WithOne(x => x.CarDetail)
            .HasForeignKey<CarDetail>(x => x.CarId);
        
        builder.HasOne(x => x.CarSpecs)
            .WithOne(x => x.CarDetail)
            .HasForeignKey<CarDetail>(x => x.CarSpecsId);

        builder.HasMany(x => x.CarDetailEquipments)
            .WithOne(x => x.CarDetail)
            .OnDelete(DeleteBehavior.Cascade);
    }
}