using Application2.IRepository;
using Domain2.Exceptions;
using Domain2.Model.Entity;
using Infrastructures2;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures2.Repository
{
    public class CarTypeRepository : ICarTypeRepository
    {
        private readonly DbSet<CarType> _dbSet;

        public CarTypeRepository(ApplicationDbContext dbSet)
        {
            _dbSet = dbSet.Set<CarType>();
        }

        public async Task Add(CarType typeModel)
        {
            try
            {
                await _dbSet.AddAsync(typeModel);
            }
            catch(Exception ex)
            {
                throw new BadRequestException($"Error: {ex.Message}");
            }
        }

        public List<CarType> GetAll()
        {
            try
            {
                var list = _dbSet.ToList();
                return list;
            }
            catch (Exception ex)
            {
                throw new BadRequestException($"Error: {ex.Message}");
            }
        }

        public List<string> GetAllTypeName()
        {
            try
            {
                var list = _dbSet.Select(t => t.Name)?.ToList();
                return list;
            }
            catch (Exception ex)
            {
                throw new BadRequestException($"Error: {ex.Message}");
            }
        }

    }
}
