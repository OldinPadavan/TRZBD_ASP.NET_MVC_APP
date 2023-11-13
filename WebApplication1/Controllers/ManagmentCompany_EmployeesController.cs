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
    public class ManagmentCompany_EmployeesController : Controller
    {
        private RentControllBDEntities db = new RentControllBDEntities();

        // GET: ManagmentCompany_Employees
        public ActionResult Index()
        {
            var managmentCompany_Employees = db.ManagmentCompany_Employees.Include(m => m.Managment_company);
            return View(managmentCompany_Employees.ToList());
        }

        // GET: ManagmentCompany_Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ManagmentCompany_Employees managmentCompany_Employees = db.ManagmentCompany_Employees.Find(id);
            if (managmentCompany_Employees == null)
            {
                return HttpNotFound();
            }
            return View(managmentCompany_Employees);
        }

        // GET: ManagmentCompany_Employees/Create
        public ActionResult Create()
        {
            ViewBag.Company_id = new SelectList(db.Managment_company, "Id", "Name");
            return View();
        }

        // POST: ManagmentCompany_Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Last_name,First_name,Middle_name,Company_id")] ManagmentCompany_Employees managmentCompany_Employees)
        {
            if (ModelState.IsValid)
            {
                db.ManagmentCompany_Employees.Add(managmentCompany_Employees);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Company_id = new SelectList(db.Managment_company, "Id", "Name", managmentCompany_Employees.Company_id);
            return View(managmentCompany_Employees);
        }

        // GET: ManagmentCompany_Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ManagmentCompany_Employees managmentCompany_Employees = db.ManagmentCompany_Employees.Find(id);
            if (managmentCompany_Employees == null)
            {
                return HttpNotFound();
            }
            ViewBag.Company_id = new SelectList(db.Managment_company, "Id", "Name", managmentCompany_Employees.Company_id);
            return View(managmentCompany_Employees);
        }

        // POST: ManagmentCompany_Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Last_name,First_name,Middle_name,Company_id")] ManagmentCompany_Employees managmentCompany_Employees)
        {
            if (ModelState.IsValid)
            {
                db.Entry(managmentCompany_Employees).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Company_id = new SelectList(db.Managment_company, "Id", "Name", managmentCompany_Employees.Company_id);
            return View(managmentCompany_Employees);
        }

        // GET: ManagmentCompany_Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ManagmentCompany_Employees managmentCompany_Employees = db.ManagmentCompany_Employees.Find(id);
            if (managmentCompany_Employees == null)
            {
                return HttpNotFound();
            }
            return View(managmentCompany_Employees);
        }

        // POST: ManagmentCompany_Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ManagmentCompany_Employees managmentCompany_Employees = db.ManagmentCompany_Employees.Find(id);
            db.ManagmentCompany_Employees.Remove(managmentCompany_Employees);
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
