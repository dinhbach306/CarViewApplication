using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Domain2.Model.Entity.Base;
using Microsoft.AspNetCore.Http;

namespace Domain2.Model.Entity;

public class CarBrand : BaseEntity
{
    public string? Name { get; set; }
    
    [NotMapped]
    [JsonIgnore]
    public IFormFile? ImageLogo { get; set; }
    
    public string? ImageLogoUrl { get; set; }
    
    
    public ICollection<CarModel>? CarModels { get; set; }
}