using Application.IRepository;
using Domain.Model.Entity;
using Domain.Model.Entity.Base;
using Domain.Model.Request;
using Infrastructures.Mapper;
using Infrastructures.Utils;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.IdentityModel.Tokens;
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
        private readonly CarTypeMapper _mapper;
        public CarTypeRepository(ApplicationDbContext context, CarTypeMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int AddNewCarType(CarTypeRequest model)
        {
            //CarType? carTypeAdd = null;
            //var carTypeDB = _context.CarTypes?.SingleOrDefault(c => c.Id == carType.Id);

            //if(carTypeDB == null)
            //{
            //CreatedAtTimeGenerator createdAtTimeGenerator = new CreatedAtTimeGenerator();
            //carTypeAdd = new CarType
            //{
            //    Id = carType.Id, 
            //    Name = carType.Name,
            //    CreatedDate = createdAtTimeGenerator.Next(_context.Entry(carType)).UtcDateTime,
            //    ModifiedDate = createdAtTimeGenerator.Next(_context.Entry(carType)).UtcDateTime,
            //    Version = 1,
            //    IsDeleted = false
            //};
            //_context.Add(carTypeAdd);
            //_context.SaveChanges();
            //}
            try
            {
                var carType = _mapper.CarTypeRequestToCar(model);
                if (!carType.Name.IsNullOrEmpty())
                {
                    _context.CarTypes?.Add(carType);
                    _context.SaveChanges();
                    return 2;
                }
                else return 1;
            }catch(Exception ex)
            {
                return 0;
            }
        }

        public ICollection<CarTypeRequest>? GetAllCarType()
        {
            var carTypes = _context.CarTypes?.ToList();
            return (ICollection<CarTypeRequest>?)carTypes;
        }


    }
}
