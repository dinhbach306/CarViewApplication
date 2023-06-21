using Domain.Model.Entity;
using Domain.Model.Request;

namespace Application.IService;

public interface ICarBrandService
{
    ICollection<CarBrand>? GetListOfAllBrand();
    public bool CreateCarBrandImage(CarBrandRequest carBrandRequest);
}