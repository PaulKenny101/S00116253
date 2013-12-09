using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace CA2.Controllers
{
    public class HomeController : Controller
    {
    //create db link
       private northwndEntities _db = new northwndEntities();

      
        //
        // GET: /Home/

        public ActionResult Index()
        {
            var x = (from o in _db.Orders
                     join c in _db.Customers on o.CustomerID equals c.CustomerID
                     select o);
         
            return View(x);
        }

        //
        // GET: /Home/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Home/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Home/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Home/Edit/5
        // GET: /Home/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Order order = _db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }

            return View(order);
        }

        //
        // POST: /Home/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Order order)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    _db.Entry(order).State = EntityState.Modified;
                    _db.SaveChanges();

                    return RedirectToAction("Index");
                }

                return View(order);


            }
            catch
            {
                return View("Error");
            }
        }

        //
        // GET: /Order/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Order order = _db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }

            return View(order);
        }

        //
        // POST: /Home/Delete/5


        [HttpPost, ActionName("Delete")]
       
        public ActionResult ConfirmDelete(int id = 0)
        {

            // TODO: Add delete logic here
            Order order = _db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            _db.Orders.Remove(order);
            _db.SaveChanges();
            return RedirectToAction("Index");


        }

        //db is disposed of when finished using
        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }

        
    }
}
