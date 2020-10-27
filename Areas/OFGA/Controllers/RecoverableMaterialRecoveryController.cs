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
    [Authorize(Roles = SD.CollManager)]
    public class RecoverableMaterialRecoveryController : Controller
    {

        private readonly ApplicationDbContext _db;
        List<RecoverableMaterialRecovery> listaRecoverableMaterialRecovery = new List<RecoverableMaterialRecovery>();
        static List<RecoverableMaterialRecovery> lista = new List<RecoverableMaterialRecovery>();
        static private string _Fecha;
        public RecoverableMaterialRecoveryController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            listaRecoverableMaterialRecovery = (from recoverableMaterialRecovery in _db.RecoverableMaterialRecovery


                                                select new RecoverableMaterialRecovery
                                                {
                                                    Id = recoverableMaterialRecovery.Id,
                                                    Weight = recoverableMaterialRecovery.Weight,
                                                    PlaceName = recoverableMaterialRecovery.PlaceName,
                                                    EntryDate = recoverableMaterialRecovery.EntryDate


                                                }).ToList();
            lista = listaRecoverableMaterialRecovery;
            return View(listaRecoverableMaterialRecovery);


        }



        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(RecoverableMaterialRecovery recoverableMaterialRecovery)
        {
            int nVeces = 0;

            try
            {
                nVeces = _db.RecoverableMaterialRecovery.Where(m => m.Id == recoverableMaterialRecovery.Id).Count();
                if (!ModelState.IsValid || nVeces >= 1)
                {
                    if (nVeces >= 1) ViewBag.Error = "Esta identificación ya existe!";

                    return View(recoverableMaterialRecovery);
                }
                else
                {

                    _db.RecoverableMaterialRecovery.Add(recoverableMaterialRecovery);
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
            RecoverableMaterialRecovery oRecoverableMaterialRecovery = _db.RecoverableMaterialRecovery
                .Where(e => e.Id == id).First();
            return View(oRecoverableMaterialRecovery);
        }
        [HttpPost]
        public IActionResult Edit(RecoverableMaterialRecovery recoverableMaterialRecovery)
        {
            string error = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    ViewBag.EntryDate = recoverableMaterialRecovery.EntryDate.ToString("yyyy-MM-dd");
                    _Fecha = ViewBag.EntryDate;
                    return View(recoverableMaterialRecovery);
                }
                else
                {
                    _db.RecoverableMaterialRecovery.Update(recoverableMaterialRecovery);
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

            RecoverableMaterialRecovery oRecoverableMaterialRecovery = _db.RecoverableMaterialRecovery
                       .Where(e => e.Id == id).First();
            return View(oRecoverableMaterialRecovery);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();

            }
            var recoverableMaterialRecovery = await _db.RecoverableMaterialRecovery.FindAsync(id);
            if (recoverableMaterialRecovery == null)
            {
                return NotFound();

            }
            return View(recoverableMaterialRecovery);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var recoverableMaterialRecovery = await _db.RecoverableMaterialRecovery.FindAsync(id);
            if (recoverableMaterialRecovery == null)
            {
                return View();
            }
            _db.RecoverableMaterialRecovery.Remove(recoverableMaterialRecovery);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
