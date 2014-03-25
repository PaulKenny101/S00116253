using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RAD302CA.Models;
using RAD302CA.DAL;

namespace RAD302CA.Controllers
{
    public class LegController : Controller
    {
        private TravelContext db = new TravelContext();

        //
        // GET: /Leg/

        public ActionResult Index()
        {
            var legs = db.Legs.Include(l => l.Trip);
            return View(legs.ToList());
        }

        //
        // GET: /Leg/Details/5

        public ActionResult Details(int id = 0)
        {
            Leg leg = db.Legs.Find(id);
            if (leg == null)
            {
                return HttpNotFound();
            }
            return View(leg);
        }

        //
        // GET: /Leg/Create

        public ActionResult Create()
        {
            ViewBag.TripId = new SelectList(db.Trips, "TripId", "TripName");
            return View();
        }

        //
        // POST: /Leg/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Leg leg)
        {
            if (ModelState.IsValid)
            {
                db.Legs.Add(leg);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TripId = new SelectList(db.Trips, "TripId", "TripName", leg.TripId);
            return View(leg);
        }

        //
        // GET: /Leg/Edit/5

        public ActionResult AddGuest()
        {
           
            return View(AddGuest);
        }

        //
        // POST: /Leg/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Leg leg)
        {
            if (ModelState.IsValid)
            {
                db.Entry(leg).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TripId = new SelectList(db.Trips, "TripId", "TripName", leg.TripId);
            return View(leg);
        }

        //
        // GET: /Leg/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Leg leg = db.Legs.Find(id);
            if (leg == null)
            {
                return HttpNotFound();
            }
            return View(leg);
        }

        //
        // POST: /Leg/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Leg leg = db.Legs.Find(id);
            db.Legs.Remove(leg);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

         

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}