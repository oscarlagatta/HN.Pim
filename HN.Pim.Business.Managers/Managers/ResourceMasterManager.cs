using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.ServiceModel;
using Core.Common.Contracts;
using Core.Common.Exceptions;
using HN.Pim.Business.Common;
using HN.Pim.Business.Contracts;
using HN.Pim.Business.Entities;
using HN.Pim.Data.Contracts.Repository_Interfaces;

namespace HN.Pim.Business.Managers.Managers
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall,
       ConcurrencyMode = ConcurrencyMode.Multiple,
       ReleaseServiceInstanceOnTransactionComplete = false)]
    public class ResourceMasterManager : ManagerBase, IResourceMasterService
    {
        public ResourceMasterManager()
        {
        }

        public ResourceMasterManager(IDataRepositoryFactory dataRepositoryFactory)
        {
            _dataRepositoryFactory = dataRepositoryFactory;
        }

        public ResourceMasterManager(IBusinessEngineFactory businessEngineFactory)
        {
            _businessEngineFactory = businessEngineFactory;
        }

        public ResourceMasterManager(IDataRepositoryFactory dataRepositoryFactory, IBusinessEngineFactory businessEngineFactory)
        {
            _dataRepositoryFactory = dataRepositoryFactory;
            _businessEngineFactory = businessEngineFactory;
        }

        [Import]
        private IDataRepositoryFactory _dataRepositoryFactory;

        [Import]
        IBusinessEngineFactory _businessEngineFactory;

        //[PrincipalPermission(SecurityAction.Demand, Role = Security.eCommerceAdminRole)]
        //[PrincipalPermission(SecurityAction.Demand, Name = Security.eCommerceUser)]
        public ResourceMaster GetMasterResource(string resourceKey)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                IResourceMasterRepository resourceMasterRepository = _dataRepositoryFactory.GetDataRepository<IResourceMasterRepository>();

                ResourceMaster resourceMasterEntity = resourceMasterRepository.Get().Where(r => r.Name == resourceKey).FirstOrDefault();

                if (resourceMasterEntity == null)
                {
                    NotFoundException ex
                        = new NotFoundException(string.Format("Master Resource with name {0} is not in the database. ", resourceKey));

                    throw new FaultException<NotFoundException>(ex, ex.Message);
                }

                return resourceMasterEntity;
            });

        }

        //[PrincipalPermission(SecurityAction.Demand, Role = Security.eCommerceAdminRole)]
        //[PrincipalPermission(SecurityAction.Demand, Name = Security.eCommerceUser)]
        public ResourceMaster[] GetAllMasterResources()
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var resourceMasterRepository
                    = _dataRepositoryFactory.GetDataRepository<IResourceMasterRepository>();

                IEnumerable<ResourceMaster> masterResources = resourceMasterRepository.Get();

                return masterResources.ToArray();
            });
        }

        
        [OperationBehavior(TransactionScopeRequired = true)]
        //[PrincipalPermission(SecurityAction.Demand, Role = Security.eCommerceAdminRole)]
        public ResourceMaster UpdateMasterResource(ResourceMaster resourceMaster)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var resourceMasterRepository = _dataRepositoryFactory.GetDataRepository<IResourceMasterRepository>();

                ResourceMaster updatedResourceMaster = null;

                if (resourceMaster.ResourceId == 0)
                    updatedResourceMaster = resourceMasterRepository.Add(resourceMaster);
                else
                    updatedResourceMaster = resourceMasterRepository.Update(resourceMaster);

                return updatedResourceMaster;
            });
        }

        //[PrincipalPermission(SecurityAction.Demand, Role = Security.eCommerceAdminRole)]
        [OperationBehavior(TransactionScopeRequired = true)]
        public void DeleteMasterResource(int ResourceId)
        {
            ExecuteFaultHandledOperation(() =>
            {
                var resourceMasterRepository = _dataRepositoryFactory.GetDataRepository<IResourceMasterRepository>();

                var accountEntity = resourceMasterRepository.Get(ResourceId);

                if (accountEntity == null)
                {
                    NotFoundException ex
                        = new NotFoundException(string.Format("Resource Master with Id {0} is not in the database. ", ResourceId));

                    throw new FaultException<NotFoundException>(ex, ex.Message);
                }

                resourceMasterRepository.Remove(ResourceId);
            });
        }

        //[PrincipalPermission(SecurityAction.Demand, Role = Security.eCommerceAdminRole)]
        //[PrincipalPermission(SecurityAction.Demand, Name = Security.eCommerceUser)]
        public string[] GetAvailableMasterResources()
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var resourceMasterRepository
                    = _dataRepositoryFactory.GetDataRepository<IResourceMasterRepository>();

                IResourceMasterEngine resourceMasterEngine =
                    _businessEngineFactory.GetBusinessEngine<IResourceMasterEngine>();

                IEnumerable<ResourceMaster> masterResources = resourceMasterRepository.Get();

                List<ResourceMaster> availableResourceMasters = new List<ResourceMaster>();

                foreach (var masterResource in masterResources)
                {
                    // calloing the business engine.
                    if (resourceMasterEngine.IsMasterResourceActive(masterResource.ResourceId, masterResources)) // verify if  master resource is available 
                    {
                        availableResourceMasters.Add(masterResource);
                    }
                }

                var resourceNames = (from resource in masterResources
                                     select resource.Name).Distinct();

                return resourceNames.ToArray();
            });
        }
    }
}