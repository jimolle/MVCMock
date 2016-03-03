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

        public ActionResult Contact()
        {
            ViewBag.Msg = TempData["msg"];
            TempData["msg"] = null;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact(ContactMessage cm)
        {

            TempData["msg"] = cm.Message;

            //ViewBag.Msg = cm.Message;
            //ModelState.Clear();

            return RedirectToAction("Contact");
        }
    }
}