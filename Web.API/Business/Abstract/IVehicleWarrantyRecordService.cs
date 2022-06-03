using Entities.Concrete;

namespace Web.API.Business.Abstract
{
    public interface IVehicleWarrantyRecordService
    {
        bool Add(VehicleWarrantyRequest vehicleWarrantyRecord);
        bool Delete(int id);
        bool Update(VehicleWarrantyRecord vehicleWarrantyRecord);
    }
}
