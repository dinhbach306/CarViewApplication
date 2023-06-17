using System.ComponentModel.DataAnnotations.Schema;
using Domain.Model.Entity.Base;
using Microsoft.AspNetCore.Http;

namespace Domain.Model.Entity;

public class CarBrand : BaseEntity
{
    public string? Name { get; set; }
    public string? ImageLogo { get; set; }
    public ICollection<CarModel>? CarModels { get; set; }
    
    [NotMapped]
    public IFormFile? ImageFile { get; set; }
}