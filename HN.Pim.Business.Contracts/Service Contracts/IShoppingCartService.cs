using System.Collections.Generic;
using System.ServiceModel;
using HN.Pim.Business.Entities;
using HN.Pim.Common;

namespace HN.Pim.Business.Contracts
{
    [ServiceContract]
    public interface IShoppingCartService
    {
        [OperationContract]
        [FaultContract(typeof(AuthorizationValidationException))]
        IEnumerable<SalesOrder> GetSalesOrderHistory(string loginEmail);
    }
}