using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using DAL.Models;
using DAL.Controller;
using JobPortal.Controllers.Common;

namespace JobPortal.Controllers
{
    public class SubMenusController : BaseController
    {
        public SubMenusController() : base("Sub Menu")
        {
            
        }

        public ActionResult GetSubMenusByMenuId()
        {
            int menuId;
            Int32.TryParse(Request["MenuId"], out menuId);
            var s = from p in DataController<SubMenu>.Get(x => x.MenuId.Equals(menuId)).AsEnumerable()
                    select new SubMenu { Sl = p.Sl, Name = p.Name };
            return Json(s, JsonRequestBehavior.AllowGet);
        }

        // GET: SubMenus
        public override ActionResult Index()
        {
            base.Index();
            return View(DataController<SubMenu>.GetAll());
        }

        // GET: SubMenus/Details/5
        public override ActionResult Details(int? id)
        {
            base.Details(id);
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
        public override ActionResult Create()
        {
            base.Create();
            ViewBag.MenuId = new SelectList(DataController<Menu>.GetAll(), "Sl", "Name");
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
        public override ActionResult Edit(int? id)
        {
            base.Edit(id);
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

        // POST: SubMenus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public override ActionResult Delete(int id)
        {
            SubMenu subMenu = DataController<SubMenu>.GetById(id);
            DataController<SubMenu>.Delete(subMenu);
            return RedirectToAction("Index");
        }
    }
}
