using Entities.Concrete;
using System.Data;
using System.Reflection;
using Web.API.Business.Abstract;
using Web.API.Context;

namespace Web.API.Business.Concrete
{
    public class VehicleManager : IVehicleService
    {
        public bool Add(VehicleAddRequest vehicle)
        {
            return DataAccessLayer.InsertVehicle(vehicle.PlateNumber, vehicle.ChassisNumber, vehicle.Brand, vehicle.Model, vehicle.ModelYear);
        }

        public bool Delete(int id)
        {
            return DataAccessLayer.DeleteVehicle(id);
        }

        public bool Update(Vehicle vehicle)
        {
            return DataAccessLayer.UpdateVehicle(vehicle.Id, vehicle.PlateNumber, vehicle.ChassisNumber, vehicle.Brand, vehicle.Model, vehicle.ModelYear);
        }

        public List<Vehicle> Getlist()
        {
            List<Vehicle> list = new List<Vehicle>();
            DataTable dt = DataAccessLayer.GetListVehicle();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    Vehicle vehicle = new Vehicle()
                    {
                        Id = Convert.ToInt32(row["Id"]),
                        PlateNumber = row["PlateNumber"].ToString(),
                        ChassisNumber = row["ChassisNumber"].ToString(),
                        Brand = row["Brand"].ToString(),
                        Model = row["Model"].ToString(),
                        ModelYear = row["ModelYear"].ToString(),
                        CreateDate = Convert.ToDateTime(row["CreateDate"])
                    };

                    list.Add(vehicle);
                }
                return list;
            }
            else
                return new List<Vehicle>();
        }
    }

    public static partial class DataAccessLayer
    {
        public static bool InsertVehicle(string plateNumber, string chassisNumber, string brand, string model, string modelYear)
        {
            return DbAccessContext.ExecuteNonQuery("usp_Add_Vehicles", MethodBase.GetCurrentMethod().GetParameters(), new object[] { plateNumber, chassisNumber, brand, model, modelYear });
        }

        public static bool DeleteVehicle(int id)
        {
            return DbAccessContext.ExecuteNonQuery("usp_Delete_Vehicles_ById", MethodBase.GetCurrentMethod().GetParameters(), new object[] { id });
        }

        public static bool UpdateVehicle(int id, string plateNumber, string chassisNumber, string brand, string model, string modelYear)
        {
            return DbAccessContext.ExecuteNonQuery("usp_Update_Vehicles_ById", MethodBase.GetCurrentMethod().GetParameters(), new object[] { id, plateNumber, chassisNumber, brand, model, modelYear });
        }

        public static DataTable GetListVehicle()
        {
            return DbAccessContext.ExecuteReader("usp_GetList_Vehicles", MethodBase.GetCurrentMethod().GetParameters(), new object[] { });
        }
    }
}
