using Domain.Model.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructures.FluentApis;

public class CarModelConfiguration : IEntityTypeConfiguration<CarModel>
{
    public void Configure(EntityTypeBuilder<CarModel> builder)
    {
        builder.ToTable("car_model_tbl");
        builder.HasKey(x => x.Id).HasName("car_model_id");
        builder.HasOne(x => x.CarBranch)
            .WithMany(x => x.CarModels)
            .HasForeignKey(x => x.CarBranchId);
    }
}