using Application.Repository;
using Application.Service;
using Domain.Model.Entity;
using Domain.Model.Request;
using Domain.Model.Response;
using Infrastructures.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Runtime.InteropServices;
using UniCar.Endpoint;

namespace UniCar.Controller;
[ApiController]
[Route(EndpointConstant.Car.CarEndpoint)]
public class CarController : ControllerBase
{
    private readonly CarBrandService _brandService;
    private readonly CarTypeService _typeService;
    private readonly IFileService _fileService;

    public CarController(CarBrandService carBrandService, CarTypeService carTypeService, IFileService fileService)
    {
        _brandService = carBrandService;
        _typeService = carTypeService;
        _fileService = fileService;
    }



    //Get all brands feature
    [HttpGet]
    [Route(EndpointConstant.Car.CarBrandEndpoint)]
    public IActionResult GetListOfBrands()
    {
        var list = _brandService.GetListOfAllBrand();
        if (!list.IsNullOrEmpty()) return StatusCode(StatusCodes.Status200OK, list);
        return StatusCode(StatusCodes.Status404NotFound);
    }



    //Add car type feature
    [HttpPost]
    [Route(EndpointConstant.Car.CarTypeEndpoint)]
    public IActionResult AddCarType(CarTypeRequest type)
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

    //Get car type feature
    [HttpGet]
    [Route(EndpointConstant.Car.CarTypeEndpoint + "/getAllCarType")]
    public IActionResult GetCarType()
    {
        try
        {
            var carType = _typeService.GetListCarType();
            return StatusCode(StatusCodes.Status200OK, carType);
        }
        catch
        {
            return StatusCode(StatusCodes.Status400BadRequest);
        }
    }

    [HttpPost]
    [Route(EndpointConstant.Car.CarBrandEndpoint + "/addBrandImage")]
    public IActionResult AddBrandImage([FromForm] CarBrandRequest model) //[FromForm] is request type multipart
    {
        var status = new Status();
        if (!ModelState.IsValid)
        {
            status.StatusCode = 0;
            status.Message = "Please pass the valid data";
            return Ok(status);
        }
        if (model.ImageFile != null)
        {
            var fileResult = _fileService.SaveImage(model.ImageFile);
            if (fileResult.Status == 1)
            {
                model.ImageLogo = fileResult.Msg; // getting name of image
            }
            var carBrandResult = _brandService.CreateCarBrandImage(model);
            if (carBrandResult)
            {
                status.StatusCode = 1;
                status.Message = "Added successfully";
            }
            else
            {
                status.StatusCode = 0;
                status.Message = "Error on adding product";
            }
        }
        return Ok(status);
    }

}