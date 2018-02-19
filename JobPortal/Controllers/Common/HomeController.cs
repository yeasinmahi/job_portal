using System.Collections.Generic;
using System.Web.Mvc;
using DAL.Controller;
using DAL.Models;

namespace JobPortal.Controllers.Common
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<ApplicationUser> applicationUsers = (List<ApplicationUser>) DataController<ApplicationUser>.GetAll();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}