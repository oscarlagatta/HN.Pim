using System.ComponentModel.Composition;
using Core.Common.ServiceModel;
using HN.Pim.Client.Contracts;
using HN.Pim.Client.Entities;

namespace HN.Pim.Client.Proxies.Service_Proxies
{
    [Export(typeof(IResourceMasterService))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ResourceMasterClient : UserClientBase<IResourceMasterService>, IResourceMasterService
    {
        
        public ResourceMaster GetMasterResource(string resourceKey)
        {
            return Channel.GetMasterResource(resourceKey);
        }

        public ResourceMaster[] GetAllMasterResources()
        {
            return Channel.GetAllMasterResources();
        }

        public ResourceMaster UpdateMasterResource(ResourceMaster resource)
        {
            return Channel.UpdateMasterResource(resource);
        }

        public void DeleteMasterResource(int ResourceId)
        {
            Channel.DeleteMasterResource(ResourceId);
        }

        public string[] GetAvailableMasterResources()
        {
            return Channel.GetAvailableMasterResources();
        }
    }
}