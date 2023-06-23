using Application.IRepository;
using Application.IService;
using Domain.Exceptions;
using Domain.Model.Entity;
using Domain.Model.Request;
using Infrastructures.Mapper;
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