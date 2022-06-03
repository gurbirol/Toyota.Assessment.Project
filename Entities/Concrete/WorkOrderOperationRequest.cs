using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class WorkOrderOperationRequest
    {
        public int WorkOrderId { get; set; }
        public string Explanation { get; set; }
        public int Status { get; set; }
    }
}
