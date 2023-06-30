using Domain2.Model.Entity;
using Domain2.Model.Request;
using Riok.Mapperly.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures2.Mapper
{
    [Mapper]
    public partial class CarModelMapper
    {
        public partial CarModel CarModelRequestToCar(CarModelRequest carModel);
    }
}
