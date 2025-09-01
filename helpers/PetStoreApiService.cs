using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using PetStoreApiSpecFlowTests.Model;
using PetStoreApiSpecFlowTests.Client;

namespace PetStoreApiSpecFlowTests.Helpers
{
    public class PetStoreApiService
    {
        private readonly StoreApiClient _client;

        public PetStoreApiService()
        {
            _client = new StoreApiClient();
        }

        public async Task<HttpResponseMessage> placeOrderAsync(Order order, bool authenticated = true)
        {
            return await _client.postOrderAsync(order, authenticated);
        }

        public async Task<HttpResponseMessage> getOrderByIdAsync(long id, bool authenticated = true)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(System.AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
            int retryCount = int.TryParse(config["RetryCount"], out var rc) ? rc : 3;
            HttpResponseMessage response = null;
            for (int i = 0; i < retryCount; i++)
            {
                response = await _client.getOrderByIdAsync(id, authenticated);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    break;
                await Task.Delay(500); //wait before retry
            }
            return response;
        }

        public async Task<HttpResponseMessage> deleteOrderByIdAsync(long id, bool authenticated = true)
        {
            return await _client.deleteOrderByIdAsync(id, authenticated);
        }

        public async Task<HttpResponseMessage> getInventoryAsync(bool authenticated = true)
        {
            return await _client.getInventoryAsync(authenticated);
        }
    }
    
       
       
}

