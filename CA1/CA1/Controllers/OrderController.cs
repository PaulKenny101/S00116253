 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CA1.Controllers
{
    public class OrderController : Controller
    {
        //
        // GET: /Order/

        //create link to local db
        private MusicStoreDataContext _db = new MusicStoreDataContext();


        public ActionResult Index()
        {
            
            return View();
        }

        //sort orders by date
        public ActionResult IndexByDate()
        {
            var x = _db.Orders.OrderBy(a => a.OrderDate);
            return View(x);
        }

        //sort orders by size (Cost)
        public ActionResult IndexBySize()
        {
            var x = _db.Orders.OrderByDescending(a => a.Total);
            return View(x);
        }

        //public ActionResult Index(string searchOrder)
        //{
        //    var orderByUserName = _db.Orders
        //        .Where(or => searchOrder == null || or.Username.Contains(searchOrder));
        //    return View(orderByUserName);}

        //
        // GET: /Order/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Order/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Order/Create

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
        // GET: /Order/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Order/Edit/5

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

        //
        // GET: /Order/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Order/Delete/5

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
