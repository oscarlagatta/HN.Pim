using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Core.Common.Contracts;
using Core.Common.Core;
using HN.Pim.Business.Bootstrapper;
using HN.Pim.Business.Entities;
using HN.Pim.Data.Contracts.Repository_Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace HN.Pim.Data.Tests
{
    [TestClass]
    public class DataLayerTests
    {
        [TestInitialize]
        public void Initialize()
        {
            ObjectBase.Container = MEFLoader.Init();
        }

        [TestMethod]
        public void test_repository_usage()
        {
            RepositoryTestClass repositoryTest = new RepositoryTestClass();

            IEnumerable<Product> products = repositoryTest.GetProducts();

            Assert.IsTrue(products != null);
        }

        [TestMethod]


        public void test_repository_factory_usage()
        {
            RepositoryFactoryTestClass factoryTest = new RepositoryFactoryTestClass();

            IEnumerable<Product> products = factoryTest.GetProducts();

            Assert.IsTrue(products != null);
        }

        [TestMethod]
        public void test_repository_factory_countryCultureCodes()
        {
            RepositoryFactoryTestClass factoryTest = new RepositoryFactoryTestClass();

            IEnumerable<CultureCountryCode> cultureCountryCodes = factoryTest.GetCultureCountryCodes();

            var countries = cultureCountryCodes.Select(e => e.Country).Distinct().ToList();

            var cultures = cultureCountryCodes.Select(e => e.CultureInfoCode).Distinct().ToList();

            Assert.IsTrue(cultureCountryCodes != null);
        }



        [TestMethod]
        public void test_repository_factory_Resources()
        {
            RepositoryFactoryTestClass factoryTest = new RepositoryFactoryTestClass();

            IEnumerable<ResourceMaster> resources = factoryTest.GetResources();

            Assert.IsTrue(resources != null);
        }
        
        [TestMethod]
        public void test_repository_mocking()
        {
            List<Product> products = new List<Product>()
            {
                new Product() { ProductId = 1, Name = "Product1" ,Asin = "ABC" , Price = 15.5m},
                new Product() { ProductId = 2, Name = "Product2" , Asin = "ABC", Price = 55.99m}
            };

            Mock<IProductRepository> mockProductrRepository = new Mock<IProductRepository>();
            mockProductrRepository.Setup(obj => obj.Get()).Returns(products);

            RepositoryTestClass repositoryTest = new RepositoryTestClass(mockProductrRepository.Object);

            IEnumerable<Product> ret = repositoryTest.GetProducts();

            Assert.IsTrue(ret == products);
        }

        [TestMethod]
        public void test_factory_mocking1()
        {
            List<Product> products = new List<Product>()
            {
                new Product() { ProductId = 1, Name = "Product1" ,Asin = "ABC" , Price = 15.5m},
                new Product() { ProductId = 2, Name = "Product2" , Asin = "ABC", Price = 55.99m}
            };


            Mock<IDataRepositoryFactory> mockDataRepository = new Mock<IDataRepositoryFactory>();
            mockDataRepository.Setup(obj => obj.GetDataRepository<IProductRepository>().Get()).Returns(products);

            RepositoryFactoryTestClass factoryTest = new RepositoryFactoryTestClass(mockDataRepository.Object);

            IEnumerable<Product> ret = factoryTest.GetProducts();

            Assert.IsTrue(ret == products);
        }

        [TestMethod]
        public void test_factory_mocking2()
        {
            List<Product> products = new List<Product>()
            {
                new Product() { ProductId = 1, Name = "Product1" ,Asin = "ABC" , Price = 15.5m},
                new Product() { ProductId = 2, Name = "Product2" , Asin = "ABC", Price = 55.99m}
            };

            Mock<IProductRepository> mockProductRepository = new Mock<IProductRepository>();
            mockProductRepository.Setup(obj => obj.Get()).Returns(products);

            Mock<IDataRepositoryFactory> mockDataRepository = new Mock<IDataRepositoryFactory>();
            mockDataRepository.Setup(obj => obj.GetDataRepository<IProductRepository>()).Returns(mockProductRepository.Object);

            RepositoryFactoryTestClass factoryTest = new RepositoryFactoryTestClass(mockDataRepository.Object);

            IEnumerable<Product> ret = factoryTest.GetProducts();

            Assert.IsTrue(ret == products);
        }
    }

    public class RepositoryTestClass
    {
        public RepositoryTestClass()
        {
            ObjectBase.Container.SatisfyImportsOnce(this);
        }

        public RepositoryTestClass(IProductRepository productRepository)
        {
            _ProductRepository = productRepository;
        }

        [Import]
        IProductRepository _ProductRepository;

        public IEnumerable<Product> GetProducts()
        {
            IEnumerable<Product> products = _ProductRepository.Get();

            return products;
        }
    }

    public class RepositoryFactoryTestClass
    {
        public RepositoryFactoryTestClass()
        {
            ObjectBase.Container.SatisfyImportsOnce(this);
        }

        public RepositoryFactoryTestClass(IDataRepositoryFactory dataRepositoryFactory)
        {
            _DataRepositoryFactory = dataRepositoryFactory;
        }

        [Import]
        IDataRepositoryFactory _DataRepositoryFactory;

        public IEnumerable<Product> GetProducts()
        {
            IProductRepository productRepository = _DataRepositoryFactory.GetDataRepository<IProductRepository>();

            IEnumerable<Product> products = productRepository.Get();

            return products;
        }

        public IEnumerable<ResourceMaster> GetResources()
        {
            IResourceMasterRepository resourcesRepository = _DataRepositoryFactory.GetDataRepository<IResourceMasterRepository>();

            IEnumerable<ResourceMaster> resources = resourcesRepository.Get();

            return resources;
        }


        public IEnumerable<CultureCountryCode> GetCultureCountryCodes()
        {
            ICultureCountryCodeRepository cultureCountryCodeRepository = _DataRepositoryFactory.GetDataRepository<ICultureCountryCodeRepository>();

            IEnumerable<CultureCountryCode> cultureCountryCodes = cultureCountryCodeRepository.Get();

            return cultureCountryCodes;
        }


    }
}