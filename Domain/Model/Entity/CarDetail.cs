using Domain.Model.Entity.Base;

namespace Domain.Model.Entity;

public class CarDetail : BaseEntity
{
    public string? Name { get; set; }
    public decimal? Price { get; set; }
    public string? Color { get; set; }
    public float WheelBase { get; set; }
    public float Length { get; set; }
    public float Height { get; set; }
    public float Weight { get; set; }
    public CarImage? CarImage { get; set; }
    public CarSpecs? CarSpecs { get; set; }
    public int? CarSpecsId { get; set; }
    public Car? Car { get; set; }
    public int? CarId { get; set; }
    public ICollection<CarDetailEquipment>? CarDetailEquipments { get; set; }
}