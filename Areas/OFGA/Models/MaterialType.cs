using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipal.Areas.OFGA.Models
{
    public partial class MaterialType
    {
        public MaterialType()
        {
            Materials = new HashSet<Materials>();
        }
        [Required(ErrorMessage = "Debe digitar el ID del tipo de material")]
        [Display(Name = "ID")]
        [DisplayName("ID")]
        public int MaterialTypeId { get; set; }

        [DisplayName("Nombre")]
        [Required(ErrorMessage = "Debe digitar el Nombre del tipo de material")]
        public string MaterialTypeName { get; set; }
        [DisplayName("Descripción")]
        [Required(ErrorMessage = "Debe digitar la descripción del tipo de material")]
        public string Description { get; set; }
        public virtual ICollection<Materials> Materials { get; set; }
    }
}