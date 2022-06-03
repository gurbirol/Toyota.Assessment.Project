using Entities.Concrete;

namespace Web.API.Business.Abstract
{
    public interface IWorkOrderOperationService
    {
        bool Add(WorkOrderOperationRequest workOrderOperation);
        bool Delete(int id);
        bool Update(WorkOrderOperation workOrderOperation);
        List<WorkOrderOperation> GetByWorkOrderId(int workOrderId);
    }
}
