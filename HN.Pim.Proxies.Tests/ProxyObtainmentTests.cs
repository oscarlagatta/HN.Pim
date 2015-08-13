using Core.Common.Contracts;
using Core.Common.Core;
using HN.Pim.Client.Bootstrapper;
using HN.Pim.Client.Contracts;
using HN.Pim.Client.Proxies;
using HN.Pim.Client.Proxies.Service_Proxies;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HN.Pim.Proxies.Tests
{
    [TestClass]
    public class ProxyObtainmentTests
    {

        [TestInitialize]
        public void Initialize()
        {
            ObjectBase.Container = MEFLoader.Init();
        }

        /// <summary>
        /// obtain a proxy from the container and verify is the proper contract
        /// </summary>
        [TestMethod]
        public void obtain_proxy_from_container_using_service_contract()
        {
            IResourceMasterService proxy =
                ObjectBase.Container.GetExportedValue<IResourceMasterService>();

            Assert.IsTrue(proxy is ResourceMasterClient);
        }

        [TestMethod]
        public void obtain_proxy_from_service_factory()
        {
            IServiceFactory factory = new ServiceFactory();

            IResourceMasterService proxy = factory.CreateClient<IResourceMasterService>();

            Assert.IsTrue(proxy is ResourceMasterClient);
        }

        [TestMethod]
        public void obtain_service_factory_and_proxy_from_container()
        {
            IServiceFactory factory = 
                ObjectBase.Container.GetExportedValue<IServiceFactory>();

            IResourceMasterService proxy = factory.CreateClient<IResourceMasterService>();

            Assert.IsTrue(proxy is ResourceMasterClient);
        }

    }
}