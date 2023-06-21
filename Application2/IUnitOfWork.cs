using Application.IRepository;
using Application.IService;

namespace Application;

public interface IUnitOfWork
{
    public ICarBranchRepository CarBranchRepository { get; }
    public Task<int> SaveChangesAsync();
}