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
    public class PlaceOrderSteps
    {
        private readonly PetStoreApiService _service = new PetStoreApiService();
        private HttpResponseMessage _response;
        private Order _order;
        private bool _authenticated = true;

        [Given("I have a valid order payload")]
        public void GivenIHaveAValidOrderPayload()
        {
            _order = MockDataFactory.createMockOrder();
        }

        [Given("I have an invalid order payload")]
        public void GivenIHaveAnInvalidOrderPayload()
        {
            _order = null;
        }

        [Given("I am not authenticated to place order")]
        public void GivenIAmNotAuthenticatedToPlaceOrder()
        {
            _authenticated = false;
        }

        [When("I POST the order to \"/store/order\"")]
        public async Task WhenIPostTheOrderToStoreOrder()
        {
            // Simulate authentication by skipping API key if not authenticated
            _response = await _service.placeOrderAsync(_order, _authenticated);
        }

        [Then("the response status for place order should be (.*)")]
        public void ThenTheResponseStatusForPlaceOrderShouldBe(int statusCode)
        {
            Assert.AreEqual(statusCode, (int)_response.StatusCode);
        }

        [Then("the order details returned should be correct based on the request")]
        public async Task ThenTheOrderDetailsReturnedShouldBeCorrectBasedOnTheRequest()
        {
            await ResponseVerifier.VerifyOrderResponse(_response, _order);
        }
    }
}
