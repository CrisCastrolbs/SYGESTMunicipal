using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipal.Areas.OFIM.Models.ViewModel
{
    public class CuposActividad
    {
        public int Id { get; set; }
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }
        public int CupoMax { get; set; }
        [Display(Name = "Está Activo ")]
        public bool IsActive { get; set; }
        public int ActividadId { get; set; }
        public string Actividad { get; set; }
        public int SelectedOption { get; set; }
        public string msgError { get; set; }

        public static implicit operator List<object>(CuposActividad v)
        {
            throw new NotImplementedException();
        }
    }
}
