
using Application2.IService;
using Application2.IRepository;

namespace Application2;

public interface IUnitOfWork
{
    public ICarBrandRepository CarBrandRepository { get; }
    public ICarTypeRepository CarTypeRepository { get; }
    public Task<int> SaveChangesAsync();
}