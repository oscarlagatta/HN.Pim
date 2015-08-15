using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Web.Mvc;
using HN.Pim.Client.Contracts;
using HN.Pim.Client.Entities;
using HN.Pim.WebUI.Core;

namespace HN.Pim.WebUI.Controllers
{
    public class HomeController : ViewControllerBase
    {

        public ActionResult Index()
        {
            //IEnumerable<MenuItem> menuItems = _MenuItemService.GetAllMenuItems();

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}