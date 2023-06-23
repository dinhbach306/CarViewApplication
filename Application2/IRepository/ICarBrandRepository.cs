using Domain.Model.Entity;

namespace Application.IRepository;

public interface ICarBrandRepository
{
    Task Add(CarBrand model);
}
