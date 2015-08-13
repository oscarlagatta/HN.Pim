using System.ServiceModel;
using Core.Common.Exceptions;
using HN.Pim.Business.Entities;
using HN.Pim.Common;

namespace HN.Pim.Business.Contracts
{
    [ServiceContract]
    public interface IAccountService
    {
        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        [FaultContract(typeof(AuthorizationValidationException))]
        Account GetCustomerAccountInfo(string loginEmail);

        [OperationContract]
        [FaultContract(typeof(AuthorizationValidationException))]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void UpdateCustomerAccountInfo(Account account);
    }
}