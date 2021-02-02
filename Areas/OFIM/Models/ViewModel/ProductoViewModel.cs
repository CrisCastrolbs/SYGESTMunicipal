using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipal.Areas.OFIM.Models.ViewModel
{
    public class ProductoViewModel
    {

        public Producto Producto { get; set; }
        public IEnumerable<Clasificacion> Clasificacion { get; set; }
        public IEnumerable<Empresa> Empresa { get; set; }
    }
}
