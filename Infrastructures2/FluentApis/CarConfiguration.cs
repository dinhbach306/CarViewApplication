using Domain.Model.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructures.FluentApis;

public class CarConfiguration : IEntityTypeConfiguration<Car>
{
    public void Configure(EntityTypeBuilder<Car> builder)
    {
        builder.ToTable("car_tbl");
        builder.HasKey(x => x.Id).HasName("car_id");
        builder.Property(x => x.Version).HasDefaultValue(1);
        builder.Property(x => x.IsDeleted).HasDefaultValue(false);

        builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
        builder.Property(x => x.Year).HasMaxLength(10).IsRequired();
        builder.Property(x => x.Description).HasMaxLength(100).IsRequired();

        builder.HasOne(x => x.CarModel)
            .WithMany(x => x.Cars)
            .HasForeignKey(x => x.CarModelId);
        
        builder.HasOne(x => x.CarDetail)
            .WithOne(x => x.Car)
            .OnDelete(DeleteBehavior.SetNull);
    }
}