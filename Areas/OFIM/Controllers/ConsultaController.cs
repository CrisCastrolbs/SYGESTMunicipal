using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SYGESTMunicipal.Areas.OFIM.Models.ViewModel;
using SYGESTMunicipal.Data;

namespace SYGESTMunicipal.Areas.OFIM.Controllers
{
    [Area("Admin")]
//    [Authorize(Roles = SD.ManagerUser)]
    public class ConsultaController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _hostEnvironment;
        [BindProperty]
        public ConsultaViewModel ConsultaVM { get; set; }
        public ConsultaController(ApplicationDbContext db,
            IWebHostEnvironment hostEnvironment)
        {
            _db = db;
            _hostEnvironment = hostEnvironment;
            ConsultaVM = new ConsultaViewModel()
            {
                PersonaOFIM = _db.PersonaOFIM,
                Consulta = new Models.Consulta()
            };
        }
        public async Task<IActionResult> Index()
        {
            var Consulta =
                await _db.Consulta.Include(m => m.PersonaOFIM).Include(m => m.TipoConsulta).ToListAsync();
            return View(Consulta);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(string dato)
        {
            if (dato == null)
            {
                var Consulta =
                await _db.Consulta.Include(m => m.PersonaOFIM).Include(m => m.TipoConsulta).ToListAsync();
                return View(Consulta);
            }
            else
            {
                var consult =
                     await _db.Consulta.Where(p => p.PersonaOFIM.PersonName == dato)
                     .Include(p => p.TipoConsulta).Include(c => c.PersonaOFIM).ToListAsync();

                return View(consult);
            }
        }

        //GET - CREATE
        public IActionResult Create()
        {
            return View(ConsultaVM);
        }
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePOST()
        {
            ConsultaVM.Consulta.TipoConsultaId = Convert.ToInt32(Request.Form["TipoConsultaId"].ToString());
            if (!ModelState.IsValid)
            {
                return View(ConsultaVM);
            }
            _db.Consulta.Add(ConsultaVM.Consulta);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        //GET - EDIT
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ConsultaVM.Consulta = await _db.Consulta.Include(m => m.PersonaOFIM).Include(m => m.TipoConsulta).SingleOrDefaultAsync(m => m.ConsultaId == id);
            ConsultaVM.TipoConsulta = await _db.TipoConsulta.Where(p => p.PersonaOFIMId == ConsultaVM.Consulta.PersonaOFIMId).ToListAsync();
            if (ConsultaVM.Consulta == null)
            {
                return NotFound();
            }
            return View(ConsultaVM);
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
            ConsultaVM.Consulta.TipoConsultaId = Convert.ToInt32(Request.Form["TipoConsultaId"].ToString());
            if (!ModelState.IsValid)
            {
                ConsultaVM.TipoConsulta = await _db.TipoConsulta.Where(p => p.PersonaOFIMId == ConsultaVM.Consulta.PersonaOFIMId).ToListAsync();
                return View(ConsultaVM);
            }
            var consultaFromDb = await _db.Consulta.FindAsync(ConsultaVM.Consulta.ConsultaId);

            consultaFromDb.HoraInicio= ConsultaVM.Consulta.HoraInicio;
            consultaFromDb.Fecha = ConsultaVM.Consulta.Fecha;
            consultaFromDb.PersonaOFIMId = ConsultaVM.Consulta.PersonaOFIMId;
            consultaFromDb.TipoConsultaId = ConsultaVM.Consulta.TipoConsultaId;
            consultaFromDb.Motivo = ConsultaVM.Consulta.Motivo;
            consultaFromDb.Descripcion = ConsultaVM.Consulta.Descripcion;
            consultaFromDb.RespuestaOfrecida = ConsultaVM.Consulta.RespuestaOfrecida;
            consultaFromDb.HoraFin = ConsultaVM.Consulta.HoraFin;
            
          
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
            ConsultaVM.Consulta = await _db.Consulta.Include(m => m.PersonaOFIM).Include(m => m.TipoConsulta).SingleOrDefaultAsync(m => m.ConsultaId == id);
            ConsultaVM.TipoConsulta = await _db.TipoConsulta.Where(s => s.PersonaOFIMId == ConsultaVM.Consulta.PersonaOFIMId).ToListAsync();
            if (ConsultaVM.Consulta == null)
            {
                return NotFound();
            }
            return View(ConsultaVM);
        }

        //GET - DELETE
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ConsultaVM.Consulta = await _db.Consulta.Include(m => m.PersonaOFIM).Include(m => m.TipoConsulta).SingleOrDefaultAsync(m => m.ConsultaId == id);
            ConsultaVM.TipoConsulta = await _db.TipoConsulta.Where(s => s.PersonaOFIMId == ConsultaVM.Consulta.PersonaOFIMId).ToListAsync();
            if (ConsultaVM.Consulta == null)
            {
                return NotFound();
            }
            return View(ConsultaVM);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePOST(int? id)
        {
            var productDelete = await _db.Consulta.FindAsync(id);
            if (productDelete == null)
            {
                return View();
            }
            _db.Consulta.Remove(productDelete);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> OnGetAsync(string searchString)
        {
            var p = from m in _db.Consulta
                    select m;
            if (!String.IsNullOrEmpty(searchString))
            {
                p = p.Where(s => s.PersonaOFIM.PersonName.Contains(searchString));
            }
            var P = await p.ToListAsync();
            return View("Index", P);
        }
    }
}