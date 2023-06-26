using Domain2.Model.Entity;
using Domain2.Model.Request;
using Riok.Mapperly.Abstractions;

namespace Infrastructures2.Mapper;

[Mapper]
public partial class CarBrandMapper
{
    public partial CarBrand CarBrandRequestToCar(CarBrandRequest carBrand);
}