using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Optimization;
using Core.Common.Data;
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

        /// <summary>
        /// Get/Set the collection of Styles
        /// </summary>
        public List<Style> Styles { get; set; }

        public StyleController() :base()
        {
            
        }
        [ImportingConstructor]
        public StyleController(IStyleService styleService) :base()
        {
            _StyleService = styleService;
            Styles = new List<Style>();
        }

        IStyleService _StyleService;
        
        [HttpGet]
        public ActionResult Index()
        {
            StyleModel styleModel = new StyleModel();
            styleModel.EventCommand = "page";
            
            HandleRequest(styleModel);
            styleModel.Styles = Styles;

            ModelState.Clear();

            return View(styleModel);
        }


        [HttpPost]
        public ActionResult Index(StyleModel styleModel)
        {
            try
            {

                System.Threading.Thread.Sleep(2000);

                HandleRequest(styleModel);

                styleModel.Styles = Styles;
                // NOTE: Must clear the model state in order to bind
                //       the @Html helpers to the new model values
                ModelState.Clear();

                return View(styleModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Init(StyleModel vm)
        {
            vm.EventCommand = string.Empty;
            vm.EventArgument = string.Empty;

            vm.Pager = new Pager();
            vm.IsPagerVisible = true;

            // initial sort expression
            vm.EventCommand = "sort";
            vm.SortExpression = "MerretDescription";
            vm.SortDirection = SortDirection.Ascending;
            vm.LastSortExpression = string.Empty;
            vm.SortDirectionNew = SortDirection.Ascending;
        }

        public void HandleRequest(StyleModel styleModel)
        {

            //styleModel.HandleRequest();

            if (styleModel.EventCommand == "sort")
            {
                // Check to see if we need to change the sort order 
                // because the sort expression changed
                styleModel.SetSortDirection();
            }

            switch (styleModel.EventCommand)
            {
                case "page":
                case "sort":
                case "search":
                    
                    styleModel.QuantityOfRecords = _StyleService.GetTotalOfStyles();
                    // Setup Pager Object
                    styleModel.SetPagerObject(styleModel.QuantityOfRecords);

                    styleModel.QuantityOfPages = styleModel.Pages.Count();

                    // Get Products for the current page
                    LoadStyles(styleModel);

                    break;
            }
        }

        #region LoadStyles method
        public void LoadStyles(StyleModel styleModel)
        {
            Styles = _StyleService.GetPagedStyles(
                                        styleModel.Pager.PageIndex,
                                        styleModel.Pager.PageSize,
                                        new string[] { }).ToList();
        }
        #endregion
    }
}