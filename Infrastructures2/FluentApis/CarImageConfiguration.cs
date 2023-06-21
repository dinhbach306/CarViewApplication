using Domain.Model.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructures.FluentApis;

public class CarImageConfiguration : IEntityTypeConfiguration<CarImage>
{
    public void Configure(EntityTypeBuilder<CarImage> builder)
    {
        builder.ToTable("car_image_tbl");
        builder.HasKey(x => x.Id).HasName("car_image_id");
        builder.Property(x => x.Version).HasDefaultValue(1);
        builder.Property(x => x.IsDeleted).HasDefaultValue(false);
       
        builder.Property(x => x.ImageCar1).HasColumnType("varchar");
        builder.Property(x => x.ImageCar2).HasColumnType("varchar");
        builder.Property(x => x.ImageCar3).HasColumnType("varchar");
        builder.Property(x => x.ImageCar4).HasColumnType("varchar");
        builder.Property(x => x.ImageCar5).HasColumnType("varchar");

        builder.HasOne(x => x.CarDetail)
            .WithOne(x => x.CarImage)
            .HasForeignKey<CarImage>(x => x.CarDetailId);

    }
}