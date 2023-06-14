using Domain.Model.Entity;
using Infrastructures.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructures.FluentApis;

public class CarEquipmentConfiguration : IEntityTypeConfiguration<CarEquipment>
{
    public void Configure(EntityTypeBuilder<CarEquipment> builder)
    {
        builder.ToTable("car_equipment_tbl");
        builder.HasKey(x => x.Id).HasName("car_equipment_id");
        builder.Property(x => x.Version).ValueGeneratedOnAdd().HasDefaultValue(1).IsConcurrencyToken();
        builder.Property(x => x.IsDeleted).ValueGeneratedOnAdd().HasDefaultValue(false);
        builder.Property(x => x.CreatedDate).HasColumnType("datetime")
            .ValueGeneratedOnAdd()
            .HasValueGenerator<CreatedAtTimeGenerator>();
        builder.Property(x => x.ModifiedDate).HasColumnType("datetime")
            .ValueGeneratedOnUpdate()
            .HasValueGenerator<ModifiedAtTimeGenerator>();
        builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
        
        builder.HasMany(x => x.CarDetailEquipments)
            .WithOne(x => x.CarEquipment)
            .OnDelete(DeleteBehavior.Cascade);
    }
}