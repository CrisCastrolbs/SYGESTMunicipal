using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipal.Areas.OFIM.Models.ViewModel
{
    public class ConsultaViewModel
    {
        [Key]
        [Display(Name = "Consulta ID")]
        public int ConsultaId { get; set; }
        [DisplayName("Motivo")]
        public string Motivo { get; set; }
        [Display(Name = "Nombre Persona")]
        public string PersonaOFIMId { get; set; }


        [Display(Name = "Nombre Persona")]
        public string PersonName { get; set; }
        [Display(Name = "Tipo de Consulta")]
        public int TipoConsultaId { get; set; }

        [Display(Name = "Nombre Tipo Consulta")]
        public string NombreTipoConsulta { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Fecha")]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy h:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime Fecha { get; set; }

        [DataType(DataType.Time)]
        [Display(Name = "Hora Inicio")]
        [DisplayFormat(DataFormatString = "{0:h:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime HoraInicio { get; set; }

        [DataType(DataType.Time)]
        [Display(Name = "Hora Fin")]
        [DisplayFormat(DataFormatString = "{0:h:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime HoraFin { get; set; }

        [DisplayName("Descripción")]
        public string Descripcion { get; set; }

        [DisplayName("Respuesta Ofrecida")]
        public string RespuestaOfrecida { get; set; }
        
        [DisplayName("Remitir")]
        public bool Remitir { get; set; }

        public int SelectedOption { get; set; }

        public string msgError { get; set; }

        public IEnumerable<SelectListItem> Lista { get; set; }
    }
}
