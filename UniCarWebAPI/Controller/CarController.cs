using Application.Repository;
using Application.Service;
using Domain.Model.Entity;
using Infrastructures.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using UniCar.Endpoint;

namespace UniCar.Controller;
[ApiController]
[Route(EndpointConstant.Car.CarEndpoint)]
public class CarController : ControllerBase
{
    private readonly CarBrandService _brandService;
    private readonly CarTypeService _typeService;

    public CarController(CarBrandService carBrandService, CarTypeService carTypeService)
    {
        _brandService = carBrandService;
        _typeService = carTypeService;
    }



    //Get all brands feature
    [HttpGet]
    [Route("brands")]
    public IActionResult GetListOfBrands()
    {
        var list = _brandService.GetListOfAllBrand();
        if (!list.IsNullOrEmpty()) return StatusCode(StatusCodes.Status200OK, list);
        return StatusCode(StatusCodes.Status404NotFound);
    }



    //Add car type feature
    [HttpPost]
    [Route("types")]
    public IActionResult AddCarType(CarType type)
    {
        try
        {
            var carType = _typeService.CreateNewCarType(type);
            return StatusCode(StatusCodes.Status200OK, carType);
        }
        catch
        {
            return StatusCode(StatusCodes.Status400BadRequest);
        }
    }

}