using System.Collections.Generic;

namespace HN.Pim.WebUI.Models
{
    public class MenuItemManager
    {
        public MenuItemManager()
        {
            Menus = new List<MenuItem>();
        }

        public List<MenuItem> Menus { get; set; } 
    }

    public class MenuItem
    {
        public int MenuId { get; set; }
        public string MenuTitle { get; set; }
        public int DisplayOrder { get; set; }
        public string MenuAction { get; set; }
        public int ParentMenuId { get; set; }
        public ICollection<MenuItem> Menus { get; set; }
        public override string ToString()
        {
            return MenuTitle;
        }
    }
}