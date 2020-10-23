using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipal.Areas.OFIM.Models.ViewModel
{
    public class ConsultaViewModel
    {
        public Consulta Consulta { get; set; }  //objeto de ProductItem (CRUD)
        public IEnumerable<PersonaOFIM> PersonaOFIM { get; set; }   //combo categoria
        public IEnumerable<TipoConsulta> TipoConsulta { get; set; }     
    }
}
