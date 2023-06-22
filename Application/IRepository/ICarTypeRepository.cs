using Domain.Model.Entity;
using Domain.Model.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepository
{
    public interface ICarTypeRepository
    {
        ICollection<CarTypeRequest>? GetAllCarType();

        int AddNewCarType(CarTypeRequest model);

    }
}
