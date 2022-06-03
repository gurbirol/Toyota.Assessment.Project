using Entities.Concrete;

namespace Web.API.Business.Abstract
{
    public interface IGeneralService
    {
        GeneralVehicleInformation GetData(string plateNumber, string chassisNumber);
    }
}
