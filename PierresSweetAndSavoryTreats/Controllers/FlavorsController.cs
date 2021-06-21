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

namespace PierresSweetAndSavoryTreats.Controllers {
  [Authorize]
  public class FlavorsController : Controller {
    private readonly PierresSweetAndSavoryTreatsContext _db;

    public FlavorsController(PierresSweetAndSavoryTreatsContext db) {
      _db = db;
    }

    public ActionResult Index() {
     List<Flavor> flavors = _db.Flavors.ToList();
        // .Include(flavor => flavor.FlavorTreat)
        // .ThenInclude(flavorTreat => authorflavorTreatBook.Flavor)
        // .OrderBy(flavor => flavor.Title)
        // .ToList();
      return View(flavors);
    }

    [Authorize]
    public ActionResult Create() {
      return View();
    }

    [HttpPost]
    [Authorize]
    public ActionResult Create(Flavor flavor) {
      _db.Flavors.Add(flavor);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int flavorId) { //understand more
      Flavor currentflavor = _db.Flavors
      .Include(flavor => flavor.FlavorTreats)
      .ThenInclude(flavorTreat => flavorTreat.Treat)
      .FirstOrDefault(flavor => flavor.FlavorId == flavorId);
      return View(currentflavor);
    }

    // public ActionResult Search() {
    //   return View();
    // }

    [Authorize]
    public ActionResult Edit(int flavorId)
    {
      Flavor currentflavor = _db.Flavors.FirstOrDefault(flavor => flavor.FlavorId == flavorId);
      return View(currentflavor);
    }

    [HttpPost]
    [Authorize]
    public ActionResult Edit(Flavor flavor)
    {
      _db.Entry(flavor).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }


    [Authorize]
    public ActionResult Delete(int flavorId)
    {
      Flavor currentFlavor = _db.Flavors.FirstOrDefault(flavor => flavor.FlavorId == flavorId);
      return View(currentFlavor);
    }

    [HttpPost, ActionName("Delete")]
    [Authorize]
    public ActionResult DeleteConfirmed(int flavorId)
    {
      Flavor currentFlavor = _db.Flavors.FirstOrDefault(flavor => flavor.FlavorId == currentFlavor);
      if (flavorId != 0)
      {
        _db.Flavors.Remove(currentFlavor);
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
   }
}