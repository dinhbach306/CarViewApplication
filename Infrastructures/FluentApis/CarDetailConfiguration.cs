using Domain.Model.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructures.FluentApis;

public class CarDetailConfiguration : IEntityTypeConfiguration<CarDetail>
{
    public void Configure(EntityTypeBuilder<CarDetail> builder)
    {
        builder.ToTable("car_detail_tbl");   
        builder.HasKey(x => x.Id).HasName("car_detail_id");
        builder.Property(x => x.Name).HasColumnName("name")
            .IsRequired().HasMaxLength(50);
        builder.Property(x => x.Price).HasColumnName("price")
            .IsRequired().HasColumnType("numeric(12,0)");
        builder.Property(x => x.Color).HasColumnName("color")
            .IsRequired().HasMaxLength(50);
        builder.Property(x => x.WheelBase).HasColumnName("wheelbase")
            .IsRequired().HasColumnType("double(10)");
        builder.Property(x => x.Length).HasColumnName("length")
            .IsRequired().HasColumnType("double(10)");
        builder.Property(x => x.Height).HasColumnName("height")
            .IsRequired().HasColumnType("double(10)");
        builder.Property(x => x.Weight).HasColumnName("weight")
            .IsRequired().HasColumnType("double(10)");

    }
}