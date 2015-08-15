using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Core.Common.Exceptions;
using HN.Pim.Business.Entities;

namespace HN.Pim.Business.Contracts
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
