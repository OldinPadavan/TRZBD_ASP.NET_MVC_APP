using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class Managment_companyController : Controller
    {
        private RentControllBDEntities db = new RentControllBDEntities();

        // GET: Managment_company
        public ActionResult Index()
        {
            return View(db.Managment_company.ToList());
        }

        // GET: Managment_company/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Managment_company managment_company = db.Managment_company.Find(id);
            if (managment_company == null)
            {
                return HttpNotFound();
            }
            return View(managment_company);
        }

        // GET: Managment_company/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Managment_company/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,INN,Address,Phone_number")] Managment_company managment_company)
        {
            if (ModelState.IsValid)
            {
                db.Managment_company.Add(managment_company);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(managment_company);
        }

        // GET: Managment_company/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Managment_company managment_company = db.Managment_company.Find(id);
            if (managment_company == null)
            {
                return HttpNotFound();
            }
            return View(managment_company);
        }

        // POST: Managment_company/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,INN,Address,Phone_number")] Managment_company managment_company)
        {
            if (ModelState.IsValid)
            {
                db.Entry(managment_company).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(managment_company);
        }

        // GET: Managment_company/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Managment_company managment_company = db.Managment_company.Find(id);
            if (managment_company == null)
            {
                return HttpNotFound();
            }
            return View(managment_company);
        }

        // POST: Managment_company/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Managment_company managment_company = db.Managment_company.Find(id);
            db.Managment_company.Remove(managment_company);
            db.SaveChanges();
            return RedirectToAction("Index");
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
