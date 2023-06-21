using Domain.Model.Entity;

namespace Application.IService;

public interface ICarBranchService
{
    Task AddCarBranch(CarBranch model);
}