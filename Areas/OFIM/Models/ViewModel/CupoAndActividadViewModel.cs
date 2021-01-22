using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipal.Areas.OFIM.Models.ViewModel
{
    public class CupoAndActividadViewModel
    {
        public IEnumerable<Actividad> ActividadList { get; set; }
        public Cupos Cupos { get; set; }
        public List<string> CuposList { get; set; }
        public string StatusMessage { get; set; }
    }
}
