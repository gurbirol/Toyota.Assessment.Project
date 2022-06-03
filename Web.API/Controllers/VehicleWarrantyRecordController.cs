using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Entities.Concrete;
using Web.API.Business.Concrete;
using Web.API.Business.Abstract;

namespace Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleWarrantyRecordController : ControllerBase
    {
        private IVehicleWarrantyRecordService _vehicleWarrantyRecordService;
        public VehicleWarrantyRecordController(IVehicleWarrantyRecordService vehicleWarrantyRecordService)
        {
            _vehicleWarrantyRecordService = vehicleWarrantyRecordService;
        }

        [HttpPost("addWorkVehicleWarrantyRecord")]
        public IActionResult Add(VehicleWarrantyRequest vehicleWarrantyRecord)
        {
            bool result = _vehicleWarrantyRecordService.Add(vehicleWarrantyRecord);

            if (result)
                return Ok();

            return BadRequest();
        }

        [HttpPost("deleteVehicleWarrantyRecord")]
        public IActionResult Delete([FromBody]int id)
        {
            bool result = _vehicleWarrantyRecordService.Delete(id);

            if (result)
                return Ok();

            return BadRequest();
        }

        [HttpPost("updateVehicleWarrantyRecord")]
        public IActionResult Update(VehicleWarrantyRecord vehicleWarrantyRecord)
        {
            bool result = _vehicleWarrantyRecordService.Update(vehicleWarrantyRecord);

            if (result)
                return Ok();

            return BadRequest();
        }
    }
}
