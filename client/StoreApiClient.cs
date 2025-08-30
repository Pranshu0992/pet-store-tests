using System.Net.Http;
using Microsoft.Extensions.Configuration;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PetStoreApiSpecFlowTests.Model;

namespace PetStoreApiSpecFlowTests.Client
{
    public class StoreApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public StoreApiClient()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(System.AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var baseUrl = config["ApiBaseUrl"] ?? "https://petstore.swagger.io/v2";
            _apiKey = config["ApiKey"] ?? string.Empty;
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new System.Uri(baseUrl);
        }

        private void AddApiKeyHeader(HttpRequestMessage request)
        {
            if (!string.IsNullOrEmpty(_apiKey))
            {
                request.Headers.Add("api_key", _apiKey);
            }
        }

        // POST /store/order
        public async Task<HttpResponseMessage> PostOrderAsync(object order)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "/store/order");
            AddApiKeyHeader(request);
            var json = JsonConvert.SerializeObject(order);
            request.Content = new StringContent(json, Encoding.UTF8, "application/json");
            return await _httpClient.SendAsync(request);
        }

        // GET /store/order/{orderId}
        public async Task<HttpResponseMessage> GetOrderByIdAsync(long orderId)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"/store/order/{orderId}");
            AddApiKeyHeader(request);
            return await _httpClient.SendAsync(request);
        }

        // DELETE /store/order/{orderId}
        public async Task<HttpResponseMessage> DeleteOrderByIdAsync(long orderId)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, $"/store/order/{orderId}");
            AddApiKeyHeader(request);
            return await _httpClient.SendAsync(request);
        }

        // GET /store/inventory
        public async Task<HttpResponseMessage> GetInventoryAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "/store/inventory");
            AddApiKeyHeader(request);
            return await _httpClient.SendAsync(request);
        }

        // Add more methods for other store endpoints as needed
    }
}
