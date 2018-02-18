using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DAL.Models;
using Others.Enum;
using DAL.Controller;

namespace JobPortal.Controllers
{
    public class SubMenusController : Controller
    {
        public SubMenusController()
        {
            ViewBag.ViewProperty = PageController.GetViewProperty(Enums.ViewPage.Index, "SubMenu");
        }

        public ActionResult GetSubMenusByMenuId()
        {
            int menuId;
            Int32.TryParse(Request["MenuId"], out menuId);
            var s = from p in DataController<SubMenu>.GetAll().AsEnumerable()
                    where p.MenuId == menuId
                    select new SubMenu { Sl = p.Sl, Name = p.Name };
            return Json(s, JsonRequestBehavior.AllowGet);
        }

        // GET: SubMenus
        public ActionResult Index()
        {
            ViewBag.ViewProperty = PageController.GetViewProperty(Enums.ViewPage.Index, "SubMenu");
            return View(Json(DataController<SubMenu>.GetAll(), JsonRequestBehavior.AllowGet));
        }

        // GET: SubMenus/Details/5
        public ActionResult Details(int? id)
        {
            ViewBag.ViewProperty = PageController.GetViewProperty(Enums.ViewPage.Details, "SubMenu");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubMenu subMenu = DataController<SubMenu>.GetById(id);
            if (subMenu == null)
            {
                return HttpNotFound();
            }
            return View(subMenu);
        }

        // GET: SubMenus/Create
        public ActionResult Create()
        {
            ViewBag.MenuId = new SelectList(DataController<Menu>.GetAll(), "Sl", "Name");
            ViewBag.ViewProperty = PageController.GetViewProperty(Enums.ViewPage.Create, "SubMenu");
            return View();
        }

        // POST: SubMenus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Sl,Name,IconClass,Order,MenuId")] SubMenu subMenu)
        {
            if (ModelState.IsValid)
            {
                DataController<SubMenu>.Insert(subMenu);
                return RedirectToAction("Index");
            }

            ViewBag.MenuId = new SelectList(DataController<Menu>.GetAll(), "Sl", "Name", subMenu.MenuId);
            return View(subMenu);
        }

        // GET: SubMenus/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.ViewProperty = PageController.GetViewProperty(Enums.ViewPage.Edit, "SubMenu");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubMenu subMenu = DataController<SubMenu>.GetById(id);
            if (subMenu == null)
            {
                return HttpNotFound();
            }
            ViewBag.MenuId = new SelectList(DataController<Menu>.GetAll(), "Sl", "Name", subMenu.MenuId);
            return View(subMenu);
        }

        // POST: SubMenus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Sl,Name,IconClass,Order,MenuId")] SubMenu subMenu)
        {
            if (ModelState.IsValid)
            {
                DataController<SubMenu>.Update(subMenu);
                return RedirectToAction("Index");
            }
            ViewBag.MenuId = new SelectList(DataController<Menu>.GetAll(), "Sl", "Name", subMenu.MenuId);
            return View(subMenu);
        }

        // GET: SubMenus/Delete/5
        public ActionResult Delete(int? id)
        {
            ViewBag.ViewProperty = PageController.GetViewProperty(Enums.ViewPage.Delete, "SubMenu");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubMenu subMenu = DataController<SubMenu>.GetById(id);
            if (subMenu == null)
            {
                return HttpNotFound();
            }
            return View(subMenu);
        }

        // POST: SubMenus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SubMenu subMenu = DataController<SubMenu>.GetById(id);
            DataController<SubMenu>.Delete(subMenu);
            return RedirectToAction("Index");
        }
    }
}
