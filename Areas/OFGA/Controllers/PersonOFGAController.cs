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
    [Authorize(Roles = SD.AdminOFGA)]
    public class PersonOFGAController : Controller
    {

        private readonly ApplicationDbContext _db;
        List<PersonOFGA> listaPersonOFGA = new List<PersonOFGA>();
        static List<PersonOFGA> lista = new List<PersonOFGA>();

        public PersonOFGAController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            listaPersonOFGA = (from personOFGA in _db.PersonOFGA


                               select new PersonOFGA
                               {
                                   PersonOFGAId = personOFGA.PersonOFGAId,
                                   Name = personOFGA.Name,
                                   LastName1 = personOFGA.LastName1,
                                   LastName2 = personOFGA.LastName2,
                                   Address = personOFGA.Address,
                                   Province = personOFGA.Province,
                                   Canton = personOFGA.Canton,
                                   District = personOFGA.District,
                                   TelephoneNumber = personOFGA.TelephoneNumber,
                                   CellphoneNumber = personOFGA.CellphoneNumber,
                                   Email = personOFGA.Email,

                               }).ToList();
            lista = listaPersonOFGA;
            return View(listaPersonOFGA);


        }



        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(PersonOFGA personOFGA)
        {
            int nVeces = 0;

            try
            {
                nVeces = _db.PersonOFGA.Where(m => m.PersonOFGAId == personOFGA.PersonOFGAId).Count();
                if (!ModelState.IsValid || nVeces >= 1)
                {
                    if (nVeces >= 1) ViewBag.Error = "Esta identificación ya existe!";

                    return View(personOFGA);
                }
                else
                {

                    _db.PersonOFGA.Add(personOFGA);
                    _db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            return RedirectToAction(nameof(Index));
        }

        //[HttpPost]
        //public IActionResult Delete(int? PersonOFGAId)
        //{
        //    string Error = "";
        //    try
        //    {
        //        PersonOFGA oPersonOFGA = _db.PersonOFGA
        //             .Where(m => m.PersonOFGAId == PersonOFGAId.ToString()).First();
        //        _db.PersonOFGA.Remove(oPersonOFGA);
        //        _db.SaveChanges();
        //    }
        //    catch (Exception ex)
        //    {
        //        Error = ex.Message;
        //    }
        //    return RedirectToAction(nameof(Index));
        //}

        [HttpGet]
        public IActionResult Edit(string id)
        {
            PersonOFGA oPersonOFGA = _db.PersonOFGA
                .Where(e => e.PersonOFGAId == id).First();
            return View(oPersonOFGA);
        }
        [HttpPost]
        public IActionResult Edit(PersonOFGA personOFGA)
        {
            string error = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(personOFGA);
                }
                else
                {
                    _db.PersonOFGA.Update(personOFGA);
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

            PersonOFGA oPersonOFGA = _db.PersonOFGA
                       .Where(e => e.PersonOFGAId == id).First();
            return View(oPersonOFGA);
        }


    }
}
