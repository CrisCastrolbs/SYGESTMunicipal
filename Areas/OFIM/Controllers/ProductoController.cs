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

    public class ProductoController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _hostEnvironment;
        [BindProperty]
        public ProductoViewModel ProductoVM { get; }
        public ProductoController(ApplicationDbContext db,
            IWebHostEnvironment hostEnvironment)
        {
            _db = db;
            _hostEnvironment = hostEnvironment;
            ProductoVM = new ProductoViewModel()
            {
                Clasificacion = _db.Clasificacion,
                Producto = new Models.Producto()
            };
        }
        public async Task<IActionResult> Index()
        {
            var Actividad =
            await _db.Producto.Include(m => m.Clasificacion).Include(m => m.Empresa).ToListAsync();
            return View(Actividad);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(string dato)
        {
            if (dato == null)
            {
                var Producto =
                await _db.Producto.Include(m => m.Clasificacion).Include(m => m.Empresa).ToListAsync();
                return View(Producto);
            }
            else
            {
                var proItem =
                     await _db.Producto.Where(p => p.Clasificacion.Name == dato)
                     .Include(p => p.Empresa).Include(c => c.Clasificacion).ToListAsync();

                return View(proItem);
            }
        }

        //GET - CREATE
        public IActionResult Create()
        {
            return View(ProductoVM);
        }
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePOST()
        {
           ProductoVM.Producto.EmpresaId = Convert.ToInt32(Request.Form["EmpresaId"].ToString());

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
                    ProductoVM.Producto.Imagen = p1;
                }
                _db.Producto.Add(ProductoVM.Producto);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ProductoVM.Producto);
        }
      

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ProductoVM.Producto = await _db.Producto.Include(m => m.Clasificacion).Include(m => m.Empresa).SingleOrDefaultAsync(m => m.Id == id);
            ProductoVM.Empresa = await _db.Empresa.Where(s => s.ClasificacionID == ProductoVM.Producto.ClasificacionID).ToListAsync();

            if (ProductoVM.Producto == null)
            {
                return NotFound();
            }
            return View(ProductoVM);
        }
    }
}
