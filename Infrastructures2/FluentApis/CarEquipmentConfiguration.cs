using Domain2.Model.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructures2.FluentApis;

public class CarEquipmentConfiguration : IEntityTypeConfiguration<CarEquipment>
{
    public void Configure(EntityTypeBuilder<CarEquipment> builder)
    {
        builder.ToTable("car_equipment_tbl");
        builder.HasKey(x => x.Id).HasName("car_equipment_id");
        builder.Property(x => x.Version).HasDefaultValue(1);
        builder.Property(x => x.IsDeleted).HasDefaultValue(false);
       
        builder.HasMany(x => x.CarDetailEquipments)
            .WithOne(x => x.CarEquipment)
            .OnDelete(DeleteBehavior.Cascade);
    }
}