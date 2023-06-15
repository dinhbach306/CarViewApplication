using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace Domain.Model.Request;

public class CarBranchRequest
{
    public string? Name { get; set; }
    public string? ImageLogo { get; set; }
    public IFormFile? ImageFile { get; set; }
    // public ICollection<CarModel>? CarModels { get; set; }
}