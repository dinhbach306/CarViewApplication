using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace Domain.Model.Request;

public class CarBranchRequest
{
    public string? Name { get; set; }
    
    [NotMapped]
    public IFormFile? ImageLogo { get; set; }
    
}