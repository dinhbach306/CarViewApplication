using Domain.Model.Entity.Base;

namespace Domain.Model.Entity;

public class CarEquipment: BaseEntity
{
    public string? Name { get; set; }

    public ICollection<CarDetailEquipment>? CarDetailEquipments { get; set; }
}