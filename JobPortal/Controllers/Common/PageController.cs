﻿using System.Linq;
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
        public ActionResult GetSubMenusByMenuId(int menuId)
        {
            var s = from p in DataController<SubMenu>.Get(x => x.MenuId.Equals(menuId)).AsEnumerable()
                    select new SubMenu { Sl = p.Sl, Name = p.Name };
            return Json(s, JsonRequestBehavior.AllowGet);
        }
    }
    
}