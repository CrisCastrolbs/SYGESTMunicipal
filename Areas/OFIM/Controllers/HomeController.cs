using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SYGESTMunicipal.Areas.OFIM.Models.ViewModel;
using SYGESTMunicipal.Data;

namespace SYGESTMunicipal.Areas.OFIM.Controllers
{
    [Area("OFIM")]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public HomeController(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            IndexViewModel IndexVM = new IndexViewModel()
            {
                Actividad = await
                    _db.Actividad.Where(m => m.IsActive == true).Include(m => m.Category).Include(m => m.Eje).ToListAsync(),
                Category = await _db.Category.ToListAsync(),
                //Actividad = await _db.Actividad.Where(c => c.IsActive == true).ToListAsync()
            };

            return View(IndexVM);
        }
       


    }
}
