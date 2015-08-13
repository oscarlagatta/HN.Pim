using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using HN.Pim.Business.Entities;
using HN.Pim.Data.Contracts.Repository_Interfaces;

namespace HN.Pim.Data.Data_Repositories
{
    [Export(typeof(IResourceMasterRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ResourceMasterRepository: DataRepositoryBase<ResourceMaster>, IResourceMasterRepository
    {
        protected override ResourceMaster AddEntity(PimContext entityContext, ResourceMaster entity)
        {
            return entityContext.ResourceMasterSet.Add(entity);
        }

        protected override ResourceMaster UpdateEntity(PimContext entityContext, ResourceMaster entity)
        {
            return (from e in entityContext.ResourceMasterSet
                    where e.ResourceId == entity.ResourceId
                    select e).FirstOrDefault();
        }

        protected override IEnumerable<ResourceMaster> GetEntities(PimContext entityContext)
        {
            return from e in entityContext.ResourceMasterSet
                   select e;
        }

        protected override ResourceMaster GetEntity(PimContext entityContext, int id)
        {
            var query = (from e in entityContext.ResourceMasterSet
                         where e.ResourceId == id
                         select e);

            var results = query.FirstOrDefault();

            return results;
        }

        public IEnumerable<ResourceMaster> GetByCultureCode(string cultureCode)
        {
            using (PimContext entityContext = new PimContext())
            {
                return  (from e in entityContext.ResourceMasterSet
                    where e.Culture == cultureCode
                    select e);
            }
        }
    }
}