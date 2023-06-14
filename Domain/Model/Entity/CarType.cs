using Domain.Model.Entity.Base;

namespace Domain.Model.Entity;

public class CarType : BaseEntity
{
    public string? Name { get; set; }
    public ICollection<CarModel>? CarModels { get; set; }
}