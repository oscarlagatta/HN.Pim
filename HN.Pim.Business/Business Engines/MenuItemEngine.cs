using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Core.Common.Contracts;
using HN.Pim.Business.Common;
using HN.Pim.Business.Entities;

namespace HN.Pim.Business
{
    [Export(typeof(IMenuItemEngine))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class MenuItemEngine : IMenuItemEngine
    {
        [ImportingConstructor]
        public MenuItemEngine(IDataRepositoryFactory dataRepositoryFactory)
        {
            _dataRepositoryFactory = dataRepositoryFactory;
        }

        IDataRepositoryFactory _dataRepositoryFactory;

        public IEnumerable<MenuItem> Load(IEnumerable<MenuItem> menus, int parentMenuId )
        {
            IEnumerable<MenuItem> nodes = new List<MenuItem>();

            nodes = (from node in menus
                where node.ParentMenuId == parentMenuId
                     orderby node.DisplayOrder
                select new MenuItem
                {
                    MenuId = node.MenuId,
                    ParentMenuId = node.ParentMenuId ?? 0,
                    MenuTitle =  node.MenuTitle,
                    DisplayOrder = node.DisplayOrder,
                    MenuAction = node.MenuAction,
                    Menus = (parentMenuId != node.MenuId ?
                        Load(menus, node.MenuId) :
                        new List<MenuItem>())
                });

            return nodes;
        }
    }
}