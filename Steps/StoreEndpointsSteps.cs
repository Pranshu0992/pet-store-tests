using System.Net.Http;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using NUnit.Framework;
using PetStoreApiSpecFlowTests.Helpers;
using PetStoreApiSpecFlowTests.Model;

namespace PetStoreApiSpecFlowTests.Steps
{
    [Binding]
    public class StoreEndpointsSteps
    {
        private readonly PetStoreApiService _service = new PetStoreApiService();
        private HttpResponseMessage _response;
        private Order _order;

        [Given("I have a valid order payload")]
        public void GivenIHaveAValidOrderPayload()
        {
            _order = PetStoreApiSpecFlowTests.MockData.MockDataFactory.createMockOrder();
        }

        [When("I POST the order to \"/store/order\"")]
        public async Task WhenIPostTheOrderToStoreOrder()
        {
            _response = await _service.placeOrderAsync(_order);
        }


        [Given("an order with ID (.*) exists")]
        public async Task GivenAnOrderWithIdExists(long orderId)
        {
            _order = PetStoreApiSpecFlowTests.MockData.MockDataFactory.createMockOrder(id: orderId);
            var response = await _service.placeOrderAsync(_order);
            Assert.AreEqual(200, (int)response.StatusCode);
        }


        [When("I GET \"/store/order/(.*)\"")]
        public async Task WhenIGetStoreOrderById(long orderId)
        {
            _response = await _service.getOrderByIdAsync(orderId);
        }

        [Then("the response should contain the order details")]
        public async Task ThenTheResponseShouldContainOrderDetails()
        {

        }

        [When("I DELETE \"/store/order/(.*)\"")]
        public async Task WhenIDeleteStoreOrderById(long orderId)
        {
            _response = await _service.deleteOrderByIdAsync(orderId);
        }

        [When("I GET \"/store/inventory\"")]
        public async Task WhenIGetStoreInventory()
        {
            _response = await _service.getInventoryAsync();
        }

        [Then("the response should contain inventory details")]
        public async Task ThenTheResponseShouldContainInventoryDetails()
        {
            
        }

        [Then("the response status should be 200")]
        public void ThenTheResponseStatusShouldBe200()
        {
            Assert.AreEqual(200, (int)_response.StatusCode);
        }

        [Then("the response status should be 404")]
        public void ThenTheResponseStatusShouldBe404()
        {
            Assert.AreEqual(404, (int)_response.StatusCode);
        }
    }
}
