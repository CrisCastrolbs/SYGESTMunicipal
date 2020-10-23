using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipal.Areas.OFIM.Models.ViewModel
{
    public class TipoConsultaAndPersonaViewModel
    {
        public IEnumerable<PersonaOFIM> PersonaOFIMList { get; set; }
        public TipoConsulta TipoConsulta { get; set; }
        public List<string> TipoConsultaList { get; set; }
        public string StatusMessage { get; set; }
    }
}
