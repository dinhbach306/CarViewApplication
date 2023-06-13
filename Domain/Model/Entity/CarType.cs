namespace Domain.Model.Entity;

public class CarType
{
    public string? Name { get; set; }
    public ICollection<CarModel>? CarModels { get; set; }
}