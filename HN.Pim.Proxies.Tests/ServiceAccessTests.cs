using HN.Pim.Client.Proxies;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HN.Pim.Proxies.Tests
{
    [TestClass]
    public class ServiceAccessTests
    {
        [TestMethod]
        public void test_product_client_connection()
        {
            ProductClient proxy = new ProductClient();

            proxy.Open();
        }

    }
}