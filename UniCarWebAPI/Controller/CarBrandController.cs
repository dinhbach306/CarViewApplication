using System.Net;
using Application2.IService;
using Domain2.Model.Entity;
using Domain2.Model.Request;
using Domain2.Model.Response;
using Infrastructures2.Mapper;
using Microsoft.AspNetCore.Mvc;
using UniCar.Endpoint;

namespace UniCar.Controller;
[ApiController]
[Route(EndpointConstant.Car.CarBrandEndpoint)]
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