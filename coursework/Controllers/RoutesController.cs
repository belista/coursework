using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using coursework.Models;

namespace coursework.Controllers
{
    public class RoutesController : Controller
    {
        private AgencyContext _db = new AgencyContext();
        
        public ActionResult Index()
        {
            var routes = _db.Routes.Include(r => r.Hotel).ToList();
            return View(routes);
        }
        
        public ActionResult Create()
        {
            ViewBag.HotelId = new SelectList(_db.Hotels, "Id", "City");
            return View();
        }

        [HttpGet]
        public ActionResult Search(string search)
        {
            var result = _db.Routes
                         .Where(c => c.City
                         .Contains(search) || c.Itinerary
                         .Contains(search) || c.Description
                         .Contains(search))
                         .ToList();

            if (result.Count != 0)
            {
                ViewData.Model = result;
            }
            else
            {
                ViewData.Model = _db.Routes;
            }

            return View("~/Views/Routes/Index.cshtml");
        }
        
        [HttpPost]
        public ActionResult Create(Route route)
        {
            if (ModelState.IsValid)
            {
                _db.Routes.Add(route);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.HotelId = new SelectList(_db.Hotels, "Id", "City", route.HotelId);
            return View(route);
        }
        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var route = _db.Routes.Find(id);
            if (route == null)
            {
                return HttpNotFound();
            }
            ViewBag.HotelId = new SelectList(_db.Hotels, "Id", "City", route.HotelId);
            return View(route);
        }
        
        [HttpPost]
        public ActionResult Edit(Route route)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(route).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HotelId = new SelectList(_db.Hotels, "Id", "City", route.HotelId);
            return View(route);
        }
        
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var route = _db.Routes.Find(id);
            if (route == null)
            {
                return HttpNotFound();
            }
            return View(route);
        }
        
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var route = _db.Routes.Find(id);
            _db.Routes.Remove(route);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
