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
    public class OrganizationsController : Controller
    {
        private AgencyContext _db = new AgencyContext();
        
        public ActionResult Index()
        {
            return View(_db.Organizations.ToList());
        }
        
        public ActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Search(string search)
        {
            var result = _db.Organizations
                         .Where(c => c.Name
                         .Contains(search) || c.ChiefFirstName
                         .Contains(search) || c.ChiefFamilyName
                         .Contains(search) || c.ChiefPatronymic
                         .Contains(search) || c.Address
                         .Contains(search))
                         .ToList();

            if (result.Count != 0)
            {
                ViewData.Model = result;
            }
            else
            {
                ViewData.Model = _db.Organizations;
            }

            return View("~/Views/Organizations/Index.cshtml");
        }
        
        [HttpPost]
        public ActionResult Create(Organization organization)
        {
            if (ModelState.IsValid)
            {
                _db.Organizations.Add(organization);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(organization);
        }
        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var organization = _db.Organizations.Find(id);
            if (organization == null)
            {
                return HttpNotFound();
            }
            return View(organization);
        }
        
        [HttpPost]
        public ActionResult Edit(Organization organization)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(organization).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(organization);
        }
        
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var organization = _db.Organizations.Find(id);
            if (organization == null)
            {
                return HttpNotFound();
            }
            return View(organization);
        }
        
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var organization = _db.Organizations.Find(id);
            _db.Organizations.Remove(organization);
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
