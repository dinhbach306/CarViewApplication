using Application2.IService;
using Application2.Service;
using Domain2.Exceptions;
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
    [Route(EndpointConstant.Car.CarModelEndpoint)]
    public class CarModelController : ControllerBase
    {
        private readonly ICarModelService _service;

        public CarModelController(ICarModelService service)
        {
            _service = service;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(CarModelRequest request)
        {
            try
            {
                var mapper = new CarModelMapper();
                var model = mapper.CarModelRequestToCar(request);
                await _service.AddCarModel(model);

                return StatusCode(200, new Status(HttpStatusCode.OK,
                    "Success",
                    model
                ));
            }
            catch (NotFoundException e)
            {
                return StatusCode(
                    404,
                    new Status(HttpStatusCode.NotFound,
                    "Failed",
                    e.Message
                ));
            }
        }
    }
}
