using Application2.IService;
using Domain2.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application2.Service
{
    public class CarModelService : ICarModelService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CarModelService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddCarModel(CarModel model)
        {
            await _unitOfWork.CarModelRepository.Add(model);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
