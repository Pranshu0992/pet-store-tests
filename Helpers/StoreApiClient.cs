using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PetStoreApiSpecFlowTests.Models;

namespace PetStoreApiSpecFlowTests.Helpers
{
    public class StoreApiClient
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://petstore.swagger.io/v2";

        public StoreApiClient()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new System.Uri(BaseUrl);
        }

        public async Task<HttpResponseMessage> PostOrderAsync(Order order)
        {
            var json = JsonConvert.SerializeObject(order);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            return await _httpClient.PostAsync("/store/order", content);
        }

        public async Task<HttpResponseMessage> GetOrderByIdAsync(long id)
        {
            return await _httpClient.GetAsync($"/store/order/{id}");
        }

        public async Task<HttpResponseMessage> DeleteOrderByIdAsync(long id)
        {
            return await _httpClient.DeleteAsync($"/store/order/{id}");
        }

        public async Task<HttpResponseMessage> GetInventoryAsync()
        {
            return await _httpClient.GetAsync("/store/inventory");
        }
    }
}
