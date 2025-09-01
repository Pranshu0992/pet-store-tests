using System.Net.Http;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using NUnit.Framework;
using PetStoreApiSpecFlowTests.Helpers;

namespace PetStoreApiSpecFlowTests.Steps
{
    [Binding]
    public class GetInventorySteps
    {
        private readonly PetStoreApiService _service = new PetStoreApiService();
        private HttpResponseMessage _response;
        private bool _authenticated = true;

        [Given("I am not authenticated to get inventory details")]
        public void GivenIAmNotAuthenticatedToGetInventoryDetails()
        {
            _authenticated = false;
        }

        [When("I GET \"/store/inventory\"")]
        public async Task WhenIGetStoreInventory()
        {
            _response = await _service.getInventoryAsync(_authenticated);
        }

        [Then("the response status for get inventory should be (.*)")]
        public void ThenTheResponseStatusForGetInventoryShouldBe(int statusCode)
        {
            Assert.AreEqual(statusCode, (int)_response.StatusCode);
        }
    }
}
