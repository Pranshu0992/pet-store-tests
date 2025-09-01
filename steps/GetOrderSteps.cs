using System.Net.Http;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using NUnit.Framework;
using PetStoreApiSpecFlowTests.Helpers;
using PetStoreApiSpecFlowTests.Model;
using PetStoreApiSpecFlowTests.MockData;
using PetStoreApiSpecFlowTests.Client;

namespace PetStoreApiSpecFlowTests.Steps
{
    [Binding]
    public class GetOrderSteps : BaseSteps
    {
        public GetOrderSteps(PetStoreApiService service) : base(service) {}

        [Given("an order with ID (.*) is created")]
        public async Task GivenAnOrderWithIdIsCreated(long orderId)
        {
            order = MockDataFactory.createMockOrder(id: orderId);
            var response = await service.placeOrderAsync(order, authenticated);
            Assert.AreEqual(200, (int)response.StatusCode);
        }

        [Given("I am not authenticated to get order details")]
        public void GivenIAmNotAuthenticatedToGetOrderDetails()
        {
            authenticated = false;
        }

        [When("I GET \"/store/order/(.*)\"")]
        public async Task WhenIGetStoreOrderById(long orderId)
        {
            response = await service.getOrderByIdAsync(orderId, authenticated);
        }

        [Then("the response status for get order should be (.*)")]
        public void ThenTheResponseStatusForGetOrderShouldBe(int statusCode)
        {
            Assert.AreEqual(statusCode, (int)response.StatusCode);
        }

        [Then("the order details returned should be corect based on created order")]
        public async Task ThenTheOrderDetailsReturnedShouldBeCorrectBasedOnCreatedOrder()
        {
            await ResponseVerifier.VerifyOrderResponse(response, order);
        }
    }
}
