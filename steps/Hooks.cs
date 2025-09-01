using TechTalk.SpecFlow;
using BoDi;
using PetStoreApiSpecFlowTests.Helpers;
using PetStoreApiSpecFlowTests.Client;

namespace PetStoreApiSpecFlowTests.Steps
{
    [Binding]
    public class Hooks
    {
        private readonly IObjectContainer _container;

        public Hooks(IObjectContainer container)
        {
            _container = container;
        }

        [BeforeScenario]
        public void RegisterDependencies()
        {
            var client = new StoreApiClient();
            var service = new PetStoreApiService(client);
            _container.RegisterInstanceAs(service);
        }
    }
}
