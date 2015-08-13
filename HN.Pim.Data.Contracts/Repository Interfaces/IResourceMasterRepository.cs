using System.Collections.Generic;
using Core.Common.Contracts;
using HN.Pim.Business.Entities;

namespace HN.Pim.Data.Contracts.Repository_Interfaces
{
    public interface IResourceMasterRepository : IDataRepository<ResourceMaster>
    {
        IEnumerable<ResourceMaster> GetByCultureCode(string cultureCode);
    }
}