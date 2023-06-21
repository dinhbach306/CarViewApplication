using Microsoft.AspNetCore.Http;

namespace Application.Repository;

public interface IFileService
{
    public Tuple<int, string> SaveImage(IFormFile formFile);
    public bool DeleteImage(string fileName);
}