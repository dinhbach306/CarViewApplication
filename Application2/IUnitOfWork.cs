using Application.IRepository;
using Application.IService;

namespace Application;

public interface IUnitOfWork
{
    public ICarBrandRepository CarBrandRepository { get; }
    public Task<int> SaveChangesAsync();
}