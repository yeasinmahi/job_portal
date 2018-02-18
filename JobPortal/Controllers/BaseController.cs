using System;
using System.Web.Mvc;
using Others.Enum;

namespace JobPortal.Controllers
{
    public abstract class BaseController : Controller
    {
        // GET: Base
        protected BaseController(string controllerName)
        {
            ControllerName = controllerName;
        }
        public string ControllerName { get; set; }
        public String ErrorMessage
        {
            get { return TempData["ErrorMessage"] == null ? String.Empty : TempData["ErrorMessage"].ToString(); }
            set { TempData["ErrorMessage"] = value; }
        }

       // public abstract ActionResult Index();

        public virtual ActionResult Index()
        {
            ViewBag.ViewProperty = PageController.GetViewProperty(Enums.ViewPage.Index, ControllerName);
            return null;
        }

        public virtual ActionResult Details(int? id)
        {
            ViewBag.ViewProperty = PageController.GetViewProperty(Enums.ViewPage.Details, ControllerName);
            return null;
        }

        public virtual ActionResult Create()
        {
            ViewBag.ViewProperty = PageController.GetViewProperty(Enums.ViewPage.Create, ControllerName);
            return null;
        }

        public virtual ActionResult Edit(int? id)
        {
            ViewBag.ViewProperty = PageController.GetViewProperty(Enums.ViewPage.Edit, ControllerName);
            return null;
        }

        public abstract ActionResult Delete(int id);

    }
}