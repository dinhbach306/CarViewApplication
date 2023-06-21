using Domain.Model.Entity;

namespace Application.IRepository;

public interface ICarBranchRepository
{
    Task Add(CarBranch model);
}
