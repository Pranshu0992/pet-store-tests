using PetStoreApiSpecFlowTests.Model;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using NUnit.Framework;

namespace PetStoreApiSpecFlowTests.Helpers
{
    public static class ResponseVerifier
    {
        public static async Task VerifyOrderResponse(HttpResponseMessage response, Order expectedOrder)
        {
            var json = await response.Content.ReadAsStringAsync();
            var actualOrder = JsonConvert.DeserializeObject<Order>(json);
            Assert.AreEqual(expectedOrder.Id, actualOrder.Id);
            Assert.AreEqual(expectedOrder.PetId, actualOrder.PetId);
            Assert.AreEqual(expectedOrder.Quantity, actualOrder.Quantity);
            Assert.AreEqual(expectedOrder.Status, actualOrder.Status);
            Assert.AreEqual(expectedOrder.Complete, actualOrder.Complete);
        }

        public static async Task VerifyInventoryResponse(HttpResponseMessage response, Dictionary<string, int> expectedInventory)
        {
            var json = await response.Content.ReadAsStringAsync();
            var actualInventory = JsonConvert.DeserializeObject<Dictionary<string, int>>(json);
            foreach (var key in expectedInventory.Keys)
            {
                Assert.AreEqual(expectedInventory[key], actualInventory[key]);
            }
        }
    }
}
