using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SYGESTMunicipal.Areas.PATENTES.Models;
using SYGESTMunicipal.Data;

namespace SYGESTMunicipal.Areas.PATENTES.Controllers
{
    [Area("Patentes")]
    public class PersonPatentesController : Controller
    {
        private readonly ApplicationDbContext _db;
        List<PersonPatentes> listaPersona = new List<PersonPatentes>();
        static List<PersonPatentes> lista = new List<PersonPatentes>();

        public PersonPatentesController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            listaPersona = (from personPatentes in _db.PersonPatentes
                            select new PersonPatentes
                            {
                                PersonId = personPatentes.PersonId,
                                Name = personPatentes.Name,
                                LastName1 = personPatentes.LastName1.Substring(0, 85) + "..."
                            }).ToList();
            lista = listaPersona;
            return View(listaPersona);
        }
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(PersonPatentes personpatentes)
        {
            int nVeces = 0;
            string Error = "";
            try
            {
                nVeces = _db.PersonPatentes.Where(e =>
                                       e.Name == personpatentes.Name).Count();

                if (!ModelState.IsValid || nVeces >= 1)
                {
                    if (nVeces > 1) ViewBag.msgError = "El nombre de la persona" +
                              " ya está registrado";

                    return View(personpatentes);
                }
                else
                {
                    _db.PersonPatentes.Add(personpatentes);
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
        public IActionResult Edit(string id)
        {
            PersonPatentes oPersonPatentes = _db.PersonPatentes
                .Where(e => e.PersonId == id).First();
            return View(oPersonPatentes);
        }
        [HttpPost]
        public IActionResult Edit(PersonPatentes personpatentes)
        {
            string error = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(personpatentes);
                }
                else
                {
                    _db.PersonPatentes.Update(personpatentes);
                    _db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();

            }
            var category = await _db.PersonPatentes.FindAsync(id);
            if (category == null)
            {
                return NotFound();

            }
            return View(category);
        }
        //POST - DELETE    //si se realiza una operacion es un POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var category = await _db.PersonPatentes.FindAsync(id);
            if (category == null)
            {
                return View();
            }
            _db.PersonPatentes.Remove(category);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var personPatentes = await _db.PersonPatentes.FirstOrDefaultAsync(m => m.PersonId == id);
            if (personPatentes == null)
            {
                return NotFound();
            }
            return View(personPatentes);
        }
    }
}