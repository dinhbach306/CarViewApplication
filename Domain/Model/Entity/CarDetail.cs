using Domain.Model.Entity.Base;

namespace Domain.Model.Entity;

public class CarDetail : BaseEntity
{
    public string? Name { get; set; }
    public decimal? Price { get; set; }
    public string? Color { get; set; }
    public double WheelBase { get; set; }
    public double Length { get; set; }
    public double Height { get; set; }
    public double Weight { get; set; }
    public CarImage? CarImage { get; set; }
    public CarSpecs? CarSpecs { get; set; }
    public int? CarSpecsId { get; set; }
    public Car? Car { get; set; }
    public int? CarId { get; set; }
    public ICollection<CarDetailEquipment>? CarDetailEquipments { get; set; }
}