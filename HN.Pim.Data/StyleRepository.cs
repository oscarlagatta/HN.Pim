using System.Collections.Generic;
using System.ComponentModel.Composition;
using HN.Pim.Business.Entities;
using HN.Pim.Data.Contracts.Repository_Interfaces;
using System.Linq;
using Core.Common.Data;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq.Expressions;

namespace HN.Pim.Data
{
    [Export(typeof(IStyleRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class StyleRepository : DataRepositoryBase<Style>, IStyleRepository
    {
        protected override Style AddEntity(PimContext entityContext, Style entity)
        {
            return entityContext.StyleSet.Add(entity);
        }

        protected override Style UpdateEntity(PimContext entityContext, Style entity)
        {
            return (from e in entityContext.StyleSet
                    where e.MerretStyleID == entity.MerretStyleID
                    select e).FirstOrDefault();
        }

        protected override IEnumerable<Style> GetEntities(PimContext entityContext)
        {
            return from e in entityContext.StyleSet
                   select e;
        }

        protected override Style GetEntity(PimContext entityContext, int id)
        {
            var query = (from e in entityContext.StyleSet
                         where e.MerretStyleID == id
                         select e);

            var results = query.FirstOrDefault();

            return results;
        }

        public int GetTotalOfStyles()
        {
            using (PimContext entityContext = new PimContext())
            {
                var query = (from e in entityContext.StyleSet
                             select e);

                return query.Count();
            }
        }
    }
}