using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SYGESTMunicipal.Areas.OFGA.Models;
using SYGESTMunicipal.Areas.OFGA.Models.ViewModel;
using SYGESTMunicipal.Data;
using SYGESTMunicipal.Utility;

namespace SYGESTMunicipal.Areas.OFGA.Controllers
{

    [Area("OFGA")]
    //[Authorize(Roles = SD.ManagerUser)]
    
    public class ComplaintController : Controller
    {

        private readonly ApplicationDbContext _db;
        List<PersonOFGAComplaintViewModel> listaComplaint = new List<PersonOFGAComplaintViewModel>();
        static List<PersonOFGAComplaintViewModel> lista = new List<PersonOFGAComplaintViewModel>();

        static private string _Fecha;
        public ComplaintController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            listaComplaint = (from complaint in _db.Complaint
                          join personOFGA in _db.PersonOFGA
                          on complaint.PersonOFGAId equals personOFGA.PersonOFGAId
                          select new PersonOFGAComplaintViewModel
                          {
                              Id = complaint.Id,
                            

                              Description = complaint.Description.Length > 50 ?
                                          complaint.Description.Substring(0, 50)
                                          + "..." : complaint.Description,
                              Date = complaint.Date,
                              
                              PersonOFGA = personOFGA.Name
                          }).ToList();
            lista = listaComplaint;
            return View(listaComplaint);
        }

        private void CargarPersonOFGA()
        {
            List<SelectListItem> listaPersonOFGA = new List<SelectListItem>();
            listaPersonOFGA = (from personOFGA in _db.PersonOFGA
                             orderby personOFGA.Name
                             select new SelectListItem
                             {
                                 Text = personOFGA.Name + " " + personOFGA.LastName1,
                                 Value = personOFGA.PersonOFGAId.ToString()
                             }
                                   ).ToList();
            ViewBag.listaPersonOFGA = listaPersonOFGA;
        }
        public IActionResult Create()
        {
            CargarPersonOFGA();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Complaint complaint)
        {
            int nVeces = 0;

            try
            {
                nVeces = _db.Complaint.Where(m => m.Id == complaint.Id).Count();
                if (!ModelState.IsValid || nVeces >= 1)
                {
                    if (nVeces >= 1) ViewBag.Error = "Este id ya existe!";
                    CargarPersonOFGA();
                    return View(complaint);
                }
                else
                {
                    Complaint _complaint = new Complaint();
                    _complaint.Id = complaint.Id;

                    _complaint.Description = complaint.Description;
                    _complaint.Date = complaint.Date;

                    _complaint.PersonOFGAId = complaint.PersonOFGAId;
                    _db.Complaint.Add(_complaint);
                    _db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            CargarPersonOFGA();
            int recCount = _db.Complaint.Count(e => e.Id == id);
            Complaint _complaint = (from p in _db.Complaint
                            where p.Id.ToString().Trim() == id.ToString().Trim()
                            select p).DefaultIfEmpty().Single();
            return View(_complaint);
        }
        [HttpPost]
        public IActionResult Edit(Complaint complaint)
        {
            string error = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    CargarPersonOFGA();
                    ViewBag.EntryDate = complaint.Date.ToString("yyyy-MM-dd");
                    _Fecha = ViewBag.EntryDate;
                    return View(complaint);
                }
                else
                {
                    _db.Complaint.Update(complaint);
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
            CargarPersonOFGA();
            Complaint oComplaint = _db.Complaint
                 .Where(m => m.Id == id).First();
            return View(oComplaint);
        }




        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();

            }
            var complaint = await _db.Complaint.FindAsync(id);
            if (complaint == null)
            {
                return NotFound();

            }
            return View(complaint);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var complaint = await _db.Complaint.FindAsync(id);
            if (complaint == null)
            {
                return View();
            }
            _db.Complaint.Remove(complaint);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
