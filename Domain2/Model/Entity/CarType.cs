using Domain2.Model.Entity.Base;

namespace Domain2.Model.Entity;

public class CarType : BaseEntity
{
    public string? Name { get; set; }
    public ICollection<CarModel>? CarModels { get; set; }
}