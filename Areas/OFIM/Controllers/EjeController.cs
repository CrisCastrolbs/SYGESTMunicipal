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
        
        List<EjeCategory> listaEje = new List<EjeCategory>();
        static List<EjeCategory> lista = new List<EjeCategory>();

       
        public string StatusMessage { get; set; }
        

        public EjeController(ApplicationDbContext db)
        {
            _db = db;
        }

        public List<EjeCategory> BuscarEjeCategory(string nombreCategory)
        {
            List<EjeCategory> listaEjeCategory = new List<EjeCategory>();
            if (nombreCategory == null || nombreCategory.Length == 0)
            {
                listaEje = (from Eje in _db.Eje
                               join category in _db.Category
                               on Eje.CategoryID equals category.Id
                               select new EjeCategory
                               {
                                   Id = Eje.Id,
                                   Name = Eje.Name,
                                   Category = category.Name
                               }).ToList();
                ViewBag.Category = "";
            }
            else
            {
                listaEje = (from Eje in _db.Eje
                               join category in _db.Category
                               on Eje.CategoryID equals category.Id
                               where category.Name.Contains(nombreCategory)
                               select new EjeCategory
                               {
                                   Id = Eje.Id,
                                   Name = Eje.Name,
                                   Category = category.Name
                               }).ToList();
                ViewBag.Category = nombreCategory;
            }
            lista = listaEje;
            return listaEje;
        }


        public IActionResult Index()
        {
            listaEje = BuscarEjeCategory("");
            return View(listaEje);
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
                    var EjeFromDB = await _db.Eje.FindAsync(id);
                    EjeFromDB.Name = model.Eje.Name;
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
      
        




        //GET - DETAILS
        public async Task<IActionResult> Details(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var eje = await _db.Eje.SingleOrDefaultAsync(m => m.Id == Id);
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


        public IActionResult Delete(int Id)
        {
            if (ModelState.IsValid)
                {
                    var EjeExist = _db.Actividad.Include(s => s.Eje).Where(s => s.EjeId == Id
                                      && s.EjeId == Id);


                    if (EjeExist.Count() > 0)
                    {
                        StatusMessage = "Error: Este Eje está siendo usado por la actividad " + EjeExist.First().Id +
                                " Primero debe editar o eliminar la actividad para poder eliminar este eje";
                    }
                    else
                    {
                        Eje oEje = _db.Eje.Where(e => e.Id == Id).First();
                        _db.Eje.Remove(oEje);
                        _db.SaveChanges();
                        StatusMessage = StatusMessage;
                    }
                }
           
            return RedirectToAction(nameof(Index));
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

        public FileResult exportar()
        {
            Utilitarios util = new Utilitarios();
            string[] cabeceras = { "Id Eje", "Nombre", "Category" };
            string[] nombrePropiedades = { "Id", "Name", "Category" };
            string titulo = "Reporte de Ejes";
            byte[] buffer = util.ExportarPDFDatos(nombrePropiedades, lista, titulo);
            return File(buffer, "application/pdf");
        }

    }
}