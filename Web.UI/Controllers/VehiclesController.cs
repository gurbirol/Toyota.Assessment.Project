using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Web.UI.Models;

namespace Web.UI.Controllers
{
    public class VehiclesController : Controller
    {
        public IActionResult Index()
        { 
            return View(RequestModel.GetVehicleListAsync().Result);
        }

        public IActionResult Detail(string id)
        {   var vehicleList = RequestModel.GetVehicleListAsync().Result;
            ViewBag.ChassisNumber = vehicleList.Select(x => x.ChassisNumber).ToList();
            var vehicleData = vehicleList.Where(x => x.Id == Convert.ToInt32(id)).FirstOrDefault();
            return View(RequestModel.GetVehicleInfoAsync(vehicleData.ChassisNumber, vehicleData.PlateNumber).Result);
        }

        public IActionResult WorkOrderOperations(string id,string vehicleId)
        {
            ViewBag.WorkOrderId = id;
            ViewBag.VehicleList = RequestModel.GetVehicleListAsync().Result.Where(x => x.Id == Convert.ToInt32(vehicleId)).FirstOrDefault();
            return View(RequestModel.GetWorOperationInfoAsync(id).Result??new List<WorkOrderOperation>());
        }
    }
}
