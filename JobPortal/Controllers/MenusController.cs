using System.Net;
using System.Web.Mvc;
using DAL.Controller;
using JobPortal.Controllers.Common;
using Others.Enum;
using Menu = DAL.Models.Menu;

namespace JobPortal.Controllers
{
    public class MenusController : Controller
    {
        
        public MenusController()
        {
            ViewBag.ViewProperty = PageController.GetViewProperty(Enums.ViewPage.Index, "Menu");
        }
        // GET: Menus
        public ActionResult Index()
        {
            ViewBag.ViewProperty = PageController.GetViewProperty(Enums.ViewPage.Index, "Menu");
            return View(DataController<Menu>.GetAll());
        }

        // GET: Menus/Details/5
        public ActionResult Details(int? id)
        {
            ViewBag.ViewProperty = PageController.GetViewProperty(Enums.ViewPage.Details, "Menu");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Menu menu = DataController<Menu>.GetById(id);
            if (menu == null)
            {
                return HttpNotFound();
            }
            return View(menu);
        }

        // GET: Menus/Create
        public ActionResult Create()
        {
            ViewBag.ViewProperty = PageController.GetViewProperty(Enums.ViewPage.Create, "Menu");

            return View();
        }

        // POST: Menus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Sl,Name,IconClass,Order")] Menu menu)
        {
            if (ModelState.IsValid)
            {
                DataController<Menu>.Insert(menu);
                return RedirectToAction("Index");
            }

            return View(menu);
        }

        // GET: Menus/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.ViewProperty = PageController.GetViewProperty(Enums.ViewPage.Edit, "Menu");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Menu menu = DataController<Menu>.GetById(id);
            if (menu == null)
            {
                return HttpNotFound();
            }
            return View(menu);
        }

        // POST: Menus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Sl,Name,IconClass,Order")] Menu menu)
        {
            if (ModelState.IsValid)
            {
                DataController<Menu>.Update(menu);
                return RedirectToAction("Index");
            }
            return View(menu);
        }

        // GET: Menus/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    ViewBag.ViewProperty = PageController.GetViewProperty(Enums.ViewPage.Delete, "Menu");
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Menu menu = DataController<Menu>.GetById(id);
        //    if (menu == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(menu);
        //}

        // POST: Menus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Menu menu = DataController<Menu>.GetById(id);
            DataController<Menu>.Delete(menu);
            return RedirectToAction("Index");
        }
    }
}
