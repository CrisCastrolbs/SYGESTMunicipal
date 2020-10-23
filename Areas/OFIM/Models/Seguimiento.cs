using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipal.Areas.OFIM.Models
{
    public partial class Seguimiento
    {
        [Key]
        [Display(Name = "Seguimiento ID")]
        public int SeguimientoId { get; set; }
           
        [DisplayName("Descripción")]
        public string Descripcion { get; set; }

        public string PersonaOFIMId { get; set; }
        [ForeignKey("PersonaOFIMId")]
        public virtual PersonaOFIM PersonaOFIM { get; set; }

        public int ConsultaId { get; set; }
        [ForeignKey("ConsultaId")]
        public virtual Consulta Consulta { get; set; }

    }
}
