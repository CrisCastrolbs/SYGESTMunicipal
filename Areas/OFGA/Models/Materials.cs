using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipal.Areas.OFGA.Models
{
    public partial class Materials
    {
        [Key]
        [Display(Name = "Id ")]
        [Required(ErrorMessage = "Se debe digitar el Id ")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe digitar el nombre")]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha ")]
        public DateTime? Date { get; set; }

        [Required(ErrorMessage = "Debe digitar el peso")]
        [Display(Name = "Peso")]
        public float Weight { get; set; }

        [Display(Name = "Color")]
        public string Color { get; set; }

        [Display(Name = "Tipo de Material")]
        public int MaterialTypeId { get; set; }
        [ForeignKey("MaterialTypeId")]
        public virtual MaterialType MaterialType { get; set; }

    }
}
