using Application.IRepository;
using Application.IService;

namespace Application;

public interface IUnitOfWork
{
    public ICarBranchRepository CarBranchRepository { get; }
    public IFileService FileService { get; }
    public Task<int> SaveChangesAsync();
}