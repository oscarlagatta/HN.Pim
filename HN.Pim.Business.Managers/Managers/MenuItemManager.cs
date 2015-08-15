using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.ServiceModel;
using Core.Common.Contracts;
using HN.Pim.Business.Common;
using HN.Pim.Business.Contracts;
using HN.Pim.Business.Entities;
using HN.Pim.Data.Contracts.Repository_Interfaces;

namespace HN.Pim.Business.Managers.Managers
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall,
       ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class MenuItemManager : ManagerBase, IMenuItemService
    {
        [Import]
        private IDataRepositoryFactory _dataRepositoryFactory;

        [Import]
        IBusinessEngineFactory _businessEngineFactory;

        public MenuItemManager()
        {
        }

        public MenuItemManager(IDataRepositoryFactory dataRepositoryFactory)
        {
            _dataRepositoryFactory = dataRepositoryFactory;
        }

        public MenuItemManager(IDataRepositoryFactory dataRepositoryFactory, IBusinessEngineFactory businessEngineFactory)
        {
            _dataRepositoryFactory = dataRepositoryFactory;
            _businessEngineFactory = businessEngineFactory;
        }

        public List<MenuItem> GetAllMenuItems()
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var styleRepository
                    = _dataRepositoryFactory.GetDataRepository<IMenuItemRepository>();

                IMenuItemEngine menuItemEngine = _businessEngineFactory.GetBusinessEngine<IMenuItemEngine>();

                IEnumerable<MenuItem> menus = styleRepository.Get().ToList();

                var ret = menuItemEngine.Load(menus, 0);

                return ret.ToList();
            });
        }
    }
}