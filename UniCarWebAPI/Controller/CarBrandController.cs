using System.Net;
using Application.IService;
using Domain.Model.Entity;
using Domain.Model.Request;
using Domain.Model.Response;
using Infrastructures.Mapper;
using Microsoft.AspNetCore.Mvc;
using UniCar.Endpoint;

namespace UniCar.Controller;
[ApiController]
[Route(EndpointConstant.Car.CarBranchEndpoint)]
public class CarBrandController : ControllerBase
{
   
    private readonly ICarBrandService _carBrandService;
    
    public CarBrandController(ICarBrandService carBrandService)
    {
        _carBrandService = carBrandService;
    }

    [HttpPost("add")]
    public async Task<Status> Add([FromForm]CarBrandRequest request) //[FromForm] is request type multipart
    {
        try
        {
            var mapper = new CarBrandMapper();
            var model = mapper.CarBrandRequestToCar(request);
            await _carBrandService.AddCarBrand(model);
        
            return new Status(HttpStatusCode.OK,
                "Success",
                model
            );
        }
        catch (Exception e)
        {
            return new Status(HttpStatusCode.InternalServerError,
                "Failed",
                e.Message
            );
        }
    }
}