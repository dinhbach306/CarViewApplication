using Domain2.Model.Entity;

namespace Application2.IService;

public interface IFileService
{
    Task<Stream> Get(string name);
}