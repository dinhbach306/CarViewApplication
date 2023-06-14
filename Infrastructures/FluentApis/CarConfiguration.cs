using Domain.Model.Entity;
using Infrastructures.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructures.FluentApis;

public class CarConfiguration : IEntityTypeConfiguration<Car>
{
    public void Configure(EntityTypeBuilder<Car> builder)
    {
        builder.ToTable("car_tbl");
        builder.HasKey(x => x.Id).HasName("car_id");
        builder.Property(x => x.Name).HasColumnName("name").IsRequired().HasMaxLength(50);
        builder.Property(x => x.Description).HasColumnName("description")
            .IsRequired().HasMaxLength(100);
        builder.Property(x => x.Year).HasColumnName("year").HasMaxLength(20);
        builder.Property(x => x.Version).HasColumnName("version").IsRequired()
            .ValueGeneratedOnAdd().HasDefaultValue(1).IsConcurrencyToken();
        builder.Property(x => x.CreatedDate).HasColumnType("datetime")
            .HasColumnName("date_create").ValueGeneratedOnAdd()
            .IsRequired().HasValueGenerator<CreatedAtTimeGenerator>();
        builder.Property(x => x.ModifiedDate).HasColumnType("datetime")
            .HasColumnName("date_update").ValueGeneratedOnUpdate()
            .HasValueGenerator<ModifiedAtTimeGenerator>();
    }
}