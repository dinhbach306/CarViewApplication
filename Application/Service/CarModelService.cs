using Application.IService;
using Domain.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
    public class CarModelService : ICarModelService
    {
        private readonly IUnitOfWork unitOfWork;

        public CarModel CreateCarModel(CarModel carModel)
        {
            throw new NotImplementedException();
        }

        public ICollection<CarModel> GetListCarModel()
        {
           return unitOfWork.CarModelRepository.GetAllCarModel();
        }
    }
}
