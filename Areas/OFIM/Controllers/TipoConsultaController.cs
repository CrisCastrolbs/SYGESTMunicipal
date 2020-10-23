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
    //[Authorize(Roles = SD.ManagerUser)]
    public class TipoConsultaController : Controller
    {
        private readonly ApplicationDbContext _db;
        [TempData]
        public string StatusMessage { get; set; }
        public TipoConsultaController(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            var product = await _db.TipoConsulta.Include(s => s.PersonaOFIM).ToListAsync();
            return View(product);
        }
        //GET - CREATE
        public async Task<IActionResult> Create()
        {
            TipoConsultaAndPersonaViewModel model = new TipoConsultaAndPersonaViewModel()
            {
                PersonaOFIMList = await _db.PersonaOFIM.ToListAsync(),
                TipoConsulta = new Models.TipoConsulta(),
                TipoConsultaList =
                     await _db.TipoConsulta.OrderBy(p => p.NombreTipoConsulta).Select(p => p.NombreTipoConsulta).Distinct().ToListAsync()
            };
            return View(model);
        }
        //POST - CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TipoConsultaAndPersonaViewModel model)
        {
            if (ModelState.IsValid)
            {
                var TipoConsultaExist = _db.TipoConsulta.Include(s => s.PersonaOFIM).Where(s => s.NombreTipoConsulta
                                      == model.TipoConsulta.NombreTipoConsulta
                                      && s.PersonaOFIMId == model.TipoConsulta.PersonaOFIMId);
                if (TipoConsultaExist.Count() > 0)
                {
                    StatusMessage = "Error: Este tipo de consulta ya ha sido creada para la persona " + TipoConsultaExist.First().PersonaOFIM.PersonName +
                          " Por favor, use otro tipo de consulta, o modifique la que ya tiene";
                }
                else
                {
                    _db.TipoConsulta.Add(model.TipoConsulta);
                    await _db.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            TipoConsultaAndPersonaViewModel modelVM = new TipoConsultaAndPersonaViewModel()
            {
                PersonaOFIMList = await _db.PersonaOFIM.ToListAsync(),
                TipoConsulta = model.TipoConsulta,
                TipoConsultaList = await _db.TipoConsulta.OrderBy(p => p.NombreTipoConsulta).Select(p => p.NombreTipoConsulta).ToListAsync(),
                StatusMessage = StatusMessage
            };
            return View(modelVM);
        }
        //GET - EDIT
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var product = await _db.TipoConsulta.SingleOrDefaultAsync(m => m.PersonaOFIMId == id);
            if (product == null)
            {
                return NotFound();
            }
            TipoConsultaAndPersonaViewModel model = new TipoConsultaAndPersonaViewModel()
            {
                PersonaOFIMList = await _db.PersonaOFIM.ToListAsync(),
                TipoConsulta = product,
                TipoConsultaList =
                await _db.TipoConsulta.OrderBy(p => p.NombreTipoConsulta).Select(p => p.NombreTipoConsulta).Distinct().ToListAsync()
            };
            return View(model);
        }
        //POST - EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TipoConsultaAndPersonaViewModel model)
        {
            if (ModelState.IsValid)
            {
                var TipoConsultaExist = _db.TipoConsulta.Include(s => s.PersonaOFIM).Where(s => s.NombreTipoConsulta == model.TipoConsulta.NombreTipoConsulta
                                  && s.PersonaOFIMId == model.TipoConsulta.PersonaOFIMId);
                if (TipoConsultaExist.Count() > 0)
                {
                    StatusMessage = "Error: Este Tipo Consulta ya ha sido creado para la persona " + TipoConsultaExist.First().PersonaOFIM.PersonName +
                          " Por favor, use otro tipo de consulta o edita la que ya se encuentra registrada";
                }
                else
                {
                    var ProdCatFromDB = await _db.TipoConsulta.FindAsync(id);
                    ProdCatFromDB.NombreTipoConsulta = model.TipoConsulta.NombreTipoConsulta;
                    await _db.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            TipoConsultaAndPersonaViewModel modelVM = new TipoConsultaAndPersonaViewModel()
            {
                PersonaOFIMList = await _db.PersonaOFIM.ToListAsync(),
                TipoConsulta = model.TipoConsulta,
                TipoConsultaList = await _db.TipoConsulta.OrderBy(p => p.NombreTipoConsulta).Select(p => p.NombreTipoConsulta).ToListAsync(),
                StatusMessage = StatusMessage
            };
            return View(modelVM);
        }
        //GET - DELETE
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var product = await _db.TipoConsulta.SingleOrDefaultAsync(m => m.PersonaOFIMId == id);
            if (product == null)
            {
                return NotFound();
            }
            TipoConsultaAndPersonaViewModel model = new TipoConsultaAndPersonaViewModel()
            {
                PersonaOFIMList = await _db.PersonaOFIM.ToListAsync(),
                TipoConsulta = product,
                TipoConsultaList = await _db.TipoConsulta.OrderBy(p => p.NombreTipoConsulta).Select(p => p.NombreTipoConsulta).Distinct().ToListAsync()
            };
            return View(model);
        }
        //POST - DELETE
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var productDelete = await _db.TipoConsulta.FindAsync(id);
            if (productDelete == null)
            {
                return View();
            }
            _db.TipoConsulta.Remove(productDelete);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        //GET - DETAILS
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var product = await _db.TipoConsulta.SingleOrDefaultAsync(m => m.PersonaOFIMId == id);
            if (product == null)
            {
                return NotFound();
            }
            TipoConsultaAndPersonaViewModel model = new TipoConsultaAndPersonaViewModel()
            {
                PersonaOFIMList = await _db.PersonaOFIM.ToListAsync(),
                TipoConsulta = product,
                TipoConsultaList =
              await _db.TipoConsulta.OrderBy(p => p.NombreTipoConsulta).Select(p => p.NombreTipoConsulta).Distinct().ToListAsync()
            };
            return View(model);
        }
        [ActionName("GetTipoConsultas")]
        public async Task<IActionResult> GetTipoConsultas(string id)
        {
            List<TipoConsulta> tipoConsulta = new List<TipoConsulta>();
            tipoConsulta = await (from TipoConsulta in _db.TipoConsulta
                              where TipoConsulta.PersonaOFIMId == id
                              select TipoConsulta).ToListAsync();
            return Json(new SelectList(tipoConsulta, "TipoConsultaId", "NombreTipoConsulta"));
        }

    }
}