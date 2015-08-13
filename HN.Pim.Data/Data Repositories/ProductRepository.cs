using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using HN.Pim.Business.Entities;
using HN.Pim.Data.Contracts.Repository_Interfaces;

namespace HN.Pim.Data.Data_Repositories
{
   
    [Export(typeof(IProductRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ProductRepository : DataRepositoryBase<Product>, IProductRepository
    {
        protected override Product AddEntity(PimContext entityContext, Product entity)
        {
            return entityContext.ProductSet.Add(entity);
        }

        protected override Product UpdateEntity(PimContext entityContext, Product entity)
        {
            return (from e in entityContext.ProductSet
                    where e.ProductId == entity.ProductId
                    select e).FirstOrDefault();
        }

        protected override IEnumerable<Product> GetEntities(PimContext entityContext)
        {
            return from e in entityContext.ProductSet
                   select e;
        }

        protected override Product GetEntity(PimContext entityContext, int id)
        {
            var query = (from e in entityContext.ProductSet
                         where e.ProductId == id
                         select e);

            var results = query.FirstOrDefault();

            return results;
        }

        public Product GetByAsin(string asinCode)
        {
            using (PimContext entityContext = new PimContext())
            {
                return (from a in entityContext.ProductSet
                        where a.Asin == asinCode
                        select a).FirstOrDefault();
            }
        }
    }
}