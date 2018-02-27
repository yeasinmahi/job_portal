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
using JobPortal.Controllers.Common;
using Microsoft.AspNet.Identity.EntityFramework;

namespace JobPortal.Controllers
{
    public class RolePermissionsController : BaseController
    {
        public RolePermissionsController() : base("RolePermission") { }
       

        // GET: RolePermissions
        public override ActionResult Index()
        {
            base.Index();
            return View(DataController<ApplicationRole>.GetAll());
        }

        // GET: RolePermissions/Details/5
        public override ActionResult Details(int? id)
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
        public override ActionResult Create()
        {
            base.Create();
            ViewBag.MenuItemId = new SelectList(DataController<MenuItem>.GetAll(), "Sl", "Name");
            return View("Edit");
        }

        // POST: RolePermissions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Sl,RoleId,MenuItemId,CanAdd,CanEdit,CanDelete")] RolePermission rolePermission)
        {
            base.Create();
            if (ModelState.IsValid)
            {
                DataController<RolePermission>.Insert(rolePermission);
                return RedirectToAction("Index");
            }

            ViewBag.MenuItemId = new SelectList(DataController<Menu>.GetAll(), "Sl", "Name", rolePermission.MenuItemId);
            return View("Edit", rolePermission);
        }

        // GET: RolePermissions/Edit/5
        public override ActionResult Edit(int? id)
        {
            base.Edit(id);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RolePermission rolePermission = DataController<RolePermission>.GetById(id);
            if (rolePermission == null)
            {
                return HttpNotFound();
            }
            ViewBag.MenuItemId = new SelectList(DataController<MenuItem>.GetAll(), "Sl", "Name", rolePermission.MenuItemId);
            return View(rolePermission);
        }

        // POST: RolePermissions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.

        public ActionResult EditRolePermission(string id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Sl,RoleId,MenuItemId,CanAdd,CanEdit,CanDelete")] RolePermission rolePermission)
        {
            base.Edit(rolePermission.Sl);
            if (ModelState.IsValid)
            {
                DataController<RolePermission>.Update(rolePermission);
                return RedirectToAction("Index");
            }
            ViewBag.MenuItemId = new SelectList(DataController<MenuItem>.GetAll(), "Sl", "Name", rolePermission.MenuItemId);
            return View(rolePermission);
        }


        // POST: RolePermissions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public override ActionResult Delete(int id)
        {
            RolePermission rolePermission = DataController<RolePermission>.GetById(id);
            DataController<RolePermission>.Delete(rolePermission);
            return RedirectToAction("Index");
        }

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
