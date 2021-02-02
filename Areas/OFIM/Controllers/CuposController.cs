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
    public class CuposController : Controller
    {
        private readonly ApplicationDbContext _db;
        List<CuposActividad> listaCupos = new List<CuposActividad>();
        static List<CuposActividad> lista = new List<CuposActividad>();
        public CuposController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            listaCupos = (from cupos in _db.Cupos
                          join actividad in _db.Actividad
                          on cupos.ActividadId equals
                          actividad.Id
                          select new CuposActividad
                          {
                              Id = cupos.Id,
                              Descripcion = cupos.Descripcion.Length > 50 ?
                                               cupos.Descripcion.Substring(0, 50)
                                               + "..." : cupos.Descripcion,
                              CupoMax = cupos.CupoMax,
                              IsActive = cupos.IsActive,
                              ActividadId = cupos.ActividadId,
                              Actividad = actividad.Name
                          }).ToList();
            lista = listaCupos;
            return View(listaCupos);
        }

        private void cargarActividades()
        {
            List<SelectListItem> listaActividades = new List<SelectListItem>();
            listaActividades = (from actividad in _db.Actividad
                                orderby actividad.Name
                                select new SelectListItem
                                {
                                    Text = actividad.Category.Name + " " + actividad.Name,
                                    Value = actividad.Id.ToString()
                                }
                                   ).ToList();
            ViewBag.ListaActividades = listaActividades;
        }

        [HttpGet]
        public IActionResult Create()
        {
            cargarActividades();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Cupos cupos)
        {
            string Error = "";
            try
            {
                
                if (ModelState.IsValid)
                {
                    var CuposExist = _db.Cupos.Include(s => s.Actividad).Where(s => s.ActividadId
                                         == cupos.ActividadId
                                         && s.ActividadId == cupos.ActividadId);
                    if (CuposExist.Count() >= 1)
                    {
                        ViewBag.msgError = "Error: Este cupo ya ha sido ingresado para la Actividad " + CuposExist.First().Actividad.Name +
                           " Por favor, use la existente, o cree otra diferente";
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

                        _db.Cupos.Add(_cupos);
                        _db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            cargarActividades();
            int recCount = _db.Cupos.Count(e => e.Id == id);
            Cupos _cupos = (from p in _db.Cupos
                            where p.Id == id
                            select p).DefaultIfEmpty().Single();
            return View(_cupos);
        }

        [HttpPost]
        public IActionResult Edit(Cupos cupos)
        {
            string error = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    cargarActividades();
                    return View(cupos);
                }
                else
                {
                    _db.Cupos.Update(cupos);
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
            cargarActividades();
            Cupos oCupos = _db.Cupos
                 .Where(m => m.Id == id).First();
            return View(oCupos);
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
    }

}