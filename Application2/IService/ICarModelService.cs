using Domain2.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application2.IService
{
    public interface ICarModelService
    {
        Task AddCarModel(CarModel carModel);
    }
}
