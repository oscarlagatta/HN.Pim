using System.Security.Principal;
using System.Threading;
using Core.Common.Contracts;
using HN.Pim.Business.Entities;
using HN.Pim.Business.Managers.Managers;
using HN.Pim.Data.Contracts.Repository_Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace HN.Pim.Business.Managers.Tests
{
    [TestClass]
    public class InventoryManagerTests
    {
        [TestInitialize]
        public void Initialize()
        {
            GenericPrincipal principal = new GenericPrincipal(
               new GenericIdentity("Oscar"), new string[] { "Administrators", "eCommerceAdmin" });
            Thread.CurrentPrincipal = principal;
        }

        [TestMethod]
        public void UpdateResourceMaster_add_new_Resource()
        {
            ResourceMaster newResourceMaster = new ResourceMaster();
            ResourceMaster addedResourceMaster = new ResourceMaster() { ResourceId = 1 };

            Mock<IDataRepositoryFactory> mockDataRepositoryFactory = new Mock<IDataRepositoryFactory>();
            mockDataRepositoryFactory.Setup(mock => mock.GetDataRepository<IResourceMasterRepository>().Add(newResourceMaster)).Returns(addedResourceMaster);

            ResourceMasterManager manager = new ResourceMasterManager(mockDataRepositoryFactory.Object);

            ResourceMaster updateResourceMasterManagerResults = manager.UpdateMasterResource(newResourceMaster);

            Assert.IsTrue(updateResourceMasterManagerResults == addedResourceMaster);
        }

         [TestMethod]
        public void UpdateResourceMaster_update_existing()
        {
            ResourceMaster existingResourceMaster = new ResourceMaster() { ResourceId = 1 };
            ResourceMaster updatedResourceMaster = new ResourceMaster() { ResourceId = 1 };

            Mock<IDataRepositoryFactory> mockDataRepositoryFactory = new Mock<IDataRepositoryFactory>();
            mockDataRepositoryFactory.Setup(mock => mock.GetDataRepository<IResourceMasterRepository>().Update(existingResourceMaster)).Returns(updatedResourceMaster);

            ResourceMasterManager manager = new ResourceMasterManager(mockDataRepositoryFactory.Object);

            ResourceMaster updateResourceMasterResults = manager.UpdateMasterResource(existingResourceMaster);

            Assert.IsTrue(updateResourceMasterResults == updatedResourceMaster);
        }


    }
}
