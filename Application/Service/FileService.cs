using Application.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Application.Service;

public class FileService : IFileService
{
    private IWebHostEnvironment _environment;

    public FileService(IWebHostEnvironment environment)
    {
        _environment = environment;
    }

    public Tuple<int, string> SaveImage(IFormFile imageFile)
    {
        try
        {
            var contentPath = _environment.ContentRootPath;
            //currentPath
            var path = Path.Combine(contentPath, "Uploads");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            //Kiem tra xem co ton tai duong dan trong thu muc hay chua, neu chua thi tao moi

            // Check the allowed extenstions
            var ext = Path.GetExtension(imageFile.FileName);

            var allowedExtensions = new String[]{".jpg", ".png", ".jpeg"};

            if (!allowedExtensions.Contains(ext)) 
            {
                string msg = $"Only {string.Join(",", allowedExtensions)} extensions are allowed";

                return new Tuple<int, string>(0, msg);
            }

            string uniqueString = Guid.NewGuid().ToString();
            // we are trying to create a unique filename here

            var newFileName = uniqueString + ext;
            var fileWithPath = Path.Combine(path, newFileName);
            var stream = new FileStream(fileWithPath, FileMode.Create);
            imageFile.CopyTo(stream);
            stream.Close();
            return new Tuple<int, string>(1, newFileName);
        }
        catch (Exception e)
        {
            return new Tuple<int, string>(0, "Error has occured");
        }
    }

    public bool DeleteImage(string imageFileName)
    {
        try
        {
            var wwwPath = _environment.WebRootPath;
            var path = Path.Combine(wwwPath, "Uploads\\", imageFileName);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
                return true;
            }
            return false;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
}