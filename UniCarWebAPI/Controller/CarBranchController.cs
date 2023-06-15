using Application;
using Application.IService;
using Domain.Model.Entity;
using Domain.Model.Request;
using Domain.Model.Response;
using Microsoft.AspNetCore.Mvc;
using UniCar.Endpoint;

namespace UniCar.Controller;
[ApiController]
[Route(EndpointConstant.Car.CarBranchEndpoint)]
public class CarBranchController : ControllerBase
{
    private readonly IFileService _fileService;
    private readonly IUnitOfWork _unitOfWork;
    
    public CarBranchController(IUnitOfWork unitOfWork, IFileService fileService)
    {
        _unitOfWork = unitOfWork;
        _fileService = fileService;
    }
    
    [HttpPost("add")]
    public IActionResult Add([FromForm]CarBranchRequest model) //[FromForm] is request type multipart
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
            if (fileResult.Item1 == 1)
            {
                model.ImageLogo = fileResult.Item2; // getting name of image
            }
            var carBrandResult = _unitOfWork.CarBranchRepository.Add(model);
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