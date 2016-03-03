using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCMock.Models;

namespace MVCMock.Controllers
{
    public class ShippingCompanyController : Controller
    {
        ShipContext db = new ShipContext();

        // GET: ShippingCompany
        public ActionResult Index()
        {
            var data = db.ShippingCompanies.ToList();
            return View(data);
        }

        // GET: ShippingCompany/Details/5
        public ActionResult Details(int id)
        {
            throw new NotImplementedException();
        }

        // GET: ShippingCompany/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShippingCompany/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                string name = Request.Form["Name"];

                var shippingCompanyToAdd = new ShippingCompany()
                {
                    Name = name
                };

                db.ShippingCompanies.Add(shippingCompanyToAdd);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ShippingCompany/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ShippingCompany/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ShippingCompany/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ShippingCompany/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
