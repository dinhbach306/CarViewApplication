using Domain.Model.Entity;

namespace Application.IService;

public interface ICarBrandService
{
    ICollection<CarBrand> GetListOfAllBrand();
}