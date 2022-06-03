using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Entities.Concrete;
using Web.API.Business.Concrete;
using Web.API.Business.Abstract;

namespace Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkOrderController : ControllerBase
    {
        private IWorkOrderService _workOrderService;
        public WorkOrderController(IWorkOrderService workOrderService)
        {
            _workOrderService = workOrderService;
        }


        [HttpPost("addWorkOrder")]
        public IActionResult Add(WorkOrderRequest workOrder)
        {
            bool result = _workOrderService.Add(workOrder);

            if (result)
                return Ok();

            return BadRequest();
        }

        [HttpPost("deleteWorkOrder")]
        public IActionResult Delete([FromBody]int id)
        {
            bool result = _workOrderService.Delete(id);

            if (result)
                return Ok();

            return BadRequest();
        }

        [HttpPost("updateWorkOrder")]
        public IActionResult Update(WorkOrder workOrder)
        {
            bool result = _workOrderService.Update(workOrder);

            if (result)
                return Ok();

            return BadRequest();
        }

        [HttpPost("updateWorkOrderByChassisNumber")]
        public IActionResult UpdateByChassisNumber(WorkOrderUpdateRequest  request)
        {
            bool result = _workOrderService.UpdateByChassisNumber(request.CurrentChassisNumber, request.TargetChassisNumber);

            if (result)
                return Ok();

            return BadRequest();
        }
    }
}
