using Entities.Concrete;

namespace Web.API.Business.Abstract
{
    public interface IVehicleService
    {
        List<Vehicle> Getlist();
        bool Add(VehicleAddRequest vehicle);
        bool Delete(int id);
        bool Update(Vehicle vehicle);
    }
}