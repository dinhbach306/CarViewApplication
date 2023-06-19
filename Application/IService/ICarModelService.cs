using Domain.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IService
{
    public interface ICarModelService
    {
        ICollection<CarModel> GetListCarModel();
        CarModel CreateCarModel(CarModel carModel);
    }
}
