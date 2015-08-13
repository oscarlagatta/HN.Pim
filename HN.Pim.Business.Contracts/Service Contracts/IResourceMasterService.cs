using System.ServiceModel;
using Core.Common.Exceptions;
using HN.Pim.Business.Entities;

namespace HN.Pim.Business.Contracts
{
    [ServiceContract]
    public interface IResourceMasterService
    {
        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        ResourceMaster GetMasterResource(string resourceKey);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        ResourceMaster[] GetAllMasterResources();

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        ResourceMaster UpdateMasterResource(ResourceMaster resource);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteMasterResource(int ResourceId);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        string[] GetAvailableMasterResources();

    }
}