using System.Collections.Generic;
using System.Linq;
using HN.Pim.Client.Entities;
using System.Linq.Dynamic;

namespace HN.Pim.WebUI.Models
{
    public class StyleModel
    {
        public StyleModel()
        {
            Styles = new List<Style>();
        }

        /// <summary>
        /// Get/Set the collection of Styles
        /// </summary>
        public List<Style> Styles { get; set; }

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
        /// Get/Set any parameters for the current command executed. This could be a page number for paging, etc.
        /// </summary>
        public string EventArgument { get; set; }
        /// <summary>
        /// Get/Set the current command executed on the client-side
        /// </summary>
        public string EventCommand { get; set; }

        #region SetSortDirection Method
        public virtual void SetSortDirection()
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

        public virtual List<T> Sort<T>(IQueryable<T> list)
        {
            // NOTE: Using System.Linq.Dynamic DLL
            list = list.OrderBy(SortExpression +
              (SortDirection ==
                SortDirection.Ascending ? " ASC" : " DESC"));

            return list.ToList();
        }
        #endregion

    }
}