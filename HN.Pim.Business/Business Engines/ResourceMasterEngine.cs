using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using HN.Pim.Business.Common;
using HN.Pim.Business.Entities;

namespace HN.Pim.Business.Business_Engines
{
    [Export(typeof(IResourceMasterEngine))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class ResourceMasterEngine : IResourceMasterEngine
    {
        public bool IsMasterResourceActive(int ResourceId, IEnumerable<ResourceMaster> resourceMasterList )
        {
            bool resourceAvailable = true;

            // here the business logic
            ResourceMaster resourceMaster = resourceMasterList.Where(r => r.ResourceId == ResourceId).FirstOrDefault();
            if (resourceMaster != null && resourceMaster.Culture == "ar") // && resourceMaster.Avctive == true )
            {
                resourceAvailable = false;
            }

            return resourceAvailable;
        }
    }
}