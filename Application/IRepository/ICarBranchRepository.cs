using Domain.Model.Entity;
using Domain.Model.Request;

namespace Application.IRepository;

public interface ICarBranchRepository
{
    bool Add(CarBranchRequest model);
}
