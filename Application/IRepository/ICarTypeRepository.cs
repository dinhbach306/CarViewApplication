﻿using Domain.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepository
{
    public interface ICarTypeRepository
    {
        ICollection<CarType>? GetAllCarType();

        CarType AddNewCarType(CarType carType);

    }
}