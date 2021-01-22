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
    public class CuposController : Controller
    {
        private readonly ApplicationDbContext _db;
        [TempData]
        public string StatusMessage { get; set; }
        public CuposController(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            var cupos =
                await _db.Cupos.Include(s => s.Actividad).ToListAsync();
            return View(cupos);
        }
        //GET - CREATE
        public async Task<IActionResult> Create()
        {
            CupoAndActividadViewModel model = new CupoAndActividadViewModel()
            {
                ActividadList = await _db.Actividad.ToListAsync(),
                Cupos = new Models.Cupos(),
                CuposList =
                     await _db.Cupos.OrderBy(p => p.CupoMax.ToString()).Select(p => p.CupoMax.ToString()).Distinct().ToListAsync()
            };
            return View(model);
        }
        //POST - CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CupoAndActividadViewModel model)
        {
            if (ModelState.IsValid)
            {
                var CuposExist = _db.Cupos.Include(s => s.Actividad).Where(s => s.ActividadId
                                      == model.Cupos.ActividadId
                                      && s.ActividadId == model.Cupos.ActividadId);

                //Where(s => s.ActividadId == model.Cupos.ActividadId);
                if (CuposExist.Count() >=1)
                {
                    StatusMessage = "Error: La Actividad " + CuposExist.First().Actividad.Name +
                          " Ya posee cupos abiertos ";
                }
                else
                {
                    _db.Cupos.Add(model.Cupos);
                    await _db.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            CupoAndActividadViewModel modelVM = new CupoAndActividadViewModel()
            {
                ActividadList = await _db.Actividad.ToListAsync(),
                Cupos = model.Cupos,
                CuposList = await _db.Cupos.OrderBy(p => p.CupoMax.ToString()).Select(p => p.CupoMax.ToString()).ToListAsync(),
               
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
            var cupos = await _db.Cupos.SingleOrDefaultAsync(m => m.Id == id);
            if (cupos == null)
            {
                return NotFound();
            }
            CupoAndActividadViewModel model = new CupoAndActividadViewModel()
            {
                ActividadList = await _db.Actividad.ToListAsync(),
                Cupos = cupos,
                CuposList =
                await _db.Cupos.OrderBy(p => p.CupoMax.ToString()).Select(p => p.CupoMax.ToString()).Distinct().ToListAsync()


            };
            return View(model);
        }
        //POST - EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CupoAndActividadViewModel model)
        {
            if (ModelState.IsValid)
            {
               var CuposExist = _db.Cupos.Include(s => s.Actividad).Where(s => s.ActividadId
                                   == model.Cupos.ActividadId
                                   && s.ActividadId == model.Cupos.ActividadId);
                if (CuposExist.Count() > 0)
                {
                    StatusMessage = "Error: La Actividad " + CuposExist.First().Actividad.Name +
                          " Ya posee cupos abiertos ";
                }
                else
                {
                    var CuposFromDB = await _db.Cupos.FindAsync(id);
                    CuposFromDB.CupoMax = model.Cupos.CupoMax;
                    await _db.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            CupoAndActividadViewModel modelVM = new CupoAndActividadViewModel()
            {
                ActividadList = await _db.Actividad.ToListAsync(),
                Cupos = model.Cupos,
                CuposList = await _db.Cupos.OrderBy(p => p.CupoMax.ToString()).Select(p => p.CupoMax.ToString()).ToListAsync(),
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
            var cupos = await _db.Cupos.SingleOrDefaultAsync(m => m.Id == id);
            if (cupos == null)
            {
                return NotFound();
            }
            CupoAndActividadViewModel model = new CupoAndActividadViewModel()
            {
                ActividadList = await _db.Actividad.ToListAsync(),
                Cupos = cupos,
                CuposList = await _db.Cupos.OrderBy(p => p.CupoMax.ToString()).Select(p => p.CupoMax.ToString()).Distinct().ToListAsync()
            };
            return View(model);
        }
        //POST - DELETE
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var ejeDelete = await _db.Cupos.FindAsync(id);
            if (ejeDelete == null)
            {
                return View();
            }
            _db.Cupos.Remove(ejeDelete);
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
            var cupos = await _db.Cupos.SingleOrDefaultAsync(m => m.Id == id);
            if (cupos == null)
            {
                return NotFound();
            }
            CupoAndActividadViewModel model = new CupoAndActividadViewModel()
            {
                ActividadList = await _db.Actividad.ToListAsync(),
                Cupos = cupos,
                CuposList =
              await _db.Cupos.OrderBy(p => p.CupoMax.ToString()).Select(p => p.CupoMax.ToString()).Distinct().ToListAsync()
            };
            return View(model);
        }
        [ActionName("GetCupos")]
        public async Task<IActionResult> GetCupos(int id)
        {
            List<Cupos> cupos = new List<Cupos>();
            cupos = await (from Cupos in _db.Cupos
                          where Cupos.ActividadId == id
                          select Cupos).ToListAsync();
            return Json(new SelectList(cupos, "Id", "Name"));
        }

    }
}