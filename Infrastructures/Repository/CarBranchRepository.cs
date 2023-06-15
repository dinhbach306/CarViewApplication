using Application.IRepository;
using Domain.Model.Entity;
using Domain.Model.Request;
using Infrastructures.Mapper;
using Microsoft.EntityFrameworkCore;

namespace Infrastructures.Repository;

public class CarBranchRepository : ICarBranchRepository
{
    private readonly DbSet<CarBranch> _dbSet;
    private readonly CarBrandMapper _mapper;
    public CarBranchRepository(ApplicationDbContext context, CarBrandMapper mapper)
    {
        _dbSet = context.Set<CarBranch>();
        _mapper = mapper;
    }

    public bool Add(CarBranchRequest model)
    {
        try
        {
            var carBranch = _mapper.CarBranchRequestToCar(model);
            _dbSet.Add(carBranch);
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
}