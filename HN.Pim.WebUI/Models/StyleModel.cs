using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using HN.Pim.Client.Entities;
using System.Linq.Dynamic;
using HN.Pim.Client.Contracts;
using HN.Pim.WebUI.Core;

namespace HN.Pim.WebUI.Models
{
    public class StyleModel 
    {
        public StyleModel()
        {
            
            Init();
        }

        public List<Style> Styles { get; set; }

        #region Public Properties
        /// <summary>
        /// Get/Set the Pager object
        /// </summary>
        public Pager Pager { get; set; }
        /// <summary>
        /// Get/Set whether or not the pager is visible
        /// </summary>
        public bool IsPagerVisible { get; set; }
        /// <summary>
        /// Get/Set the page collection
        /// </summary>
        public PagerItemCollection Pages { get; set; }
        /// <summary>
        /// Get/Set the current sort direction
        /// </summary>
        public SortDirection SortDirection { get; set; }
        /// <summary>
        /// Get/Set the new sort direction
        /// </summary>
        public SortDirection SortDirectionNew { get; set; }
        /// <summary>
        /// Get/Set the current column you wish to sort on
        /// </summary>
        public string SortExpression { get; set; }
        /// <summary>
        /// Get/Set the last column you sorted on
        /// </summary>
        public string LastSortExpression { get; set; }
        /// <summary>
        /// Get/Set the current command executed on the client-side
        /// </summary>
        public string EventCommand { get; set; }
        /// <summary>
        /// Get/Set any parameters for the current command executed. This could be a page number for paging, etc.
        /// </summary>
        public string EventArgument { get; set; }

        public int QuantityOfRecords { get; set; }

        public int QuantityOfPages { get; set; }
        public string StyleNameSearch { get; set; }

        public bool IsSearchAreaVisible { get; set; }
        #endregion

        #region Init Method
        public void Init()
        {
            EventCommand = string.Empty;
            EventArgument = string.Empty;

            SortExpression = string.Empty;
            LastSortExpression = string.Empty;
            SortDirection = SortDirection.Ascending;
            SortDirectionNew = SortDirection.Ascending;

            Pager = new Pager();
            IsPagerVisible = true;
        }
        #endregion

        #region SetSortDirection Method
        public  virtual void SetSortDirection()
        {
            if (SortExpression == LastSortExpression)
            {
                if (SortDirection == SortDirection.Ascending)
                    SortDirection = SortDirection.Descending;
                else
                    SortDirection = SortDirection.Ascending;
            }
            else
            {
                SortDirection = SortDirectionNew;
            }
        }
        #endregion

        #region Sort Method
        protected virtual List<T> Sort<T>(IQueryable<T> list)
        {
            string orderby = SortExpression;

            // NOTE: Using System.Linq.Dynamic DLL
            list = list.OrderBy(SortExpression +
              (SortDirection == SortDirection.Ascending ? " ASC" : " DESC"));

            return list.ToList();
        }
        #endregion

        #region HandleRequest Method
        //public virtual void HandleRequest()
        //{
        //}
        #endregion

        #region SetPagerObject Method

        public virtual void SetPagerObject(int totalRecords)
        {
            // Set Pager Information
            Pager.TotalRecords = totalRecords;
            Pager.SetPagerProperties(EventArgument);

            // Build paging collection
            Pages = new PagerItemCollection(Pager.TotalRecords, Pager.PageSize, Pager.PageIndex);
            // Set total pages
            Pager.TotalPages = Pages.PageCount;
        }
        #endregion
    }
}