using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCMock.Models;
using System.Data.Entity.Infrastructure;

namespace MVCMock.Controllers
{
    public class ShippingCompanyController : Controller
    {
        private ShipContext db = new ShipContext();

        // GET: ShippingCompany
        public ActionResult Index(string sortOrder, string searchString)
        {
            ViewBag.NameSortParam = string.IsNullOrWhiteSpace(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParam = sortOrder == "Date" ? "date_desc" : "Date";
            var shippingCompanies = from s in db.ShippingCompanies
                                    select s;
            if (!string.IsNullOrEmpty(searchString))
            {
                shippingCompanies = shippingCompanies.Where(s => s.Name.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    shippingCompanies = shippingCompanies.OrderByDescending(s => s.Name);
                    break;
                default:
                    shippingCompanies = shippingCompanies.OrderBy(n => n.Name);
                    break;
            }

            return View(shippingCompanies);
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
        public ActionResult Create([Bind(Include = "Name")]ShippingCompany shippingCompany)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //string name = Request.Form["Name"];

                    var shippingCompanyToAdd = new ShippingCompany()
                    {
                        Name = shippingCompany.Name
                    };

                    db.ShippingCompanies.Add(shippingCompanyToAdd);
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
            }
            catch (RetryLimitExceededException)
            {
                ModelState.AddModelError("", "Unable to save changes...");
            }
            return View(shippingCompany);
        }

        // GET: ShippingCompany/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var shippingCompany = db.ShippingCompanies.Find(id);
            if (shippingCompany == null)
            {
                return HttpNotFound();
            }
            return View(shippingCompany);
        }

        // POST: ShippingCompany/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID, Name")] ShippingCompany shippingCompany)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(shippingCompany).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (RetryLimitExceededException)
            {
                ModelState.AddModelError("", "Unable to save changes...");
            }
            return View(shippingCompany);
        }

        // GET: ShippingCompany/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return  new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var shippingCompany = db.ShippingCompanies.Find(id);
            if (shippingCompany == null)
            {
                return HttpNotFound();
            }
            return View(shippingCompany);
        }

        // POST: ShippingCompany/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var shippingCompany = db.ShippingCompanies.Find(id);
                db.ShippingCompanies.Remove(shippingCompany);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (RetryLimitExceededException)
            {
                ModelState.AddModelError("", "Unable to save changes...");
                return View();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
