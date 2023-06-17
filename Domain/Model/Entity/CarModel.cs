using Domain.Model.Entity.Base;

namespace Domain.Model.Entity;

public class CarModel : BaseEntity
{
    public string? Name { get; set; }
    public CarType? CarType { get; set; }
    public int CarTypeId { get; set; }
    public CarBrand? CarBrand { get; set; }
    public int CarBrandId { get; set; }
    // public CarModel? CarModelSpecs{ get; set; }
    // public int CarModelSpecsId{ get; set; }
    public ICollection<Car>? Cars { get; set; }
}