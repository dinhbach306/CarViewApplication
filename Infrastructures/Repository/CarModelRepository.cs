using Application.IRepository;
using Domain.Model.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Repository
{
    public class CarModelRepository : ICarModelRepository
    {
        private readonly ApplicationDbContext _context;

        public CarModelRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public CarModel AddNewCarModel(CarModel carModel)
        {
            throw new NotImplementedException();
        }

        public ICollection<CarModel> GetAllCarModel()
        {
            return _context.CarModels.ToList();
        }
    }
}
