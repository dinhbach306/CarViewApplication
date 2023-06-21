using Domain.Model.Entity;
using Domain.Model.Request;
using Riok.Mapperly.Abstractions;

namespace Infrastructures.Mapper;

[Mapper]
public partial class CarBrandMapper
{
    public partial CarBranch CarBranchRequestToCar(CarBranchRequest carBranch);
}