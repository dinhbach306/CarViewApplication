using Domain.Model.Entity;

namespace Application.Repository;

public interface ICarBrandRepository
{
    ICollection<CarBrand> GetCarBrands();
    CarBrand GetCarBrandById(int id);
}
