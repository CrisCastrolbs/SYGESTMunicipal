using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SYGESTMunicipal.Areas.PATENTES.Models;
using SYGESTMunicipal.Areas.PATENTES.Models.ViewModel;
using SYGESTMunicipal.Data;

namespace SYGESTMunicipal.Areas.PATENTES.Controllers
{
    [Area("Patentes")]
    public class EstablishmentController : Controller
    {
        private readonly ApplicationDbContext _db;
        List<EstablishmentViewModel> listaEstablishment = new List<EstablishmentViewModel>();
        static List<EstablishmentViewModel> lista = new List<EstablishmentViewModel>();

        public EstablishmentController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            listaEstablishment = (from establishment in _db.Establishment

                                  join ciiu in _db.CIIU
                                  on establishment.CIIUId equals
                                  ciiu.CIIUId

                                  join applicant in _db.Applicant
                                  on establishment.ApplicantId equals
                                  applicant.ApplicantId

                                  join establishmenttype in _db.EstablishmentType
                                  on establishment.EstablishmentTypeId equals
                                  establishmenttype.EstablishmentTypeId

                                  join activitytype in _db.ActivityType
                                  on establishment.ActivityTypeId equals
                                  activitytype.ActivityTypeId
                                  select new EstablishmentViewModel
                                  {
                                      Id = establishment.Id,
                                      Name = establishment.Name,
                                      CIIUId = ciiu.CIIUId,
                                      CIIUName = ciiu.Name,
                                      Description = establishment.Description,
                                      OtherActivities = establishment.OtherActivities,
                                      NFarm = establishment.NFarm,
                                      DesignNum = establishment.DesignNum,
                                      WorkingHours = establishment.WorkingHours,
                                      WMen = establishment.WMen,
                                      WWomen = establishment.WWomen,
                                      ApplicantId = applicant.ApplicantId,
                                      ApplicantName = applicant.Name,
                                      WebPage = establishment.WebPage,
                                      SkilledWorkers = establishment.SkilledWorkers,
                                      UnskilledWorkers = establishment.UnskilledWorkers,
                                      EstablishmentTypeId = establishmenttype.EstablishmentTypeId,
                                      EstablishmentTypeName = establishmenttype.Name

                                  }).ToList();
            ViewBag.Controlador = "Establishment";
            ViewBag.Accion = "Index";
            return View(listaEstablishment);
        }

        private void cargarCIIU()
        {
            List<SelectListItem> listaCIIU = new List<SelectListItem>();
            listaCIIU = (from ciiu in _db.CIIU
                         orderby ciiu.Name
                         select new SelectListItem
                         {
                             Text = ciiu.Name,
                             Value = ciiu.CIIUId.ToString()
                         }
                                   ).ToList();
            ViewBag.ListaCIIU = listaCIIU;
        }

        private void cargarApplicant()
        {
            List<SelectListItem> listaCIIU = new List<SelectListItem>();
            listaCIIU = (from applicant in _db.Applicant
                         orderby applicant.Name
                         select new SelectListItem
                         {
                             Text = applicant.Name,
                             Value = applicant.ApplicantId.ToString()
                         }
                                   ).ToList();
            ViewBag.ListaApplicant = listaCIIU;
        }

        private void cargarEstablishmentType()
        {
            List<SelectListItem> listaCIIU = new List<SelectListItem>();
            listaCIIU = (from establishmenttype in _db.EstablishmentType
                         orderby establishmenttype.Name
                         select new SelectListItem
                         {
                             Text = establishmenttype.Name,
                             Value = establishmenttype.EstablishmentTypeId.ToString()
                         }
                                   ).ToList();
            ViewBag.ListaEstablishmentType = listaCIIU;
        }

