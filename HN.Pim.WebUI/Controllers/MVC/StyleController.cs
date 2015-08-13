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
        public ActionResult Index()
        {
            try
            {
                //var style = _StyleService.GetStyle(10735);

                Style[] styles = _StyleService.GetAllStyles();

                var styleModel = styles.Select(description => new StyleModel()
                {
                    MerretDescription = description.ToString()
                });
                return View(styleModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}