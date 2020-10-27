using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipal.Areas.OFIM.Models.ViewModel
{
    public class TipoConsultaAndPersonaViewModel
    {
        [Key]
        public int TipoConsultaId { get; set; }
        public string NombreTipoConsulta { get; set; }
        public string PersonaOFIMId { get; set; }
        [Display(Name = "Nombre Persona")]
        public string PersonaOFIM { get; set; }
        public int SelectedOption { get; set; }

        public string msgError { get; set; }

        public static implicit operator List<object>(TipoConsultaAndPersonaViewModel v)
        {
            throw new NotImplementedException();
        }
    }
} 

