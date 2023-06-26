using Domain2.Model.Entity.Base;

namespace Domain2.Model.Entity;

public class CarEquipment: BaseEntity
{
    public string? Name { get; set; }

    public ICollection<CarDetailEquipment>? CarDetailEquipments { get; set; }
}