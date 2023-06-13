using Domain.Model.Entity.Base;

namespace Domain.Model.Entity;

public class CarBranch : BaseEntity
{
    public string? Name { get; set; }
    public byte[]? ImageLogo { get; set; }
    public ICollection<CarModel>? CarModels { get; set; }
}