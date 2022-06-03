using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Entities.Concrete;
using Web.API.Business.Concrete;
using Web.API.Business.Abstract;


namespace Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkOrderOperationController : ControllerBase
    {
        private IWorkOrderOperationService _workOrderOperationService;
        public WorkOrderOperationController(IWorkOrderOperationService workOrderOperationService)
        {
            _workOrderOperationService = workOrderOperationService;
        }

        [HttpPost("addWorkOrderOperation")]
        public IActionResult Add(WorkOrderOperationRequest workOrderOperation)
        {
            bool result = _workOrderOperationService.Add(workOrderOperation);

            if (result)
                return Ok();

            return BadRequest();
        }

        [HttpPost("deleteWorkOrderOperation")]
        public IActionResult Delete([FromBody]int id)
        {
            bool result = _workOrderOperationService.Delete(id);

            if (result)
                return Ok();

            return BadRequest();
        }

        [HttpPost("updateWorkOrderOperation")]
        public IActionResult Update(WorkOrderOperation workOrderOperation)
        {
            bool result = _workOrderOperationService.Update(workOrderOperation);

            if (result)
                return Ok();

            return BadRequest();
        }

        [HttpGet("getListWorkOrderOperationByWorkOrderId")]
        public IActionResult GetByWorkOrderId(string workOrderId)
        {
            List<WorkOrderOperation> list = _workOrderOperationService.GetByWorkOrderId(Convert.ToInt32(workOrderId));
            return Ok(list);
        }
    }
}
