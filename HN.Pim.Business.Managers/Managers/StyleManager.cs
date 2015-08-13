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
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall,
       ConcurrencyMode = ConcurrencyMode.Multiple,
       ReleaseServiceInstanceOnTransactionComplete = false)]
    public class StyleManager : ManagerBase, IStyleService
    {
        [Import]
        private IDataRepositoryFactory _dataRepositoryFactory;


        public StyleManager()
        {

        }

        public StyleManager(IDataRepositoryFactory dataRepositoryFactory)
        {
            _dataRepositoryFactory = dataRepositoryFactory;
        }

        public Style GetStyle(int MerretStleID)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                IStyleRepository styleRepository = _dataRepositoryFactory.GetDataRepository<IStyleRepository>();

                Style resourceMasterEntity = styleRepository.Get().Where(r => r.MerretStyleID == MerretStleID).FirstOrDefault();

                if (resourceMasterEntity == null)
                {
                    NotFoundException ex
                        = new NotFoundException(string.Format("Style ID {0} is not in the database. ", MerretStleID));

                    throw new FaultException<NotFoundException>(ex, ex.Message);
                }

                return resourceMasterEntity;
            });
        }

        public Style[] GetAllStyles()
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var styleRepository
                    = _dataRepositoryFactory.GetDataRepository<IStyleRepository>();

                IEnumerable<Style> styles = styleRepository.Get();

                return styles.ToArray();
            });
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public Style UpdateStyle(Style style)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var styleRepository = _dataRepositoryFactory.GetDataRepository<IStyleRepository>();

                Style updatedStyle = null;

                if (updatedStyle.MerretStyleID == 0)
                    updatedStyle = styleRepository.Add(style);
                else
                    updatedStyle = styleRepository.Update(style);

                return updatedStyle;
            });
        }

        public void DeleteStyle(int MerretStleID)
        {
            ExecuteFaultHandledOperation(() =>
            {
                var styleRepository = _dataRepositoryFactory.GetDataRepository<IStyleRepository>();

                var styleEntity = styleRepository.Get(MerretStleID);

                if (styleEntity == null)
                {
                    NotFoundException ex
                        = new NotFoundException(string.Format("Resource Master with Id {0} is not in the database. ", MerretStleID));

                    throw new FaultException<NotFoundException>(ex, ex.Message);
                }

                styleRepository.Remove(MerretStleID);
            });
        }
    }
}