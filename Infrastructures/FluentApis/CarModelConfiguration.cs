using Domain.Model.Entity;
using Infrastructures.Utils;
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
        builder.Property(x => x.Version).ValueGeneratedOnAdd().HasDefaultValue(1).IsConcurrencyToken();
        builder.Property(x => x.IsDeleted).ValueGeneratedOnAdd().HasDefaultValue(false);
        builder.Property(x => x.CreatedDate).HasColumnType("datetime")
            .ValueGeneratedOnAdd()
            .HasValueGenerator<CreatedAtTimeGenerator>();
        builder.Property(x => x.ModifiedDate).HasColumnType("datetime")
            .ValueGeneratedOnUpdate()
            .HasValueGenerator<ModifiedAtTimeGenerator>();
        
        builder.HasOne(x => x.CarType)
            .WithMany(x => x.CarModels)
            .HasForeignKey(x => x.CarTypeId);
        
        builder.HasOne(x => x.CarBranch)
            .WithMany(x => x.CarModels)
            .HasForeignKey(x => x.CarBranchId);

        builder.HasOne(x => x.CarModelSpecs)
            .WithOne(x => x.CarModelSpecs)
            .HasForeignKey<CarModel>(x => x.CarModelSpecsId);
        
        builder.HasMany(x => x.Cars)
            .WithOne(x => x.CarModel)
            .OnDelete(DeleteBehavior.Cascade);
    }
}