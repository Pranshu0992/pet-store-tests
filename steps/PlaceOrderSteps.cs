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
        public class PlaceOrderSteps : BaseSteps
    {
        public PlaceOrderSteps(PetStoreApiService service) : base(service) {}

        [Given("I have a valid order payload")]
        public void GivenIHaveAValidOrderPayload()
        {
            order = MockDataFactory.createMockOrder();
        }

        [Given("I have an invalid order payload")]
        public void GivenIHaveAnInvalidOrderPayload()
        {
            order = null;
        }

        [Given("I am not authenticated to place order")]
        public void GivenIAmNotAuthenticatedToPlaceOrder()
        {
            authenticated = false;
        }

        [When("I POST the order to \"/store/order\"")]
        public async Task WhenIPostTheOrderToStoreOrder()
        {
            response = await service.placeOrderAsync(order, authenticated);
        }

        [Then("the response status for place order should be (.*)")]
        public void ThenTheResponseStatusForPlaceOrderShouldBe(int statusCode)
        {
            Assert.AreEqual(statusCode, (int)response.StatusCode);
        }

        [Then("the order details returned should be correct based on the request")]
        public async Task ThenTheOrderDetailsReturnedShouldBeCorrectBasedOnTheRequest()
        {
            await ResponseVerifier.VerifyOrderResponse(response, order);
        }
    }
}
