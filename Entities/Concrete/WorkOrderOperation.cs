using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class WorkOrderOperation : IEntity
    {
        public int Id { get; set; }
        public int WorkOrderId { get; set; }
        public string Explanation { get; set; }
        public int Status { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
