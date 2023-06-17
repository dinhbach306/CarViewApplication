using Application.Repository;

namespace Application;

public interface IUnitOfWork
{
    public ICarBrandRepository CarBrandRepository { get; }
    public IFileService FileService { get; }
    public Task<int> SaveChangesAsync();
}