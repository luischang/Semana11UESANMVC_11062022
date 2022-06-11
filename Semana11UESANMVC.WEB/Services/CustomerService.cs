using Newtonsoft.Json;
using Semana11UESANMVC.WEB.Models;
using System.Text;

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

        //Create CustomerModel
        public static async Task<int> Create(CustomerModel customer)
        {
            string urlBase = "http://localhost:5257/api/Customer/";

            var json = JsonConvert.SerializeObject(customer);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using var httpClient = new HttpClient();
            using var response = await httpClient.PostAsync(urlBase + "Create", data);
            string apiResponse = await response.Content.ReadAsStringAsync();
            var customerResponse = JsonConvert.DeserializeObject<int>(apiResponse);

            return customerResponse;
        }

        //Update CustomerModel
        public static async Task<int> Update(CustomerModel customer) 
        {
            string urlBase = "http://localhost:5257/api/Customer/";
            var json = JsonConvert.SerializeObject(customer);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            using var httpClient = new HttpClient();
            using var response = await httpClient.PutAsync(urlBase + "Update", data);
            string apiResponse = await response.Content.ReadAsStringAsync();
            var customerResponse = JsonConvert.DeserializeObject<int>(apiResponse);
            return customerResponse;
        }

        //Delete CustomerModel
        public static async Task<bool> Delete(int id)
        {
            string urlBase = "http://localhost:5257/api/Customer/";
            using var httpClient = new HttpClient();
            using var response = await httpClient.DeleteAsync(urlBase + "Delete/" + id);
            string apiResponse = await response.Content.ReadAsStringAsync();

            return ((int)response.StatusCode == 400 ? false : true);

        }



    }
}
