using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SYGESTMunicipal.Areas.OFGA.Models;
using SYGESTMunicipal.Data;
using SYGESTMunicipal.Utility;

namespace SYGESTMunicipal.Areas.OFGA.Controllers
{ 
    [Area("OFGA")]
    [Authorize(Roles = SD.ManagerUser)]
    [Authorize(Roles = SD.AdminOFGA)]
    public class SolidWasteController : Controller
    { 
        private readonly ApplicationDbContext _db;
        List<SolidWaste> listaSolidWaste = new List<SolidWaste>();
        static List<SolidWaste> lista = new List<SolidWaste>();
        static private string _Fecha;
        public SolidWasteController(ApplicationDbContext db)
        {
             _db = db;
        }

    public IActionResult Index()
    {
        listaSolidWaste = (from solidWaste in _db.SolidWaste


                           select new SolidWaste
                           {
                               SolidWasteId = solidWaste.SolidWasteId,
                               Weight = solidWaste.Weight,
                               EntryDate = solidWaste.EntryDate
                           

                           }).ToList();
        lista = listaSolidWaste;
        return View(listaSolidWaste);

    }

    public IActionResult Create()
    {

        return View();
    }
    [HttpPost]
    public IActionResult Create(SolidWaste solidWaste)
    {
        int nVeces = 0;

        try
        {
            nVeces = _db.SolidWaste.Where(m => m.SolidWasteId == solidWaste.SolidWasteId).Count();
            if (!ModelState.IsValid || nVeces >= 1)
            {
                if (nVeces >= 1) ViewBag.Error = "Esta identificación ya existe!";

                return View(solidWaste);
            }
            else
            {

                _db.SolidWaste.Add(solidWaste);
                _db.SaveChanges();
            }
        }
        catch (Exception ex)
        {
            ViewBag.Error = ex.Message;
        }
        return RedirectToAction(nameof(Index));
    }



    

    [HttpGet]
    public IActionResult Edit(int id)
    {
        SolidWaste oSolidWaste = _db.SolidWaste
            .Where(e => e.SolidWasteId == id).First();
        return View(oSolidWaste);
    }
    [HttpPost]
    public IActionResult Edit(SolidWaste solidWaste)
    {
        string error = "";
        try
        {
            if (!ModelState.IsValid)
            {
                    ViewBag.EntryDate = solidWaste.EntryDate.ToString("yyyy-MM-dd");
                    _Fecha = ViewBag.EntryDate;
                    return View(solidWaste);
            }
            else
            {
                _db.SolidWaste.Update(solidWaste);
                _db.SaveChanges();
            }
        }
        catch (Exception ex)
        {
            error = ex.Message;
        }
         
            return RedirectToAction(nameof(Index));
    }

    public IActionResult Details(int id)
    {

        SolidWaste oSolidWaste = _db.SolidWaste
                   .Where(e => e.SolidWasteId == id).First();
        return View(oSolidWaste);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();

        }
        var solidWaste = await _db.SolidWaste.FindAsync(id);
        if (solidWaste == null)
        {
            return NotFound();

        }
        return View(solidWaste);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
     public async Task<IActionResult> DeleteConfirmed(int? id)
     {
        var solidWaste = await _db.SolidWaste.FindAsync(id);
        if (solidWaste == null)
        {
            return View();
        }
        _db.SolidWaste.Remove(solidWaste);
        await _db.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
        }


    }
}
