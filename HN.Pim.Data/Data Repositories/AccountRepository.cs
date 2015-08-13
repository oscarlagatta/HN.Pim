using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using HN.Pim.Business.Entities;
using HN.Pim.Data.Contracts.Repository_Interfaces;

namespace HN.Pim.Data.Data_Repositories
{
    [Export(typeof(IAccountRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class AccountRepository : DataRepositoryBase<Account>, IAccountRepository
    {
        protected override Account AddEntity(PimContext entityContext, Account entity)
        {
            return entityContext.AccountSet.Add(entity);
        }

        protected override Account UpdateEntity(PimContext entityContext, Account entity)
        {
            return (from e in entityContext.AccountSet
                    where e.AccountId == entity.AccountId
                    select e).FirstOrDefault();
        }

        protected override IEnumerable<Account> GetEntities(PimContext entityContext)
        {
            return from e in entityContext.AccountSet
                   select e;
        }

        protected override Account GetEntity(PimContext entityContext, int id)
        {
            var query = (from e in entityContext.AccountSet
                         where e.AccountId == id
                         select e);

            var results = query.FirstOrDefault();

            return results;
        }

        public Account GetByLogin(string login)
        {
            using (PimContext entityContext = new PimContext())
            {
                return (from a in entityContext.AccountSet
                        where a.LoginEmail == login
                        select a).FirstOrDefault();
            }
        }
    }
}