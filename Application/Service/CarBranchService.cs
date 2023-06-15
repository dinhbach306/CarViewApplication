using Application.IService;

namespace Application.Service;

public class CarBranchService : ICarBranchService
{
    private readonly IUnitOfWork _unitOfWork;
    
    public CarBranchService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
}