using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SYGESTMunicipal.Areas.OFIM.Models.ViewModel;
using SYGESTMunicipal.Data;

namespace SYGESTMunicipal.Areas.OFIM.Controllers
{
    [Area("OFIM")]
    
    public class ActividadController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _hostEnvironment;
        [BindProperty]
        public ActividadViewModel ActividadVM { get; set; }
        public ActividadController(ApplicationDbContext db,
            IWebHostEnvironment hostEnvironment)
        {
            _db = db;
            _hostEnvironment = hostEnvironment;
            ActividadVM = new ActividadViewModel()
            {
                Category = _db.Category,
                Actividad = new Models.Actividad()
            };
        }
        public async Task<IActionResult> Index()
        {
            var Actividad =
            await _db.Actividad.Include(m => m.Category).Include(m => m.Eje).ToListAsync();
            return View(Actividad);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(string dato)
        {
            if (dato == null)
            {
                var Actividad =
                await _db.Actividad.Include(m => m.Category).Include(m => m.Eje).ToListAsync();
                return View(Actividad);
            }
            else
            {
                var actItem =
                     await _db.Actividad.Where(p => p.Category.Name == dato)
                     .Include(p => p.Eje).Include(c => c.Category).ToListAsync();

                return View(actItem);
            }
        }

        //GET - CREATE
        public IActionResult Create()
        {
            return View(ActividadVM);
        }
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePOST()
        {
            ActividadVM.Actividad.EjeId = Convert.ToInt32(Request.Form["EjeId"].ToString());
           
                if (ModelState.IsValid)
                {
                    var files = HttpContext.Request.Form.Files;
                    if (files.Count > 0)
                    {
                        byte[] p1 = null;
                        using (var fs1 = files[0].OpenReadStream())
                        {
                            using (var ms1 = new MemoryStream())
                            {
                                fs1.CopyTo(ms1);
                                p1 = ms1.ToArray();
                            }
                        }
                        ActividadVM.Actividad.Imagen = p1;
                    }
                    _db.Actividad.Add(ActividadVM.Actividad);
                    await _db.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            return View(ActividadVM.Actividad);
        }
    

        //GET - EDIT
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ActividadVM.Actividad = await _db.Actividad.Include(m => m.Category).Include(m => m.Eje).SingleOrDefaultAsync(m => m.Id == id);
            ActividadVM.Eje = await _db.Eje.Where(p => p.CategoryID == ActividadVM.Actividad.CategoryId).ToListAsync();
            if (ActividadVM.Actividad == null)
            {
                return NotFound();
            }
            return View(ActividadVM);
        }

        //POST - EDIT
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPOST(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ActividadVM.Actividad.EjeId = Convert.ToInt32(Request.Form["EjeId"].ToString());
            if (!ModelState.IsValid)
            {
                ActividadVM.Eje = await _db.Eje.Where(p => p.CategoryID == ActividadVM.Actividad.CategoryId).ToListAsync();
                return View(ActividadVM);
            }
            //work in the image saving
            var files = HttpContext.Request.Form.Files;
            var actividadFromDb = await _db.Actividad.FindAsync(ActividadVM.Actividad.Id);
            if (files.Count > 0)
            {
                byte[] p1 = null;
                using (var fs1 = files[0].OpenReadStream())
                {
                    using (var ms1 = new MemoryStream())
                    {
                        fs1.CopyTo(ms1);
                        p1 = ms1.ToArray();
                    }
                }
                actividadFromDb.Imagen = p1;
            }
            actividadFromDb.Name = ActividadVM.Actividad.Name;
            actividadFromDb.Descripcion = ActividadVM.Actividad.Descripcion;
            actividadFromDb.Fecha = ActividadVM.Actividad.Fecha;
            actividadFromDb.IsActive = ActividadVM.Actividad.IsActive;
            actividadFromDb.CategoryId = ActividadVM.Actividad.CategoryId;
            actividadFromDb.EjeId = ActividadVM.Actividad.EjeId;
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
            ActividadVM.Actividad = await _db.Actividad.Include(m => m.Category).Include(m => m.Eje).SingleOrDefaultAsync(m => m.Id == id);
            ActividadVM.Eje = await _db.Eje.Where(s => s.CategoryID == ActividadVM.Actividad.CategoryId).ToListAsync();

            if (ActividadVM.Actividad == null)
            {
                return NotFound();
            }
            return View(ActividadVM);
        }

        //GET - DELETE
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ActividadVM.Actividad = await _db.Actividad.Include(m => m.Category).Include(m => m.Eje).SingleOrDefaultAsync(m => m.Id == id);
            ActividadVM.Eje = await _db.Eje.Where(s => s.CategoryID == ActividadVM.Actividad.CategoryId).ToListAsync();
            if (ActividadVM.Actividad == null)
            {
                return NotFound();
            }
            return View(ActividadVM);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> DeletePOST(int? id)
        {
            var actividadDelete = await _db.Actividad.FindAsync(id);
            if (actividadDelete == null)
            {
                return View();
            }
            _db.Actividad.Remove(actividadDelete);
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


    }
}

