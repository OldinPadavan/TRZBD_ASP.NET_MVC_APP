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
    public class FlatsController : Controller
    {
        private RentControllBDEntities db = new RentControllBDEntities();

        // GET: Flats
        public ActionResult Index()
        {
            var flats = db.Flats.Include(f => f.Building).Include(f => f.Owner);
            return View(flats.ToList());
        }

        // GET: Flats/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flat flat = db.Flats.Find(id);
            if (flat == null)
            {
                return HttpNotFound();
            }
            return View(flat);
        }

        // GET: Flats/Create
        public ActionResult Create()
        {
            ViewBag.Building_id = new SelectList(db.Buildings, "Id", "Address");
            ViewBag.Flat_owner_id = new SelectList(db.Owners, "Id", "Last_name");
            return View();
        }

        // POST: Flats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Flat_number,Flat_square,Building_id,Flat_owner_id")] Flat flat)
        {
            if (ModelState.IsValid)
            {
                db.Flats.Add(flat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Building_id = new SelectList(db.Buildings, "Id", "Address", flat.Building_id);
            ViewBag.Flat_owner_id = new SelectList(db.Owners, "Id", "Last_name", flat.Flat_owner_id);
            return View(flat);
        }

        // GET: Flats/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flat flat = db.Flats.Find(id);
            if (flat == null)
            {
                return HttpNotFound();
            }
            ViewBag.Building_id = new SelectList(db.Buildings, "Id", "Address", flat.Building_id);
            ViewBag.Flat_owner_id = new SelectList(db.Owners, "Id", "Last_name", flat.Flat_owner_id);
            return View(flat);
        }

        // POST: Flats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Flat_number,Flat_square,Building_id,Flat_owner_id")] Flat flat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(flat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Building_id = new SelectList(db.Buildings, "Id", "Address", flat.Building_id);
            ViewBag.Flat_owner_id = new SelectList(db.Owners, "Id", "Last_name", flat.Flat_owner_id);
            return View(flat);
        }

        // GET: Flats/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flat flat = db.Flats.Find(id);
            if (flat == null)
            {
                return HttpNotFound();
            }
            return View(flat);
        }

        // POST: Flats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Flat flat = db.Flats.Find(id);
            db.Flats.Remove(flat);
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
