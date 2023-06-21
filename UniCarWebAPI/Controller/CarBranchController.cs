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
public class CarBranchController : ControllerBase
{
   
    private readonly ICarBranchService _carBranchService;
    
    public CarBranchController(ICarBranchService carBranchService)
    {
        _carBranchService = carBranchService;
    }

    [HttpPost("add")]
    public async Task<Status> Add([FromForm]CarBranchRequest request) //[FromForm] is request type multipart
    {
        try
        {
            var mapper = new CarBrandMapper();
            var model = mapper.CarBranchRequestToCar(request);
            await _carBranchService.AddCarBranch(model);
        
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