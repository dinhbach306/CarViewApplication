using Domain.Model.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructures.FluentApis;

public class CarModelConfiguration : IEntityTypeConfiguration<CarModel>
{
    public void Configure(EntityTypeBuilder<CarModel> builder)
    {
        builder.ToTable("car_model_tbl");
        builder.HasKey(x => x.Id).HasName("car_model_id");
        builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
        builder.Property(x => x.Version).HasDefaultValue(1);
        builder.Property(x => x.IsDeleted).HasDefaultValue(false);
       
        builder.HasOne(x => x.CarType)
            .WithMany(x => x.CarModels)
            .HasForeignKey(x => x.CarTypeId);
        
        builder.HasOne(x => x.CarBrand)
            .WithMany(x => x.CarModels)
            .HasForeignKey(x => x.CarBrandId);

        // builder.HasOne(x => x.CarModelSpecs)
        //     .WithOne(x => x.CarModelSpecs)
        //     .HasForeignKey<CarModel>(x => x.CarModelSpecsId);
        
        builder.HasMany(x => x.Cars)
            .WithOne(x => x.CarModel)
            .OnDelete(DeleteBehavior.Cascade);
    }
}