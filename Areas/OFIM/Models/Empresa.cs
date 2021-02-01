using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipal.Areas.OFIM.Models
{
    public partial class Empresa
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Nombre Empresa")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Representante")]
        public string Manager { get; set; }
        [Required]
        [Display(Name = "Descripción")]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Direcion")]
        public string Direction { get; set; }
        [Display(Name = "Pagina Web")]
        public string WebPage { get; set; }
        [Required]
        [Display(Name = "Telefono")]
        public string Telephone { get; set; }

        [Display(Name = "Correo electronico")]
        public string Email { get; set; }
        public byte[] Imagen { get; set; }
        [Required]
        [Display(Name = "ID Clasificación ")]
        public int ClasificacionID { get; set; }
        [ForeignKey("ClasificacionID")]
        public virtual Clasificacion Clasificacion { get; set; }

    }
}
