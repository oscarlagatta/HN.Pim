using System.Collections.Generic;
using System.ServiceModel;
using Core.Common.Exceptions;
using HN.Pim.Client.Entities;

namespace HN.Pim.Client.Contracts
{
    [ServiceContract]
    public interface IMenuItemService
    {
        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        List<MenuItem> GetAllMenuItems();
    }
}