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
    public class MaterialTypeController : Controller
    {
        private readonly ApplicationDbContext _db;
        List<MaterialType> listaMaterial = new List<MaterialType>();
        static List<MaterialType> lista = new List<MaterialType>();

        public MaterialTypeController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            listaMaterial = (from materialsType in _db.MaterialType
                            select new MaterialType
                            {
                                MaterialTypeId = materialsType.MaterialTypeId,
                                MaterialTypeName = materialsType.MaterialTypeName,
                                Description = materialsType.Description.Substring(0, 85) + "..."
                            }).ToList();
            lista = listaMaterial;
            return View(listaMaterial);
        }
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(MaterialType materialType)
        {
            int nVeces = 0;
            string Error = "";
            try
            {
                nVeces = _db.MaterialType.Where(e =>
                                       e.MaterialTypeName == materialType.MaterialTypeName).Count();

                if (!ModelState.IsValid || nVeces >= 1)
                {
                    if (nVeces > 1) ViewBag.msgError = "El nombre de la persona" +
                              " ya está registrado";

                    return View(materialType);
                }
                else
                {
                    _db.MaterialType.Add(materialType);
                    _db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            MaterialType oMaterialType = _db.MaterialType
                .Where(e => e.MaterialTypeId == id).First();
            return View(oMaterialType);
        }
        [HttpPost]
        public IActionResult Edit(MaterialType materialType)
        {
            string error = "";
            try
            {
                if (!ModelState.IsValid)
                {
                   
                    return View(materialType);
                }
                else
                {
                    _db.MaterialType.Update(materialType);
                    _db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();

            }
            var category = await _db.MaterialType.FindAsync(id);
            if (category == null)
            {
                return NotFound();

            }
            return View(category);
        }
        //POST - DELETE    //si se realiza una operacion es un POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var category = await _db.MaterialType.FindAsync(id);
            if (category == null)
            {
                return View();
            }
            _db.MaterialType.Remove(category);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Details(int id)
        {
            MaterialType oEspecialidad = _db.MaterialType
                       .Where(e => e.MaterialTypeId == id).First();
            return View(oEspecialidad);
        }
    }
}
