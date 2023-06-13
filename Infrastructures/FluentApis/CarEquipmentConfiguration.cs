using Domain.Model.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructures.FluentApis;

public class CarEquipmentConfiguration : IEntityTypeConfiguration<CarEquipment>
{
    public void Configure(EntityTypeBuilder<CarEquipment> builder)
    {
        throw new NotImplementedException();
    }
}