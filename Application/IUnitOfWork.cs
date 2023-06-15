using Application.Repository;

namespace Application;

public interface IUnitOfWork
{
    public ICarBranchRepository CarBranchRepository { get; }
    public IFileService FileService { get; }
    public Task<int> SaveChangesAsync();
}