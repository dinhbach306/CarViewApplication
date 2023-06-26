using Domain2.Model.Entity;

namespace Application2.IService;

public interface ICarBrandService
{
    Task AddCarBrand(CarBrand model);
}