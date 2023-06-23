using Domain.Model.Entity;

namespace Application.IService;

public interface ICarBrandService
{
    Task AddCarBrand(CarBrand model);
}