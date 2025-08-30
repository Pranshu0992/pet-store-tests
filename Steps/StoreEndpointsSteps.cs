using System.Net.Http;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using NUnit.Framework;
using PetStoreApiSpecFlowTests.Helpers;
using PetStoreApiSpecFlowTests.Models;

namespace PetStoreApiSpecFlowTests.Steps
{
    [Binding]
    public class StoreEndpointsSteps
    {
        private readonly StoreApiClient _apiClient = new StoreApiClient();
        private HttpResponseMessage _response;
        private Order _order;

        [Given("I have a valid order payload")]
        public void GivenIHaveAValidOrderPayload()
        {
            _order = new Order { Id = 1, PetId = 1, Quantity = 1, Status = "placed", Complete = true };
        }

        [When("I POST the order to \"/store/order\"")]
        public async Task WhenIPostTheOrderToStoreOrder()
        {
            _response = await _apiClient.PostOrderAsync(_order);
        }

        [When("I GET \"/store/order/1\"")]
        public async Task WhenIGetStoreOrderById()
        {
            _response = await _apiClient.GetOrderByIdAsync(1);
        }

        [When("I DELETE \"/store/order/1\"")]
        public async Task WhenIDeleteStoreOrderById()
        {
            _response = await _apiClient.DeleteOrderByIdAsync(1);
        }

        [When("I GET \"/store/inventory\"")]
        public async Task WhenIGetStoreInventory()
        {
            _response = await _apiClient.GetInventoryAsync();
        }

        [Then("the response status should be 200")]
        public void ThenTheResponseStatusShouldBe200()
        {
            Assert.AreEqual(200, (int)_response.StatusCode);
        }
    }
}
