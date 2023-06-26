using Domain2.Model.Entity;

namespace Application2.IRepository;

public interface ICarBrandRepository
{
    Task Add(CarBrand model);
}
