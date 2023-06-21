﻿using Domain.Model.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructures.FluentApis;

public class CarBranchConfiguration : IEntityTypeConfiguration<CarBranch>
{
    public void Configure(EntityTypeBuilder<CarBranch> builder)
    {
        builder.ToTable("car_brand_tbl");
        builder.HasKey(x => x.Id).HasName("car_brand_id");
        builder.Property(x => x.Name).IsRequired().HasMaxLength(100).IsRequired();
        builder.Property(x => x.ImageLogoUrl).HasColumnType("varchar").HasMaxLength(255);
        builder.Property(x => x.Version).HasDefaultValue(1);
        builder.Property(x => x.IsDeleted).HasDefaultValue(false);
        
        builder.HasMany(x => x.CarModels)
            .WithOne(x => x.CarBranch)
            .OnDelete(DeleteBehavior.Cascade);
    }
}