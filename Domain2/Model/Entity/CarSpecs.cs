using Domain2.Model.Entity.Base;

namespace Domain2.Model.Entity;

public class CarSpecs : BaseEntity
{
    public string? Power { get; set; }
    public decimal MaximumTorque { get; set; }
    public decimal Acceleration { get; set; }
    public decimal Speed { get; set; }
    public decimal FuelConsumption { get; set; }
    public decimal Emissions { get; set; }
    public CarDetail? CarDetail { get; set; }
}