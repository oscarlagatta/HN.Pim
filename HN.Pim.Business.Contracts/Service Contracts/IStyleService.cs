using System.ServiceModel;
using Core.Common.Exceptions;
using HN.Pim.Business.Entities;

namespace HN.Pim.Business.Contracts
{
    [ServiceContract]
    public interface IStyleService
    {
        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        Style GetStyle(int MerretStleID);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        Style[] GetAllStyles();

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        Style UpdateStyle(Style style);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteStyle(int MerretStleID);

    }
}