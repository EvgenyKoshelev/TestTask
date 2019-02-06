using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestTask.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Test Task.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "My email.";

            return View();
        }
    }
}