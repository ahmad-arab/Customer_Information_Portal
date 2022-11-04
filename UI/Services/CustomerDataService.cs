using Models.Model;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace UI.Services
{
    public class CustomerDataService
    {
        private HttpClient client = new HttpClient();
        private string basePath = "http://localhost:5023/Customerinfo/";
        public CustomerDataService()
        {
        }
        public async Task<List<Customer>> GetAllCustomersAsync()
        {
            List<Customer> customers = null;
            HttpResponseMessage response = await client.GetAsync(basePath+ "getall");
            if (response.IsSuccessStatusCode)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                customers = JsonConvert.DeserializeObject<List<Customer>>(apiResponse);
            }
            return customers;
        }
        public async Task<List<Country>> GetAllCountriesAsync()
        {
            List<Country> countries = null;
            HttpResponseMessage response = await client.GetAsync(basePath + "getallcountries");
            if (response.IsSuccessStatusCode)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                countries = JsonConvert.DeserializeObject<List<Country>>(apiResponse);
            }
            return countries;
        }
        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            Customer customer = null;
            HttpResponseMessage response = await client.GetAsync(basePath + "get/"+id.ToString());
            if (response.IsSuccessStatusCode)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                customer = JsonConvert.DeserializeObject<Customer>(apiResponse);
            }
            return customer;
        }

        public async Task<bool> CreateCustomerAsync(Customer customer)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync<Customer>(basePath + "create",customer);
            if (response.IsSuccessStatusCode) return true;
            return false;
        }

        public async Task<bool> UpdateCustomerAsync(Customer customer)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync<Customer>(basePath + "put", customer);
            if (response.IsSuccessStatusCode) return true;
            return false;
        }
        public async Task<bool> DeleteCustomerAsync(int id)
        {
            HttpResponseMessage response = await client.DeleteAsync(basePath + "delete/"+id.ToString());
            if (response.IsSuccessStatusCode) return true;
            return false;
        }
    }
}