        private void cargarActivityTipe()
        {
            List<SelectListItem> listaCIIU = new List<SelectListItem>();
            listaCIIU = (from activitytipe in _db.ActivityType
                         orderby activitytipe.Name
                         select new SelectListItem
                         {
                             Text = activitytipe.Name,
                             Value = activitytipe.ActivityTypeId.ToString()
                         }
                                   ).ToList();
            ViewBag.ListaActivityType = listaCIIU;
        }
        public IActionResult Create()
        {
            cargarCIIU();
            cargarApplicant();
            cargarEstablishmentType();
            cargarActivityTipe();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Establishment establishment)
        {
            int nVeces = 0;

            try
            {
                nVeces = _db.Establishment.Where(m => m.Id == establishment.Id).Count();
                if (!ModelState.IsValid || nVeces >= 1)
                {
                    if (nVeces >= 1) ViewBag.Error = "Este id ya existe!";
                    cargarCIIU();
                    cargarApplicant();
                    cargarEstablishmentType();
                    cargarActivityTipe();
                    return View(establishment);
                }
                else
                {
                    Establishment _establishment = new Establishment();
                    // _establishment.Id = establishment.Id;
                    _establishment.Name = establishment.Name;
                    _establishment.CIIUId = establishment.CIIUId;
                    _establishment.Description = establishment.Description;
                    _establishment.OtherActivities = establishment.OtherActivities;
                    _establishment.NFarm = establishment.NFarm;
                    _establishment.DesignNum = establishment.DesignNum;
                    _establishment.WorkingHours = establishment.WorkingHours;
                    _establishment.WMen = establishment.WMen;
                    _establishment.WWomen = establishment.WWomen;
                    _establishment.ApplicantId = establishment.ApplicantId;
                    _establishment.WebPage = establishment.WebPage;
                    _establishment.SkilledWorkers = establishment.SkilledWorkers;
                    _establishment.UnskilledWorkers = establishment.UnskilledWorkers;
                    _establishment.EstablishmentTypeId = establishment.EstablishmentTypeId;
                    _establishment.ActivityTypeId = establishment.ActivityTypeId;
                    _db.Establishment.Add(_establishment);
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
            cargarCIIU();
            cargarApplicant();
            cargarEstablishmentType();
            cargarActivityTipe();
            int recCount = _db.Establishment.Count(e => e.Id == id);
            Establishment _establishment = (from p in _db.Establishment
                                            where p.Id == id
                                            select p).DefaultIfEmpty().Single();
            return View(_establishment);
        }
        [HttpPost]
        public IActionResult Edit(Establishment establishment)
        {
            string error = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    cargarCIIU();
                    cargarApplicant();
                    cargarEstablishmentType();
                    cargarActivityTipe();
                    return View(establishment);
                }
                else
                {
                    _db.Establishment.Update(establishment);
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
            cargarCIIU();
            cargarApplicant();
            cargarEstablishmentType();
            cargarActivityTipe();
            Establishment oEstablishment = _db.Establishment
                       .Where(e => e.Id == id).First();
            return View(oEstablishment);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();

            }
            var establishment = await _db.Establishment.FindAsync(id);
            if (establishment == null)
            {
                return NotFound();

            }
            return View(establishment);
        }
        //POST - DELETE    //si se realiza una operacion es un POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var establishment = await _db.Establishment.FindAsync(id);
            if (establishment == null)
            {
                return View();
            }
            _db.Establishment.Remove(establishment);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        //private void BuscarEstablishment(int? EstablismentId)
        //{
        //    Establishment oPersona = _db.Establishment
        //   .Where(p => p.Id == EstablismentId).FirstOrDefault();
        //    if (oPersona != null)
        //    {
        //        ViewBag.EstablishmentId = oPersona.Id;
        //        ViewBag.Nombre = oPersona.Name;

        //    }
        //    else
        //    {
        //        ViewBag.Error = "Establecimiento no registrado, intente de nuevo!";
        //    }
        //}

        //private void buscarEstablishment(int? EstablishmentId)
        //{
        //    listaEstablishment = (from establishment in _db.Establishment

        //                          join ciiu in _db.CIIU
        //                          on establishment.CIIUId equals
        //                          ciiu.CIIUId where establishment.Id== EstablishmentId

        //                          join applicant in _db.Applicant
        //                          on establishment.ApplicantId equals
        //                          applicant.ApplicantId
        //                          where establishment.Id == EstablishmentId

        //                          join establishmenttype in _db.EstablishmentType
        //                          on establishment.EstablishmentTypeId equals
        //                          establishmenttype.EstablishmentTypeId
        //                          where establishment.Id == EstablishmentId

        //                          join activitytype in _db.ActivityType
        //                          on establishment.ActivityTypeId equals
        //                          activitytype.ActivityTypeId
        //                          where establishment.Id == EstablishmentId
        //                          select new EstablishmentViewModel
        //                          {
        //                              Id = establishment.Id,
        //                              Name = establishment.Name,
        //                              CIIUId = ciiu.CIIUId,
        //                              CIIUName = ciiu.Name,
        //                              Description = establishment.Description,
        //                              OtherActivities = establishment.OtherActivities,
        //                              NFarm = establishment.NFarm,
        //                              DesignNum = establishment.DesignNum,
        //                              WorkingHours = establishment.WorkingHours,
        //                              WMen = establishment.WMen,
        //                              WWomen = establishment.WWomen,
        //                              ApplicantId = applicant.ApplicantId,
        //                              ApplicantName = applicant.Name,
        //                              WebPage = establishment.WebPage,
        //                              SkilledWorkers = establishment.SkilledWorkers,
        //                              UnskilledWorkers = establishment.UnskilledWorkers,
        //                              EstablishmentTypeId = establishmenttype.EstablishmentTypeId,
        //                              EstablishmentTypeName = establishmenttype.Name

        //                          }).ToList();
        //}


    }
}
