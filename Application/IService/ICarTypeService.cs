using Domain.Model.Entity;
using Domain.Model.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IService
{
    public interface ICarTypeService
    {
        public (int Status, ICollection<CarTypeRequest>? List) GetListCarType();

        public (int Status, string Msg) CreateNewCarType(CarTypeRequest carType);
    }
}
