using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CA1.Controllers
{
    public class AlbumController : Controller
    {
        //
        // GET: /Album/
        MusicStoreDataContext _db = new MusicStoreDataContext();
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Album/Details/5

        //get albums
        public ActionResult Details(int id)
        { 
            var x= from a in _db.Albums
                    join o in _db.OrderDetails on a.AlbumId equals o.AlbumId
                    where o.OrderId == id
                    select a;

            return View(x);
        }

        //get artists
        public ActionResult ArtistDetails(int id = 0)
        {
            var x = from a in _db.Artists
                    join alb in _db.Albums on a.ArtistId equals alb.ArtistId
                    where alb.AlbumId == id
                    select a;

            return View(x);
        }

        //
        // GET: /Album/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Album/Create

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
        // GET: /Album/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Album/Edit/5

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
        // GET: /Album/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Album/Delete/5

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
