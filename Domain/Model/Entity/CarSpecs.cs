namespace Domain.Model.Entity;

public class CarSpecs
{
    public string? Power { get; set; }
    public double MaximumTorque { get; set; }
    public double Acceleration { get; set; }
    public double Speed { get; set; }
    public double FuelConsumption { get; set; }
    public double Emissions { get; set; }
    public CarDetail? CarDetail { get; set; }
}