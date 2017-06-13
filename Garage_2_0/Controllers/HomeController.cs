using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Garage_2_0.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Description of the application.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "How to get in contact with us about this application.";

            return View();
        }
    }
}