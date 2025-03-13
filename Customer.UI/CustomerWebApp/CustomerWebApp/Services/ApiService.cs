using CustomerWebApp.Model;
using Newtonsoft.Json;
using System.Buffers.Text;
using System.Net.Http;
using System.Text;

namespace CustomerWebApp.Services
{
    public class ApiService
    {
        public static string ApiBaseUrl;
        public static async Task<List<Customer>> GetAllCustomers()
        {
            var customers = new List<Customer>();
            HttpClient client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, $"{ApiBaseUrl}/customers");

            var response = await client.SendAsync(request);
            string content = await response.Content.ReadAsStringAsync();
            var pgdata = JsonConvert.DeserializeObject<CustomerResponse>(content);

            customers.AddRange(pgdata.Customers.Data);
            return customers;

        }

        public static async Task<bool> CreateCustomer(Customer customer)
        {
            var reqdata = new CreateCustomerRequest() { Customer = customer };
            customer.Id = Guid.NewGuid();
            HttpClient client = new HttpClient();
            var jsonData = JsonConvert.SerializeObject(reqdata);
            HttpContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync($"{ApiBaseUrl}/customers", content);

            if (response.StatusCode == System.Net.HttpStatusCode.Created)
                return true;
            else
                return false;
        }

        public static async Task<bool> UpdateCustomer(Customer customer)
        {
            var reqdata = new UpdateCustomerRequest() { Customer = customer };
            //customer.Id = Guid.NewGuid();
            HttpClient client = new HttpClient();
            var jsonData = JsonConvert.SerializeObject(reqdata);
            HttpContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PutAsync($"{ApiBaseUrl}/customers", content);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return true;
            else
                return false;
        }

        public static async Task<Customer> GetCustomerById(Guid id)
        {
            Customer customer ;
            HttpClient client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, $"{ApiBaseUrl}/customers");

            var response = await client.SendAsync(request);
            string content = await response.Content.ReadAsStringAsync();
            var pgdata = JsonConvert.DeserializeObject<CustomerResponse>(content);
            customer = pgdata.Customers.Data.Where(x => x.Id == id).FirstOrDefault();
            return customer;

        }

        public static async Task<bool> DeleteCustomer(Guid id)
        {
            HttpClient client = new HttpClient();
            var url = $"{ApiBaseUrl}/customers/{id}";
            var response = await client.DeleteAsync(url);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return true;
            else
                return false;
        }
    }
}
