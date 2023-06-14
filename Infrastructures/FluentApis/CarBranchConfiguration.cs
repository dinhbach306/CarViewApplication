using Domain.Model.Entity;
using Infrastructures.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructures.FluentApis;

public class CarBranchConfiguration : IEntityTypeConfiguration<CarBranch>
{
    public void Configure(EntityTypeBuilder<CarBranch> builder)
    {
        builder.ToTable("car_brand_tbl");
        builder.HasKey(x => x.Id).HasName("car_brand_id");
        builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
        builder.Property(x => x.ImageLogo).HasColumnType("varbinary(100)");
        builder.Property(x => x.Version).ValueGeneratedOnAdd().HasDefaultValue(1).IsConcurrencyToken();
        builder.Property(x => x.CreatedDate).HasColumnType("datetime")
            .ValueGeneratedOnAdd()
            .HasValueGenerator<CreatedAtTimeGenerator>();
        builder.Property(x => x.ModifiedDate).HasColumnType("datetime")
            .ValueGeneratedOnUpdate()
            .HasValueGenerator<ModifiedAtTimeGenerator>();
        
    }
}