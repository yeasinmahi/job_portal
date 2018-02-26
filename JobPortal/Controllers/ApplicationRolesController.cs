using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DAL.Models;
using JobPortal.Controllers.Common;
using DAL.Controller;

namespace JobPortal.Controllers
{
    public class ApplicationRolesController : BaseController
    {
        public ApplicationRolesController() : base("ApplicationRole") { }

        // GET: ApplicationRoles
        public override ActionResult Index()
        {
            base.Index();
            return View(DataController<ApplicationRole>.GetAll());
        }

        // GET: ApplicationRoles/Details/5
        public override ActionResult Details(int? id)
        {
            base.Details(id);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationRole applicationRole = DataController<ApplicationRole>.GetById(id);
            if (applicationRole == null)
            {
                return HttpNotFound();
            }
            return View(applicationRole);
        }

        // GET: ApplicationRoles/Create
        public override ActionResult Create()
        {
            base.Create();
            return View("Edit");
        }

        // POST: ApplicationRoles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Sl")] ApplicationRole applicationRole)
        {
            base.Create();
            if (ModelState.IsValid)
            {
                DataController<ApplicationRole>.Insert(applicationRole);
                return RedirectToAction("Index");
            }

            return View("Edit", applicationRole);
        }

        // GET: ApplicationRoles/Edit/5
        public override ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationRole applicationRole = DataController<ApplicationRole>.GetById(id);
            if (applicationRole == null)
            {
                return HttpNotFound();
            }
            return View(applicationRole);
        }

        // POST: ApplicationRoles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Sl")] ApplicationRole applicationRole)
        {
            base.Edit(applicationRole.Sl);
            if (ModelState.IsValid)
            {
                DataController<ApplicationRole>.Update(applicationRole);
                return RedirectToAction("Index");
            }
            return View(applicationRole);
        }

        // GET: ApplicationRoles/Delete/5
        //public ActionResult Delete(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ApplicationRole applicationRole = db.IdentityRoles.Find(id);
        //    if (applicationRole == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(applicationRole);
        //}

        // POST: ApplicationRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public override ActionResult Delete(int id)
        {
            ApplicationRole applicationRole = DataController<ApplicationRole>.GetById(id);
            DataController<ApplicationRole>.Delete(applicationRole);
            return RedirectToAction("Index");
        }
    }
}
