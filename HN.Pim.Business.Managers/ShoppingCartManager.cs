using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Security.Permissions;
using System.ServiceModel;
using Core.Common.Contracts;
using Core.Common.Exceptions;
using HN.Pim.Business.Contracts;
using HN.Pim.Business.Entities;
using HN.Pim.Common;
using HN.Pim.Data.Contracts.Repository_Interfaces;

namespace HN.Pim.Business.Managers
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall,
    ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class ShoppingCartManager : ManagerBase, IShoppingCartService
    {
        public ShoppingCartManager()
        {
        }

        public ShoppingCartManager(IDataRepositoryFactory dataRepositoryFactory)
        {
            _dataRepositoryFactory = dataRepositoryFactory;
        }

        protected override Account LoadAuthorizationValidationAccount(string loginName)
        {
            IAccountRepository accountRepository = _dataRepositoryFactory.GetDataRepository<IAccountRepository>();
            Account authAccount = accountRepository.GetByLogin(loginName);
            if (authAccount == null)
            {
                NotFoundException ex = new NotFoundException(string.Format("Cannot find account for login name {0} to use for security filtering.", loginName));
                throw new FaultException<NotFoundException>(ex, ex.Message);
            }

            return authAccount;
        }

        public ShoppingCartManager(IBusinessEngineFactory businessEngineFactory)
        {
            _businessEngineFactory = businessEngineFactory;
        }

        public ShoppingCartManager(IDataRepositoryFactory dataRepositoryFactory, IBusinessEngineFactory businessEngineFactory)
        {
            _dataRepositoryFactory = dataRepositoryFactory;
            _businessEngineFactory = businessEngineFactory;
        }

        [Import]
        private IDataRepositoryFactory _dataRepositoryFactory;

        [Import]
        IBusinessEngineFactory _businessEngineFactory;

        [PrincipalPermission(SecurityAction.Demand, Role = Security.eCommerceAdminRole)]
        [PrincipalPermission(SecurityAction.Demand, Name = Security.eCommerceUser)]
        public IEnumerable<SalesOrder> GetSalesOrderHistory(string loginEmail)
        {

            return ExecuteFaultHandledOperation(() =>
            {
                IAccountRepository accountRepository = _dataRepositoryFactory.GetDataRepository<IAccountRepository>();
                // IRentalRepository salesOrderRepository = _DataRepositoryFactory.GetDataRepository<ISalesOrderRepository>();

                Account account = accountRepository.GetByLogin(loginEmail);

                if (account == null)
                {
                    NotFoundException ex = new NotFoundException(string.Format("No account found for login '{0}'.", loginEmail));
                    throw new FaultException<NotFoundException>(ex, ex.Message);
                }

                ValidateAuthorization(account);

                //IEnumerable<SalesOrder> rentalHistory = salesOrderRepository.GetSalesOrderHistoryByAccount(account.AccountId);

                var SalesOrderList =
               new List<SalesOrder>
                {
                    new SalesOrder {SalesOrderId = 1, AccountId = 1, Amount = 18.0000M},
                    new SalesOrder {SalesOrderId = 2, AccountId = 1, Amount = 19.0000M},
                    new SalesOrder {SalesOrderId = 3, AccountId = 1, Amount = 10.0000M}
                };

                return SalesOrderList;
            });
        }
    }
}