using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipal.Areas.OFIM.Models.ViewModel
{
    public class EjeActividadList
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Nombre Actividad")]
        public string Name { get; set; }
        public int EjeId { get; set; }
        public string Eje { get; set; }

       
    }
}
