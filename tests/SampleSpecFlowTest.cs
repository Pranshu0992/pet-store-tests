using NUnit.Framework;
using System.Net.Http;
using System.Threading.Tasks;
using PetStoreApiSpecFlowTests.Helpers;
using PetStoreApiSpecFlowTests.Model;

namespace PetStoreApiSpecFlowTests.Tests
{
    public class SampleSpecFlowTest
    {
        private readonly PetStoreApiService _service = new PetStoreApiService();

        [Test]
        public async Task PlaceOrder_ShouldReturn200()
        {
            var order = new Order { Id = 2, PetId = 2, Quantity = 1, Status = "placed", Complete = true };
            var response = await _service.placeOrderAsync(order);
            Assert.AreEqual(200, (int)response.StatusCode);
        }

        [Test]
        public async Task GetInventory_ShouldReturn200()
        {
            var response = await _service.getOrderByIdAsync(1);
            Assert.AreEqual(200, (int)response.StatusCode);
        }
    }
}
