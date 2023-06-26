using Domain2.Model.Entity;
using Domain2.Model.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application2.IRepository
{
    public interface ICarTypeRepository
    {
        Task Add(CarType typeModel);
    }
}
