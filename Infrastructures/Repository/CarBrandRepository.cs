using Application.Repository;
using Domain.Model.Entity;
using Domain.Model.Request;
using Infrastructures.Mapper;

namespace Infrastructures.Repository;

public class CarBrandRepository : ICarBrandRepository
{
    private readonly ApplicationDbContext _context;
    private readonly CarBrandMapper _carBrandMapper;
    public CarBrandRepository(ApplicationDbContext context, CarBrandMapper carBrandMapper)
    {
        _context= context;
        _carBrandMapper= carBrandMapper;
    }

    public CarBrand? GetCarBrandById(int id)
    {
        var carBrand = _context.CarBrands?.SingleOrDefault(c => c.Id == id);
        return carBrand;
    }

    public ICollection<CarBrand>? GetCarBrands()
    {
        return _context.CarBrands?.ToList();
    }

    public bool AddCarBrandImage(CarBrandRequest model)
    {
        try
        {
            var carBrand = _carBrandMapper.CarBrandRequestToCar(model);
            _context.CarBrands?.Add(carBrand);
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }
}