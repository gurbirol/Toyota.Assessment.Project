using Web.API.Context;
using Entities.Concrete;
using System.Data;
using System.Reflection;
using Web.API.Business.Abstract;

namespace Web.API.Business.Concrete
{
    public class WorkOrderOperationManager : IWorkOrderOperationService
    {
        public bool Add(WorkOrderOperationRequest workOrderOperation)
        {
            return DataAccessLayer.InsertWorkOrderOperation(workOrderOperation.WorkOrderId, workOrderOperation.Explanation, workOrderOperation.Status);
        }

        public bool Delete(int id)
        {
            return DataAccessLayer.DeleteWorkOrderOperation(id);
        }

        public bool Update(WorkOrderOperation workOrderOperation)
        {
            return DataAccessLayer.UpdateWorkOrderOperation(workOrderOperation.Id, workOrderOperation.Explanation, workOrderOperation.Status);
        }

        public List<WorkOrderOperation> GetByWorkOrderId(int workOrderId)
        {
            List<WorkOrderOperation> list = new List<WorkOrderOperation>();
            DataTable dt = DataAccessLayer.GetWorkOrderOperationById(workOrderId);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    WorkOrderOperation item = new WorkOrderOperation()
                    {
                        Id = Convert.ToInt32(row["Id"]),
                        WorkOrderId = Convert.ToInt32(row["WorkOrderId"]),
                        Explanation = row["Explanation"].ToString(),
                        Status = Convert.ToInt32(row["Status"]),
                        CreateDate = Convert.ToDateTime(row["CreateDate"])
                    };

                    list.Add(item);
                }
                return list;
            }
            else
                return new List<WorkOrderOperation>();
        }
    }

    public static partial class DataAccessLayer
    {
        public static bool InsertWorkOrderOperation(int workOrderId, string explanation, int status)
        {
            return DbAccessContext.ExecuteNonQuery("usp_Add_WorkOrderOperations", MethodBase.GetCurrentMethod().GetParameters(), new object[] { workOrderId, explanation, status });
        }

        public static bool DeleteWorkOrderOperation(int id)
        {
            return DbAccessContext.ExecuteNonQuery("usp_Delete_WorkOrderOperations_ById", MethodBase.GetCurrentMethod().GetParameters(), new object[] { id });
        }

        public static bool UpdateWorkOrderOperation(int id, string explanation, int status)
        {
            return DbAccessContext.ExecuteNonQuery("usp_Update_WorkOrderOperations_ById", MethodBase.GetCurrentMethod().GetParameters(), new object[] { id, explanation, status });
        }

        public static DataTable GetWorkOrderOperationById(int workOrderId)
        {
            return DbAccessContext.ExecuteReader("usp_GetList_WorkOrderOperations_ByWorkOrderId", MethodBase.GetCurrentMethod().GetParameters(), new object[] { workOrderId });
        }
    }
}
