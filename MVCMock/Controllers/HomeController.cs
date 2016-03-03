using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCMock.Models;

namespace MVCMock.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Never used...";

            return View();
        }

        public ActionResult Contact(string msg)
        {
            ViewBag.Message = msg;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact(ContactMessage cm)
        {
            //HARD-CORE-WAY to clear.
            //ModelState.Clear();

            return RedirectToAction("Contact", new {msg = cm.Message});
        }
    }
}