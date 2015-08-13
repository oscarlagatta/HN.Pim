using System.ServiceModel;
using Core.Common.Contracts;
using Core.Common.Exceptions;
using HN.Pim.Client.Entities;

namespace HN.Pim.Client.Contracts
{
    [ServiceContract]
    public interface ICultureCountryCodeService :IServiceContract
    {
        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        CultureCountryCode GetCultureCountryCode(int cultureCountryCodeId);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        CultureCountryCode[] GetAllCultureCountryCode();

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        CultureCountryCode UpdateCultureCountryCode(CultureCountryCode cultureCountryCode);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteCultureCountryCode(int cultureCountryCodeId);
    }
}