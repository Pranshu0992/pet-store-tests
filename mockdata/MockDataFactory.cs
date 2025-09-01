using PetStoreApiSpecFlowTests.Model;
using System.Collections.Generic;

namespace PetStoreApiSpecFlowTests.MockData
{
    public static class MockDataFactory
    {
        public static Order createMockOrder(long id = 1, long petId = 1, int quantity = 1, string status = "placed", bool complete = true)
        {
            return new Order
            {
                id = id,
                petId = petId,
                quantity = quantity,
                status = status,
                complete = complete
            };
        }
    }
}
