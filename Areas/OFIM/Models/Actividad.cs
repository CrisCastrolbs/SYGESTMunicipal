using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipal.Areas.OFIM.Models
{
    public partial class Actividad
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Nombre Actividad")]
        public string Name { get; set; }
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy h:mm tt}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha ")]
        public DateTime? Fecha { get; set; }
        public byte[] Imagen { get; set; }
        [Display(Name = "Está Activo ")]
        public bool IsActive { get; set; }
        [Display(Name = "Categoria")]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
        [Display(Name = "Eje")]
        public int EjeId { get; set; }
        [ForeignKey("EjeId")]
        public virtual Eje Eje { get; set; }
    }
}
