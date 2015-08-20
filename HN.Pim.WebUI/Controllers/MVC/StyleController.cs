using System;
using System.ComponentModel.Composition;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;
using HN.Pim.Client.Contracts;
using HN.Pim.Client.Entities;
using HN.Pim.WebUI.Core;
using HN.Pim.WebUI.Models;

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
       
        public ActionResult Index(StyleModel vm)
        {
            try
            {
                if (string.IsNullOrEmpty(vm.EventCommand))
                {
                    Init(vm);
                }

                switch (vm.EventCommand)
                {
                    case "sort":
                        {
                            vm.SetSortDirection();
                            vm.Styles = _StyleService.GetAllStyles().Take(20).ToList();
                            if (!string.IsNullOrEmpty(vm.SortExpression))
                            {
                                vm.Styles = vm.Sort<Style>(vm.Styles.AsQueryable<Style>());
                            }
                            break;
                        }
                }

                ModelState.Clear();

                return View(vm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private  void Init(StyleModel vm)
        {
            vm.EventCommand = string.Empty;
            vm.IsPagerVisible = true;
            // initial sort expression
            vm.EventCommand = "sort";
            vm.SortExpression = "MerretDescription";
            vm.SortDirection = SortDirection.Ascending;
            vm.LastSortExpression = string.Empty;
            vm.SortDirectionNew = SortDirection.Ascending;
        }
    }
}