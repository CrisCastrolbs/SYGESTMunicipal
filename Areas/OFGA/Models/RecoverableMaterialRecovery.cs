using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipal.Areas.OFGA.Models
{
    public partial class RecoverableMaterialRecovery
    {
        [Key]
        [Display(Name = "Id ")]
        [Required(ErrorMessage = "Se debe digitar el Id ")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe digitar el Peso")]
        [Display(Name = "Peso en Toneladas ")]
        public float Weight { get; set; }

        [Required(ErrorMessage = "Debe digitar el nombre del lugar")]
        [Display(Name = "Nombre del lugar ")]
        public string PlaceName { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Fecha de Ingreso")]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy h:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime EntryDate { get; set; }


    }
}

