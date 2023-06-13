using Domain.Model.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructures.FluentApis;

public class CarSpecsConfiguration : IEntityTypeConfiguration<CarSpecs>
{
    public void Configure(EntityTypeBuilder<CarSpecs> builder)
    {
        throw new NotImplementedException();
    }
}