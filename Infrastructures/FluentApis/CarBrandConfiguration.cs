﻿using Domain.Model.Entity;
using Infrastructures.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructures.FluentApis;

public class CarBrandConfiguration : IEntityTypeConfiguration<CarBrand>
{
    public void Configure(EntityTypeBuilder<CarBrand> builder)
    {
        builder.ToTable("car_brand_tbl");
        builder.HasKey(x => x.Id).HasName("car_brand_id");
        builder.Property(x => x.Name).IsRequired().HasMaxLength(100).IsRequired();
        builder.Property(x => x.ImageLogo).HasColumnType("varchar").HasMaxLength(50);
        builder.Property(x => x.Version).ValueGeneratedOnAdd().HasDefaultValue(1).IsConcurrencyToken();
        builder.Property(x => x.IsDeleted).ValueGeneratedOnAdd().HasDefaultValue(false);
        builder.Property(x => x.CreatedDate).HasColumnType("datetime")
            .ValueGeneratedOnAdd()
            .HasValueGenerator<CreatedAtTimeGenerator>();
        builder.Property(x => x.ModifiedDate).HasColumnType("datetime")
            .ValueGeneratedOnUpdate()
            .HasValueGenerator<ModifiedAtTimeGenerator>();

        builder.HasMany(x => x.CarModels)
            .WithOne(x => x.CarBrand)
            .OnDelete(DeleteBehavior.Cascade);
    }
}