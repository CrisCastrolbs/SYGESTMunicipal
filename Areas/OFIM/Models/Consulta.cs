using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipal.Areas.OFIM.Models
{
    public partial class Consulta
    {
        [Key]
        [Display(Name = "Consulta ID")]
        public int ConsultaId { get; set; }
        [DisplayName("Nombre Motivo")]
        public string Motivo { get; set; }
        [Display(Name = "Persona")]
        public string PersonaOFIMId { get; set; }
        [ForeignKey("PersonaOFIMId")]
        public virtual PersonaOFIM PersonaOFIM { get; set; }

        [Display(Name = "Tipo Consulta")]
        public int TipoConsultaId { get; set; }
        [ForeignKey("TipoConsultaId")]
        public virtual TipoConsulta TipoConsulta { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Fecha")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Fecha { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Hora Inicio")]
        [DisplayFormat(DataFormatString = "{0:h:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime? HoraInicio { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Hora Fin")]
        [DisplayFormat(DataFormatString = "{0:h:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime? HoraFin { get; set; }

        [DisplayName("Descripción")]
        public string Descripcion { get; set; }

        [DisplayName("Respuesta Ofrecida")]
        public string RespuestaOfrecida { get; set; }

        [DisplayName("Remitir")]
        public bool Remitir { get; set; }
    }
}
