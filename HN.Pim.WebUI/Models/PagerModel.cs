using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HN.Pim.WebUI.Models
{
    public class PagerModel
    {
        #region Constructor
        public PagerModel()
          : base()
        {
            Init();
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// Get/Set the Pager object
        /// </summary>
        public Pager Pager { get; set; }
        /// <summary>
        /// Get/Set the page collection
        /// </summary>
        public PagerItemCollection Pages { get; set; }
        #endregion

        #region Init Method
        public void Init()
        {
            Pager = new Pager();

            SetPagerObject(11);
        }
        #endregion

        #region SetPagerObject Method
        private void SetPagerObject(int totalRecords)
        {
            // Set Pager Information
            Pager.TotalRecords = totalRecords;
            Pager.PageSize = 5;
            Pager.SetPagerProperties(string.Empty);

            // Build paging collection
            Pages = new PagerItemCollection(
              Pager.TotalRecords,
              Pager.PageSize,
              Pager.PageIndex);

            // Set total pages
            Pager.TotalPages = Pages.PageCount;
        }
        #endregion
    }
}