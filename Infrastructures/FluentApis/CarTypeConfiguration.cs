using Domain.Model.Entity;
using Infrastructures.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructures.FluentApis;

public class CarTypeConfiguration : IEntityTypeConfiguration<CarType>
{
    public void Configure(EntityTypeBuilder<CarType> builder)
    {
        builder.ToTable("car_type_tbl");
        builder.HasKey(k => k.Id).HasName("car_type_id");
        builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
        builder.Property(x => x.Version).ValueGeneratedOnAdd().HasDefaultValue(1).IsConcurrencyToken();
        builder.Property(x => x.IsDeleted).ValueGeneratedOnAdd().HasDefaultValue(false);
        builder.Property(x => x.CreatedDate).HasColumnType("datetime")
            .ValueGeneratedOnAdd()
            .HasValueGenerator<CreatedAtTimeGenerator>();
        builder.Property(x => x.ModifiedDate).HasColumnType("datetime")
            .ValueGeneratedOnUpdate()
            .HasValueGenerator<ModifiedAtTimeGenerator>();
        builder.HasMany(x => x.CarModels)
            .WithOne(x => x.CarType)
            .OnDelete(DeleteBehavior.Cascade);
    }
}