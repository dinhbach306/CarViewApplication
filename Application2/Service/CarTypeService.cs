using Application2;
using Application2.IService;
using Domain2.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application2.Service
{
    public class CarTypeService : ICarTypeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CarTypeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddCarType(CarType model)
        {
            await _unitOfWork.CarTypeRepository.Add(model);
            await _unitOfWork.SaveChangesAsync();
        }

        public List<string> GetAllCarTypeName()
        {
            var typeList = _unitOfWork.CarTypeRepository.GetAllTypeName();
            return typeList;
        }

        public List<CarType> GetCarTypes()
        {
            var typeList = _unitOfWork.CarTypeRepository.GetAll();
            return typeList;
        }
    }
}
