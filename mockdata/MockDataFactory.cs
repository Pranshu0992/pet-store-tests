using PetStoreApiSpecFlowTests.Model;
using System.Collections.Generic;
using System;

namespace PetStoreApiSpecFlowTests.MockData
{
    public static class MockDataFactory
    {
    public static Order createMockOrder(long id = 5, long petId = 10, int quantity = 15, DateTime? shipDateTime = null, string status = "placed", bool complete = true)
        {
            return new Order
            {
                id = id,
                petId = petId,
                quantity = quantity,
                shipDate = shipDateTime ?? DateTime.UtcNow,
                status = status,
                complete = complete
            };
        }
    }
}
