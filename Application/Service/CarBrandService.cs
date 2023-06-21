using Application.IService;
using Domain.Model.Entity;
using Domain.Model.Request;

namespace Application.Service;

public class CarBrandService : ICarBrandService
{
    private readonly IUnitOfWork _unitOfWork;
    
    public CarBrandService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }


    public ICollection<CarBrand>? GetListOfAllBrand()
    {
        return _unitOfWork.CarBrandRepository.GetCarBrands();
    }

    public bool AddCarImage(CarBrandRequest carBrandRequest)
    {
        return _unitOfWork.CarBrandRepository.AddCarBrandImage(carBrandRequest);
    }
}