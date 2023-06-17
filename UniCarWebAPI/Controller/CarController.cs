using Application.Repository;
using Application.Service;
using Domain.Model.Entity;
using Infrastructures.Repository;
using Microsoft.AspNetCore.Mvc;
using UniCar.Endpoint;

namespace UniCar.Controller;
[ApiController]
[Route(EndpointConstant.Car.CarEndpoint)]
public class CarController : ControllerBase
{
    private readonly CarBrandService _brandService;

    public CarController(CarBrandService carBrandService)
    {
        _brandService = carBrandService;
    }

    [HttpGet]
    [Route("brands")]
    public IActionResult GetListOfBrands()
    {
        var list = _brandService.GetListOfAllBrand();
        if (list != null) return StatusCode(StatusCodes.Status200OK, list);
        return StatusCode(StatusCodes.Status404NotFound);
    }
}