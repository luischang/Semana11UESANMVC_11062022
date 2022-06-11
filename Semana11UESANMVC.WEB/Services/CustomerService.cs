using Newtonsoft.Json;
using Semana11UESANMVC.WEB.Models;

namespace Semana11UESANMVC.WEB.Services
{
    public class CustomerService
    {
        public static async Task<IEnumerable<CustomerModel>> GetAll()
        {
            //Get All using HttpClient
            string urlBase = "http://localhost:5257/api/Customer/";

            using var httpClient = new HttpClient();
            using var response = await httpClient.GetAsync(urlBase + "GetAll");
            string apiResponse = response.Content.ReadAsStringAsync().Result;
            var customers = JsonConvert.DeserializeObject<IEnumerable<CustomerModel>>(apiResponse);
            return customers;

        }



    }
}
