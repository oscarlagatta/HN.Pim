using System.ComponentModel.Composition;
using System.Web.Mvc;
using HN.Pim.WebUI.Core;

namespace HN.Pim.WebUI.Controllers.MVC
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [Authorize]
    public class CustomerController : ViewControllerBase
    {

        [HttpGet]
        public ActionResult ReserveCar()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ReserveProduct()
        {
            return View();
        }

        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }
    }
}