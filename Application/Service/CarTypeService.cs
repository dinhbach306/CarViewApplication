using Application.IRepository;
using Application.IService;
using Domain.Model.Entity;
using Domain.Model.Request;
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

        public (int Status, ICollection<CarTypeRequest>? List) GetListCarType()
        {
            try
            {
                var list = _unitOfWork.CarTypeRepository?.GetAllCarType();

                if (list == null) return (1, null);
                else return (2 , list);
            }catch(Exception ex)
            {
                return (0, null);
            }
        }

        public (int Status, String Msg) CreateNewCarType(CarTypeRequest carType)
        {
            var status = _unitOfWork.CarTypeRepository.AddNewCarType(carType);
            if (status == 0) return (status, "Error when runtime! Please try again!");//Loi he thong
            else if (status == 1) return (status, "Invalid input! Please try again!");//Loi nguoi dung
            else return (status, $"Type {carType.Name} was added successfully!!");
        }
    }
}
