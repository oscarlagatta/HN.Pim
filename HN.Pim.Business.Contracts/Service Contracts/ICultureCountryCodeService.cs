using System.ServiceModel;
using Core.Common.Exceptions;
using HN.Pim.Business.Entities;

namespace HN.Pim.Business.Contracts
{
    [ServiceContract]
    public interface ICultureCountryCodeService
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