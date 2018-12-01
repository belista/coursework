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
    public class HotelsController : Controller
    {
        private AgencyContext _db = new AgencyContext();
        
        public ActionResult Index()
        {
            var hotels = _db.Hotels.Include(h => h.Country).ToList();
            return View(hotels);
        }
        
        public ActionResult Create()
        {
            ViewBag.CountryId = new SelectList(_db.Countries, "Id", "Name");
            return View();
        }
        
        [HttpGet]
        public ActionResult Search(string search)
        {
            var result = _db.Hotels
                         .Where(c => c.City
                         .Contains(search) || c.Name
                         .Contains(search) || c.Status
                         .Contains(search))
                         .ToList();

            if (result.Count != 0)
            {
                ViewData.Model = result;
            }
            else
            {
                ViewData.Model = _db.Hotels;
            }

            return View("~/Views/Hotels/Index.cshtml");
        }
        
        [HttpPost]
        public ActionResult Create(Hotel hotel)
        {
            if (ModelState.IsValid)
            {
                _db.Hotels.Add(hotel);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CountryId = new SelectList(_db.Countries, "Id", "Name", hotel.CountryId);
            return View(hotel);
        }
        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var hotel = _db.Hotels.Find(id);
            if (hotel == null)
            {
                return HttpNotFound();
            }
            ViewBag.CountryId = new SelectList(_db.Countries, "Id", "Name", hotel.CountryId);
            return View(hotel);
        }
        
        [HttpPost]
        public ActionResult Edit(Hotel hotel)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(hotel).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CountryId = new SelectList(_db.Countries, "Id", "Name", hotel.CountryId);
            return View(hotel);
        }
        
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var hotel = _db.Hotels.Find(id);
            if (hotel == null)
            {
                return HttpNotFound();
            }
            return View(hotel);
        }
        
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var hotel = _db.Hotels.Find(id);
            _db.Hotels.Remove(hotel);
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
