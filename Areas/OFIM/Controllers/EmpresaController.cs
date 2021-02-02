using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SYGESTMunicipal.Areas.OFIM.Models;
using SYGESTMunicipal.Areas.OFIM.Models.ViewModel;
using SYGESTMunicipal.Data;

namespace SYGESTMunicipal.Areas.OFIM.Controllers
{
    [Area("OFIM")]
    public class EmpresaController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _hostEnvironment;
        [BindProperty]
        public EmpresaAndClasificacionViewModel EmpresaVM { get; set; }
        public string StatusMessage { get; private set; }

        public EmpresaController(ApplicationDbContext db,
            IWebHostEnvironment hostEnvironment)
        {
            _db = db;
            _hostEnvironment = hostEnvironment;
            EmpresaVM = new EmpresaAndClasificacionViewModel()
            {
                Clasificacion = _db.Clasificacion,
                Empresa = new Models.Empresa()
            };
        }
        public async Task<IActionResult> Index()
        {
            var Empresa =
            await _db.Empresa.Include(m => m.Clasificacion).ToListAsync();
            return View(Empresa);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(string dato)
        {
            if (dato == null)
            {
                var Empresa =
                await _db.Empresa.Include(m => m.Clasificacion).ToListAsync();
                return View(Empresa);
            }
            else
            {
                var actItem =
                     await _db.Empresa.Where(p => p.Clasificacion.Name == dato)
                     .Include(c => c.Clasificacion).ToListAsync();

                return View(actItem);
            }
        }
        //GET - CREATE
        public async Task<IActionResult> Create()
        {
            EmpresaAndClasificacionViewModel EmpresaVM = new EmpresaAndClasificacionViewModel()
            {
                Clasificacion = await _db.Clasificacion.ToListAsync(),
                Empresa = new Models.Empresa(),
                EmpresaList =
                     await _db.Empresa.OrderBy(p => p.Name).Select(p => p.Name).Distinct().ToListAsync()
            };
            return View(EmpresaVM);
        }
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePOST(EmpresaAndClasificacionViewModel EmpresaVM)
        {
            //EmpresaVM.Empresa.ClasificacionID = Convert.ToInt32(Request.Form["ClasificacionId"].ToString());
            //try
            //{
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
                    EmpresaVM.Empresa.Imagen = p1;
                }
                _db.Empresa.Add(EmpresaVM.Empresa);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //}
            //catch (Exception ex)
            //{
            //ViewBag.Error = ex.Message;
            //}
            return View(EmpresaVM.Empresa);
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var eje = await _db.Empresa.SingleOrDefaultAsync(m => m.Id == id);
            if (eje == null)
            {
                return NotFound();
            }
            EmpresaAndClasificacionViewModel model = new EmpresaAndClasificacionViewModel()
            {
                Clasificacion = await _db.Clasificacion.ToListAsync(),
                Empresa = eje,
                EmpresaList =
              await _db.Empresa.OrderBy(p => p.Name).Select(p => p.Name).Distinct().ToListAsync()
            };
            return View(model);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var eje = await _db.Empresa.SingleOrDefaultAsync(m => m.Id == id);
            if (eje == null)
            {
                return NotFound();
            }
            EmpresaAndClasificacionViewModel model = new EmpresaAndClasificacionViewModel()
            {
                Clasificacion = await _db.Clasificacion.ToListAsync(),
                Empresa = eje,
                EmpresaList =
                await _db.Empresa.OrderBy(p => p.Name).Select(p => p.Name).Distinct().ToListAsync()
            };
            return View(model);
        }
        //POST - EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EmpresaAndClasificacionViewModel model)
        {
            if (ModelState.IsValid)
            {
                var EjeExist = _db.Empresa.Include(s => s.Clasificacion).Where(s => s.Name == model.Empresa.Name
                                  && s.ClasificacionID == model.Empresa.ClasificacionID);
                if (EjeExist.Count() > 0)
                {
                    StatusMessage = "Error: Esta Empresa ya ha sido creado en la Clasificacion " + EjeExist.First().Clasificacion.Name +
                            " Por favor, use otro nombre";
                }
                else
                {
                    var ProdCatFromDB = await _db.Empresa.FindAsync(id);
                    ProdCatFromDB.Name = model.Empresa.Name;
                    await _db.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            EmpresaAndClasificacionViewModel modelVM = new EmpresaAndClasificacionViewModel()
            {
                Clasificacion = await _db.Clasificacion.ToListAsync(),
                Empresa = model.Empresa,
                EmpresaList = await _db.Empresa.OrderBy(p => p.Name).Select(p => p.Name).ToListAsync(),
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
            var eje = await _db.Empresa.SingleOrDefaultAsync(m => m.Id == id);
            if (eje == null)
            {
                return NotFound();
            }
            EmpresaAndClasificacionViewModel model = new EmpresaAndClasificacionViewModel()
            {
                Clasificacion = await _db.Clasificacion.ToListAsync(),
                Empresa = eje,
                EmpresaList = await _db.Empresa.OrderBy(p => p.Name).Select(p => p.Name).Distinct().ToListAsync()
            };
            return View(model);
        }
        //POST - DELETE
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var ejeDelete = await _db.Empresa.FindAsync(id);
            if (ejeDelete == null)
            {
                return View();
            }
            _db.Empresa.Remove(ejeDelete);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> GetEmpresa(int id)
        {
            List<Empresa> empresa = new List<Empresa>();
            empresa = await (from Empresa in _db.Empresa
                             where Empresa.ClasificacionID == id
                             select Empresa).ToListAsync();
            return Json(new SelectList(empresa, "Id", "Name"));
        }
    }
}
