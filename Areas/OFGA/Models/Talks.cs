using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipal.Areas.OFGA.Models
{
    public partial class Talks
    {
        [Key]
        [Display(Name = "Id ")]
        [Required(ErrorMessage = "Se debe digitar el Id ")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe digitar el nombre")]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Debe digitar la descripcion")]
        [Display(Name = "Descripción")]
        public string Description { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha ")]
        public DateTime? Date { get; set; }
        public byte[] Picture { get; set; }
        public bool IsActive { get; set; }
    }
}
