using Application.Repository;
using Domain.Model.Entity;

namespace Infrastructures.Repository;

public class CarBrandRepository : ICarBrandRepository
{
    private readonly ApplicationDbContext _context;
    public CarBrandRepository(ApplicationDbContext context)
    {
        _context= context;
    }

    public CarBrand? GetCarBrandById(int id)
    {
        var carBrand = _context.CarBrands.SingleOrDefault(c => c.Id == id);
        return carBrand;
    }

    public ICollection<CarBrand>? GetCarBrands()
    {
        return _context.CarBrands.ToList();
    }
}