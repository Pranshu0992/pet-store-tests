using System.Net.Http;
using System.Threading.Tasks;
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

        public async Task<HttpResponseMessage> placeOrderAsync(Order order)
        {
            return await _client.postOrderAsync(order);
        }

        public async Task<HttpResponseMessage> getOrderByIdAsync(long id)
        {
            return await _client.getOrderByIdAsync(id);
        }

        public async Task<HttpResponseMessage> deleteOrderByIdAsync(long id)
        {
            return await _client.deleteOrderByIdAsync(id);
        }

        public async Task<HttpResponseMessage> getInventoryAsync()
        {
            return await _client.getInventoryAsync();
        }
    }
    
       
       
}

