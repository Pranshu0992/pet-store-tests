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

            var baseUrl = config["ApiBaseUrl"] ?? "https://petstore.swagger.io";
            _apiKey = config["ApiKey"] ?? string.Empty;
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new System.Uri(baseUrl);
        }

        private void addApiKeyHeader(HttpRequestMessage request)
        {
            if (!string.IsNullOrEmpty(_apiKey))
            {
                request.Headers.Add("api_key", _apiKey);
            }
        }

        // POST /store/order
        public async Task<HttpResponseMessage> postOrderAsync(object order)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "/v2/store/order");
            addApiKeyHeader(request);
            var json = JsonConvert.SerializeObject(order);
            request.Content = new StringContent(json, Encoding.UTF8, "application/json");
            return await _httpClient.SendAsync(request);
        }

        // GET /store/order/{orderId}
        public async Task<HttpResponseMessage> getOrderByIdAsync(long orderId)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"/v2/store/order/{orderId}");
            addApiKeyHeader(request);
            return await _httpClient.SendAsync(request);
        }

        // DELETE /store/order/{orderId}
        public async Task<HttpResponseMessage> deleteOrderByIdAsync(long orderId)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, $"/v2/store/order/{orderId}");
            addApiKeyHeader(request);
            return await _httpClient.SendAsync(request);
        }

        // GET /store/inventory
        public async Task<HttpResponseMessage> getInventoryAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "/v2/store/inventory");
            addApiKeyHeader(request);
            return await _httpClient.SendAsync(request);
        }
    }
}
