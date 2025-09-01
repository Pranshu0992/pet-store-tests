using System.Net.Http;
using PetStoreApiSpecFlowTests.Model;
using PetStoreApiSpecFlowTests.Client;
using PetStoreApiSpecFlowTests.Helpers;

namespace PetStoreApiSpecFlowTests.Steps
{
    public abstract class BaseSteps
    {
        protected PetStoreApiService service { get; }
        protected HttpResponseMessage response;
        protected bool authenticated = true;
        protected Order order;

        public BaseSteps(PetStoreApiService service)
        {
            this.service = service;
        }
    }
}
