using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipal.Areas.OFIM.Models.ViewModel
{
    public class EmpresaAndClasificacionViewModel
    {
        public IEnumerable<Clasificacion> Clasificacion { get; set; }
        public Empresa Empresa { get; set; }
        public List<string> EmpresaList { get; set; }
        public string StatusMessage { get; set; }
    }
}
