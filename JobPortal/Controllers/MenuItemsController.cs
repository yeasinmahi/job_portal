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
    public class MenuItemsController : Controller
    {
        public MenuItemsController()
        {
            ViewBag.ViewProperty = PageController.GetViewProperty(Enums.ViewPage.Index, "MenuItem");
        }

        // GET: MenuItems
        public ActionResult Index()
        {
            ViewBag.ViewProperty = PageController.GetViewProperty(Enums.ViewPage.Index, "MenuItem");
            return View(DataController<MenuItem>.GetAll());
        }

        // GET: MenuItems/Details/5
        public ActionResult Details(int? id)
        {
            ViewBag.ViewProperty = PageController.GetViewProperty(Enums.ViewPage.Details, "MenuItem");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenuItem menuItem = DataController<MenuItem>.GetById(id);
            if (menuItem == null)
            {
                return HttpNotFound();
            }
            return View(menuItem);
        }

        // GET: MenuItems/Create
        public ActionResult Create()
        {
            ViewBag.MenuId = new SelectList(DataController<Menu>.GetAll(), "Sl", "Name");
            ViewBag.SubMenuId = new SelectList(DataController<SubMenu>.GetAll(), "Sl", "Name");
            ViewBag.ViewProperty = PageController.GetViewProperty(Enums.ViewPage.Create, "MenuItem");
            return View();
        }

        // POST: MenuItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Sl,Name,IconClass,Order,MenuId,SubMenuId,ControllerName,ActionName")] MenuItem menuItem)
        {
            if (ModelState.IsValid)
            {
                DataController<MenuItem>.Insert(menuItem);
                return RedirectToAction("Index");
            }
            ViewBag.MenuId = new SelectList(DataController<Menu>.GetAll(), "Sl", "Name", menuItem.MenuId);
            ViewBag.SubMenuId = new SelectList(DataController<SubMenu>.GetAll(), "Sl", "Name", menuItem.SubMenuId);
            return View(menuItem);
        }

        // GET: MenuItems/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.ViewProperty = PageController.GetViewProperty(Enums.ViewPage.Edit, "MenuItem");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenuItem menuItem = DataController<MenuItem>.GetById(id);
            if (menuItem == null)
            {
                return HttpNotFound();
            }
            ViewBag.MenuId = new SelectList(DataController<Menu>.GetAll(), "Sl", "Name", menuItem.MenuId);
            ViewBag.SubMenuId = new SelectList(DataController<SubMenu>.GetAll(), "Sl", "Name", menuItem.SubMenuId);
            return View(menuItem);
        }

        // POST: MenuItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Sl,Name,IconClass,Order,MenuId,SubMenuId,ControllerName,ActionName")] MenuItem menuItem)
        {
            if (ModelState.IsValid)
            {
                DataController<MenuItem>.Update(menuItem);
                return RedirectToAction("Index");
            }
            ViewBag.MenuId = new SelectList(DataController<Menu>.GetAll(), "Sl", "Name", menuItem.MenuId);
            ViewBag.SubMenuId = new SelectList(DataController<SubMenu>.GetAll(), "Sl", "Name", menuItem.SubMenuId);
            return View(menuItem);
        }

        // GET: MenuItems/Delete/5
        public ActionResult Delete(int? id)
        {
            ViewBag.ViewProperty = PageController.GetViewProperty(Enums.ViewPage.Delete, "MenuItem");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenuItem menuItem = DataController<MenuItem>.GetById(id);
            if (menuItem == null)
            {
                return HttpNotFound();
            }
            return View(menuItem);
        }

        // POST: MenuItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MenuItem menuItem = DataController<MenuItem>.GetById(id);
            DataController<MenuItem>.Delete(menuItem);
            return RedirectToAction("Index");
        }
    }
}
