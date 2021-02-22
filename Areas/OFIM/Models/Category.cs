using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace SYGESTMunicipal.Areas.OFIM.Models
{
    public class Category
    {

        [Key]
        public int Id { get; set; }
        
        [DisplayName("Nombre Categoria")]
        [Required(ErrorMessage = "Debe digitar el Nombre de la Categoria")]
        public string Name { get; set; }

        public virtual ICollection<Eje> Eje { get; set; }
    }
}
