using Application2.IService;
using Domain2.Model.Request;
using Domain2.Model.Response;
using Infrastructures2.Mapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using UniCar.Endpoint;

namespace UniCar.Controller
{
    
    [ApiController]
    [Route(EndpointConstant.Car.CarTypeEndpoint)]
    public class CarTypeController : ControllerBase
    {
        private readonly ICarTypeService _carTypeService;

        public CarTypeController(ICarTypeService carTypeService)
        {
            _carTypeService = carTypeService;
        }

        [HttpPost("add")]
        public async Task<Status> Add(CarTypeRequest request)
        {
            try
            {
                var mapper = new CarTypeMapper();
                var model = mapper.CarTypeRequestToCar(request);
                await _carTypeService.AddCarType(model);

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


        [HttpGet("getAllType")]
        public Status GetAll()
        {
            try
            {
                var list = _carTypeService.GetCarTypes();

                return new Status(HttpStatusCode.OK,
                    "Success",
                    list
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


        [HttpGet("getAllTypeName")]
        public Status GetAllTypeName()
        {
            try
            {
                var list = _carTypeService.GetAllCarTypeName();

                return new Status(HttpStatusCode.OK,
                    "Success",
                    list
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
}
