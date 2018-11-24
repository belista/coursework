using coursework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace coursework.Controllers
{
    public class HomeController : Controller
    {
        private AgencyContext _db;

        public HomeController()
        {
            _db = new AgencyContext();
        }

        public ActionResult Index()
        {
            _db.Countries.Add(new Country { Name = "USA" });
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}