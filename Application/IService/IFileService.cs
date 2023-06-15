using Microsoft.AspNetCore.Http;

namespace Application.IService;

public interface IFileService
{
    public Tuple<int, string> SaveImage(IFormFile imageFile);
    public bool DeleteImage(string imageFileName);
}