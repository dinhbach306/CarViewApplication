using Application2.IRepository;
using Application2.IService;
using Domain2.Exceptions;
using Domain2.Model.Entity;
using Domain2.Model.Request;
using Infrastructures2;
using Infrastructures2.Mapper;
using Microsoft.EntityFrameworkCore;

namespace Infrastructures.Repository;

public class CarBrandRepository : ICarBrandRepository
{
    private readonly DbSet<CarBrand> _dbSet;
    // private readonly CarBrandMapper _mapper;
    public CarBrandRepository(ApplicationDbContext context)
    {
        _dbSet = context.Set<CarBrand>();
        // _mapper = mapper;
    }

    public async Task Add(CarBrand model)
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