using Application.IRepository;
using Domain.Model.Entity;
using Domain.Model.Entity.Base;
using Infrastructures.Utils;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Repository
{
    public class CarTypeRepository : ICarTypeRepository
    {
        private readonly ApplicationDbContext _context;

        public CarTypeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public CarType AddNewCarType(CarType carType)
        {
            CarType? carTypeAdd = null;
            var carTypeDB = _context.CarTypes.SingleOrDefault(c => c.Id == carType.Id);

            if(carTypeDB == null)
            {
                CreatedAtTimeGenerator createdAtTimeGenerator = new CreatedAtTimeGenerator();
                carTypeAdd = new CarType
                {
                    Id = carType.Id, 
                    Name = carType.Name,
                    CreatedDate = createdAtTimeGenerator.Next(_context.Entry(carType)).UtcDateTime,
                    ModifiedDate = createdAtTimeGenerator.Next(_context.Entry(carType)).UtcDateTime,
                    Version = 1,
                    IsDeleted = false
                };
                _context.Add(carTypeAdd);
                _context.SaveChanges();
            }
                return carTypeAdd;
        }

        public ICollection<CarType>? GetAllCarType()
        {
            var carTypes = _context.CarTypes.ToList();
            return carTypes;
        }

        
    }
}
