using Entities.Concrete;

namespace Web.API.Business.Abstract
{
    public interface IWorkOrderService
    {
        bool Add(WorkOrderRequest workOrder);
        bool Delete(int id);
        bool Update(WorkOrder workOrder);
        bool UpdateByChassisNumber(string currentChassisNumber, string targetChassisNumber);
    }
}
