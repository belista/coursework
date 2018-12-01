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
    public class EmployeesController : Controller
    {
        private AgencyContext _db = new AgencyContext();
        
        public ActionResult Index()
        {
            var employees = _db.Employees.Include(e => e.Organization).ToList();
            return View(employees);
        }
        
        public ActionResult Create()
        {
            ViewBag.OrganizationId = new SelectList(_db.Organizations, "Id", "Name");
            return View();
        }

        [HttpGet]
        public ActionResult Search(string search)
        {
            var result = _db.Employees
                         .Where(c => c.Surname
                         .Contains(search) || c.Name
                         .Contains(search) || c.Patronymic
                         .Contains(search) || c.Passport.PassportSeries
                         .Contains(search) || c.Position
                         .Contains(search) || c.Category
                         .Contains(search))
                         .ToList();

            if (result.Count != 0)
            {
                ViewData.Model = result;
            }
            else
            {
                ViewData.Model = _db.Employees;
            }

            return View("~/Views/Employees/Index.cshtml");
        }

        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _db.Employees.Add(employee);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OrganizationId = new SelectList(_db.Organizations, "Id", "Name", employee.OrganizationId);
            return View(employee);
        }
        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var employee = _db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.OrganizationId = new SelectList(_db.Organizations, "Id", "Name", employee.OrganizationId);
            return View(employee);
        }
        
        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(employee).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OrganizationId = new SelectList(_db.Organizations, "Id", "Name", employee.OrganizationId);
            return View(employee);
        }
        
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var employee = _db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }
        
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var employee = _db.Employees.Find(id);
            _db.Employees.Remove(employee);
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
