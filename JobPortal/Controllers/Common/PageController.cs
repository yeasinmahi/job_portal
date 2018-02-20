using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using DAL.Controller;
using DAL.Models;
using Others.Enum;
using Others.UI;

namespace JobPortal.Controllers.Common
{
    public class PageController : Controller
    {
        // GET: Page
        public static ViewProperty GetViewProperty(Enums.ViewPage viewPage, string controllerName)
        {
            ViewProperty viewProperty = new ViewProperty();
            viewProperty.ControllerName = controllerName;
            viewProperty.ViewPage = viewPage;
            switch (viewPage)
            {
                case Enums.ViewPage.Create:
                    viewProperty.Title = "Create";
                    break;
                case Enums.ViewPage.Delete:
                    viewProperty.Title = "Delete";
                    break;
                case Enums.ViewPage.Details:
                    viewProperty.Title = "Details";
                    break;
                case Enums.ViewPage.Edit:
                    viewProperty.Title = "Edit";
                    break;
                case Enums.ViewPage.Index:
                    viewProperty.Title = "Index";
                    break;
            }
            return viewProperty;
        }
        public ActionResult GetJsonSubMenusByMenuId(int menuId)
        {
            var s = from p in DataController<SubMenu>.Get(x => x.MenuId.Equals(menuId)).AsEnumerable()
                    select new SubMenu { Sl = p.Sl, Name = p.Name };
            return Json(s, JsonRequestBehavior.AllowGet);
        }

        public static List<Menu> GetMenus()
        {
            return DataController<Menu>.GetAll().ToList();
        }

        public static List<SubMenu> GetSubMenusByMenuId(int menuId)
        {
            return DataController<SubMenu>.Get(x => x.MenuId.Equals(menuId)).ToList();
        }
        public static List<MenuItem> GetMenuItemsByMenuId(int menuId)
        {
            return DataController<MenuItem>.Get(x => x.MenuId.Equals(menuId) && x.SubMenuId.Equals(0)).ToList();
        }
        public static List<MenuItem> GetMenuItemsBySubMenuId(int? subMenuId)
        {
            return DataController<MenuItem>.Get(x => x.SubMenuId.Equals(subMenuId)).ToList();
        }

        public static List<MenuItem> GetSubMenuAndMenuItems(int menuId)
        {
            List<SubMenu> subMenus = GetSubMenusByMenuId(menuId);
            List<MenuItem> menuItems = GetMenuItemsByMenuId(menuId);
            foreach (SubMenu subMenu in subMenus)
            {
                MenuItem menuItem = new MenuItem
                {
                    Name = subMenu.Name,
                    IconClass = subMenu.IconClass,
                    Order = subMenu.Order,
                    MenuId = subMenu.MenuId,
                    SubMenuId = subMenu.Sl
                };
                menuItems.Add(menuItem);
            }
            return menuItems.OrderBy(x=>x.Order).ToList();
        } 
    }
    
}