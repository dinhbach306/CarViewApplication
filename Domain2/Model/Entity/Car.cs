using Domain2.Model.Entity.Base;

namespace Domain2.Model.Entity;

public class Car : BaseEntity
{
    public string? Name { get; set; }
    public string? Year { get; set; }
    public string? Description { get; set; }
    public CarDetail? CarDetail { get; set; }
    public CarModel? CarModel { get; set; }
    public int? CarModelId { get; set; }
}