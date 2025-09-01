using System.Net.Http;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using NUnit.Framework;
using PetStoreApiSpecFlowTests.Helpers;
using PetStoreApiSpecFlowTests.Client;

namespace PetStoreApiSpecFlowTests.Steps
{
    [Binding]
    public class GetInventorySteps : BaseSteps
    {
        public GetInventorySteps(PetStoreApiService service) : base(service) {}

        [Given("I am not authenticated to get inventory details")]
        public void GivenIAmNotAuthenticatedToGetInventoryDetails()
        {
            authenticated = false;
        }

        [When("I GET \"/store/inventory\"")]
        public async Task WhenIGetStoreInventory()
        {
            response = await service.getInventoryAsync(authenticated);
        }

        [Then("the response status for get inventory should be (.*)")]
        public void ThenTheResponseStatusForGetInventoryShouldBe(int statusCode)
        {
            Assert.AreEqual(statusCode, (int)response.StatusCode);
        }
    }
}
