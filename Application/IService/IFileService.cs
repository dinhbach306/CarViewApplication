using Microsoft.AspNetCore.Http;

namespace Application.Repository;

public interface IFileService
{
    public (int Status, string Msg) SaveImage(IFormFile formFile);
    public bool DeleteImage(string fileName);
}