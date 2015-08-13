using System.Collections.Generic;
using Core.Common.Contracts;
using HN.Pim.Business.Entities;

namespace HN.Pim.Business.Common
{
    public interface IResourceMasterEngine : IBusinessEngine
    {
        bool IsMasterResourceActive(int ResourceId, IEnumerable<ResourceMaster> resourceMasterList);
    }
}