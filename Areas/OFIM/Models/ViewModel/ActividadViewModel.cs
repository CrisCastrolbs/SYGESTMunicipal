using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipal.Areas.OFIM.Models.ViewModel
{
    public class ActividadViewModel
    {
        public Actividad Actividad { get; set; }  //objeto de Actividad (CRUD)
        public IEnumerable<Category> Category { get; set; }   
        public IEnumerable<Eje> Eje { get; set; }
    }
}
