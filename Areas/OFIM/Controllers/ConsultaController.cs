using SYGESTMunicipal.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
    //    [Authorize(Roles = SD.ManagerUser)]
    public class ConsultaController : Controller
    {
        private readonly ApplicationDbContext _db;
        List<ConsultaViewModel> listaConsulta = new List<ConsultaViewModel>();
        static List<ConsultaViewModel> lista = new List<ConsultaViewModel>();

        public ConsultaController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            if (User.IsInRole(SD.ManagerUser) || User.IsInRole(SD.AdminOFIM) || User.IsInRole(SD.RedUser))
            {
                listaConsulta = (from consulta in _db.Consulta

                                 join personaOFIM in _db.PersonaOFIM
                                 on consulta.PersonaOFIMId equals
                                 personaOFIM.PersonaOFIMId

                                 join tipoConsulta in _db.TipoConsulta
                                 on consulta.TipoConsultaId equals
                                 tipoConsulta.TipoConsultaId

                                 select new ConsultaViewModel
                                 {
                                     ConsultaId = consulta.ConsultaId,
                                     Motivo = consulta.Motivo,
                                     PersonaOFIMId = personaOFIM.PersonaOFIMId,
                                     PersonName = personaOFIM.PersonName,
                                     TipoConsultaId = consulta.TipoConsultaId,
                                     NombreTipoConsulta = tipoConsulta.NombreTipoConsulta,
                                     Fecha = consulta.Fecha,
                                     HoraInicio = consulta.HoraInicio.Value,
                                     HoraFin = consulta.HoraFin.Value,
                                     Descripcion = consulta.Descripcion,
                                     RespuestaOfrecida = consulta.RespuestaOfrecida,
                                     //IsActive = consulta.IsActive
                                 }).ToList();
                ViewBag.Controlador = "Consulta";
                ViewBag.Accion = "Index";


                if (User.IsInRole(SD.RedUser))
                {
                    listaConsulta = (from consulta in _db.Consulta
                                     where consulta.Remitir == true

                                     join personaOFIM in _db.PersonaOFIM
                                     on consulta.PersonaOFIMId equals
                                     personaOFIM.PersonaOFIMId

                                     join tipoConsulta in _db.TipoConsulta
                                     on consulta.TipoConsultaId equals
                                     tipoConsulta.TipoConsultaId

                                     select new ConsultaViewModel
                                     {
                                         ConsultaId = consulta.ConsultaId,
                                         Motivo = consulta.Motivo,
                                         PersonaOFIMId = personaOFIM.PersonaOFIMId,
                                         PersonName = personaOFIM.PersonName,
                                         TipoConsultaId = consulta.TipoConsultaId,
                                         Remitir = consulta.Remitir,
                                         NombreTipoConsulta = tipoConsulta.NombreTipoConsulta,
                                         Fecha = consulta.Fecha,
                                         HoraInicio = consulta.HoraInicio.Value,
                                         HoraFin = consulta.HoraFin.Value,
                                         Descripcion = consulta.Descripcion,
                                         RespuestaOfrecida = consulta.RespuestaOfrecida,

                                     }).ToList();
                    ViewBag.Controlador = "Consulta";
                    ViewBag.Accion = "Index";

                }
            }
             
            return View(listaConsulta);
        }

        private void cargarPersonaOFIM()
        {
            List<SelectListItem> listaPersonaOFIM = new List<SelectListItem>();
            listaPersonaOFIM = (from personaOFIM in _db.PersonaOFIM
                                orderby personaOFIM.PersonName
                                select new SelectListItem
                                {
                                    Text = personaOFIM.PersonName + " " + personaOFIM.LatName1,
                                    Value = personaOFIM.PersonaOFIMId.ToString()
                                }
                                   ).ToList();
            ViewBag.ListaPersonaOFIM = listaPersonaOFIM;
        }

        private void cargarTipoConsulta()
        {
            List<SelectListItem> listaTipoConsulta = new List<SelectListItem>();
            listaTipoConsulta = (from tipoConsulta in _db.TipoConsulta
                                 orderby tipoConsulta.NombreTipoConsulta
                                 select new SelectListItem
                                 {
                                     Text = tipoConsulta.NombreTipoConsulta,
                                     Value = tipoConsulta.TipoConsultaId.ToString()
                                 }
                                   ).ToList();
            ViewBag.ListaTipoConsulta = listaTipoConsulta;
        }
        public IActionResult Create()
        {
            cargarPersonaOFIM();
            cargarTipoConsulta();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Consulta consulta)
        {
            int nVeces = 0;

            try
            {
                nVeces = _db.Consulta.Where(m => m.ConsultaId == consulta.ConsultaId).Count();
                if (!ModelState.IsValid || nVeces >= 1)
                {
                    if (nVeces >= 1) ViewBag.Error = "Este id ya existe!";
                    cargarPersonaOFIM();
                    cargarTipoConsulta();
                    return View(consulta);
                }
                else
                {
                    Consulta _consulta = new Consulta();
                    // _consulta.Id = consulta.Id;
                    _consulta.Motivo = consulta.Motivo;
                    _consulta.PersonaOFIMId = consulta.PersonaOFIMId;
                    _consulta.TipoConsultaId = consulta.TipoConsultaId;
                    _consulta.Fecha = consulta.Fecha;
                    _consulta.HoraInicio = consulta.HoraInicio;
                    _consulta.HoraFin = consulta.HoraFin;
                    _consulta.Descripcion = consulta.Descripcion;
                    _consulta.Remitir = consulta.Remitir;
                    _consulta.RespuestaOfrecida = consulta.RespuestaOfrecida;
                    _db.Consulta.Add(_consulta);
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
            cargarPersonaOFIM();
            cargarTipoConsulta();
            int recCount = _db.Consulta.Count(e => e.ConsultaId == id);
            Consulta _consulta = (from p in _db.Consulta
                                  where p.ConsultaId == id
                                  select p).DefaultIfEmpty().Single();
            return View(_consulta);
        }
        [HttpPost]
        public IActionResult Edit(Consulta consulta)
        {
            string error = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    cargarPersonaOFIM();
                    cargarTipoConsulta();
                    return View(consulta);
                }
                else
                {
                    _db.Consulta.Update(consulta);
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
            cargarTipoConsulta();
            Consulta oConsulta = _db.Consulta
                       .Where(e => e.ConsultaId == id).First();
            return View(oConsulta);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();

            }
            var consulta = await _db.Consulta.FindAsync(id);
            if (consulta == null)
            {
                return NotFound();

            }
            return View(consulta);
        }
        //POST - DELETE    //si se realiza una operacion es un POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var consulta = await _db.Consulta.FindAsync(id);
            if (consulta == null)
            {
                return View();
            }
            _db.Consulta.Remove(consulta);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

       

    }
}

