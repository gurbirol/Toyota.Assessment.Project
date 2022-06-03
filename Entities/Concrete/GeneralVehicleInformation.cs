using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class GeneralVehicleInformation : IEntity
    {
        public GeneralVehicleInformation()
        {
            VehicleList = new List<Vehicle>();
            WorkOrderList = new List<WorkOrder>();
            VehicleWarrantyRecordList = new List<VehicleWarrantyRecord>();
        }


        public List<Vehicle> VehicleList { get; set; }
        public List<WorkOrder> WorkOrderList { get; set; }
        public List<VehicleWarrantyRecord> VehicleWarrantyRecordList { get; set; }
    }
}
