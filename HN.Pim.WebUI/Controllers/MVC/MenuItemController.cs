using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HN.Pim.Client.Contracts;
using HN.Pim.WebUI.Core;

namespace HN.Pim.WebUI.Controllers.MVC
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [System.Web.Mvc.RoutePrefix("menuitem")]
    public class MenuItemController : ViewControllerBase
    {
        [ImportingConstructor]
        public MenuItemController(IMenuItemService menuItemService)
        {
            _MenuItemService = menuItemService;
        }

        IMenuItemService _MenuItemService;

        // GET: MenuItem
        [ChildActionOnly]
        public PartialViewResult MenuIndex()
        {
            var menuItems = _MenuItemService.GetAllMenuItems();

            return PartialView(menuItems);
        }
    }
}