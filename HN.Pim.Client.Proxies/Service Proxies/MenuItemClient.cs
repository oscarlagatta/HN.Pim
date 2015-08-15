using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using Core.Common.ServiceModel;
using HN.Pim.Client.Contracts;
using HN.Pim.Client.Entities;

namespace HN.Pim.Client.Proxies.Service_Proxies
{
    [Export(typeof(IMenuItemService))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class MenuItemClient : UserClientBase<IMenuItemService>, IMenuItemService
    {
        public List<MenuItem> GetAllMenuItems()
        {
            return Channel.GetAllMenuItems();
        }
    }
}