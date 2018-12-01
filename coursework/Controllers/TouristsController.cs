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
    public class TouristsController : Controller
    {
        private AgencyContext _db = new AgencyContext();
        
        public ActionResult Index()
        {
            return View(_db.Tourists.ToList());
        }
        
        public ActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Search(string search)
        {
            var result = _db.Tourists
                         .Where(c => c.Surname
                         .Contains(search) || c.Name
                         .Contains(search) || c.Patronymic
                         .Contains(search) || c.Passport.PassportSeries
                         .Contains(search) || c.Address
                         .Contains(search))
                         .ToList();

            if (result.Count != 0)
            {
                ViewData.Model = result;
            }
            else
            {
                ViewData.Model = _db.Tourists;
            }

            return View("~/Views/Tourists/Index.cshtml");
        }
        
        [HttpPost]
        public ActionResult Create(Tourist tourist)
        {
            if (ModelState.IsValid)
            {
                _db.Tourists.Add(tourist);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tourist);
        }
        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var tourist = _db.Tourists.Find(id);
            if (tourist == null)
            {
                return HttpNotFound();
            }
            return View(tourist);
        }
        
        [HttpPost]
        public ActionResult Edit(Tourist tourist)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(tourist).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tourist);
        }
        
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var tourist = _db.Tourists.Find(id);
            if (tourist == null)
            {
                return HttpNotFound();
            }
            return View(tourist);
        }
        
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var tourist = _db.Tourists.Find(id);
            _db.Tourists.Remove(tourist);
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
