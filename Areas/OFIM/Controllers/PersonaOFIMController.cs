using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SYGESTMunicipal.Areas.OFIM.Models;
using SYGESTMunicipal.Areas.OFIM.Models.ViewModel;
using SYGESTMunicipal.Data;

namespace SYGESTMunicipal.Areas.OFIM.Controllers
{
    [Area("OFIM")]
    public class PersonaOFIMController : Controller
    {
        private readonly ApplicationDbContext _db;
        List<DatosPersonaViewModel> listaPersonas = new List<DatosPersonaViewModel>();
        static List<DatosPersonaViewModel> lista = new List<DatosPersonaViewModel>();
        public PersonaOFIMController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            listaPersonas = (from personaOFIM in _db.PersonaOFIM
                             join estadoCivil in _db.EstadoCivil
                           on personaOFIM.EstadoCivilId equals
                           estadoCivil.EstadoCivilId

                             join nacionalidad in _db.Nacionalidad
                             on personaOFIM.NacionalidadId equals
                             nacionalidad.Id

                             join nivelAcademico in _db.NivelAcademico
                             on personaOFIM.NivelAcademicoId equals
                             nivelAcademico.Id

                             join ocupacion in _db.Ocupacion
                             on personaOFIM.OcupacionId equals
                             ocupacion.Id

                             join seguro in _db.Seguro
                             on personaOFIM.SeguroId equals
                             seguro.Id

                             select new DatosPersonaViewModel
                             {
                                 PersonaOFIMId = personaOFIM.PersonaOFIMId,
                                 PersonName = personaOFIM.PersonName + " " +
                            personaOFIM.LatName1 + " " +
                            personaOFIM.LatName2,
                                 Address = personaOFIM.Address,
                                 Province = personaOFIM.Province,
                                 Canton = personaOFIM.Canton,
                                 District = personaOFIM.District,
                                 TelephoneNumber = personaOFIM.TelephoneNumber,
                                 MobilePhoneNumber = personaOFIM.MobilePhoneNumber,
                                 Email = personaOFIM.Email,
                                 Sex = personaOFIM.Sex,
                                 DateBirth = personaOFIM.DateBirth,
                                 CoupleName = personaOFIM.CoupleName,
                                 ChildNumber = personaOFIM.ChildNumber,
                                 Disability = personaOFIM.Disability,
                                 MedicalCondition = personaOFIM.MedicalCondition,
                                 EstadoCivilId = estadoCivil.EstadoCivilId,
                                 OcupacionId = ocupacion.Id,
                                 NacionalidadId = nacionalidad.Id,
                                 NivelAcademicoId = nivelAcademico.Id,
                                 SeguroId = seguro.Id
                             }).ToList();
            ViewBag.Controlador = "PersonaOFIM";
            ViewBag.Accion = "Index";
            return View(listaPersonas);
        }
        private void cargarEstadoCivil()
        {
            List<SelectListItem> listaEstadoCivil = new List<SelectListItem>();
            listaEstadoCivil = (from estadoCivil in _db.EstadoCivil
                                orderby estadoCivil.Name
                                select new SelectListItem
                                {
                                    Text = estadoCivil.Name,
                                    Value = estadoCivil.EstadoCivilId.ToString()
                                }
                                ).ToList();
            ViewBag.ListaEstadoCivil = listaEstadoCivil;
        }

        private void cargarOcupacion()
        {
            List<SelectListItem> listaOcupacion = new List<SelectListItem>();
            listaOcupacion = (from ocupacion in _db.Ocupacion
                              orderby ocupacion.Name
                              select new SelectListItem
                              {
                                  Text = ocupacion.Name,
                                  Value = ocupacion.Id.ToString()
                              }
                                ).ToList();
            ViewBag.ListaOcupacion = listaOcupacion;
        }

        private void cargarNacionalidad()
        {
            List<SelectListItem> listaNacionalidad = new List<SelectListItem>();
            listaNacionalidad = (from nacionalidad in _db.Nacionalidad
                                 orderby nacionalidad.Name
                                 select new SelectListItem
                                 {
                                     Text = nacionalidad.Name,
                                     Value = nacionalidad.Id.ToString()
                                 }
                                ).ToList();
            ViewBag.ListaNacionalidad = listaNacionalidad;
        }

        private void cargarNivelAcademico()
        {
            List<SelectListItem> listaNivelAcademico = new List<SelectListItem>();
            listaNivelAcademico = (from nivelAcademico in _db.NivelAcademico
                                   orderby nivelAcademico.Name
                                   select new SelectListItem
                                   {
                                       Text = nivelAcademico.Name,
                                       Value = nivelAcademico.Id.ToString()
                                   }
                                ).ToList();
            ViewBag.ListaNivelAcademico = listaNivelAcademico;
        }

        private void cargarSeguro()
        {
            List<SelectListItem> listaSeguro = new List<SelectListItem>();
            listaSeguro = (from seguro in _db.Seguro
                           orderby seguro.Name
                           select new SelectListItem
                           {
                               Text = seguro.Name,
                               Value = seguro.Id.ToString()
                           }
                                ).ToList();
            ViewBag.ListaSeguro = listaSeguro;
        }

