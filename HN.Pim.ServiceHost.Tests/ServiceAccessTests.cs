using System.ServiceModel;
using HN.Pim.Business.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HN.Pim.ServiceHost.Tests
{
    [TestClass]
    public class ServiceAccessTests
    {
        [TestMethod]
        public void test_product_manager_as_service()
        {

            ChannelFactory<IProductService> channelFactory = 
                new ChannelFactory<IProductService>("");

            IProductService proxy = channelFactory.CreateChannel();
            
            (proxy as ICommunicationObject).Open();

            channelFactory.Close();
        }

        [TestMethod]
        public void test_resourceMaster_manager_as_service()
        {

            ChannelFactory<IResourceMasterService> channelFactory =
                new ChannelFactory<IResourceMasterService>("");

            IResourceMasterService proxy = channelFactory.CreateChannel();

            (proxy as ICommunicationObject).Open();

            channelFactory.Close();
        }
    }
}
