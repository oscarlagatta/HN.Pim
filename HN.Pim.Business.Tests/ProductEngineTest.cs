using Core.Common.Contracts;
using HN.Pim.Business.Business_Engines;
using HN.Pim.Business.Entities;
using HN.Pim.Data.Contracts.Repository_Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace HN.Pim.Business.Tests
{
    /*
  * Naming convetion for a test
  * underscore delimited sentence describing the test or
  * pascal casing which indicates this test corresponds to 
  * a method with the same name
  */
    [TestClass]
    public class ProductEngineTest
    {
        [TestMethod]
        public void IsProductAvailable_any_client()
        {
            Product product = new Product()
            {
                ProductId = 1,
                Stock = 5
            };

            Mock<IProductRepository> mockProductRepository = new Mock<IProductRepository>();
            mockProductRepository.Setup(obj => obj.Get(1)).Returns(product);

            Mock<IDataRepositoryFactory> mockRepositoryFactory = new Mock<IDataRepositoryFactory>();
            mockRepositoryFactory.Setup(obj => obj.GetDataRepository<IProductRepository>()).Returns(mockProductRepository.Object);

            ProductEngine engine = new ProductEngine(mockRepositoryFactory.Object);

            bool try1 = engine.isProductAvailable(2);

            Assert.IsFalse(try1);

            bool try2 = engine.isProductAvailable(1);

            Assert.IsTrue(try2);
        }
    }
}
