using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipal.Areas.OFIM.Models.ViewModel
{
    public class IndexViewModel
    {
        public IEnumerable<Actividad> Actividad { get; set; }
        public IEnumerable<Category> Category { get; set; }
        //public IEnumerable<Eje> Eje { get; set; }

    }
}
