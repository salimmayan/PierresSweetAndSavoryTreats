using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using PierresSweetAndSavoryTreats.Models;
using System.Linq;

namespace PierresSweetAndSavoryTreats.Controllers
{
    public class HomeController : Controller
    {

        private readonly PierresSweetAndSavoryTreatsContext _db;

        public HomeController(PierresSweetAndSavoryTreatsContext db)
        {
            _db = db;
        }

        [HttpGet("/")]
        public ActionResult Index()
        {
            ViewBag.TreatList = _db.Treats.ToList();
            ViewBag.FlavorList = _db.Flavors.ToList();
            return View();
        }
    }
}