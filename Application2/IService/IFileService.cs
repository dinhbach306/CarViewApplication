using Domain.Model.Entity;

namespace Application.IService;

public interface IFileService
{
    Task<Stream> Get(string name);
}