        public IActionResult Create()
        {
            cargarEstadoCivil();
            cargarOcupacion();
            cargarNacionalidad();
            cargarNivelAcademico();
            cargarSeguro();

            return View();
        }

        [HttpPost]
        public IActionResult Create(PersonaOFIM personaOFIM)
        {
            int nVeces = 0;

            try
            {
                nVeces = _db.PersonaOFIM.Where(m => m.PersonaOFIMId == personaOFIM.PersonaOFIMId).Count();
                if (!ModelState.IsValid || nVeces >= 1)
                {
                    if (nVeces >= 1) ViewBag.Error = "Esta cédula de persona ya existe!";
                    cargarEstadoCivil();
                    cargarOcupacion();
                    cargarNacionalidad();
                    cargarNivelAcademico();
                    cargarSeguro();
                    return View(personaOFIM);
                }
                else
                {
                    PersonaOFIM _personaOFIM = new PersonaOFIM();
                    _personaOFIM.PersonaOFIMId = personaOFIM.PersonaOFIMId;
                    _personaOFIM.PersonName = personaOFIM.PersonName;
                    _personaOFIM.LatName1 = personaOFIM.LatName1;
                    _personaOFIM.LatName2 = personaOFIM.LatName2;
                    _personaOFIM.Address = personaOFIM.Address;
                    _personaOFIM.Province = personaOFIM.Province;
                    _personaOFIM.Canton = personaOFIM.Canton;
                    _personaOFIM.District = personaOFIM.District;
                    _personaOFIM.TelephoneNumber = personaOFIM.TelephoneNumber;
                    _personaOFIM.MobilePhoneNumber = personaOFIM.MobilePhoneNumber;
                    _personaOFIM.Email = personaOFIM.Email;
                    _personaOFIM.Sex = personaOFIM.Sex;
                    _personaOFIM.DateBirth = personaOFIM.DateBirth;
                    _personaOFIM.CoupleName = personaOFIM.CoupleName;
                    _personaOFIM.ChildNumber = personaOFIM.ChildNumber;
                    _personaOFIM.Disability = personaOFIM.Disability;
                    _personaOFIM.MedicalCondition = personaOFIM.MedicalCondition;
                    _personaOFIM.EstadoCivilId = personaOFIM.EstadoCivilId;
                    _personaOFIM.NacionalidadId = personaOFIM.NacionalidadId;
                    _personaOFIM.NivelAcademicoId = personaOFIM.NivelAcademicoId;
                    _personaOFIM.SeguroId = personaOFIM.SeguroId;
                    _personaOFIM.OcupacionId = personaOFIM.OcupacionId;
                    _db.PersonaOFIM.Add(_personaOFIM);
                    _db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(string id)
        {
            cargarEstadoCivil();
            cargarOcupacion();
            cargarNacionalidad();
            cargarNivelAcademico();
            cargarSeguro();
            int recCount = _db.PersonaOFIM.Count(e => e.PersonaOFIMId == id);
            PersonaOFIM _personaOFIM = (from p in _db.PersonaOFIM
                                        where p.PersonaOFIMId == id
                                        select p).DefaultIfEmpty().Single();
            return View(_personaOFIM);
        }
        [HttpPost]
        public IActionResult Edit(PersonaOFIM personaOFIM)
        {
            string error = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    cargarEstadoCivil();
                    cargarOcupacion();
                    cargarNacionalidad();
                    cargarNivelAcademico();
                    cargarSeguro();
                    return View(personaOFIM);
                }
                else
                {
                    _db.PersonaOFIM.Update(personaOFIM);
                    _db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(string id)
        {
            cargarEstadoCivil();
            cargarOcupacion();
            cargarNacionalidad();
            cargarNivelAcademico();
            cargarSeguro();
            PersonaOFIM personaOFIM = _db.PersonaOFIM
                       .Where(e => e.PersonaOFIMId == id).First();
            return View(personaOFIM);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();

            }
            var personaOFIM = await _db.PersonaOFIM.FindAsync(id);
            if (personaOFIM == null)
            {
                return NotFound();

            }
            return View(personaOFIM);
        }
        //POST - DELETE    //si se realiza una operacion es un POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var personaOFIM = await _db.PersonaOFIM.FindAsync(id);
            if (personaOFIM == null)
            {
                return View();
            }
            _db.PersonaOFIM.Remove(personaOFIM);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private void BuscarPersona(string PersonOfimID)
        {
            PersonaOFIM oPersona = _db.PersonaOFIM
           .Where(p => p.PersonaOFIMId == PersonOfimID).FirstOrDefault();
            if (oPersona != null)
            {
                ViewBag.PersonOfimID = oPersona.PersonaOFIMId;
                ViewBag.Nombre = oPersona.PersonName + " " + oPersona.LatName1;

            }
            else
            {
                ViewBag.Error = "Persona no registrada, intente de nuevo!";
            }
        }



    }
}

