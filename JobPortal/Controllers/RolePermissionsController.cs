using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DAL.Controller;
using DAL.Models;
using Others.Enum;

namespace JobPortal.Controllers
{
    public class RolePermissionsController : Controller
    {
        public RolePermissionsController()
        {
            ViewBag.ViewProperty = PageController.GetViewProperty(Enums.ViewPage.Index, "RolePermission");
        }

        // GET: RolePermissions
        public ActionResult Index()
        {
            ViewBag.ViewProperty = PageController.GetViewProperty(Enums.ViewPage.Index, "RolePermission");
            return View(Json(DataController<RolePermission>.GetAll(), JsonRequestBehavior.AllowGet));
        }

        // GET: RolePermissions/Details/5
        public ActionResult Details(int? id)
        {
            ViewBag.ViewProperty = PageController.GetViewProperty(Enums.ViewPage.Details, "RolePermission");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RolePermission rolePermission = DataController<RolePermission>.GetById(id);
            if (rolePermission == null)
            {
                return HttpNotFound();
            }
            return View(rolePermission);
        }

        // GET: RolePermissions/Create
        public ActionResult Create()
        {
            ViewBag.MenuItemId = new SelectList(DataController<MenuItem>.GetAll(), "Sl", "Name");
            ViewBag.ViewProperty = PageController.GetViewProperty(Enums.ViewPage.Create, "RolePermission");
            return View();
        }

        // POST: RolePermissions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Sl,RoleId,MenuItemId,CanAdd,CanEdit,CanDelete")] RolePermission rolePermission)
        {
            if (ModelState.IsValid)
            {
                DataController<RolePermission>.Insert(rolePermission);
                return RedirectToAction("Index");
            }

            ViewBag.MenuItemId = new SelectList(DataController<Menu>.GetAll(), "Sl", "Name", rolePermission.MenuItemId);
            return View(rolePermission);
        }

        //// GET: RolePermissions/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    RolePermission rolePermission = db.RolePermission.Find(id);
        //    if (rolePermission == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.MenuItemId = new SelectList(db.MenuItem, "Sl", "Name", rolePermission.MenuItemId);
        //    return View(rolePermission);
        //}

        //// POST: RolePermissions/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Sl,RoleId,MenuItemId,CanAdd,CanEdit,CanDelete")] RolePermission rolePermission)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(rolePermission).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.MenuItemId = new SelectList(db.MenuItem, "Sl", "Name", rolePermission.MenuItemId);
        //    return View(rolePermission);
        //}

        //// GET: RolePermissions/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    RolePermission rolePermission = db.RolePermission.Find(id);
        //    if (rolePermission == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(rolePermission);
        //}

        //// POST: RolePermissions/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    RolePermission rolePermission = db.RolePermission.Find(id);
        //    db.RolePermission.Remove(rolePermission);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
