using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipal.Areas.OFGA.Models
{
    public partial class Complaint
    {
        [Key]
        [Display(Name = "Id ")]
        [Required(ErrorMessage = "Se debe digitar el Id ")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe digitar la Descripción")]
        [Display(Name = "Descripción ")]
        public string Description { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Fecha")]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy h:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Display(Name = "Nombre de Persona")]
        public string PersonOFGAId { get; set; }
        [ForeignKey("PersonOFGAId")]
        public virtual PersonOFGA PersonOFGA { get; set; }
    }
}
