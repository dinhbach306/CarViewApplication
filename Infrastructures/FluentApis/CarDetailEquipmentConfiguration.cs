using Domain.Model.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructures.FluentApis;

public class CarDetailEquipmentConfiguration : IEntityTypeConfiguration<CarDetailEquipment>
{
    public void Configure(EntityTypeBuilder<CarDetailEquipment> builder)
    {
        throw new NotImplementedException();
    }
}