using Domain.Model.Entity;
using Domain.Model.Request;
using Riok.Mapperly.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Mapper
{
    [Mapper]
    public partial class CarTypeMapper
    {
        public partial CarType CarTypeRequestToCar(CarTypeRequest carTypeRequest);
    }
}
