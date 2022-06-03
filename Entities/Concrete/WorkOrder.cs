using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class WorkOrder : IEntity
    {
        public int Id { get; set; }
        public int VehicleId { get; set; }
        public DateTime DateValue { get; set; }
        public string CustomerName { get; set; }
        public string Request { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
