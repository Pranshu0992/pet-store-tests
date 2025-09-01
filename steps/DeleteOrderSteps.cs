using System.Net.Http;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using NUnit.Framework;
using PetStoreApiSpecFlowTests.Helpers;
using PetStoreApiSpecFlowTests.Model;
using PetStoreApiSpecFlowTests.MockData;

namespace PetStoreApiSpecFlowTests.Steps
{
    [Binding]
    public class DeleteOrderSteps
    {
        private readonly PetStoreApiService _service = new PetStoreApiService();
        private HttpResponseMessage _response;
        private Order _order;
        private bool _authenticated = true;

        [Given("an order with ID (.*) exists")]
        public async Task GivenAnOrderWithIdExists(long orderId)
        {
            _order = MockDataFactory.createMockOrder(id: orderId);
            var response = await _service.placeOrderAsync(_order, _authenticated);
            Assert.AreEqual(200, (int)response.StatusCode);
        }

        [Given("I am not authenticated to delete order")]
        public void GivenIAmNotAuthenticatedToDeleteOrder()
        {
            _authenticated = false;
        }

        [When("I DELETE \"/store/order/(.*)\"")]
        public async Task WhenIDeleteStoreOrderById(long orderId)
        {
            _response = await _service.deleteOrderByIdAsync(orderId, _authenticated);
        }

        [Then("the response status for delete order should be (.*)")]
        public void ThenTheResponseStatusForDeleteOrderShouldBe(int statusCode)
        {
            Assert.AreEqual(statusCode, (int)_response.StatusCode);
        }
    }
}
