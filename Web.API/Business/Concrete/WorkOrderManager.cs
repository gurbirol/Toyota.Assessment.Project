using Web.API.Context;
using Entities.Concrete;
using System.Data;
using System.Reflection;
using Web.API.Business.Abstract;

namespace Web.API.Business.Concrete
{
    public class WorkOrderManager : IWorkOrderService
    {

        public bool Add(WorkOrderRequest workOrder)
        {
            return DataAccessLayer.InsertWorkOrder(workOrder.VehicleId, workOrder.DateValue, workOrder.CustomerName, workOrder.Request);
        }

        public bool Delete(int id)
        {
            return DataAccessLayer.DeleteWorkOrder(id);
        }

        public bool Update(WorkOrder workOrder)
        {
            return DataAccessLayer.UpdateWorkOrder(workOrder.Id, workOrder.DateValue, workOrder.CustomerName, workOrder.Request);
        }

        public bool UpdateByChassisNumber(string currentChassisNumber, string targetChassisNumber)
        {
            return DataAccessLayer.UpdateWorkOrderByChassisNumber(currentChassisNumber, targetChassisNumber);
        }
    }

    public static partial class DataAccessLayer
    {
        public static bool InsertWorkOrder(int vehicleId, DateTime date, string customerName, string request)
        {
            return DbAccessContext.ExecuteNonQuery("usp_Add_WorkOrders", MethodBase.GetCurrentMethod().GetParameters(), new object[] { vehicleId, date, customerName, request });
        }

        public static bool DeleteWorkOrder(int id)
        {
            return DbAccessContext.ExecuteNonQuery("usp_Delete_WorkOrders_ById", MethodBase.GetCurrentMethod().GetParameters(), new object[] { id });
        }

        public static bool UpdateWorkOrder(int id, DateTime date, string customerName, string request)
        {
            return DbAccessContext.ExecuteNonQuery("usp_Update_WorkOrders_ById", MethodBase.GetCurrentMethod().GetParameters(), new object[] { id, date, customerName, request });
        }

        public static bool UpdateWorkOrderByChassisNumber(string currentChassisNumber, string targetChassisNumber)
        {
            return DbAccessContext.ExecuteNonQuery("usp_Update_WorkOrders_ByChassisNumber", MethodBase.GetCurrentMethod().GetParameters(), new object[] { currentChassisNumber, targetChassisNumber });
        }
    }
}
