using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Entities.Concrete;
using Web.API.Business.Concrete;
using Web.API.Business.Abstract;

namespace Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneralController : ControllerBase
    {
        private IGeneralService _generalService;
        public GeneralController(IGeneralService generalService)
        {
            _generalService = generalService;
        }


        [HttpGet("getData")]
        public IActionResult GetData(string plateNumber, string chassisNumber)
        {
            GeneralVehicleInformation generalVehicleInformation = _generalService.GetData(plateNumber, chassisNumber);

            return Ok(generalVehicleInformation);
        }
    }
}
