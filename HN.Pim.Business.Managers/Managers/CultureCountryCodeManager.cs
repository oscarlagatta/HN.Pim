using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.ServiceModel;
using Core.Common.Contracts;
using Core.Common.Exceptions;
using HN.Pim.Business.Contracts;
using HN.Pim.Business.Entities;
using HN.Pim.Data.Contracts.Repository_Interfaces;

namespace HN.Pim.Business.Managers.Managers
{
    /// <summary>
    /// Web service to manage operations with the Culture Country Code
    /// </summary>
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall,
       ConcurrencyMode = ConcurrencyMode.Multiple,
       ReleaseServiceInstanceOnTransactionComplete = false)]
    public class CultureCountryCodeManager : ManagerBase, ICultureCountryCodeService
    {
        public CultureCountryCodeManager()
        {
        }

        public CultureCountryCodeManager(IDataRepositoryFactory dataRepositoryFactory)
        {
            _dataRepositoryFactory = dataRepositoryFactory;
        }

        [Import]
        IDataRepositoryFactory _dataRepositoryFactory;

        /// <summary>
        /// Get an entity of type CultureCountryCode
        /// </summary>
        /// <param name="cultureCountryCodeId"></param>
        /// <returns></returns>
        public CultureCountryCode GetCultureCountryCode(int cultureCountryCodeId)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var productRepositoryFactory = _dataRepositoryFactory.GetDataRepository<ICultureCountryCodeRepository>();

                CultureCountryCode CultureCountryCodeEntity = productRepositoryFactory.Get(cultureCountryCodeId);

                if (CultureCountryCodeEntity == null)
                {
                    NotFoundException ex
                        = new NotFoundException(string.Format("Culture Country with Id {0} is not in the database. ", cultureCountryCodeId));

                    throw new FaultException<NotFoundException>(ex, ex.Message);
                }

                return CultureCountryCodeEntity;
            });

        }

        /// <summary>
        /// Get a list of all the existing culture country codes available in the database
        /// </summary>
        /// <returns></returns>
        public CultureCountryCode[] GetAllCultureCountryCode()
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var cultureCountryCodeRepository
                    = _dataRepositoryFactory.GetDataRepository<ICultureCountryCodeRepository>();

                IEnumerable<CultureCountryCode> cultureCountryCodes = cultureCountryCodeRepository.Get();

                return cultureCountryCodes.ToArray();
            });
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public CultureCountryCode UpdateCultureCountryCode(CultureCountryCode cultureCountryCode)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var cultureCountryCodeRepository = _dataRepositoryFactory.GetDataRepository<ICultureCountryCodeRepository>();

                CultureCountryCode updatedCultureCountryCode = null;

                if (cultureCountryCode.Id == 0)
                    updatedCultureCountryCode = cultureCountryCodeRepository.Add(cultureCountryCode);
                else
                    updatedCultureCountryCode = cultureCountryCodeRepository.Update(cultureCountryCode);

                return updatedCultureCountryCode;
            });
        }

        public void DeleteCultureCountryCode(int cultureCountryCodeId)
        {
            ExecuteFaultHandledOperation(() =>
            {
                var cultureCountryCodeRepository = _dataRepositoryFactory.GetDataRepository<ICultureCountryCodeRepository>();

                var accountEntity = cultureCountryCodeRepository.Get(cultureCountryCodeId);

                if (accountEntity == null)
                {
                    NotFoundException ex
                        = new NotFoundException(string.Format("Product with Id {0} is not in the database. ", cultureCountryCodeId));

                    throw new FaultException<NotFoundException>(ex, ex.Message);
                }

                cultureCountryCodeRepository.Remove(cultureCountryCodeId);
            });
        }
    }
}