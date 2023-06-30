using Domain2.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain2.Model.Request
{
    public class CarModelRequest
    {
        public string? Name { get; set; }

        public int CarTypeId{ get; set; }

        public int CarBrandId { get; set; }

    }
}
