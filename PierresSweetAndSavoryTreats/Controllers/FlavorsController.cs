using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using PierresSweetAndSavoryTreats.Models;
using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;

namespace PierresSweetAndSavoryFlavors.Controllers
{
    [Authorize]
    public class FlavorsController : Controller
    {
        private readonly PierresSweetAndSavoryTreatsContext _db;

        private readonly UserManager<ApplicationUser> _userManager;

        public FlavorsController(UserManager<ApplicationUser> userManager, PierresSweetAndSavoryTreatsContext db)
        {
            _userManager = userManager;
            _db = db;
        }

        public ActionResult Index()
        {
            IEnumerable<Flavor> sortedFlavors = _db.Flavors.ToList().OrderBy(flavor => flavor.FlavorName);
            return View(sortedFlavors.ToList());
        }

        [Authorize]
        public ActionResult Create()
        {
            ViewBag.TreatId = new SelectList(_db.Treats, "TreatId", "TreatName");
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult Create(Flavor flavor, int TreatId)  //why int for string from drop
        {
            _db.Flavors.Add(flavor); //add new student btut no need to update course table - course already exists
            _db.SaveChanges();
            if (TreatId != 0) //why?
            {
                _db.FlavorTreats.Add(new FlavorTreat() { TreatId = TreatId, FlavorId = flavor.FlavorId });
            }
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize]
        public ActionResult Details(int id)
        {
            Flavor thisFlavor = _db.Flavors
              .Include(flavor => flavor.FlavorTreats)
              .ThenInclude(join => join.Flavor)
              .FirstOrDefault(flavor => flavor.FlavorId == id);
            return View(thisFlavor);
        }

        [HttpPost]
        [Authorize]
        public ActionResult DeleteEngineer(int joinId)
        {
            var joinEntry = _db.FlavorTreats.FirstOrDefault(entry => entry.FlavorTreatId == joinId);
            _db.FlavorTreats.Remove(joinEntry);
            _db.SaveChanges();
            return RedirectToAction("Details", new { id = joinEntry.FlavorId });
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            var thisItem = _db.Flavors.FirstOrDefault(flavor => flavor.FlavorId == id);
            // ViewBag.FlavorId = new SelectList(_db.Flavors, "FlavorId", "FlavorName");
            ViewBag.FlavorId = new SelectList(_db.Flavors, "FlavorId", "FlavorName");
            return View(thisItem);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Edit(Flavor flavor, int FlavorId)
        {
            if (FlavorId != 0)
            {
                _db.FlavorTreats.Add(new FlavorTreat() { FlavorId = FlavorId, TreatId = flavor.FlavorId });
            }
            _db.Entry(flavor).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult Delete(int id)
        {
            var thisFlavor = _db.Flavors.FirstOrDefault(flavor => flavor.FlavorId == id);
            return View(thisFlavor);
        }

        [HttpPost, ActionName("Delete")]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            var thisFlavor = _db.Flavors.FirstOrDefault(flavor => flavor.FlavorId == id);
            _db.Flavors.Remove(thisFlavor);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
