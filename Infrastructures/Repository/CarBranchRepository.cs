using Application.Repository;

namespace Infrastructures.Repository;

public class CarBranchRepository : ICarBranchRepository
{
    public CarBranchRepository(ApplicationDbContext context)
    {
    }
}