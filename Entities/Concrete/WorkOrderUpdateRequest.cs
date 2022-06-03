using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class WorkOrderUpdateRequest
    {
        public string CurrentChassisNumber { get; set; }
        public string TargetChassisNumber { get; set; }
    }
}
