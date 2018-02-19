using System.Net;
using System.Web.Mvc;
using DAL.Models;
using Others.Enum;
using DAL.Controller;
using JobPortal.Controllers.Common;

namespace JobPortal.Controllers
{
    public class MenuItemsController : BaseController
    {
        public MenuItemsController() : base("MenuItem"){}

        // GET: MenuItems
        public override ActionResult Index()
        {
            base.Index();
            return View(DataController<MenuItem>.GetAll());
        }
        
        //GET: MenuItems By SubmenuId
        public ActionResult GetMenuItemsBySubmenuId()
        {
            int submenuId;
            Int32.TryParse(Request["SubmenuId"], out submenuId);
            var s = from p in DataController<MenuItem>.GetAll().AsEnumerable()
                    where p.SubMenuId == submenuId
                    select new MenuItem { Sl = p.Sl, Name = p.Name };
            return Json(s, JsonRequestBehavior.AllowGet);
        }

        // GET: MenuItems/Details/5
        public override ActionResult Details(int? id)
        {
            base.Details(id);
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
        public override ActionResult Create()
        {
            base.Create();
            ViewBag.MenuId = new SelectList(DataController<Menu>.GetAll(), "Sl", "Name");
            ViewBag.SubMenuId = new SelectList(DataController<SubMenu>.GetAll(), "Sl", "Name");
            return View("Edit");
        }

        // POST: MenuItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Sl,Name,IconClass,Order,MenuId,SubMenuId,ControllerName,ActionName")] MenuItem menuItem)
        {
            base.Create();
            if (ModelState.IsValid)
            {
                DataController<MenuItem>.Insert(menuItem);
                return RedirectToAction("Index");
            }
            ViewBag.MenuId = new SelectList(DataController<Menu>.GetAll(), "Sl", "Name", menuItem.MenuId);
            ViewBag.SubMenuId = new SelectList(DataController<SubMenu>.GetAll(), "Sl", "Name", menuItem.SubMenuId);
            return View("Edit",menuItem);
        }

        // GET: MenuItems/Edit/5
        public override ActionResult Edit(int? id)
        {
            base.Edit(id);
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
            base.Edit(menuItem.Sl);
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
        //public ActionResult Delete(int? id)
        //{
        //    ViewBag.ViewProperty = PageController.GetViewProperty(Enums.ViewPage.Delete, "MenuItem");
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    MenuItem menuItem = DataController<MenuItem>.GetById(id);
        //    if (menuItem == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(menuItem);
        //}

        // POST: MenuItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public override ActionResult Delete(int id)
        {
            MenuItem menuItem = DataController<MenuItem>.GetById(id);
            DataController<MenuItem>.Delete(menuItem);
            return RedirectToAction("Index");
        }
    }
}