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
        List<TipoConsultaAndPersonaViewModel> listaTipoConsultas = new List<TipoConsultaAndPersonaViewModel>();
        static List<TipoConsultaAndPersonaViewModel> lista = new List<TipoConsultaAndPersonaViewModel>();
        public TipoConsultaController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            listaTipoConsultas = (from tipoConsulta in _db.TipoConsulta
                               join personaOFIM in _db.PersonaOFIM
                               on tipoConsulta.PersonaOFIMId equals
                               personaOFIM.PersonaOFIMId
                               select new TipoConsultaAndPersonaViewModel
                               {

                                   TipoConsultaId = tipoConsulta.TipoConsultaId,
                                   NombreTipoConsulta = tipoConsulta.NombreTipoConsulta,
                                   PersonaOFIMId = tipoConsulta.PersonaOFIMId,
                                   PersonaOFIM = personaOFIM.PersonName
                               }).ToList();
            lista = listaTipoConsultas;
            return View(listaTipoConsultas);
        }
        private void cargarPersonaOFIM()
        {
            List<SelectListItem> listaTipoConsulta = new List<SelectListItem>();
            listaTipoConsulta = (from ciiu in _db.PersonaOFIM
                             orderby ciiu.PersonName
                             select new SelectListItem
                             {
                                 Text = ciiu.PersonName,
                                 Value = ciiu.PersonaOFIMId.ToString()
                             }
                                   ).ToList();
            ViewBag.ListaConsulta = listaTipoConsulta;
        }
        public IActionResult Create()
        {
            cargarPersonaOFIM();
            return View();
        }
        [HttpPost]
        public IActionResult Create(TipoConsultaAndPersonaViewModel tipoConsulta)
        {
            int nVeces = 0;
            try
            {
                nVeces = _db.TipoConsulta.Where(m => m.TipoConsultaId == tipoConsulta.TipoConsultaId).Count();

                if (ModelState.IsValid)
                {
                    var TipoConExist = _db.TipoConsulta.Include(s => s.PersonaOFIM).Where(s => s.NombreTipoConsulta
                                         == tipoConsulta.NombreTipoConsulta
                                         && s.PersonaOFIMId == tipoConsulta.PersonaOFIMId);
                    if (TipoConExist.Count() > 0 || nVeces >= 1)
                    {
                        ViewBag.Error = "Error: Este tipo consulta ya ha sido creada para la Persona " + TipoConExist.First().PersonaOFIM.PersonName +
                           " Por favor, use la existente, o cree otra diferente";
                        cargarPersonaOFIM();
                        return View(tipoConsulta);
                    }
                    else
                    {
                        TipoConsulta _tipoConsulta = new TipoConsulta();
                        _tipoConsulta.TipoConsultaId = tipoConsulta.TipoConsultaId;
                        _tipoConsulta.NombreTipoConsulta = tipoConsulta.NombreTipoConsulta;
                        _tipoConsulta.PersonaOFIMId = tipoConsulta.PersonaOFIMId;

                        _db.TipoConsulta.Add(_tipoConsulta);
                        _db.SaveChanges();
                    }
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
            cargarPersonaOFIM();
            int recCount = _db.TipoConsulta.Count(e => e.TipoConsultaId == id);
            TipoConsulta _tipoConsulta = (from p in _db.TipoConsulta
                                    where p.TipoConsultaId == id
                                    select p).DefaultIfEmpty().Single();
            return View(_tipoConsulta);
        }
        [HttpPost]
        public IActionResult Edit(TipoConsulta tipoConsulta)
        {
            string error = "";
            try
            {
                if (!ModelState.IsValid)
                {

                    return View(tipoConsulta);
                }
                else
                {
                    _db.TipoConsulta.Update(tipoConsulta);
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
            cargarPersonaOFIM();
            TipoConsulta oTipoConsulta = _db.TipoConsulta
                       .Where(e => e.TipoConsultaId == id).First();
            return View(oTipoConsulta);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();

            }
            var tipoConsulta = await _db.TipoConsulta.FindAsync(id);
            if (tipoConsulta == null)
            {
                return NotFound();

            }
            return View(tipoConsulta);
        }
        //POST - DELETE    //si se realiza una operacion es un POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var tipoConsulta = await _db.TipoConsulta.FindAsync(id);
            if (tipoConsulta == null)
            {
                return View();
            }
            _db.TipoConsulta.Remove(tipoConsulta);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
