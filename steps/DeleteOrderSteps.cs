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
    public class DeleteOrderSteps : BaseSteps
    {

        public DeleteOrderSteps(PetStoreApiService service) : base(service) {}

        [Given("an order with ID (.*) exists")]
        public async Task GivenAnOrderWithIdExists(long orderId)
        {
            order = MockDataFactory.createMockOrder(id: orderId);
            var response = await service.placeOrderAsync(order, authenticated);
            Assert.AreEqual(200, (int)response.StatusCode);
        }

        [Given("I am not authenticated to delete order")]
        public void GivenIAmNotAuthenticatedToDeleteOrder()
        {
            authenticated = false;
        }

        [When("I DELETE \"/store/order/(.*)\"")]
        public async Task WhenIDeleteStoreOrderById(long orderId)
        {
            response = await service.deleteOrderByIdAsync(orderId, authenticated);
        }

        [Then("the response status for delete order should be (.*)")]
        public void ThenTheResponseStatusForDeleteOrderShouldBe(int statusCode)
        {
            Assert.AreEqual(statusCode, (int)response.StatusCode);
        }
    }
}
