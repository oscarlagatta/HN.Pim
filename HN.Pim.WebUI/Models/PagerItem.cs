﻿namespace HN.Pim.WebUI.Models
{
    public class PagerItem
    {
        #region Constructors
        public PagerItem(int pageCount, int pageIndex, string tooltip)
        {
            Init();

            Text = (pageCount + 1).ToString();
            Argument = pageCount.ToString();
            IsSelected = (pageCount == pageIndex);
            Tooltip = tooltip;
        }

        public PagerItem(string text, string arg, bool disabled, string tooltip)
        {
            Init();

            Text = text;
            Argument = arg;
            Tooltip = tooltip;
            IsDisabled = disabled;
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// Get/Set the text to use for the pager
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Get/Set the tooltip to use for the pager
        /// </summary>
        public string Tooltip { get; set; }
        /// <summary>
        /// Get/Set the argument to use for the pager
        /// </summary>
        public string Argument { get; set; }
        /// <summary>
        /// Get/Set whether or not this pager is selected
        /// </summary>
        public bool IsSelected { get; set; }
        /// <summary>
        /// Get/Set whether or not this pager is disabled
        /// </summary>
        public bool IsDisabled { get; set; }
        /// <summary>
        /// Get/Set the css class for a selected pager. Default is 'active'.
        /// </summary>
        public string CssActiveClass { get; set; }
        /// <summary>
        /// Get/Set the css class for a disabled pager. Default is 'disabled'.
        /// </summary>
        public string CssDisabledClass { get; set; }
        /// <summary>
        /// Get/Set the CSS Class to apply based on the IsSelected/IsDisabled properties.
        /// </summary>
        public string CssClass
        {
            get
            {
                string result = string.Empty;
                if (IsSelected)
                {
                    result = CssActiveClass;
                }
                else if (IsDisabled)
                {
                    result = CssDisabledClass;
                }
                return result;
            }
        }
        #endregion

        #region Init Method
        public void Init()
        {
            Text = string.Empty;
            Argument = string.Empty;
            Tooltip = string.Empty;
            CssActiveClass = "active";
            CssDisabledClass = "disabled";
            IsSelected = false;
            IsDisabled = false;
        }
        #endregion

        #region ToString Override
        public override string ToString()
        {
            return Text;
        }
        #endregion
    }
}