using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SYGESTMunicipal.Areas.OFGA.Models;
using SYGESTMunicipal.Areas.OFGA.Models.ViewModel;
using SYGESTMunicipal.Data;
using SYGESTMunicipal.Utility;

namespace SYGESTMunicipal.Areas.OFGA.Controllers
{
    [Area("OFGA")]
    //[Authorize(Roles = SD.ManagerUser)]
    
    public class TalksController : Controller
    {
        private readonly ApplicationDbContext _db;
        List<Talks> listaTalks = new List<Talks>();
        static List<Talks> lista = new List<Talks>();

        public TalksController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            listaTalks = (from especialidad in _db.Talks
                          select new Talks
                          {
                              Id = especialidad.Id,
                              Name = especialidad.Name,
                              Description = especialidad.Description.Substring(0, 85) + "...",
                              Date = especialidad.Date,
                              Picture = especialidad.Picture,
                              IsActive = especialidad.IsActive

                          }).ToList();
            lista = listaTalks;
            return View(listaTalks);
        }

        //GET- CREATE
        public IActionResult Create()
        {
            return View();
        }
        ////POST - CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(Talks talks)
        {
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
                    talks.Picture = p1;
                }
                _db.Talks.Add(talks);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(talks);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var talks = await _db.Talks.SingleOrDefaultAsync(m => m.Id == id);
            if (talks == null)
            {
                return NotFound();
            }
            return View(talks);
        }

        //Postt-Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Talks talks)
        {
            if (talks.Id == 0)
            {
                return NotFound();
            }

            var talksFromDb = await _db.Talks.Where(c => c.Id == talks.Id).FirstOrDefaultAsync();

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
                    talksFromDb.Picture = p1;
                }
                talksFromDb.Name = talks.Name;
                talksFromDb.Description = talks.Description;
                talksFromDb.Date = talks.Date;
                talksFromDb.IsActive = talks.IsActive;
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(talks);
        }


        //DELETE
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var talks = await _db.Talks.SingleOrDefaultAsync(m => m.Id == id);
            if (talks == null)
            {
                return NotFound();
            }
            return View(talks);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        //POST DELETE
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var talks = await _db.Talks.SingleOrDefaultAsync(m => m.Id == id);
            _db.Talks.Remove(talks);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        ////DETAILS
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var talks = await _db.Talks.FirstOrDefaultAsync(m => m.Id == id);
            if (talks == null)
            {
                return NotFound();
            }
            return View(talks);
        }


        public async Task<IActionResult> IndexTalks()
        {
            listaTalks = (from talks in _db.Talks
                          where talks.IsActive == true
                          select new Talks
                          {

                              Id = talks.Id,
                              Name = talks.Name,
                              Description = talks.Description.Substring(0, 85) + "...",
                              Date = talks.Date,
                              Picture = talks.Picture,
                              IsActive = talks.IsActive


                          }).ToList();

            lista = listaTalks;

            //return View(await _db.Talks.ToListAsync());


            return View(listaTalks);


        }


    }
}

