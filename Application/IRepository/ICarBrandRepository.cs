using Domain.Model.Entity;
using Domain.Model.Request;

namespace Application.Repository;

public interface ICarBrandRepository
{
    ICollection<CarBrand>? GetCarBrands();
    CarBrand? GetCarBrandById(int id);

    bool AddCarBrandImage(CarBrandRequest brandRequest);
}
