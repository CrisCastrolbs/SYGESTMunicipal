using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipal.Areas.OFIM.Models
{
    public partial class Cupos
    {
        public int Id { get; set; }
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }
        public int CupoMax { get; set; }
        [Display(Name = "Está Activo ")]
        public bool IsActive { get; set; }
        public int ActividadId { get; set; }
        [NotMapped]
        [ForeignKey("ActividadId")]
        public virtual Actividad Actividad { get; set; }

    }
}
