using PetStoreApiSpecFlowTests.Model;
using System.Collections.Generic;

namespace PetStoreApiSpecFlowTests.MockData
{
    public static class MockDataFactory
    {
        public static Order CreateMockOrder(long id = 1, long petId = 1, int quantity = 1, string status = "placed", bool complete = true)
        {
            return new Order
            {
                Id = id,
                PetId = petId,
                Quantity = quantity,
                Status = status,
                Complete = complete
            };
        }

        public static Dictionary<string, int> CreateMockInventory()
        {
            return new Dictionary<string, int>
            {
                { "available", 10 },
                { "pending", 2 },
                { "sold", 5 }
            };
        }
    }
}
