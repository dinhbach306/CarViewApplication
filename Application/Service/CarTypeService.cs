using Application.IRepository;
using Application.IService;
using Domain.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
    public class CarTypeService : ICarTypeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CarTypeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ICollection<CarType> GetListCarType()
        {
            return _unitOfWork.CarTypeRepository.GetAllCarType();
        }

        public CarType CreateNewCarType(CarType carType)
        {
            return _unitOfWork.CarTypeRepository.AddNewCarType(carType);
        }
    }
}
