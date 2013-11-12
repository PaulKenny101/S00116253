using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CA1.Controllers
{
    public class ArtistController : Controller
    {
        //
        // GET: /Artist/
        MusicStoreDataContext _db = new MusicStoreDataContext();

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Artist/Details/5

        public ActionResult Details(int id)
        {
            var x = from a in _db.Artists
                    join alb in _db.Albums on a.ArtistId equals alb.ArtistId
                    where alb.AlbumId == id
                    select a;

            return View(x);
        }

        //
        // GET: /Artist/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Artist/Create

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
        // GET: /Artist/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Artist/Edit/5

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
        // GET: /Artist/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Artist/Delete/5

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
