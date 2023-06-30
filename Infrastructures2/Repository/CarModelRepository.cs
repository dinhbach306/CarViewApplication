using Application2.IRepository;
using Domain2.Exceptions;
using Domain2.Model.Entity;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Infrastructures2.Repository
{
    public class CarModelRepository : ICarModelRepository
    {
        private readonly DbSet<CarModel> _dbModel;
        private readonly DbSet<CarType> _dbType;
        private readonly DbSet<CarBrand> _dbBrand;
        // private readonly CarBrandMapper _mapper;
        public CarModelRepository(ApplicationDbContext context)
        {
            _dbModel = context.Set<CarModel>();
            _dbBrand = context.Set<CarBrand>();
            _dbType = context.Set<CarType>();

            // _mapper = mapper;
        }

        public async Task Add(CarModel model)
        {
            var message = "";
            var type = _dbType.SingleOrDefault(t => t.Id == model.CarTypeId);
            var brand = _dbBrand.SingleOrDefault(b => b.Id == model.CarBrandId);
            if (type != null && brand != null)
            {
                await _dbModel.AddAsync(model);
            }
            else if (type == null)
            {
                message = "Error: Invalid type value! The value does not exist!";
                NotFoundException ex = new NotFoundException(message);
                throw ex;
            }
            else if (brand == null)
            {
                message = "Error: Invalid brand value! The value does not exist!";
                NotFoundException ex = new NotFoundException(message);
                throw ex;
            }
            else if(type == null && brand == null)
            {
                message = "Error: Invalid brand and type value! The value and type does not exist!";
                NotFoundException ex = new NotFoundException(message);
                throw ex;
            }
        }
    }
}
