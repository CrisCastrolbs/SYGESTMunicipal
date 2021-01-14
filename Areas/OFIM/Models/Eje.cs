using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipal.Areas.OFIM.Models
{
    public partial class Eje
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Nombre Eje")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "ID Categoria ")]
        public int CategoryID { get; set; }
        [ForeignKey("CategoryID")]
        public virtual Category Category { get; set; }
    }
}
