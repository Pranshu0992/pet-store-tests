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
    public class GetOrderSteps
    {
        private readonly PetStoreApiService _service = new PetStoreApiService();
        private HttpResponseMessage _response;
        private Order _order;
        private bool _authenticated = true;

        [Given("an order with ID (.*) is created")]
        public async Task GivenAnOrderWithIdIsCreated(long orderId)
        {
            _order = MockDataFactory.createMockOrder(id: orderId);
            var response = await _service.placeOrderAsync(_order, _authenticated);
            Assert.AreEqual(200, (int)response.StatusCode);
        }

        [Given("I am not authenticated to get order details")]
        public void GivenIAmNotAuthenticatedToGetOrderDetails()
        {
            _authenticated = false;
        }

        [When("I GET \"/store/order/(.*)\"")]
        public async Task WhenIGetStoreOrderById(long orderId)
        {
            _response = await _service.getOrderByIdAsync(orderId, _authenticated);
        }

        [Then("the response status for get order should be (.*)")]
        public void ThenTheResponseStatusForGetOrderShouldBe(int statusCode)
        {
            Assert.AreEqual(statusCode, (int)_response.StatusCode);
        }

        [Then("the order details returned should be corect based on created order")]
        public async Task ThenTheOrderDetailsReturnedShouldBeCorrectBasedOnCreatedOrder()
        {
            await ResponseVerifier.VerifyOrderResponse(_response, _order);
        }
    }
}
