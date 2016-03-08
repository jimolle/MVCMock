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
            ShipContext db = new ShipContext();

            var cookie = Request.Cookies["sentMsg"];
            if (cookie != null)
            {
                ViewBag.CookieMsg = cookie["key1"];
            }

            return View(db.ShippingCompanies.ToList());
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


            var cookie = new HttpCookie("sentMsg");
            cookie["key1"] = cm.Message;
            cookie.Expires = DateTime.Now.AddDays(30);
            Response.Cookies.Add(cookie);

            //ViewBag.Msg = cm.Message;
            //ModelState.Clear();

            return RedirectToAction("Contact");
        }
    }
}