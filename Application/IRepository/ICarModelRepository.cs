using Domain.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepository
{
    public interface ICarModelRepository
    {
        ICollection<CarModel> GetAllCarModel();
        
        CarModel AddNewCarModel (CarModel carModel);
    }
}
