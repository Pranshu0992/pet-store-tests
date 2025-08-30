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

        public async Task<HttpResponseMessage> PlaceOrderAsync(Order order)
        {
            return await _client.PostOrderAsync(order);
        }

        public async Task<HttpResponseMessage> GetOrderByIdAsync(long id)
        {
            return await _client.GetOrderByIdAsync(id);
        }

        public async Task<HttpResponseMessage> DeleteOrderByIdAsync(long id)
        {
            return await _client.DeleteOrderByIdAsync(id);
        }

        public async Task<HttpResponseMessage> GetInventoryAsync()
        {
            return await _client.GetInventoryAsync();
        }
    }
    
       
       
}

