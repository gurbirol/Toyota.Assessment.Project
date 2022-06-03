using Entities.Concrete;
using System.Data;
using System.Reflection;
using Web.API.Business.Abstract;
using Web.API.Context;

namespace Web.API.Business.Concrete
{
    public class VehicleWarrantyRecordManager : IVehicleWarrantyRecordService
    {
        public bool Add(VehicleWarrantyRequest vehicleWarrantyRecord)
        {
            return DataAccessLayer.InsertVehicleWarrantyRecord(vehicleWarrantyRecord.VehicleId, vehicleWarrantyRecord.StartDate, vehicleWarrantyRecord.EndDate);
        }

        public bool Delete(int id)
        {
            return DataAccessLayer.DeleteVehicleWarrantyRecord(id);
        }

        public bool Update(VehicleWarrantyRecord vehicleWarrantyRecord)
        {
            return DataAccessLayer.UpdateVehicleWarrantyRecord(vehicleWarrantyRecord.Id, vehicleWarrantyRecord.StartDate, vehicleWarrantyRecord.EndDate);
        }
    }

    public static partial class DataAccessLayer
    {
        public static bool InsertVehicleWarrantyRecord(int vehicleId, DateTime startDate, DateTime endDate)
        {
            return DbAccessContext.ExecuteNonQuery("usp_Add_VehicleWarrantyRecords", MethodBase.GetCurrentMethod().GetParameters(), new object[] { vehicleId, startDate, endDate });
        }

        public static bool DeleteVehicleWarrantyRecord(int id)
        {
            return DbAccessContext.ExecuteNonQuery("usp_Delete_VehicleWarrantyRecords_ById", MethodBase.GetCurrentMethod().GetParameters(), new object[] { id });
        }

        public static bool UpdateVehicleWarrantyRecord(int id, DateTime startDate, DateTime endDate)
        {
            return DbAccessContext.ExecuteNonQuery("usp_Update_VehicleWarrantyRecords_ById", MethodBase.GetCurrentMethod().GetParameters(), new object[] { id, startDate, endDate });
        }
    }
}