using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipal.Areas.PATENTES.Models
{
    public partial class EstablishmentType
    {
        public EstablishmentType()
        {
            Establishment = new HashSet<Establishment>();
        }
        [Key]
        public int EstablishmentTypeId { get; set; }
        [Required]
        [Display(Name = "Tipo Establecimiento")]
        public string Name { get; set; }
        public virtual ICollection<Establishment> Establishment { get; set; }
    }
}