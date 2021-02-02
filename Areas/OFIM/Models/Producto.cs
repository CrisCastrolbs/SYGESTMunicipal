using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipal.Areas.OFIM.Models
{
    public partial class Producto
    {
        public int Id { get; set; }
        
        [Required]
        [Display(Name = "Nombre del producto")]
        public string Name { get; set; }

        [Display(Name = "Descripción")]
        public string Description { get; set; }

        public byte[] Imagen { get; set; }
        
        [Display(Name = "ID Clasificación ")]
        public int ClasificacionID { get; set; }
        [ForeignKey("ClasificacionID")]
        public virtual Clasificacion Clasificacion { get; set; }

        [Display(Name = "Empresa")]
        public int EmpresaId { get; set; }
        [ForeignKey("EmpresaId")]
        public virtual Empresa Empresa { get; set; }


    }
}
