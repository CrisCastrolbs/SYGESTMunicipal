using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SYGESTMunicipal.Areas.OFGA.Models;
using SYGESTMunicipal.Areas.OFGA.Models.ViewModel;
using SYGESTMunicipal.Data;
using SYGESTMunicipal.Utility;

namespace SYGESTMunicipal.Areas.OFGA.Controllers
{
    [Area("OFGA")]

    public class MaterialsController : Controller
    {
        private readonly ApplicationDbContext _db;
        List<MaterialsViewModel> listaMateriales = new List<MaterialsViewModel>();
        static List<MaterialsViewModel> lista = new List<MaterialsViewModel>();
        public MaterialsController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            listaMateriales = (from materials in _db.Materials
                           join materialType in _db.MaterialType
                           on materials.MaterialTypeId equals 
                           materialType.MaterialTypeId
                           select new MaterialsViewModel
                           {

                               Id = materials.Id,
                               Name = materials.Name,
                               Date = materials.Date,
                               Weight = materials.Weight,
                               Color = materials.Color,
                               
                               MaterialTypeId = materials.MaterialTypeId,
                              
                           }).ToList();
            lista = listaMateriales;
            return View(listaMateriales);
        }
        private void cargarMaterialType()
        {
            List<SelectListItem> listaMaterial = new List<SelectListItem>();
            listaMaterial = (from ciiu in _db.MaterialType
                         orderby ciiu.MaterialTypeName
                         select new SelectListItem
                         {
                             Text = ciiu.MaterialTypeName,
                             Value = ciiu.MaterialTypeId.ToString()
                         }
                                   ).ToList();
            ViewBag.ListaTMaterial = listaMaterial;
        }
        public IActionResult Create()
        {
            cargarMaterialType();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Materials materials)
        {
            int nVeces = 0;

            try
            {
                nVeces = _db.Materials.Where(m => m.Id == materials.Id).Count();
                if (!ModelState.IsValid || nVeces >= 1)
                {
                    if (nVeces >= 1) ViewBag.Error = "Este id ya existe!";

                    cargarMaterialType();
                    return View(materials);
                }
                else
                {
                    Materials _materials = new Materials();
                    _materials.Id = materials.Id;
                    _materials.Name = materials.Name;
                    _materials.Date = materials.Date;
                    _materials.Weight = materials.Weight;
                    _materials.Color = materials.Color;
                    _materials.MaterialTypeId = materials.MaterialTypeId;
                    
                    _db.Materials.Add(_materials);
                    _db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int? id)
        {
            cargarMaterialType();
            int recCount = _db.Materials.Count(e => e.Id == id);
            Materials _materials = (from p in _db.Materials
                                            where p.Id == id
                                            select p).DefaultIfEmpty().Single();
            return View(_materials);
        }
        [HttpPost]
        public IActionResult Edit(Materials materials)
        {
            string error = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    
                    return View(materials);
                }
                else
                {
                    _db.Materials.Update(materials);
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
            cargarMaterialType();
            Materials oMaterials = _db.Materials
                       .Where(e => e.Id == id).First();
            return View(oMaterials);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();

            }
            var materials = await _db.Materials.FindAsync(id);
            if (materials == null)
            {
                return NotFound();

            }
            return View(materials);
        }
        //POST - DELETE    //si se realiza una operacion es un POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var materials = await _db.Materials.FindAsync(id);
            if (materials == null)
            {
                return View();
            }
            _db.Materials.Remove(materials);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
