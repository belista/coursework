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
    public class ServicesController : Controller
    {
        private AgencyContext _db = new AgencyContext();
        
        public ActionResult Index()
        {
            return View(_db.Services.ToList());
        }
        
        public ActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Search(string search)
        {
            var result = _db.Services.Where(c => c.Name.Contains(search)).ToList();

            if (result.Count != 0)
            {
                ViewData.Model = result;
            }
            else
            {
                ViewData.Model = _db.Services;
            }

            return View("~/Views/Services/Index.cshtml");
        }
        
        [HttpPost]
        public ActionResult Create(Service service)
        {
            if (ModelState.IsValid)
            {
                _db.Services.Add(service);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(service);
        }
        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var service = _db.Services.Find(id);
            if (service == null)
            {
                return HttpNotFound();
            }
            return View(service);
        }
        
        [HttpPost]
        public ActionResult Edit(Service service)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(service).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(service);
        }
        
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var service = _db.Services.Find(id);
            if (service == null)
            {
                return HttpNotFound();
            }
            return View(service);
        }
        
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var service = _db.Services.Find(id);
            _db.Services.Remove(service);
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
