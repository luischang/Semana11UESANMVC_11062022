using Newtonsoft.Json;
using Semana11UESANMVC.WEB.Models;

namespace Semana11UESANMVC.WEB.Services
{
    public class CustomerService
    {     
        public static async Task<IEnumerable<CustomerModel>> GetAll()
        {
            //Get all customers
            string urlBase = "http://localhost:5257/api/Customer/";
            
            var client = new HttpClient();
            var response = await client.GetAsync(urlBase + "GetAll");
            string result = await response.Content.ReadAsStringAsync();
            var customers = JsonConvert.DeserializeObject<IEnumerable<CustomerModel>>(result);
            return customers;
        }



    }
}
