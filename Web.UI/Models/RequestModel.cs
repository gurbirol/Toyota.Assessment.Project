using Entities.Concrete;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Security.Cryptography.Xml;
using System.Text;

namespace Web.UI.Models
{
    public static class RequestModel
    {
        public static async Task<List<Vehicle>> GetVehicleListAsync()
        {
            string apiUrl = GetAPIUrl();
            using var client = new HttpClient();
            var result = await client.GetAsync(apiUrl + "/Vehicle/getListVehicle");
            var content = await result.Content.ReadAsStringAsync();

            var resultData = JsonConvert.DeserializeObject<List<Vehicle>>(value: content);

            return resultData;

        }
        public static async Task<GeneralVehicleInformation> GetVehicleInfoAsync(string chassisNumber, string plate)
        {
            string apiUrl = GetAPIUrl();
            using var client = new HttpClient();

            var response = await client.GetAsync(apiUrl + $"/api/General/getData?plateNumber={plate}&chassisNumber={chassisNumber}");

            var result = await response.Content.ReadAsStringAsync();
            var resultData = JsonConvert.DeserializeObject<GeneralVehicleInformation>(value: result);

            return resultData;

        }
        public static async Task<List<WorkOrderOperation>> GetWorOperationInfoAsync(string id)
        {
            string apiUrl = GetAPIUrl();
            using var client = new HttpClient();

            var response = await client.GetAsync(apiUrl + "/api/WorkOrderOperation/getListWorkOrderOperationByWorkOrderId?workOrderId=" + id + "");

            var result = await response.Content.ReadAsStringAsync();
            var resultData = JsonConvert.DeserializeObject<List<WorkOrderOperation>>(value: result);

            return resultData;
        }

        public static string GetAPIUrl()
        {
            return AppSettings.ReadFileValue().ApiUrl;
        }
    }
}
