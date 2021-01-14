using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SYGESTMunicipal.Areas.OFIM.Models;
using SYGESTMunicipal.Areas.OFIM.Models.ViewModel;
using SYGESTMunicipal.Data;

namespace SYGESTMunicipal.Areas.OFIM.Controllers
{
    [Area("OFIM")]
    public class EjeController : Controller
    {
        private readonly ApplicationDbContext _db;
        [TempData]
        public string StatusMessage { get; set; }
        public EjeController(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            var eje =
                await _db.Eje.Include(s => s.Category).ToListAsync();
            return View(eje);
        }
        //GET - CREATE
        public async Task<IActionResult> Create()
        {
            EjeAndCategoryViewModel model = new EjeAndCategoryViewModel()
            {
                CategoryList = await _db.Category.ToListAsync(),
                Eje = new Models.Eje(),
                EjeList =
                     await _db.Eje.OrderBy(p => p.Name).Select(p => p.Name).Distinct().ToListAsync()
            };
            return View(model);
        }
        //POST - CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EjeAndCategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var EjeExist = _db.Eje.Include(s => s.Category).Where(s => s.Name
                                      == model.Eje.Name
                                      && s.CategoryID == model.Eje.CategoryID);
                if (EjeExist.Count() > 0)
                {
                    StatusMessage = "Error: Este Eje ya ha sido creado en la Categoria " + EjeExist.First().Category.Name +
                          " Por favor, use otro nombre";
                }
                else
                {
                    _db.Eje.Add(model.Eje);
                    await _db.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            EjeAndCategoryViewModel modelVM = new EjeAndCategoryViewModel()
            {
                CategoryList = await _db.Category.ToListAsync(),
                Eje = model.Eje,
                EjeList = await _db.Eje.OrderBy(p => p.Name).Select(p => p.Name).ToListAsync(),
                StatusMessage = StatusMessage
            };
            return View(modelVM);
        }
        //GET - EDIT
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var eje = await _db.Eje.SingleOrDefaultAsync(m => m.Id == id);
            if (eje == null)
            {
                return NotFound();
            }
            EjeAndCategoryViewModel model = new EjeAndCategoryViewModel()
            {
                CategoryList = await _db.Category.ToListAsync(),
                Eje = eje,
                EjeList =
                await _db.Eje.OrderBy(p => p.Name).Select(p => p.Name).Distinct().ToListAsync()
            };
            return View(model);
        }
        //POST - EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EjeAndCategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var EjeExist = _db.Eje.Include(s => s.Category).Where(s => s.Name == model.Eje.Name
                                  && s.CategoryID == model.Eje.CategoryID);
                if (EjeExist.Count() > 0)
                {
                    StatusMessage = "Error: Este Eje ya ha sido creado en la Categoria " + EjeExist.First().Category.Name +
                            " Por favor, use otro nombre";
                }
                else
                {
                    var ProdCatFromDB = await _db.Eje.FindAsync(id);
                    ProdCatFromDB.Name = model.Eje.Name;
                    await _db.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            EjeAndCategoryViewModel modelVM = new EjeAndCategoryViewModel()
            {
                CategoryList = await _db.Category.ToListAsync(),
                Eje = model.Eje,
                EjeList = await _db.Eje.OrderBy(p => p.Name).Select(p => p.Name).ToListAsync(),
                StatusMessage = StatusMessage
            };
            return View(modelVM);
        }
        //GET - DELETE
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var eje = await _db.Eje.SingleOrDefaultAsync(m => m.Id == id);
            if (eje == null)
            {
                return NotFound();
            }
            EjeAndCategoryViewModel model = new EjeAndCategoryViewModel()
            {
                CategoryList = await _db.Category.ToListAsync(),
                Eje = eje,
                EjeList = await _db.Eje.OrderBy(p => p.Name).Select(p => p.Name).Distinct().ToListAsync()
            };
            return View(model);
        }
        //POST - DELETE
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var ejeDelete = await _db.Eje.FindAsync(id);
            if (ejeDelete == null)
            {
                return View();
            }
            _db.Eje.Remove(ejeDelete);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        //GET - DETAILS
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var eje = await _db.Eje.SingleOrDefaultAsync(m => m.Id == id);
            if (eje == null)
            {
                return NotFound();
            }
            EjeAndCategoryViewModel model = new EjeAndCategoryViewModel()
            {
                CategoryList = await _db.Category.ToListAsync(),
                Eje = eje,
                EjeList =
              await _db.Eje.OrderBy(p => p.Name).Select(p => p.Name).Distinct().ToListAsync()
            };
            return View(model);
        }
        [ActionName("GetEjes")]
        public async Task<IActionResult> GetEjes(int id)
        {
            List<Eje> ejes = new List<Eje>();
            ejes = await (from Eje in _db.Eje
                              where Eje.CategoryID == id
                              select Eje).ToListAsync();
            return Json(new SelectList(ejes, "Id", "Name"));
        }

    }
}