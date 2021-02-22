using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipal.Areas.OFIM.Models.ViewModel
{
    public class EjeCategory
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Nombre Eje")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "ID Categoria ")]
        public int CategoryID { get; set; }
        public string Category { get; set; }

        public static implicit operator List<object>(EjeCategory v)
        {
            throw new NotImplementedException();
        }
    }
}
