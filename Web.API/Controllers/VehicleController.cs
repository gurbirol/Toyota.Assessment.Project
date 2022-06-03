using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Entities.Concrete;
using Web.API.Business.Concrete;
using Web.API.Business.Abstract;

namespace Web.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private IVehicleService _vehicleService;
        public VehicleController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }


        [HttpPost("addVehicle")]
        public IActionResult Add(VehicleAddRequest vehicle)
        {
            var checkVehicle = _vehicleService.Getlist().Where(x => x.ChassisNumber == vehicle.ChassisNumber);
            bool result = false;
            if (!checkVehicle.Any())
            {
                result = _vehicleService.Add(vehicle);
            }

            if (result)
                return Ok();

            return BadRequest();
        }

        [HttpPost("deleteVehicle")]
        public IActionResult Delete([FromBody] int id)
        {
            bool result = _vehicleService.Delete(id);

            if (result)
                return Ok();

            return BadRequest();
        }

        [HttpPost("updateVehicle")]
        public IActionResult Update(Vehicle vehicle)
        {
            bool result = _vehicleService.Update(vehicle);

            if (result)
                return Ok();

            return BadRequest();
        }

        [HttpGet("getListVehicle")]
        public IActionResult GetList()
        {
            List<Vehicle> list = _vehicleService.Getlist();
            return Ok(list);
        }
    }
}
