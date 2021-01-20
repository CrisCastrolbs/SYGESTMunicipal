using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SYGESTMunicipal.Areas.OFIM.Models;
using SYGESTMunicipal.Areas.OFIM.Models.ViewModel;
using SYGESTMunicipal.Data;

namespace SYGESTMunicipal.Areas.OFIM.Controllers
{
    [Area("OFIM")]
    public class CuposController : Controller
    {
        private readonly ApplicationDbContext _db;
        List<CupoAndActividadViewModel> listaCupos = new List<CupoAndActividadViewModel>();
        static List<CupoAndActividadViewModel> lista = new List<CupoAndActividadViewModel>();

        public CuposController(ApplicationDbContext db)
        {
            _db = db;
        }

        public List<CupoAndActividadViewModel> BuscarCuposActividad(string nombreActividad)
        {
            List<CupoAndActividadViewModel> listaCupoActividad = new List<CupoAndActividadViewModel>();
            if (nombreActividad == null || nombreActividad.Length == 0)
            {
                listaCupos = (from cupos in _db.Cupos
                               join actividad in _db.Actividad
                               on cupos.ActividadId equals actividad.Id
                              select new CupoAndActividadViewModel
                               {
                                   Id = cupos.Id,
                                   Descripcion = cupos.Descripcion.Length > 50 ?
                                               cupos.Descripcion.Substring(0, 50)
                                               + "..." : cupos.Descripcion,
                                   CupoMax = cupos.CupoMax,
                                   IsActive = cupos.IsActive,
                                   Actividad = actividad.Name
                               }).ToList();
                ViewBag.Actividad = "";
            }
            else
            {
                listaCupos = (from cupos in _db.Cupos
                               join actividad in _db.Actividad
                               on cupos.ActividadId equals actividad.Id
                               where actividad.Name.Contains(nombreActividad)
                               select new CupoAndActividadViewModel
                               {
                                   Id = cupos.Id,
                                   Descripcion = cupos.Descripcion.Length > 50 ?
                                               cupos.Descripcion.Substring(0, 50)
                                               + "..." : cupos.Descripcion,
                                   CupoMax = cupos.CupoMax,
                                   IsActive = cupos.IsActive,
                                   Actividad = actividad.Name
                               }).ToList();
                ViewBag.Actividad = nombreActividad;
            }
            lista = listaCupos;
            return listaCupos;
        }

        public IActionResult Index()
        {
            listaCupos = BuscarCuposActividad("");
            return View(listaCupos);
            

        }
        [HttpPost]
        public IActionResult Delete(int? Id)
        {
            string Error = "";
            try
            {
                Cupos oCupos = _db.Cupos
                     .Where(m => m.Id == Id).First();
                _db.Cupos.Remove(oCupos);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }
            return RedirectToAction(nameof(Index));
        }
        private void cargarActividades()
        {
            List<SelectListItem> listaActividades = new List<SelectListItem>();
            listaActividades = (from actividad in _db.Actividad
                                   orderby actividad.Name
                                   select new SelectListItem
                                   {
                                       Text = actividad.Name,
                                       Value = actividad.Id.ToString()
                                   }
                                   ).ToList();
            ViewBag.ListaActividades = listaActividades;
        }
        public IActionResult Create()
        {
            cargarActividades();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Cupos cupos)
        {
            int CupoExist = 0;
            string Error = "";
            try
            {
               
                CupoExist = _db.Cupos.Include(s => s.Actividad).Where(s => s.ActividadId == cupos.ActividadId).Count();

                if (!ModelState.IsValid || CupoExist >= 1)
                {
                    if (CupoExist > 1) ViewBag.msgError = "Error!: " +
                            "Este Cupo ya ha sido creado para la actividad ";
                    cargarActividades();
                    return View(cupos);
                }
                else
                {
                    Cupos _cupos = new Cupos();
                    _cupos.Id = cupos.Id;
                    _cupos.Descripcion = cupos.Descripcion;
                    _cupos.CupoMax = cupos.CupoMax;
                    _cupos.IsActive = cupos.IsActive;

                    _cupos.ActividadId = cupos.ActividadId;
                    _db.Cupos.Add(cupos);
                    _db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }
            return RedirectToAction(nameof(Index));
        }



        //public IActionResult Edit(string id)
        //{
        //    cargarEspecialidades();
        //    int recCount = _db.Medico.Count(e => e.MedicoId == id);
        //    Medico _medico = (from p in _db.Medico
        //                      where p.MedicoId.Trim() == id.Trim()
        //                      select p).DefaultIfEmpty().Single();
        //    return View(_medico);
        //}
        //[HttpPost]
        //public IActionResult Edit(Medico medico)
        //{
        //    string error = "";
        //    try
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            cargarEspecialidades();
        //            return View(medico);
        //        }
        //        else
        //        {
        //            _db.Medico.Update(medico);
        //            _db.SaveChanges();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        error = ex.Message;
        //    }
        //    return RedirectToAction(nameof(Index));
        //}

        //public IActionResult Details(int id)
        //{
        //    cargarEspecialidades();
        //    Medico oMedico = _db.Medico
        //         .Where(m => m.MedicoId == id.ToString()).First();
        //    return View(oMedico);
        //}
    }
}
