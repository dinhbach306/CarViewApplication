using Domain.Model.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructures.FluentApis;

public class CarDetailConfiguration : IEntityTypeConfiguration<CarDetail>
{
    public void Configure(EntityTypeBuilder<CarDetail> builder)
    {
        throw new NotImplementedException();
    }
}