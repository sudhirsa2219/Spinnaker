using Newtonsoft.Json;

namespace CustomerWebApp.Model
{
    public class CustomerResponse
    {
        [JsonProperty("customers")]
        public Customers Customers { get; set; }
    }

    public class Customers
    {
        [JsonProperty("pageIndex")]
        public int PageIndex { get; set; }

        [JsonProperty("pageSize")]
        public int PageSize { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("data")]
        public List<Customer> Data { get; set; }
    }

    public class Customer
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("surname")]
        public string Surname { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("telephone")]
        public string Telephone { get; set; }

        [JsonProperty("idNumber")]
        public string IdNumber { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }
    }

}
