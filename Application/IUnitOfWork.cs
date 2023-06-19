using Application.IRepository;
using Application.Repository;

namespace Application;

public interface IUnitOfWork
{
    public ICarBrandRepository CarBrandRepository { get; }

    public ICarTypeRepository CarTypeRepository { get; }

    public ICarModelRepository CarModelRepository { get; }
    public IFileService FileService { get; }
    public Task<int> SaveChangesAsync();
}