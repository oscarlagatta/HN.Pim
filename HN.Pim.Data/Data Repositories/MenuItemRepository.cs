using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using HN.Pim.Business.Entities;
using HN.Pim.Data.Contracts.Repository_Interfaces;

namespace HN.Pim.Data.Data_Repositories
{
    [Export(typeof(IMenuItemRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class MenuItemRepository : DataRepositoryBase<MenuItem>, IMenuItemRepository
    {
        protected override MenuItem AddEntity(PimContext entityContext, MenuItem entity)
        {
            return entityContext.MenuItemSet.Add(entity);
        }

        protected override MenuItem UpdateEntity(PimContext entityContext, MenuItem entity)
        {
            return (from e in entityContext.MenuItemSet
                    where e.MenuId == entity.MenuId
                    select e).FirstOrDefault();
        }

        protected override IEnumerable<MenuItem> GetEntities(PimContext entityContext)
        {
            return from e in entityContext.MenuItemSet
                   select e;
        }

        protected override MenuItem GetEntity(PimContext entityContext, int id)
        {
            var query = (from e in entityContext.MenuItemSet
                         where e.MenuId == id
                         select e);

            var results = query.FirstOrDefault();

            return results;
        }
    }
}