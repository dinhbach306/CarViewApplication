using Application.IRepository;
using Application.IService;
using Domain.Exceptions;
using Domain.Model.Entity;
using Domain.Model.Request;
using Infrastructures.Mapper;
using Microsoft.EntityFrameworkCore;

namespace Infrastructures.Repository;

public class CarBranchRepository : ICarBranchRepository
{
    private readonly DbSet<CarBranch> _dbSet;
    // private readonly CarBrandMapper _mapper;
    public CarBranchRepository(ApplicationDbContext context)
    {
        _dbSet = context.Set<CarBranch>();
        // _mapper = mapper;
    }

    public async Task Add(CarBranch model)
    {
        try
        {
            await _dbSet.AddAsync(model);
        }
        catch (Exception ex)
        {
            throw new BadRequestException($"Error: {ex.Message}");
        }
    }
}