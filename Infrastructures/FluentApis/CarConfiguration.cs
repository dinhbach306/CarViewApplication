using Domain.Model.Entity;
using Infrastructures.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructures.FluentApis;

public class CarConfiguration : IEntityTypeConfiguration<Car>
{
    public void Configure(EntityTypeBuilder<Car> builder)
    {
        builder.ToTable("car_tbl");
        builder.HasKey(x => x.Id).HasName("car_id");
        builder.Property(x => x.Version).ValueGeneratedOnAdd().HasDefaultValue(1).IsConcurrencyToken();
        builder.Property(x => x.IsDeleted).ValueGeneratedOnAdd().HasDefaultValue(false);
        builder.Property(x => x.CreatedDate).HasColumnType("datetime")
            .ValueGeneratedOnAdd()
            .HasValueGenerator<CreatedAtTimeGenerator>();
        builder.Property(x => x.ModifiedDate).HasColumnType("datetime")
            .ValueGeneratedOnUpdate()
            .HasValueGenerator<ModifiedAtTimeGenerator>();

        builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
        builder.Property(x => x.Year).HasMaxLength(10).IsRequired();
        builder.Property(x => x.Description).HasMaxLength(100).IsRequired();

        builder.HasOne(x => x.CarModel)
            .WithMany(x => x.Cars)
            .HasForeignKey(x => x.CarModelId);
        
        builder.HasOne(x => x.CarDetail)
            .WithOne(x => x.Car)
            .OnDelete(DeleteBehavior.Cascade);
    }
}