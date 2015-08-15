using System.Collections;
using System.Collections.Generic;
using Core.Common.Core;

namespace HN.Pim.Client.Entities
{
    public class MenuItem : ObjectBase
    {
        private int _menuId;

        public int MenuId
        {
            get { return _menuId; }
            set { _menuId = value; }
        }

        private int? _parentMenuId;

        public int? ParentMenuId
        {
            get { return _parentMenuId; }
            set { _parentMenuId = value; }
        }
        private string _menuTitle;

        public string MenuTitle
        {
            get { return _menuTitle; }
            set { _menuTitle = value; }
        }

        private int _displayOrder;

        public int DisplayOrder
        {
            get { return _displayOrder; }
            set { _displayOrder = value; }
        }

        private string _menuAction;

        public string MenuAction
        {
            get { return _menuAction; }
            set { _menuAction = value; }
        }
        //public IEnumerable<MenuItem> Menus { get; set; }

        private IEnumerable<MenuItem> _menus;

        public IEnumerable<MenuItem> Menus
        {
            get { return _menus; }
            set { _menus = value; }
        }

    }
}