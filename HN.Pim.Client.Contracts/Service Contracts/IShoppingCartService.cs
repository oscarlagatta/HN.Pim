using System.Collections.Generic;
using System.ServiceModel;
using Core.Common.Contracts;
using HN.Pim.Client.Entities;
using HN.Pim.Common;

namespace HN.Pim.Client.Contracts
{
    [ServiceContract]
    public interface IShoppingCartService : IServiceContract
    {
        [OperationContract]
        [FaultContract(typeof(AuthorizationValidationException))]
        IEnumerable<SalesOrder> GetSalesOrderHistory(string loginEmail);
    }
}