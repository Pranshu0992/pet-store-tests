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
            Assert.AreEqual(expectedOrder.id, actualOrder.id, "order id does not match");
            Assert.AreEqual(expectedOrder.petId, actualOrder.petId, "petId does not match");
            Assert.AreEqual(expectedOrder.quantity, actualOrder.quantity, "quantity does not match");
            Assert.AreEqual(expectedOrder.status, actualOrder.status, "status does not match");
            Assert.AreEqual(expectedOrder.complete, actualOrder.complete, "complete status does not match");
            var expected = expectedOrder.shipDate.ToUniversalTime().ToString("yyyy-MM-dd HH");
            var actual = actualOrder.shipDate.ToUniversalTime().ToString("yyyy-MM-dd HH");
            Assert.AreEqual(expected, actual, "shipDate does not match (ignoring minutes)");
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
