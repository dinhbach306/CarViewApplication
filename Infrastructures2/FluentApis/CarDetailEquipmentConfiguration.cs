using Domain2.Model.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructures2.FluentApis;

public class CarDetailEquipmentConfiguration : IEntityTypeConfiguration<CarDetailEquipment>
{
    public void Configure(EntityTypeBuilder<CarDetailEquipment> builder)
    {
        builder.ToTable("car_detail_equipment_tbl");
        builder.HasKey(k => new
        {
            k.CarDetailId, k.CarEquipmentId
        });
        builder
            .HasOne(x => x.CarDetail)
            .WithMany(x => x.CarDetailEquipments)
            .HasForeignKey(x => x.CarDetailId);

        builder
            .HasOne(x => x.CarEquipment)
            .WithMany(x => x.CarDetailEquipments)
            .HasForeignKey(x => x.CarEquipmentId);
    }
}