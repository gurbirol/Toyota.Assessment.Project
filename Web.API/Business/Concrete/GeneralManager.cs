using Entities.Concrete;
using System.Data;
using System.Reflection;
using Web.API.Business.Abstract;
using Web.API.Context;

namespace Web.API.Business.Concrete
{
    public class GeneralManager : IGeneralService
    {
        public GeneralVehicleInformation GetData(string plateNumber, string chassisNumber)
        {
            //List<Vehicle> list = new List<Vehicle>();
            DataTable dt = DataAccessLayer.GetGeneralListByVehicleInformations(plateNumber, chassisNumber);
            GeneralVehicleInformation generalVehicleInformation = new GeneralVehicleInformation();

            try
            {
                for (int i = 0; i < 3; i++)
                {
                    if (dt.DataSet.Tables[i].Rows.Count > 0)
                    {
                        foreach (DataRow row in dt.DataSet.Tables[i].Rows)
                        {
                            switch (i)
                            {
                                case 0:
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
                                    generalVehicleInformation.VehicleList.Add(vehicle);
                                    break;
                                case 1:
                                    VehicleWarrantyRecord vehicleWarrantyRecord = new VehicleWarrantyRecord()
                                    {
                                        Id = Convert.ToInt32(row["Id"]),
                                        VehicleId = Convert.ToInt32(row["VehicleId"]),
                                        StartDate = Convert.ToDateTime(row["StartDate"]),
                                        CreateDate = Convert.ToDateTime(row["CreateDate"]),
                                        EndDate = Convert.ToDateTime(row["EndDate"]),
                                        Status= Convert.ToDateTime(row["EndDate"])>DateTime.Now?"Aktif":"Pasif"
                                    };
                                    generalVehicleInformation.VehicleWarrantyRecordList.Add(vehicleWarrantyRecord);
                                    break;
                                case 2:
                                    WorkOrder workOrder = new WorkOrder()
                                    {
                                        Id = Convert.ToInt32(row["Id"]),
                                        VehicleId = Convert.ToInt32(row["VehicleId"]),
                                        DateValue = Convert.ToDateTime(row["Date"]),
                                        CreateDate = Convert.ToDateTime(row["CreateDate"]),
                                        Request = row["Request"].ToString(),
                                        CustomerName = row["CustomerName"].ToString()
                                    };
                                    generalVehicleInformation.WorkOrderList.Add(workOrder);
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                }

                return generalVehicleInformation;
            }
            catch (Exception)
            {
                return new GeneralVehicleInformation();
            }


            return new GeneralVehicleInformation();
        }
    }

    public static partial class DataAccessLayer
    {
        public static DataTable GetGeneralListByVehicleInformations(string plateNumber, string chassisNumber)
        {
            return DbAccessContext.ExecuteReader("usp_GetList_General_VehicleInformations", MethodBase.GetCurrentMethod().GetParameters(), new object[] { plateNumber, chassisNumber });
        }
    }
}
