using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using HN.Pim.Business.Entities;
using HN.Pim.Data.Contracts.Repository_Interfaces;

namespace HN.Pim.Data.Data_Repositories
{
    [Export(typeof(ICultureCountryCodeRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class CultureCountryCodeRepository : DataRepositoryBase<CultureCountryCode>, ICultureCountryCodeRepository
    {
        protected override CultureCountryCode AddEntity(PimContext entityContext, CultureCountryCode entity)
        {
            return entityContext.CultureCountryCodeSet.Add(entity);
        }

        protected override CultureCountryCode UpdateEntity(PimContext entityContext, CultureCountryCode entity)
        {
            return (from e in entityContext.CultureCountryCodeSet
                    where e.Id == entity.Id
                    select e).FirstOrDefault();
        }

        protected override IEnumerable<CultureCountryCode> GetEntities(PimContext entityContext)
        {
            return from e in entityContext.CultureCountryCodeSet
                   select e;
        }

        protected override CultureCountryCode GetEntity(PimContext entityContext, int id)
        {
            var query = (from e in entityContext.CultureCountryCodeSet
                         where e.Id == id
                         select e);

            var results = query.FirstOrDefault();

            return results;
        }
    }
}