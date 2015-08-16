using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HN.Pim.Client.Contracts;
using HN.Pim.Client.Entities;
using HN.Pim.WebUI.Core;
using HN.Pim.WebUI.Models;
using System.Linq.Dynamic;

namespace HN.Pim.WebUI.Controllers.MVC
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [System.Web.Mvc.RoutePrefix("style")]
    public class StyleController : ViewControllerBase
    {
        [ImportingConstructor]
        public StyleController(IStyleService styleService)
        {
            _StyleService = styleService;
        }

        IStyleService _StyleService;


        [System.Web.Mvc.HttpGet]
        public ActionResult Index(StyleModel vm)
        {
            try
            {
                vm.Init();

                vm.Styles = _StyleService.GetAllStyles().Take(20).ToList();

                return View(vm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [System.Web.Mvc.HttpGet]
        public ActionResult SearchAction(StyleModel vm)
        {
            try
            {
                switch (vm.EventCommand)
                {
                    case "sort":
                        {
                            vm.SetSortDirection();
                            vm.Styles = _StyleService.GetAllStyles().Take(30).ToList();
                            if (!string.IsNullOrEmpty(vm.SortExpression))
                            {
                                vm.Styles = vm.Sort<Style>(vm.Styles.AsQueryable<Style>());
                            }
                            break;
                        }
                }

                return View(vm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}