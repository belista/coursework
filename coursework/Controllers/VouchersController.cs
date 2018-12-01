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
    public class VouchersController : Controller
    {
        private AgencyContext _db = new AgencyContext();
        
        public ActionResult Index()
        {
            var vouchers = _db.Vouchers.Include(v => v.Employee).Include(v => v.Route).Include(v => v.Tourist).ToList();
            return View(vouchers);
        }
        
        public ActionResult Create()
        {
            ViewBag.EmployeeId = new SelectList(_db.Employees, "Id", "Surname");
            ViewBag.RouteId = new SelectList(_db.Routes, "Id", "City");
            ViewBag.TouristId = new SelectList(_db.Tourists, "Id", "Surname");
            return View();
        }

        [HttpGet]
        public ActionResult Search(string search)
        {
            var result = _db.Vouchers
                         .Where(c => c.Start
                         .Equals(search) || c.Ending
                         .Equals(search))
                         .ToList();

            if (result.Count != 0)
            {
                ViewData.Model = result;
            }
            else
            {
                ViewData.Model = _db.Vouchers;
            }

            return View("~/Views/Vouchers/Index.cshtml");
        }
        
        [HttpPost]
        public ActionResult Create(Voucher voucher)
        {
            if (ModelState.IsValid)
            {
                _db.Vouchers.Add(voucher);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeId = new SelectList(_db.Employees, "Id", "Surname", voucher.EmployeeId);
            ViewBag.RouteId = new SelectList(_db.Routes, "Id", "City", voucher.RouteId);
            ViewBag.TouristId = new SelectList(_db.Tourists, "Id", "Surname", voucher.TouristId);
            return View(voucher);
        }
        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var voucher = _db.Vouchers.Find(id);
            if (voucher == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeId = new SelectList(_db.Employees, "Id", "Surname", voucher.EmployeeId);
            ViewBag.RouteId = new SelectList(_db.Routes, "Id", "City", voucher.RouteId);
            ViewBag.TouristId = new SelectList(_db.Tourists, "Id", "Surname", voucher.TouristId);
            return View(voucher);
        }
        
        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,Cost,Start,Ending,EmployeeId,TouristId,RouteId")] Voucher voucher)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(voucher).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeId = new SelectList(_db.Employees, "Id", "Surname", voucher.EmployeeId);
            ViewBag.RouteId = new SelectList(_db.Routes, "Id", "City", voucher.RouteId);
            ViewBag.TouristId = new SelectList(_db.Tourists, "Id", "Surname", voucher.TouristId);
            return View(voucher);
        }
        
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var voucher = _db.Vouchers.Find(id);
            if (voucher == null)
            {
                return HttpNotFound();
            }
            return View(voucher);
        }
        
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var voucher = _db.Vouchers.Find(id);
            _db.Vouchers.Remove(voucher);
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
