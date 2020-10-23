using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipal.Areas.OFIM.Models
{
    public partial class TipoConsulta
    {
        [Key]
        [Required]
        public int TipoConsultaId { get; set; }
        public string NombreTipoConsulta { get; set; }
        public string PersonaOFIMId { get; set; }
        [ForeignKey("PersonaOFIMId")]
        public virtual PersonaOFIM PersonaOFIM { get; set; }
    }
}
